using MDS_BE.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MDS_BE.Repositories
{
    public interface IAssignmentRepository
    {
        IQueryable<Assignment> GetAssignmentsIQueryable();
        void Create(Assignment assignment);
        void Update(Assignment assignment);
        void Delete(Assignment assignment);

    }
}
