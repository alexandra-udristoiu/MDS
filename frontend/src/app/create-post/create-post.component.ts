import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { COMMA, ENTER } from '@angular/cdk/keycodes';
import { Router } from '@angular/router';
import { MatChipInputEvent } from '@angular/material/chips';
import { PostCreateModel } from '../_models/post-create';
import { PostService } from '../_services/post.service';

@Component({
  selector: 'app-create-post',
  templateUrl: './create-post.component.html',
  styleUrls: ['./create-post.component.css']
})
export class CreatePostComponent implements OnInit {

  postForm!: FormGroup;

  loading: boolean = false

  submitted: boolean = false

  readonly separatorKeysCodes = [ENTER, COMMA] as const;

  constructor(
    private formBuilder: FormBuilder,
    private router: Router,
    private postService: PostService
  ) { }

  ngOnInit(): void {
    this.postForm = this.formBuilder.group({
      title: ['', Validators.required],
      text: ['', Validators.required],
      tags: []
    });
  }

  get f() { return this.postForm.controls; }

  onSubmit() {
    if (this.postForm.invalid) {
      return;
    }

    const post = {
      title: this.f['title'].value,
      text: this.f['text'].value,
      tags: this.f['tags'].value,
    };

    this.loading = true;
    this.postService.addPost(post as PostCreateModel)
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
      this.router.navigate(['posts']);
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

}
