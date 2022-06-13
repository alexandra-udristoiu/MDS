import { Component, Input, OnInit } from '@angular/core';
import { Comment } from '../_models/comment';
import { User } from '../_models/user';
import { AuthenticationService } from '../_services/authentication.service';
import { CommentService } from '../_services/comment.service';
import { UserService } from '../_services/user.service';

@Component({
  selector: 'app-comment',
  templateUrl: './comment.component.html',
  styleUrls: ['./comment.component.css']
})
export class CommentComponent implements OnInit {

  @Input() comment!: Comment;

  user!: User;

  isEditOn: boolean = false;

  constructor(
    private commentService : CommentService,
    public authService: AuthenticationService,
    public userService: UserService,
    ) { }

  ngOnInit(): void {
    this.userService.getAll().subscribe(
      (users : User[]) => {
        this.user = users.filter(u => u.id == this.comment.userId)[0];
      },
      (error: any) => {
        console.log(error);
      }
    );
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

  editComment(): void {
    this.isEditOn = true;
  }

  editFinished(event): void {
    console.log("aici")
    this.isEditOn = false;
  }



}
