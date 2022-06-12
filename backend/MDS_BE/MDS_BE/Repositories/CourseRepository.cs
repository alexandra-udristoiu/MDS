using MDS_BE.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MDS_BE.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        private DatabaseContext db;

        public CourseRepository(DatabaseContext db)
        {
            this.db = db;
        }

        public void Create(Course course)
        {
            db.Courses.Add(course);

            db.SaveChanges();
        }

        public void Delete(Course course)
        {
            db.Courses.Remove(course);

            db.SaveChanges();
        }

        public IQueryable<Course> GetCoursesIQeriable()
        {
            var courses = db.Courses;

            return courses;
        }

        public void Update(Course course)
        {
            db.Courses.Update(course);

            db.SaveChanges();
        }

        public void AssignUser(string userId, int courseId)
        {
            var userCourse = new UserCourse
            {
                UserId = userId,
                CourseId = courseId
            };

            db.UserCourses.Add(userCourse);

            db.SaveChanges();
        }
    }
}
