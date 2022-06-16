using MDS_BE.Entities;
using System.Linq;

namespace MDS_BE.Repositories
{
    public class MaterialRepository : IMaterialRepository
    {
        private DatabaseContext db;

        public MaterialRepository(DatabaseContext db)
        {
            this.db = db;
        }

        public void Create(Material material)
        {
            db.Materials.Add(material);

            db.SaveChanges();
        }

        public void Delete(Material material)
        {
            db.Materials.Remove(material);

            db.SaveChanges();
        }

        public IQueryable<Material> GetMaterialsIQueriable()
        {
            var materials = db.Materials;

            return materials;
        }

        public void Update(Material material)
        {
            db.Materials.Update(material);

            db.SaveChanges();
        }
    }
}

