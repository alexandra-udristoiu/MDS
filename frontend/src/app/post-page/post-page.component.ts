import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Post } from '../_models/post';
import { Comment } from '../_models/comment';
import { PostService } from '../_services/post.service';
import { AuthenticationService } from '../_services/authentication.service';
import { CommentService } from '../_services/comment.service';

@Component({
  selector: 'app-post-page',
  templateUrl: './post-page.component.html',
  styleUrls: ['./post-page.component.css']
})
export class PostPageComponent implements OnInit {

  post!: Post

  comments: Comment[] = []

  commentsActive: boolean = false

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private postService: PostService,
    private authService: AuthenticationService,
    private commentService: CommentService
  ) { }

  ngOnInit(): void {
    let postId = this.route.snapshot.params['postId'];
    console.log(postId);
    this.postService.getPost(postId).subscribe(
      (data) => {
        this.post = data;
        console.log(data);
      },
      (error) => {
        console.log(error);
      });

    this.showComments()
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
