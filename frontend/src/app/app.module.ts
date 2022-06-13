import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { NgxSpinnerModule } from 'ngx-spinner';
import { MatStepperModule } from '@angular/material/stepper';
import { MatGridListModule } from '@angular/material/grid-list';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatNativeDateModule } from '@angular/material/core';


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
import { UsersComponent } from './users/users.component';
import { UserComponent } from './user/user.component';
import { EditProfileComponent } from './edit-profile/edit-profile.component';
import { AssignOrganizationComponent } from './assign-organization/assign-organization.component';
import { UploadPictureComponent } from './upload-picture/upload-picture.component';
import { HomeworkComponent } from './homework/homework.component';
import { AddHomeworkComponent } from './add-homework/add-homework.component';
import { CommentEditComponent } from './comment-edit/comment-edit.component';
import { HwDetailsComponent } from './hw-details/hw-details.component';


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
    UsersComponent,
    UserComponent,
    EditProfileComponent,
    AssignOrganizationComponent,
    UploadPictureComponent,
    HomeworkComponent,
    AddHomeworkComponent,
    CommentEditComponent,
    HwDetailsComponent,

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
    MatDatepickerModule,
    MatNativeDateModule,
  ],
  providers: [
    MatDatepickerModule,
    MatNativeDateModule,
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
