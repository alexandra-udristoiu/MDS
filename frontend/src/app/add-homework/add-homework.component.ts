import { Component, Input, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { HwService } from '../_services/hw.service';

@Component({
  selector: 'app-add-homework',
  templateUrl: './add-homework.component.html',
  styleUrls: ['./add-homework.component.css']
})
export class AddHomeworkComponent implements OnInit {
  hwForm!: FormGroup;
  isLinear = false;
  fileName = '';
  file!: File;

  ngOnInit(): void {
    this.hwForm = this.formBuilder.group({
      title: ['', Validators.required],
      text: ['', Validators.required],
      dueDate: ['', Validators.required],
      file: []
    });
  }

  get f() { return this.hwForm.controls; }
  
  constructor(
    private formBuilder: FormBuilder,
    private hwService: HwService,
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

    if (this.f['dueDate']) {
      formData.append('dueDate', this.f['dueDate'].value.toDateString());
    }

    this.hwService.addHw(formData)
      .subscribe(
        (data) => {
          console.log('succes');
        },
        (error) => {
          console.log(error);
        }, 
        () => {
          this.hwForm.reset();
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
