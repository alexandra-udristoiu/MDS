using System;
using System.Collections.Generic;
using System.Linq;
using MDS_BE.Entities;
using MDS_BE.Models;
using MDS_BE.Repositories;

namespace MDS_BE.Managers
{
    public class OrganizationManager : IOrganizationManager
    {
        private readonly IOrganizationsRepository organizationRepository;

        public OrganizationManager(IOrganizationsRepository organizationRepository)
        {
            this.organizationRepository = organizationRepository;
        }

        public void Create(OrganizationModel model)
        {
            var newOrganization = new Organization
            {
                UniversityName = model.UniversityName,
                FacultyName = model.FacultyName,
                City = model.City,
                Contact = model.Contact
            };

            organizationRepository.Create(newOrganization);
        }

        public void Delete(string FacultyName)
        {
            var organization = GetOrganizationByName(FacultyName);

            if (organization == null)
            {
                throw new Exception();
            }

            organizationRepository.Delete(organization);
        }

        public List<Organization> GetOrganisations()
        {
            return organizationRepository.GetOrganizationsIQueryable().ToList();
        }

        public Organization GetOrganizationByName(string FacultyName)
        {
            var organization = organizationRepository.GetOrganizationsIQueryable()
                    .FirstOrDefault(o => o.FacultyName == FacultyName);

            return organization;
        }

        public void Update(OrganizationModel model)
        {
            var organization = GetOrganizationByName(model.FacultyName);

            if (organization == null)
            {
                throw new Exception();
            }

            if (model.Contact != null)
            {
                organization.Contact = model.Contact;
            }

            organizationRepository.Update(organization);
        }

        public void AssignUser(string userId, int organizationId)
        {
            if (userId == null)
            {
                throw new Exception();
            }

            organizationRepository.AssignUser(userId, organizationId);
        }
    }
}