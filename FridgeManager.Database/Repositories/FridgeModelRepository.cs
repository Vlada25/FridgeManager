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
    public class FridgeModelRepository : BaseRepository<FridgeModel>, IFridgeModelRepository
    {
        public FridgeModelRepository(FridgeManagerDbContext dbContext) 
            : base(dbContext) { }

        public void Create(FridgeModel model) => Create(model);

        public IEnumerable<FridgeModel> GetAll(bool trackChanges) =>
            GetAll(trackChanges).OrderBy(fm => fm.Name);

        public FridgeModel GetById(Guid id, bool trackChanges) =>
            GetByCondition(fm => fm.Id.Equals(id), trackChanges).SingleOrDefault();

        public void Delete(FridgeModel model) => Delete(model);
    }
}
