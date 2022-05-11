import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { AuthenticationService } from './authentication.service';
import { Comment } from '../_models/comment';

@Injectable({
  providedIn: 'root'
})
export class CommentService {

  token: string;
  
  headers: HttpHeaders;

  private baseUrl = `${environment.apiUrl}/Posts`;

  constructor(private http: HttpClient, public authService: AuthenticationService) { 
    this.token = authService.token;
    this.headers = new HttpHeaders({
      'Authorization': `Bearer ${this.token}`
    });
  }

  getPostComments(postId: number): Observable<Comment[]> {
    const url = `${this.baseUrl}/${postId}/Comments`;

    return this.http.get<Comment[]>(url, {
      headers: this.headers,
    });
  }

  removeComment(postId: number, commentId: number) {
    const url = `${this.baseUrl}/${postId}/Comments/${commentId}`;

    return this.http.delete<any>(url, {
      headers: this.headers,
    });
  }

  addComment(postId: number, text: string) {
    const url = `${this.baseUrl}/${postId}/Comments`;

    return this.http.post<any>(url, { text }, {
      headers: this.headers,
    });
  }

}
