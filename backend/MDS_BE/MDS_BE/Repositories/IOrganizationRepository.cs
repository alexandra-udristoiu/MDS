using System.Linq;
using MDS_BE.Entities;

namespace MDS_BE.Repositories
{
    public interface IOrganizationsRepository
    {
        IQueryable<Organization> GetOrganizationsIQueryable();

        void Create(Organization organization);
        void Update(Organization organization);
        void Delete(Organization organization);
        void AssignUser(string userId, int organizationId);
    }
}