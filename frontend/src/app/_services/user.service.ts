import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { User } from '../_models/user';
import { UserOrganization } from '../_models/user_organization';
import { AuthenticationService } from './authentication.service';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  token: string;

  httpOptions: any;

  headers: any;

  private usersUrl = `${environment.apiUrl}/Users`;

  constructor(private http: HttpClient, public authService: AuthenticationService) { 
    this.token = authService.token;

    this.headers = new HttpHeaders({
      'Authorization': `Bearer ${this.token}`
    });
    this.httpOptions = {
      headers: new HttpHeaders({
        'Authorization': `Bearer ${this.token}`
      })
    };
  }

  getAll(): Observable<User[]> {
    return this.http.get<User[]>(this.usersUrl, {
      headers: this.headers,
    });
  }

  updateUser(user: User): Observable<any> {
    return this.http.put(this.usersUrl, user, this.httpOptions);
  }

  deleteUser(id: string): Observable<any> {
    const url = `${this.usersUrl}/${id}`;
    return this.http.delete<any>(url, {
      headers: this.headers,
    });
  }
  
  assignOrganization(id: string, model: UserOrganization): Observable<any> {
    const url = `${this.usersUrl}/${id}/Organizations`;
    return this.http.post(url, model, {
      headers: this.headers,
    });
  }
}
