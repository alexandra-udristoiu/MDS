using MDS_BE.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MDS_BE.Repositories
{
    public class AssignmentRepository : IAssignmentRepository
    {
        private DatabaseContext db;

        public AssignmentRepository(DatabaseContext db)
        {
            this.db = db;
        }

        public void Create(Assignment assignment)
        {
            db.Assignments.Add(assignment);

            db.SaveChanges();
        }

        public void Delete(Assignment assignment)
        {
            db.Assignments.Remove(assignment);

            db.SaveChanges();
        }

        public IQueryable<Assignment> GetAssignmentsIQueryable()
        {
            var assignments = db.Assignments;

            return assignments;
        }

        public void Update(Assignment assignment)
        {
            db.Assignments.Update(assignment);

            db.SaveChanges();
        }
    }
}
