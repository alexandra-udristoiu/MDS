using System.Linq;
using MDS_BE.Entities;

namespace MDS_BE.Repositories
{
    public class RegisterRepository : IRegisterRepository
    {
        private DatabaseContext db;

        public RegisterRepository(DatabaseContext db)
        {
            this.db = db;
        }

        public void Create(Register register)
        {
            db.Register.Add(register);

            db.SaveChanges();
        }

        public void Delete(Register register)
        {
            db.Register.Remove(register);

            db.SaveChanges();
        }

        public IQueryable<Register> GetRegistersIQueryable()
        {
            var register = db.Register;

            return register;
        }

        public void Update(Register register)
        {
            db.Register.Update(register);

            db.SaveChanges();
        }
    }
}
