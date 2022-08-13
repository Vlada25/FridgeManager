using FridgeManager.Domain.Models;
using FridgeManager.Interfaces.Repositories;

namespace FridgeManager.Database.Repositories
{
    public class FridgeModelRepository : BaseRepository<FridgeModel>, IFridgeModelRepository
    {
        public FridgeModelRepository(FridgeManagerDbContext dbContext)
            : base(dbContext) { }

        public void Create(FridgeModel model) => CreateEntity(model);

        public IEnumerable<FridgeModel> GetAll(bool trackChanges) =>
            GetAllEntities(trackChanges).OrderBy(fm => fm.Name);

        public FridgeModel GetById(Guid id, bool trackChanges) =>
            GetByCondition(fm => fm.Id.Equals(id), trackChanges).SingleOrDefault();

        public void Delete(FridgeModel model) => DeleteEntity(model);
    }
}
