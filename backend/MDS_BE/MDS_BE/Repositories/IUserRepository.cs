using MDS_BE.Entities;
using System.Linq;

namespace MDS_BE.Repositories
{
    public interface IUserRepository
    {
        IQueryable<User> GetUsersIQueryable();
        void Create(User user);
        void Update(User user);
        void Delete(User user);
        void AssignOrganization(string userId, int organizationId);
        void AssignCourse(string userId, int courseId);
    }
}