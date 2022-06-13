import { Component, Inject, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Organization } from '../_models/organization';
import { OrganizationService } from '../_services/organization.service';
import { UserService } from '../_services/user.service';

@Component({
  selector: 'app-assign-organization',
  templateUrl: './assign-organization.component.html',
  styleUrls: ['./assign-organization.component.css']
})
export class AssignOrganizationComponent implements OnInit {

  organizations: Organization[] = [];

  assignOrganization!: FormGroup;

  id: string = '';

  constructor(
    @Inject(MAT_DIALOG_DATA) public data: any,
    private userService: UserService,
    private organizationService: OrganizationService,
    public dialogRef: MatDialogRef<AssignOrganizationComponent>,
    private formBuilder: FormBuilder,
  ) { 
    this.id = data.id
  }

  ngOnInit(): void {
    this.assignOrganization = this.formBuilder.group({
      organization: ['', Validators.required]
    });

    this.organizationService.getOrganizations().subscribe(
      (organizations: Organization[]) => {
        this.organizations = organizations;
      },
      (error: any) => {
        console.log(error);
      }
    );
  }

  onSubmit(): void {
    if (!this.assignOrganization.valid) {
      return;
    }

    const userOrganization = {
      organizationId : this.assignOrganization.controls['organization'].value
    };
    this.userService.assignOrganization(this.id, userOrganization).subscribe(
      (result) => {
        this.dialogRef.close();
      },
      (error) => {
        console.log(error);
      }
    );

  }

}
