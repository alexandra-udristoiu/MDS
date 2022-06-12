import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Post } from '../_models/post';
import { PostService } from '../_services/post.service';
import { AuthenticationService } from '../_services/authentication.service';

@Component({
  selector: 'app-homework',
  templateUrl: './homework.component.html',
  styleUrls: ['./homework.component.css']
})
export class HomeworkComponent implements OnInit {

  posts: Post[] = []

  constructor(
    private router: Router,
    private postService: PostService,
    public authService: AuthenticationService,
  ) {}

  ngOnInit(): void {
    this.postService.getPosts().subscribe(
      (posts : Post[]) => {
        this.posts = posts;
      },
      (error: any) => {
        console.log(error);
      }
    );
  }

  createPost(): void {
    this.router.navigate(['create-post'])
  }
}
