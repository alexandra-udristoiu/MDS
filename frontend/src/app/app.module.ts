import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { NgxSpinnerModule } from 'ngx-spinner';
import { MatStepperModule } from '@angular/material/stepper';
import { MatGridListModule } from '@angular/material/grid-list';


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
import { OrganizationsComponent } from './organizations/organizations.component';
import { OrganizationDetailsComponent } from './organization-details/organization-details.component';
import { AddOrganizationComponent } from './add-organization/add-organization.component';

import { PostsComponent } from './posts/posts.component';
import { PostPageComponent } from './post-page/post-page.component';
import { CommentComponent } from './comment/comment.component';
import { CommentCreateComponent } from './comment-create/comment-create.component';
import { CreatePostComponent } from './create-post/create-post.component';
import { PostDetailsComponent } from './post-details/post-details.component';
import { EditPostComponent } from './edit-post/edit-post.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { SidenavComponent } from './sidenav/sidenav.component';
import { HeaderComponent } from './header/header.component';
import { LayoutComponent } from './layout/layout.component';
import { HomeworkComponent } from './homework/homework.component';
import { AddHomeworkComponent } from './add-homework/add-homework.component';


const mockModule = [MockModule];
@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    RegisterComponent,

    DashboardComponent,
    CoursesComponent,
    CourseDetailComponent,
    SignUpToCourseComponent,
    OrganizationsComponent,
    OrganizationDetailsComponent,
    AddOrganizationComponent,

    PostsComponent,
    PostPageComponent,
    CommentComponent,
    CommentCreateComponent,
    CreatePostComponent,
    PostDetailsComponent,
    EditPostComponent,
    SidenavComponent,
    HeaderComponent,
    LayoutComponent,
    HomeworkComponent,
    AddHomeworkComponent,

  ],
  imports: [
    ...mockModule,
    NgxSpinnerModule,
    MatStepperModule,
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MaterialModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    MatGridListModule,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
