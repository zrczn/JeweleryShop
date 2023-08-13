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
    public class GemstoneRepository : Repository<Stone>, IGemstoneRepository
    {
        private AppDbContext _db;

        public GemstoneRepository(AppDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Stone obj)
        {
            _db.Update(obj);
        }
    }
}
