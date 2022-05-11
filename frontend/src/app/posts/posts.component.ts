import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Post } from '../_models/post';
import { PostService } from '../_services/post.service';

@Component({
  selector: 'app-posts',
  templateUrl: './posts.component.html',
  styleUrls: ['./posts.component.css']
})
export class PostsComponent implements OnInit {

  posts: Post[] = []

  constructor(
    private router: Router,
    private postService: PostService,
  ) { }

  ngOnInit(): void {
    this.postService.getPosts().subscribe(
      (posts : Post[]) => {
        this.posts = posts
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
