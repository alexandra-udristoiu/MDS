import { Component, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Post } from '../_models/post';
import { User } from '../_models/user';
import { AuthenticationService } from '../_services/authentication.service';
import { PostService } from '../_services/post.service';
import { UserService } from '../_services/user.service';

@Component({
  selector: 'app-post-details',
  templateUrl: './post-details.component.html',
  styleUrls: ['./post-details.component.css']
})
export class PostDetailsComponent implements OnInit {

  @Input() post: Post;

  user!: User;

  constructor(
    public postService: PostService,
    public authService: AuthenticationService,
    public userService: UserService,
    private router: Router,
  ) { 
    this.post = {} as Post;
  }

  ngOnInit(): void {
    this.userService.getAll().subscribe(
      (users : User[]) => {
        this.user = users.filter(u => u.id == this.post.userId)[0];
      },
      (error: any) => {
        console.log(error);
      }
    );
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

  editPost(): void {
    this.router.navigate(['/edit-post', this.post.id], {queryParams: {returnUrl: this.router.url}});
  }

  goToTag(tag): void {
    this.router.navigate(['/posts'], {queryParams: {tag: tag}});
  }

}
