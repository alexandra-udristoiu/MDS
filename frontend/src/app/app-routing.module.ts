import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { CourseDetailComponent } from './course-detail/course-detail.component';
import { CoursesComponent } from './courses/courses.component';
import { CreatePostComponent } from './create-post/create-post.component';
import { EditPostComponent } from './edit-post/edit-post.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { AuthGuard } from './guards/auth.guard';
import { CheckGuard } from './guards/check.guard';
import { LoginComponent } from './login/login.component';
import { OrganizationsComponent } from './organizations/organizations.component';
import { OrganizationDetailsComponent } from './organization-details/organization-details.component';
import { PostPageComponent } from './post-page/post-page.component';
import { PostsComponent } from './posts/posts.component';
import { RegisterComponent } from './register/register.component';
import { SignUpToCourseComponent } from './sign-up-to-course/sign-up-to-course.component';
import { HomeworkComponent } from './homework/homework.component';
import { AddOrganizationComponent } from './add-organization/add-organization.component';

const routes: Routes = [
  { path: '', redirectTo: '/dashboard', pathMatch: 'full' },
  { path: 'courses', component: CoursesComponent, canActivate: [AuthGuard]},
  { path: 'courses/:name', component: CourseDetailComponent, canActivate: [AuthGuard]},
  { path: 'sign-up-to-course', component: SignUpToCourseComponent, canActivate: [AuthGuard]},
  { path: 'organizations', component: OrganizationsComponent, canActivate: [AuthGuard]},
  { path: 'organizations/:facultyName', component: OrganizationDetailsComponent, canActivate: [AuthGuard]},
  { path: 'add-organization', component: AddOrganizationComponent, canActivate: [AuthGuard]},
  { path: 'login', component: LoginComponent, canActivate: [CheckGuard] },
  { path: 'register', component: RegisterComponent, canActivate: [CheckGuard] },
  { path: 'posts', component: PostsComponent, canActivate: [AuthGuard]},
  { path: 'posts/:postId', component: PostPageComponent, canActivate: [AuthGuard]},
  { path: "create-post", component: CreatePostComponent, canActivate: [AuthGuard]},
  { path: "edit-post/:postId", component: EditPostComponent, canActivate: [AuthGuard]},
  { path: 'dashboard', component: DashboardComponent, canActivate: [AuthGuard] },
  { path: 'homework', component: HomeworkComponent, canActivate: [AuthGuard] },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
