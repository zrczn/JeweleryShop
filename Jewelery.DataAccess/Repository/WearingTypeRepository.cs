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
    public class WearingTypeRepository : Repository<WearingType>, IWearingTypeRepository
    {
        private AppDbContext _db;
        public WearingTypeRepository(AppDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(WearingType obj)
        {
            _db.Update(obj);
        }
    }
}
