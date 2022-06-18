using FridgeManager.Domain;
using FridgeManager.Domain.Models;
using FridgeManager.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
