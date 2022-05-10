import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';



import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { LoginComponent } from './login/login.component';
import { MaterialModule } from './_modules/material.module';
import { MockModule } from './mock/mock.module';
import { RouterModule } from '@angular/router';
import { RegisterComponent } from './register/register.component';
import { CoursesComponent } from './courses/courses.component';
import { CourseDetailComponent } from './course-detail/course-detail.component';
import { SignUpToCourseComponent } from './sign-up-to-course/sign-up-to-course.component';

const mockModule = [MockModule];
@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    RegisterComponent,
    CoursesComponent,
    CourseDetailComponent,
    SignUpToCourseComponent,
  ],
  imports: [
    ...mockModule,
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MaterialModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule,
    HttpClientModule,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
