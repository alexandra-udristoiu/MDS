using MDS_BE.Entities;
using System.Linq;

namespace MDS_BE.Repositories
{
    public interface IMaterialRepository
    {
        IQueryable<Material> GetMaterialsIQueriable();
        void Create(Material material);
        void Update(Material material);
        void Delete(Material material);
    }
}

