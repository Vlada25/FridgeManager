using FridgeManager.Domain;
using FridgeManager.Domain.Models;
using FridgeManager.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FridgeManager.Database.Repositories
{
    public class FridgeRepository : BaseRepository<Fridge>, IFridgeRepository
    {
        public FridgeRepository(FridgeManagerDbContext dbContext)
            : base(dbContext) { }

        public void Create(Fridge model) => CreateEntity(model);

        public IEnumerable<Fridge> GetAll(bool trackChanges) =>
            GetAllEntities(trackChanges).Include(f => f.Model).OrderBy(f => f.Name);

        public Fridge GetById(Guid id, bool trackChanges) =>
            GetByCondition(f => f.Id.Equals(id), trackChanges).Include(f => f.Model).SingleOrDefault();

        public IEnumerable<Fridge> GetFridgesByModel(Guid modelId, bool trackChanges) =>
            GetByCondition(f => f.ModelId.Equals(modelId), trackChanges)
                .Include(f => f.Model).OrderBy(e => e.Name);

        public void Delete(Fridge model) => DeleteEntity(model);

        public int GetYearOfTheMostSpaciousFridge()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Fridge> SearchFridgesBySubstring(string substring, bool trackChanges) =>
            GetAllEntities(trackChanges).Where(f => f.Name.Contains(substring))
            .Include(f => f.Model).OrderBy(f => f.Name);
    }
}
