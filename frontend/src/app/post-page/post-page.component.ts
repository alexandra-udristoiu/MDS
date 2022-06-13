import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Post } from '../_models/post';
import { Comment } from '../_models/comment';
import { PostService } from '../_services/post.service';
import { AuthenticationService } from '../_services/authentication.service';
import { CommentService } from '../_services/comment.service';
import { DatePipe } from '@angular/common';

@Component({
  selector: 'app-post-page',
  templateUrl: './post-page.component.html',
  styleUrls: ['./post-page.component.css']
})
export class PostPageComponent implements OnInit {

  post!: Post

  comments: Comment[] = []
  pipe = new DatePipe('en-US');

  commentsActive: boolean = false

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private postService: PostService,
    private authService: AuthenticationService,
    private commentService: CommentService
  ) { 
    this.post = {} as Post;
  }

  ngOnInit(): void {
    let postId = this.route.snapshot.params['postId'];
    console.log(postId);
    this.postService.getPost(postId).subscribe(
      (data) => {
        this.post = data;
        this.post.createdDate = this.pipe.transform(new Date(this.post.createdDate), 'MMM d, y, h:mm:ss a') || this.post.createdDate;
        this.showComments();
      },
      (error) => {
        console.log(error);
      });
  }

  showComments(): void {
    this.commentService.getPostComments(this.post.id)
      .subscribe((comments: Comment[]) => {
        this.comments = comments;
        this.commentsActive = true;
      },
      (error) => {
          this.commentsActive = false;
          console.log(error)
        });
    this.commentsActive = true
  }

  hideComments(): void {
    this.commentsActive = false
  }

  removePost(): void {
    this.postService.removePost(this.post.id)
    .subscribe(() => {
      this.post = {} as Post;
    },
    (error: any) => { });
    
    this.router.navigate(['posts'])
  }
  
  get isMine(): boolean {
    return this.authService.user.id === this.post.userId;
  }

  addComment(): void {
    this.showComments()
  }

}
