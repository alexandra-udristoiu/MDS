using System.Collections.Generic;
using MDS_BE.Entities;
using MDS_BE.Models;

namespace MDS_BE.Managers
{
    public interface IOrganizationManager
    {
        List<Organization> GetOrganisations();
        Organization GetOrganizationByName(string FacultyName);
        void Create(OrganizationModel model);
        void Update(OrganizationModel model);
        void Delete(string FacultyName);
        void AssignUser(string userId, int organizationId);

    }
}