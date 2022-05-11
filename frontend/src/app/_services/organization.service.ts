import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { Organization } from '../_models/organization';


import { HttpClient, HttpHeaders } from '@angular/common/http';
import { catchError, map, tap } from 'rxjs/operators';
import { environment } from '../../environments/environment';
import { AuthenticationService } from './authentication.service';
import { MessageService } from './message.service';
@Injectable({
  providedIn: 'root'
})
export class OrganizationService {
  token!: string;
  httpOptions: any;
  headers: any;

  constructor(private http: HttpClient, private messageService: MessageService, public authService: AuthenticationService) {
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

  private organizationsUrl = `${environment.apiUrl}/Organizations`;  // URL to web api

  getOrganizations(): Observable<Organization[]> {
    return this.http.get<Organization[]>(this.organizationsUrl, {
      headers: this.headers,
    }).pipe(
      catchError(this.handleError<Organization[]>('getOrganizations', []))
    );
  }

  getOrganization(facultyName: string): Observable<Organization> {
    const url = `${this.organizationsUrl}/${facultyName}`;
    return this.http.get<Organization>(url, {
      headers: this.headers,
    }).pipe(

      tap(_ => this.log(`fetched post facultyNmae=${facultyName}`)),
      catchError(this.handleError<Organization>(`getOrganization facultyNmae=${facultyName}`))
    );
  }

  updateOrganization(organization: Organization): Observable<any> {
    return this.http.put(this.organizationsUrl, organization, this.httpOptions).pipe(
      tap(_ => this.log(`updated organization facultyName=${organization.facultyName}`)),
      catchError(this.handleError<any>('updateOrganization'))
    );
  }

  addOrganization(organization : Organization): Observable<Organization> {
    return this.http.post<Organization>(this.organizationsUrl, organization, {
      headers: this.headers,
    }).pipe(
      tap((newOrganization: Organization) => newOrganization),
      catchError(this.handleError<any>('signUpToCourse'))
    );
  }

  removeOrganization(facultyName: string): Observable<any> {
    const url = `${this.organizationsUrl}/${facultyName}`;

    return this.http.delete<any>(url, {
      headers: this.headers,
    }).pipe(
      catchError(this.handleError<string>('removeOrganization'))
    );
  }

  private handleError<T>(operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {

      // TODO: send the error to remote logging infrastructure
      console.error(error); // log to console instead

      // TODO: better job of transforming error for user consumption
      this.log(`${operation} failed: ${error.message}`);

      // Let the app keep running by returning an empty result.
      return of(result as T);
    };
  }
  private log(message: string) {
    this.messageService.add(`postService: ${message}`);
  }
}

