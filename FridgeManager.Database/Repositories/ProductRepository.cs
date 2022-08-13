using FridgeManager.Domain.Models;
using FridgeManager.Interfaces.Repositories;

namespace FridgeManager.Database.Repositories
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(FridgeManagerDbContext dbContext)
            : base(dbContext) { }

        public void Create(Product model) => CreateEntity(model);

        public IEnumerable<Product> GetAll(bool trackChanges) =>
            GetAllEntities(trackChanges);

        public Product GetById(Guid id, bool trackChanges) =>
            GetByCondition(p => p.Id.Equals(id), trackChanges).SingleOrDefault();

        public void Delete(Product model) => DeleteEntity(model);
    }
}
