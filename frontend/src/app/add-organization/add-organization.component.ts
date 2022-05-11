import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { OrganizationService } from '../_services/organization.service';
import { Organization } from "../_models/organization";

@Component({
  selector: 'app-add-organization',
  templateUrl: './add-organization.component.html',
  styleUrls: ['./add-organization.component.css']
})

export class AddOrganizationComponent{

  addOrganization!: FormGroup;
  loading = false;
  submitted = false;
  error = '';

  constructor(private formBuilder : FormBuilder, private organizationService : OrganizationService) {}

  ngOnInit() {
    this.addOrganization = this.formBuilder.group({
      universityName: ['', Validators.required],
      facultyName: ['', Validators.required],
      city: [''],
      contact: ['']
    });
  }

  onSubmit() {
    if (this.addOrganization.invalid) {
      return;
    }
    
    const organization = {
      universityName : this.addOrganization.controls['universityName'].value,
      facultyName : this.addOrganization.controls['facultyName'].value,
      city : this.addOrganization.controls['city'].value,
      contact : this.addOrganization.controls['contact'].value,
    };

    this.loading = true;
    this.organizationService.addOrganization(organization as Organization)
      .subscribe(
        data => {
          this.submitted = true;
          alert("You organization was succesfully added!");
        },
        error => {
          console.log('error');
          this.error = error;
          this.loading = false;
        });
  }

}
