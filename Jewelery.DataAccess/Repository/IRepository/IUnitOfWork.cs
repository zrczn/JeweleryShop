using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jewelery.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork
    {
        IProductRepository ProductRepository { get; }
        IGemstoneRepository GemstoneRepository { get; }
        IMaterialRepository MaterialRepository { get; }
        IWearingTypeRepository WearingTypeRepository { get; }
        void Save();
    }
}
