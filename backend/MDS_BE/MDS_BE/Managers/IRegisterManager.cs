using System.Collections.Generic;
using MDS_BE.Entities;
using MDS_BE.Model;

namespace MDS_BE.Managers
{
    public interface IRegisterManager
    {
        List<Register> GetRegisters();
        List<Register> GetRegistersByCourseName(string CourseName);
        List<Register> GetRegistersByUserId(string UserId);
        Register GetRegisterByUserAndCourse(string UserId, string CourseName);

        void Create(RegisterModel model);
        void Update(RegisterModel mode);
        void Delete(string UserId, string CourseName);
    }
}
