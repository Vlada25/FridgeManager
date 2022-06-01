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
    public class FridgeProductRepository : BaseRepository<FridgeProduct>, IFridgeProductRepository
    {
        public FridgeProductRepository(FridgeManagerDbContext dbContext)
            : base(dbContext) { }

        public void Create(FridgeProduct model) => CreateEntity(model);

        public IEnumerable<FridgeProduct> GetAll(bool trackChanges) =>
            GetAllEntities(trackChanges);

        public FridgeProduct GetById(Guid id, bool trackChanges) =>
            GetByCondition(fm => fm.Id.Equals(id), trackChanges).SingleOrDefault();

        public void Delete(FridgeProduct model) => DeleteEntity(model);
    }
}
