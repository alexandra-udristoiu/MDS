import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CourseDetailComponent } from './course-detail/course-detail.component';
import { CoursesComponent } from './courses/courses.component';
import { AuthGuard } from './guards/auth.guard';
import { LoginComponent } from './login/login.component';
import { OrganizationsComponent } from './organizations/organizations.component';
import { OrganizationDetailsComponent } from './organization-details/organization-details.component';
import { RegisterComponent } from './register/register.component';
import { SignUpToCourseComponent } from './sign-up-to-course/sign-up-to-course.component';
import { AddOrganizationComponent } from './add-organization/add-organization.component';

const routes: Routes = [
  { path: 'login', component: LoginComponent, canActivate: [AuthGuard] },
  { path: 'register', component: RegisterComponent, canActivate: [AuthGuard] },
  { path: 'courses', component: CoursesComponent, canActivate: [AuthGuard]},
  { path: 'courses/:name', component: CourseDetailComponent, canActivate: [AuthGuard]},
  { path: 'sign-up-to-course', component: SignUpToCourseComponent, canActivate: [AuthGuard]},
  { path: 'organizations', component: OrganizationsComponent, canActivate: [AuthGuard]},
  { path: 'organizations/:facultyName', component: OrganizationDetailsComponent, canActivate: [AuthGuard]},
  { path: 'add-organization', component: AddOrganizationComponent, canActivate: [AuthGuard]},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
