using MDS_BE.Entities;
using System.Collections.Generic;

namespace MDS_BE.Managers
{
    public interface ICourseManager
    {
        List<Course> GetCourses();
        List<UserCourse> GetCourseUsers(int courseId);
        List<Course> GetCoursesForUser(string userId);
        Course GetCourseByName(string Name);
        void Create(CourseModel model);
        void Update(CourseModel model);
        void Delete(string Name);
        void AssignUser(string userId, int courseId);
    }
}
