import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

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
  
  constructor(private formBuilder: FormBuilder) {}

  onSubmit() {
    if (this.hwForm.invalid) {
      return;
    }

    const post = {
      title: this.f['title'].value,
      text: this.f['text'].value,
      fileName: '',
    };

    if (this.file) {
      post.fileName = this.file.name;
    }
    
    console.log(post);
  }


  onFileSelected(event) {
    const file: File = event.target.files[0];

    if (file) {
        this.fileName = file.name;
        this.file = file;
    }
  }
}
