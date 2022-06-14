using MDS_BE.Entities;
using MDS_BE.Model;
using MDS_BE.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MDS_BE.Managers
{
    public class AssignmentManager : IAssignmentManager
    {
        private readonly IAssignmentRepository assignmentsRepository;

        public AssignmentManager(IAssignmentRepository assignmentsRepository)
        {
            this.assignmentsRepository = assignmentsRepository;
        }

        private Assignment GetAssignmentById(int id)
        {
            var assignment = assignmentsRepository.GetAssignmentsIQueryable()
                .FirstOrDefault(x => x.AssignmentId == id);

            return assignment;
        }

        public void Create(AssignmentModel model)
        {
            var newAssignment = new Assignment
            {
                CourseName = model.CourseName,
                Text = model.Text,
                Grade = model.Grade,
                CourseId = model.CourseId
            };

            assignmentsRepository.Create(newAssignment);

        }

        public List<Assignment> GetAssignments()
        {
            var assignments = assignmentsRepository
                .GetAssignmentsIQueryable()
                .ToList();

            return assignments;
        }

        public List<Assignment> GetCourseAssignments(int courseId)
        {
            var cursor = assignmentsRepository.GetAssignmentsIQueryable()
                        .Where(a => a.CourseId == courseId);
            return cursor.ToList();
        }
        public void Update(AssignmentModel model)
        {
            var assignment = GetAssignmentById(model.AssignmentId);
            if (assignment == null || model.AssignmentId != assignment.AssignmentId)
            {
                throw new Exception();
            }

            assignment.Text = model.Text;
            assignmentsRepository.Update(assignment);
        }

        public void Delete(int id)
        {
            var assignment = GetAssignmentById(id);
            if (assignment == null)
            {
                return;
            }

            assignmentsRepository.Delete(assignment);
        }
    }
}
