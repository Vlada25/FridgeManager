using FridgeManager.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FridgeManager.Interfaces.Repositories
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAll(bool trackChanges);
        Product GetById(Guid id, bool trackChanges);
        void Create(Product model);
        void Delete(Product model);
    }
}
