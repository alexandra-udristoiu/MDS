using MDS_BE.Entities;
using MDS_BE.Managers;
using System.Linq;

namespace MDS_BE.Repositories
{
    public class UserCourseRepository : IUserCourseRepository
    {
        private DatabaseContext db;

        public UserCourseRepository(DatabaseContext db)
        {
            this.db = db;
        }

        public IQueryable<UserCourse> GetUsersCoursesIQueryable()
        {
            var userCourse = db.UserCourses;

            return userCourse;
        }
    }
}
