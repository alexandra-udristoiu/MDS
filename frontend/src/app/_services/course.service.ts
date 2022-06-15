import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { Course } from '../_models/courses';
import { SignUpToCourseModel } from '../_models/sign-up-to-course';


import { HttpClient, HttpHeaders } from '@angular/common/http';
import { catchError, map, tap } from 'rxjs/operators';
import { environment } from '../../environments/environment';
import { AuthenticationService } from './authentication.service';
import { MessageService } from './message.service';

@Injectable({
  providedIn: 'root'
})
export class CourseService {

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

  private coursesUrl = `${environment.apiUrl}/Courses`;  // URL to web api


  getCourses(): Observable<Course[]> {
    return this.http.get<Course[]>(this.coursesUrl, {
      headers: this.headers,
    }).pipe(
      catchError(this.handleError<Course[]>('getOrganizations', []))
    );
  }

  getCoursesForUser(userId: string): Observable<Course[]> {
    const url = `${this.coursesUrl}/User/${userId}`;
    return this.http.get<Course[]>(url, {
      headers: this.headers,
    });
  }

  getCourse(name : string): Observable<Course> {
    const url = `${this.coursesUrl}/${name}`;
    return this.http.get<Course>(url, {
      headers: this.headers,
    }).pipe(

      tap(_ => this.log(`fetched post facultyNmae=${name}`)),
      catchError(this.handleError<Course>(`getOrganization facultyNmae=${name}`))
    );
  }

  assignUserToCourse(userCourse : SignUpToCourseModel): Observable<SignUpToCourseModel> {
    const url = `${this.coursesUrl}/${userCourse.courseId}/Users`;
    console.log(url);
    return this.http.post<SignUpToCourseModel>(url, userCourse, {
      headers: this.headers,
    }).pipe(
      tap((newUserCourse: SignUpToCourseModel) => newUserCourse),
      catchError(this.handleError<any>('signUpToCourse'))
    );
  }

  updateCourse(course : Course): Observable<any> {
    return this.http.put(this.coursesUrl, course, this.httpOptions).pipe(
      tap(_ => this.log(`updated organization facultyName=${course.name}`)),
      catchError(this.handleError<any>('updateOrganization'))
    );
  }

  removeCourse(name : string): Observable<any> {
    const url = `${this.coursesUrl}/${name}`;

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
