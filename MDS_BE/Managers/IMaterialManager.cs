using MDS_BE.Entities;
using MDS_BE.Model;
using System.Collections.Generic;

namespace MDS_BE.Managers
{
    public interface IMaterialManager
    {
        Material GetMaterialById(int MaterialId);
        List<Material> GetMaterials();
        void Create(MaterialModel model);
        void Update(MaterialModel model);
        void Delete(int MaterialId);
    }
}
