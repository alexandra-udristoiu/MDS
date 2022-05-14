import { Component, Input, OnInit } from '@angular/core';
import { Comment } from '../_models/comment';
import { AuthenticationService } from '../_services/authentication.service';
import { CommentService } from '../_services/comment.service';

@Component({
  selector: 'app-comment',
  templateUrl: './comment.component.html',
  styleUrls: ['./comment.component.css']
})
export class CommentComponent implements OnInit {

  @Input() comment!: Comment;

  constructor(
    private commentService : CommentService,
    public authService: AuthenticationService
    ) { }

  ngOnInit(): void {
  }

  get isMine(): boolean {
    return this.authService.user.id === this.comment.userId;
  }

  removeComment(): void {
    this.commentService.removeComment(this.comment.postId, this.comment.id).subscribe(
      (data) => {
        this.comment = {} as Comment;
      },
      (error: any) => { 
        console.log(error);
      }
    );
  }



}
