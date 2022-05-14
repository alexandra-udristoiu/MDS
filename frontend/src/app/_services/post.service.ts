import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, tap } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Post } from '../_models/post';
import { PostCreateModel } from '../_models/post-create';
import { AuthenticationService } from './authentication.service';

@Injectable({
  providedIn: 'root'
})
export class PostService {

  token: string;

  httpOptions: any;

  headers: any;

  private postsUrl = `${environment.apiUrl}/Posts`; 

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

   getPosts(): Observable<Post[]> {
    return this.http.get<Post[]>(this.postsUrl, {
      headers: this.headers,
    });
  }

  getPost(id: number): Observable<Post> {
    const url = `${this.postsUrl}/${id}`;
    return this.http.get<Post>(url, {
      headers: this.headers,
    });
  }

  updatePost(post: Post): Observable<any> {
    return this.http.put(this.postsUrl, post, this.httpOptions);
  }

  addPost(post: PostCreateModel): Observable<Post> {
    return this.http.post<Post>(this.postsUrl, post, {
      headers: this.headers,
    });
  }

  removePost(postId: number): Observable<any> {
    const url = `${this.postsUrl}/${postId}`;

    return this.http.delete<any>(url, {
      headers: this.headers,
    });
  }

}
