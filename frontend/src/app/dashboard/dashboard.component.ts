import { Component, OnInit } from '@angular/core';
import { Post } from '../_models/post';
import { PostService } from '../_services/post.service';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit {

  posts: Post[] = [];
  constructor(private postService: PostService) { }

  ngOnInit(): void {
    this.getPosts();
  }

  getPosts(): void {
    this.postService.getPosts().subscribe(posts => {
      this.posts = posts
    });
  }
}
