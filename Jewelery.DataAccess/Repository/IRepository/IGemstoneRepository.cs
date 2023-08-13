using Jewelery.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jewelery.DataAccess.Repository.IRepository
{
    public interface IGemstoneRepository : IRepository<Stone>
    {
        void Update(Stone obj);
    }
}
