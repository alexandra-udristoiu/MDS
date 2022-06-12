import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, tap } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Hw } from '../_models/hw';
import { AuthenticationService } from './authentication.service';

@Injectable({
  providedIn: 'root'
})

export class HwService {
  token: string;
  headers: any;

  private hwUrl = `${environment.apiUrl}/Homework`; 

  constructor(private http: HttpClient, public authService: AuthenticationService) {
    this.token = authService.token;
    this.headers = new HttpHeaders({
      'Authorization': `Bearer ${this.token}`
    });
   }

   getHomework(): Observable<Hw[]> {
    return this.http.get<Hw[]>(this.hwUrl, {
      headers: this.headers,
    });
  }

  addHw(hw: FormData): Observable<Hw> {
    return this.http.post<Hw>(this.hwUrl, hw, {
      headers: this.headers,
    });
  }

  removeHw(hwId: number): Observable<any> {
    const url = `${this.hwUrl}/${hwId}`;

    return this.http.delete<any>(url, {
      headers: this.headers,
    });
  }

  resolveHw(hwId: number, userId: number, file: File): Observable<any> {
    const url = `${this.hwUrl}/${hwId}/resolve`;
    const params = {
      hwId,
      userId,
      file,
    };

    return this.http.post<any>(url, params, {
      headers: this.headers,
    });
  }

}
