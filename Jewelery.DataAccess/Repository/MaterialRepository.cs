using Jewelery.DataAccess.Repository.IRepository;
using Jewelery.Models;
using JeweleryShop.DatabaseContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jewelery.DataAccess.Repository
{
    public class MaterialRepository : Repository<Material>, IMaterialRepository
    {
        private AppDbContext _db;

        public MaterialRepository(AppDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Material obj)
        {
            _db.Update(obj);
        }
    }
}
