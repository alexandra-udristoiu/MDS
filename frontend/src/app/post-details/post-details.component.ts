import { Component, Input, OnInit } from '@angular/core';
import { Post } from '../_models/post';
import { AuthenticationService } from '../_services/authentication.service';
import { PostService } from '../_services/post.service';

@Component({
  selector: 'app-post-details',
  templateUrl: './post-details.component.html',
  styleUrls: ['./post-details.component.css']
})
export class PostDetailsComponent implements OnInit {

  @Input() post: Post;

  constructor(
    public postService: PostService,
    public authService: AuthenticationService
  ) { 
    this.post = {} as Post;
  }

  ngOnInit(): void {
  }

  get isMine(): boolean {
    return this.authService.user.id === this.post.userId;
  }

  removePost(): void {
    this.postService.removePost(this.post.id).subscribe(
      (data) => {
        this.post = {} as Post;
      },
      (error: any) => {
        console.log(error);
      });
  }

}
