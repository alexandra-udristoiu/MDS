using MDS_BE.Entities;
using MDS_BE.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MDS_BE.Managers
{
    public interface IAssignmentManager
    {
        List<Assignment> GetAssignments();
        void Create(AssignmentModel model);
        void Update(AssignmentModel model);
        void Delete(int AssignmentId);
        List<Assignment> GetCourseAssignments(int courseId);
    }
}
