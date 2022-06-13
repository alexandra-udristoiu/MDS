import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { User } from '../_models/user';
import { AuthenticationService } from '../_services/authentication.service';
import { UserService } from '../_services/user.service';

@Component({
  selector: 'app-edit-profile',
  templateUrl: './edit-profile.component.html',
  styleUrls: ['./edit-profile.component.css']
})
export class EditProfileComponent implements OnInit {

  user!: User;

  userForm!: FormGroup;

  loading: boolean = false

  submitted: boolean = false

  response!: any;

  constructor(
    private formBuilder: FormBuilder,
    private router: Router,
    private route: ActivatedRoute,
    private userService: UserService,
    private authService: AuthenticationService
  ) { }

  ngOnInit(): void {
    let id = this.authService.user.id;
    this.userService.getAll().subscribe(
      (users : User[]) => {
        this.user = users.filter(u => u.id == id)[0];
      },
      (error: any) => {
        console.log(error);
      }
    );

    this.userForm = this.formBuilder.group({
      username: [this.user.username, Validators.required],
      picture: ['']
    })
    this.response = {dbPath: this.user.imgPath};
  }

  uploadFinished(event): void {
    this.response = event;
  }

  get f() { 
    return this.userForm.controls; 
  }

  onSubmit(): void {
    if (this.userForm.invalid) {
      return;
    }
    
    this.user.username = this.f['username'].value;
    this.user.imgPath = this.response.dbPath;

    this.loading = true;
    this.userService.updateUser(this.user)
      .subscribe(
        (data) => {
          this.submitted = true;
          console.log('succes');
        },
        (error) => {
          console.log(error);
          this.loading = false;
        });
        
    if (this.submitted) {
      this.router.navigate(['/users', this.user.id]);
    }
  }

  cancel(): void {
    this.router.navigate(['/users', this.user.id]);
  }

}
