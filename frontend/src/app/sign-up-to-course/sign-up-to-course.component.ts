import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { CourseService } from '../_services/course.service';
import { SignUpToCourseModel } from "../_models/sign-up-to-course";

@Component({
  selector: 'app-sign-up-to-course',
  templateUrl: './sign-up-to-course.component.html',
  styleUrls: ['./sign-up-to-course.component.css']
})
export class SignUpToCourseComponent{

  signUpToCourse!: FormGroup;
  loading = false;
  submitted = false;
  error = '';

  constructor(private formBuilder : FormBuilder, private courseService : CourseService) {}

  ngOnInit() {
    this.signUpToCourse = this.formBuilder.group({
      courseId: ['', Validators.required],
      userId: ['', Validators.required],
    });
  }

  onSubmit() {
    if (this.signUpToCourse.invalid) {
      return;
    }
    alert("Successfully registerd to the course");

    const signup = {
      courseId : this.signUpToCourse.controls['courseId'].value,
      userId : this.signUpToCourse.controls['userId'].value,
    };

    this.loading = true;
    this.courseService.assignUserToCourse(signup as SignUpToCourseModel)
      .subscribe(
        data => {
          this.submitted = true;
          console.log('succes');
        },
        error => {
          console.log('error');
          this.error = error;
          this.loading = false;
        });
  }

}
