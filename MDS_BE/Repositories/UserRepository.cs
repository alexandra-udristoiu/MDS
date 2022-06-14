using MDS_BE.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace MDS_BE.Repositories
{
    public class UserRepository : IUserRepository
    {
        private DatabaseContext db;

        public UserRepository(DatabaseContext db)
        {
            this.db = db;
        }

        public IQueryable<User> GetUsersIQueryable()
        {
            var users = db.Users;

            return users;
        }

        public void Create(User user)
        {
            db.Users.Add(user);

            db.SaveChanges();
        }

        public void Update(User user)
        {
            db.Users.Update(user);

            db.SaveChanges();
        }

        public void Delete(User user)
        {
            db.Users.Remove(user);

            db.SaveChanges();
        }

        public void AssignOrganization(string userId, int organizationId)
        {
            var userOrganization = new UserOrganization
            {
                UserId = userId,
                OrganizationId = organizationId
            };

            db.UserOrganizations.Add(userOrganization);

            db.SaveChanges();
        }

        //public void AssignCourse(string userId, int courseId)
        //{
        //    var userCourse = new UserCourse
        //    {
        //        UserId = userId,
        //        CourseId = courseId
        //    };

        //    db.UserCourses.Add(userCourse);

        //    db.SaveChanges();
        //}
    }
}
