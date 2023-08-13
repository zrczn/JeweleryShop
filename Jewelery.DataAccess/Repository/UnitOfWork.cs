using Jewelery.DataAccess.Repository.IRepository;
using JeweleryShop.DatabaseContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jewelery.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        public IProductRepository ProductRepository { get; private set; }

        public IGemstoneRepository GemstoneRepository { get; private set; }
        public IMaterialRepository MaterialRepository { get; private set; }

        public IWearingTypeRepository WearingTypeRepository { get; private set; }

        private AppDbContext _db;

        public UnitOfWork(AppDbContext db)
        {
            _db = db;
            ProductRepository = new ProductRepository(_db);
            GemstoneRepository = new GemstoneRepository(_db);
            MaterialRepository = new MaterialRepository(_db);
            WearingTypeRepository = new WearingTypeRepository(_db);
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
