using System.Linq;
using MDS_BE.Entities;

namespace MDS_BE.Repositories
{
    public interface IRegisterRepository
    {
        IQueryable<Register> GetRegistersIQueryable();

        void Create(Register register);
        void Update(Register register);
        void Delete(Register register);
    }
}
