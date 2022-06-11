using System;
using System.Collections.Generic;
using System.Linq;
using MDS_BE.Entities;
using MDS_BE.Model;
using MDS_BE.Repositories;

namespace MDS_BE.Managers
{
    public class RegisterManager : IRegisterManager
    {
        private readonly IRegisterRepository registerRepository;

        public RegisterManager(IRegisterRepository registerRepository)
        {
            this.registerRepository = registerRepository;
        }

        public void Create(RegisterModel model)
        {
            var newRegister = new Register
            {
                CourseName = model.CourseName,
                Grade = model.Grade,
                UserId = model.UserId
            };

            registerRepository.Create(newRegister);
        }

        public void Delete(string UserId, string CourseName)
        {
            var register = GetRegisterByUserAndCourse(UserId, CourseName);

            if (register == null)
            {
                throw new Exception();
            }

            registerRepository.Delete(register);
        }

        public Register GetRegisterByUserAndCourse(string UserId, string CourseName)
        {
            var register = registerRepository.GetRegistersIQueryable().
                FirstOrDefault(r => r.UserId == UserId && r.CourseName == CourseName);

            return register;
        }

        public List<Register> GetRegisters()
        {
            return registerRepository.GetRegistersIQueryable().ToList();
        }

        public List<Register> GetRegistersByCourseName(string CourseName)
        {
            return registerRepository.GetRegistersIQueryable()
                .Where(r => r.CourseName == CourseName)
                .ToList();
        }

        public List<Register> GetRegistersByUserId(string UserId)
        {
            return registerRepository.GetRegistersIQueryable()
                .Where(r => r.UserId == UserId)
                .ToList();
        }

        public void Update(RegisterModel model)
        {
            var register = GetRegisterByUserAndCourse(model.UserId, model.CourseName);

            register.Grade = model.Grade;
            registerRepository.Update(register); 
        }
    }
}
