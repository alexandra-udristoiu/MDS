import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { Post } from '../_models/post';
import { PostService } from '../_services/post.service';

@Component({
  selector: 'app-posts',
  templateUrl: './posts.component.html',
  styleUrls: ['./posts.component.css']
})
export class PostsComponent implements OnInit {

  posts: Post[] = []

  tag: string = ''

  constructor(
    private router: Router,
    private postService: PostService,
    private route: ActivatedRoute,
    private spinnerService: NgxSpinnerService,
  ) { 
    this.router.routeReuseStrategy.shouldReuseRoute = () => false;
  }

  ngOnInit(): void {
    this.spinnerService.show();
    this.postService.getPosts().subscribe(
      (posts : Post[]) => {
        this.posts = posts;
      },
      (error: any) => {
        console.log(error);
      },
      () => {
        this.spinnerService.hide();
      }
    );

    this.route.queryParams.subscribe(params => {
      this.tag = params['tag'];
    })

    console.log(this.tag);

    if (this.tag) {
      this.posts = this.posts.filter(p => p.tags.indexOf(this.tag) != -1);
    }
  }

  createPost(): void {
    this.router.navigate(['create-post'])
  }

}
