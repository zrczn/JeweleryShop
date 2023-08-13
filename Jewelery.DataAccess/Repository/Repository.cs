using Jewelery.DataAccess.Repository.IRepository;
using JeweleryShop.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Jewelery.DataAccess.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private AppDbContext _db;
        private DbSet<T> dbset;

        public Repository(AppDbContext db)
        {
            _db = db;
            dbset = _db.Set<T>();
        }

        public void Add(T entity)
        {
            dbset.Add(entity);
        }

        public IEnumerable<T> GetAll()
        {
            IQueryable<T> query = dbset;

            return query.Select(x => x);
        }

        public T GetSingle(Expression<Func<T, bool>> lambda)
        {
            IQueryable<T> query = dbset;

            return query.Where(lambda).FirstOrDefault();
        }

        public void Remove(T entity)
        {
            dbset.Remove(entity);
        }
    }
}
