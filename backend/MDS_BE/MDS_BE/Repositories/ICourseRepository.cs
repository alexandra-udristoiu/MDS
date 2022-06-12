using MDS_BE.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MDS_BE.Repositories
{
    public interface ICourseRepository
    {
        IQueryable<Course> GetCoursesIQeriable();

        void Create(Course course);
        void Update(Course course);
        void Delete(Course course);
        void AssignUser(string userId, int courseId);
    }
}
