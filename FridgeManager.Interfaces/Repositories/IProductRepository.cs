using FridgeManager.Domain.Models;

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
