using System.Linq;
using MDS_BE.Entities;

namespace MDS_BE.Repositories
{
    public class OrganizationsRepository : IOrganizationsRepository
    {
        private DatabaseContext db;

        public OrganizationsRepository(DatabaseContext db)
        {
            this.db = db;
        }

        public void Create(Organization organization)
        {
            db.Organizations.Add(organization);

            db.SaveChanges();
        }

        public void Delete(Organization organization)
        {
            db.Organizations.Remove(organization);

            db.SaveChanges();
        }

        public IQueryable<Organization> GetOrganizationsIQueryable()
        {
            var organizations = db.Organizations;

            return organizations;
        }

        public void Update(Organization organization)
        {
            db.Organizations.Update(organization);

            db.SaveChanges();

        }

        public void AssignUser(string userId, int organizationId)
        {
            var userOrganization = new UserOrganization
            {
                UserId = userId,
                OrganizationId = organizationId
            };

            db.UserOrganizations.Add(userOrganization);

            db.SaveChanges();
        }
    }
}