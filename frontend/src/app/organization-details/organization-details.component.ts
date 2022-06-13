import { Component, OnInit, Input } from '@angular/core';
import { Organization } from '../_models/organization';
import { ActivatedRoute } from '@angular/router';
import { Location } from '@angular/common';
import { OrganizationService } from '../_services/organization.service';

@Component({
  selector: 'app-organization-details',
  templateUrl: './organization-details.component.html',
  styleUrls: ['./organization-details.component.css']
})
export class OrganizationDetailsComponent implements OnInit {

  @Input() organization?: Organization;
  constructor(private route: ActivatedRoute, private organizationService: OrganizationService, private location: Location) { }

  ngOnInit(): void {
    this.getOrganization();
  }
  getOrganization() : void{
    const facultyName = String(this.route.snapshot.paramMap.get('facultyName'));
    this.organizationService.getOrganization(facultyName)
      .subscribe(organization => this.organization = organization);
  }

}
