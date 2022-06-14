using MDS_BE.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MDS_BE.Managers
{
    public interface ICourseManager
    {
        List<Course> GetCourses();
        List<UserCourse> GetCourseUsers(int courseId);
        Course GetCourseByName(string Name);
        void Create(CourseModel model);
        void Update(CourseModel model);
        void Delete(string Name);
        void AssignUser(string userId, int courseId);
    }
}
