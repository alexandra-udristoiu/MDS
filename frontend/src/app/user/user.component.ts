import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Course } from '../_models/courses';
import { Organization } from '../_models/organization';
import { User } from '../_models/user';
import { CourseService } from '../_services/course.service';
import { OrganizationService } from '../_services/organization.service';
import { UserService } from '../_services/user.service';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { AssignOrganizationComponent } from '../assign-organization/assign-organization.component';
import { AuthenticationService } from '../_services/authentication.service';

@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.css']
})
export class UserComponent implements OnInit {

  user!: User;

  organizations: Organization[] = [];

  courses: Course[] = [];

  constructor(
    private route: ActivatedRoute,
    private userService: UserService,
    private router: Router,
    private organizationService: OrganizationService,
    private courseService: CourseService,
    public authService: AuthenticationService,
    public dialog: MatDialog,
  ) { }

  ngOnInit(): void {
    let userId = this.route.snapshot.params['id'];
    this.userService.getAll().subscribe(
      (users : User[]) => {
        this.user = users.filter(u => u.id == userId)[0];
      },
      (error: any) => {
        console.log(error);
      }
    );
    this.courseService.getCourses().subscribe(
      (courses: Course[]) => {
        this.courses = courses;
      },
      (error: any) => {
        console.log(error);
      }
    );
    this.organizationService.getOrganizations().subscribe(
      (organizations: Organization[]) => {
        this.organizations = organizations;
      },
      (error: any) => {
        console.log(error);
      }
    );
  }

  deleteUser(): void {
    this.userService.deleteUser(this.user.id).subscribe(
      (data) => {
        this.user = {} as User;
      },
      (error: any) => {
        console.log(error);
    });
    this.router.navigate(['/users']);
  }

  editUser(): void {
    this.router.navigate(['/edit-profile']);
  }

  addToOrganization(): void {
    var userId = this.user.id
    const data = {
      userId
    };
    const dialogConfig = new MatDialogConfig();
    dialogConfig.width = '550px';
    dialogConfig.height = '400px';
    dialogConfig.data = data;
    const dialogRef = this.dialog.open(AssignOrganizationComponent, dialogConfig);
  }

  get isMine(): boolean {
    return this.authService.user.id === this.user.id;
  }

}
