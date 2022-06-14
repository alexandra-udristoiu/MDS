using MDS_BE.Entities;
using MDS_BE.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
