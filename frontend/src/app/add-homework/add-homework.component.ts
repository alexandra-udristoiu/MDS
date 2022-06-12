import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { PostService } from '../_services/post.service';
import { PostCreateModel } from '../_models/post-create';

@Component({
  selector: 'app-add-homework',
  templateUrl: './add-homework.component.html',
  styleUrls: ['./add-homework.component.css']
})
export class AddHomeworkComponent {
  hwForm!: FormGroup;
  isLinear = false;
  fileName = '';
  file!: File;

  ngOnInit(): void {
    this.hwForm = this.formBuilder.group({
      title: ['', Validators.required],
      text: ['', Validators.required],
      file: []
    });
  }

  get f() { return this.hwForm.controls; }
  
  constructor(
    private formBuilder: FormBuilder,
    private postService: PostService,
  ) {}

  onSubmit() {
    if (this.hwForm.invalid) {
      return;
    }

    const formData = new FormData();
    formData.append('title', this.f['title'].value);
    formData.append('text', this.f['text'].value);

    if (this.file) {
      formData.append('file', this.file);
    }

    this.postService.addPost(formData)
      .subscribe(
        (data) => {
          console.log('succes');
        },
        (error) => {
          console.log(error);
        });
  }


  onFileSelected(event) {
    const file: File = event.target.files[0];

    if (file) {
        this.fileName = file.name;
        this.file = file;
    }
  }
}
