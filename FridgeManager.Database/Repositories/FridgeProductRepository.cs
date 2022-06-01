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

        public void Create(FridgeProduct model) => CreateEntity(model);

        public IEnumerable<FridgeProduct> GetAll(bool trackChanges) =>
            GetAllEntities(trackChanges).Include(f => f.Fridge).Include(f => f.Product);

        public FridgeProduct GetById(Guid id, bool trackChanges) =>
            GetByCondition(fm => fm.Id.Equals(id), trackChanges)
            .Include(f => f.Fridge).Include(f => f.Product).SingleOrDefault();

        public void Delete(FridgeProduct model) => DeleteEntity(model);

        public void ChangeNullQuantity() =>
            dbContext.Database.ExecuteSqlRaw("EXECUTE dbo.ChangeNullQuantity");

        // TODO: Implement with the stored procedure
        public IEnumerable<FridgeProduct> GetProductsInFridge(Guid fridgeId, bool trackChanges)
        {
            var fridgeProducts = GetAllEntities(trackChanges).Include(f => f.Fridge).Include(f => f.Product).ToList();

            List<FridgeProduct> fpToReturn = new List<FridgeProduct>();

            foreach (var fridgeProduct in fridgeProducts.Where(fp => fp.FridgeId == fridgeId))
            {
                if (!fpToReturn.Select(fp => fp.ProductId).Contains(fridgeProduct.ProductId))
                {
                    fpToReturn.Add(fridgeProduct);
                }
                else
                {
                    int index = fpToReturn.Select(fp => fp.ProductId).ToList().IndexOf(fridgeProduct.ProductId);
                    fpToReturn[index].Quantity += fridgeProduct.Quantity;
                }
            }

            return fpToReturn;
        }

    }
}
