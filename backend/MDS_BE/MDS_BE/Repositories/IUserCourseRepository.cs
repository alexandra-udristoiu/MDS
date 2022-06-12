using MDS_BE.Entities;
using System.Linq;

namespace MDS_BE.Managers
{
    public interface IUserCourseRepository
    {
        IQueryable<UserCourse> GetUsersCoursesIQueryable();
    }
}