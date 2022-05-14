import { Component, OnInit } from '@angular/core';
import { Organization } from '../_models/organization';
import { OrganizationService } from '../_services/organization.service';
import { MessageService } from '../_services/message.service';

@Component({
  selector: 'app-organizations',
  templateUrl: './organizations.component.html',
  styleUrls: ['./organizations.component.css']
})
export class OrganizationsComponent implements OnInit {

  organizations: Organization[] = [];
  selectedOrganization?: Organization;

  constructor(private organizationService : OrganizationService, private messageService: MessageService) { }

  ngOnInit(): void {
    this.getOrganizations();
  }
  getOrganizations(): void {
    this.organizationService.getOrganizations()
      .subscribe(organizations => this.organizations = organizations);
  }

  onSelect(organization: Organization)
  {
    this.selectedOrganization = organization;
    this.messageService.add(`HeroesComponent: Selected organization name=${organization.facultyName}`)
  }

}
