using MDS_BE.Entities;
using MDS_BE.Model;
using MDS_BE.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MDS_BE.Managers
{
    public class MaterialManager : IMaterialManager
    {
        private readonly IMaterialRepository materialRepository;

        public MaterialManager(IMaterialRepository materialRepository)
        {
            this.materialRepository = materialRepository;
        }

        public void Create(MaterialModel model)
        {
            var newMaterial = new Material
            {
                CourseId  = model.CourseId
            };

            materialRepository.Create(newMaterial);
        }

        public void Delete(int MaterialId)
        {
            var material = GetMaterialById(MaterialId);

            if (material == null)
            {
                throw new Exception();
            }

            materialRepository.Delete(material);
        }

        public Material GetMaterialById(int MaterialId)
        {
            var material = materialRepository.GetMaterialsIQueriable()
                        .FirstOrDefault(m => m.MaterialId == MaterialId);

            return material;
        }

        public List<Material> GetMaterials()
        {
            return materialRepository.GetMaterialsIQueriable().ToList();
        }

        public void Update(MaterialModel model)
        {
            var material = GetMaterialById(model.MaterialId);

            if (material == null)
            {
                throw new Exception();
            }

            if (model.CourseId != null)
            {
                material.CourseId = model.CourseId;
            }

            materialRepository.Update(material);
        }
    }
}

