import { COMMA, ENTER } from '@angular/cdk/keycodes';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatChipInputEvent } from '@angular/material/chips';
import { ActivatedRoute, Router } from '@angular/router';
import { Post } from '../_models/post';
import { PostCreateModel } from '../_models/post-create';
import { PostService } from '../_services/post.service';

@Component({
  selector: 'app-edit-post',
  templateUrl: './edit-post.component.html',
  styleUrls: ['./edit-post.component.css']
})
export class EditPostComponent implements OnInit {

  postForm!: FormGroup;

  post!: Post;

  loading: boolean = false

  submitted: boolean = false

  returnUrl: string = '/posts'

  readonly separatorKeysCodes = [ENTER, COMMA] as const;

  constructor(
    private formBuilder: FormBuilder,
    private router: Router,
    private route: ActivatedRoute,
    private postService: PostService
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


    this.postForm = this.formBuilder.group({
      title: [this.post.title, Validators.required],
      text: [this.post.text, Validators.required],
      tags: [this.post.tags]
    });

    this.returnUrl = this.route.snapshot.queryParams['returnUrl'] || '/posts';
  }

  get f() { return this.postForm.controls; }

  onSubmit() {
    if (this.postForm.invalid) {
      return;
    }

    
    this.post.title = this.f['title'].value;
    this.post.text = this.f['text'].value;
    this.post.tags = this.f['tags'].value;

    this.loading = true;
    this.postService.updatePost(this.post)
      .subscribe(
        (data) => {
          this.submitted = true;
          console.log('succes');
        },
        (error) => {
          console.log(error);
          this.loading = false;
        });
        
    if (this.submitted) {
      this.router.navigate([this.returnUrl]);
    }
  }

  get tags(): string[] {
    return this.postForm.get('tags') ?.value || [];
  }
  addTag(event: MatChipInputEvent): void {
    const value = (event.value || '').trim();
    if (value) {
      const tags = this.postForm.get('tags') ?.value || [];
      tags.push(value);
      this.postForm.patchValue({
        tags: tags
      });
    }
    event.chipInput!.clear();
  }

  removeTag(tag: string): void {
    const tags = this.postForm.get('tags') ?.value || [];
    const index = tags.indexOf(tag);
    if (index >= 0) {
      tags.splice(index, 1);
      this.postForm.patchValue({
        tags: tags
      });
    }
  }

  cancel(): void {
    this.router.navigate([this.returnUrl]);
  }

}
