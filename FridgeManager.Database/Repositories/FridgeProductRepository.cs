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
    public class FridgeProductRepository : BaseRepository<FridgeProduct>, IFridgeProductRepository
    {
        public FridgeProductRepository(FridgeManagerDbContext dbContext)
            : base(dbContext) { }

        public void Create(FridgeProduct model)
        {
            if (GetAllEntities(false).FirstOrDefault(fp => fp.FridgeId == model.FridgeId && fp.ProductId == model.ProductId) is not null)
            {
                throw new Exception("This product is alresdy exists in that fridge. You can update it.");
            }
            CreateEntity(model);
        }

        public IEnumerable<FridgeProduct> GetAll(bool trackChanges) =>
            GetAllEntities(trackChanges).Include(f => f.Fridge).Include(f => f.Product);

        public FridgeProduct GetById(Guid id, bool trackChanges) =>
            GetByCondition(fm => fm.Id.Equals(id), trackChanges)
            .Include(f => f.Fridge).Include(f => f.Product).SingleOrDefault();

        public void Delete(FridgeProduct model) => DeleteEntity(model);

        public void ChangeNullQuantity() =>
            dbContext.Database.ExecuteSqlRaw("EXECUTE dbo.ChangeNullQuantity");

        // TODO: Implement with the stored procedure
        public IEnumerable<FridgeProduct> GetProductsInFridge(Guid fridgeId, bool trackChanges) =>
            GetAllEntities(trackChanges).Where(fp => fp.FridgeId == fridgeId)
            .Include(f => f.Fridge).Include(f => f.Product).ToList();
    }
}
