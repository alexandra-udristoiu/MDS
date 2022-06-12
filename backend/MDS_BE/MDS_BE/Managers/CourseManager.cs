using MDS_BE.Entities;
using MDS_BE.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MDS_BE.Managers
{
    public class CourseManager : ICourseManager
    {
        private readonly ICourseRepository courseRepository;
        private readonly IUserCourseRepository userCourseRepository;

        public CourseManager(ICourseRepository courseRepository,  IUserCourseRepository userCourseRepository)
        {
            this.courseRepository = courseRepository;
            this.userCourseRepository = userCourseRepository;
        }

        public void Create(CourseModel model)
        {
            var newCourse = new Course
            {
                Name = model.Name,
                Duration = model.Duration,
                Description = model.Description
            };

            courseRepository.Create(newCourse);
        }

        public void Delete(string Name)
        {
            var course = GetCourseByName(Name);

            if (course == null)
            {
                throw new Exception();
            }

            courseRepository.Delete(course);
        }

        public List<UserCourse> GetCourseUsers(int courseId)
        {
            var users = userCourseRepository.GetUsersCoursesIQueryable()
                        .Where(c => c.CourseId == courseId)
                        .Include(x => x.User)
                        .ToList();

            return users;
        }

        public Course GetCourseByName(string Name)
        {
            var course = courseRepository.GetCoursesIQeriable()
                        .FirstOrDefault(c => c.Name == Name);

            return course;
        }

        public List<Course> GetCourses()
        {
            return courseRepository.GetCoursesIQeriable().ToList();
        }

        public void Update(CourseModel model)
        {
            var course = GetCourseByName(model.Name);

            if (course == null)
            {
                throw new Exception();
            }

            if (model.Duration != null)
            {
                course.Duration = model.Duration;
            }

            courseRepository.Update(course);
        }

        public void AssignUser(string userId, int courseId)
        {
            if (userId == null)
            {
                throw new Exception();
            }

            courseRepository.AssignUser(userId, courseId);
        }
    }
}
