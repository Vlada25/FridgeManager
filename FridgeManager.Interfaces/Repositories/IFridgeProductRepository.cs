using FridgeManager.Domain.Models;
using FridgeManager.DTO.Fridge;

namespace FridgeManager.Interfaces.Repositories
{
    public interface IFridgeProductRepository
    {
        IEnumerable<FridgeProduct> GetAll(bool trackChanges);
        FridgeProduct GetById(Guid id, bool trackChanges);
        void Create(FridgeProduct model);
        void Delete(FridgeProduct model);
        void ChangeNullQuantity();
        IEnumerable<FridgeProduct> GetProductsInFridge(Guid fridgeId, bool trackChanges);
        IEnumerable<FridgeWithCountOfProductsDto> GetFridgesAndCountOfProducts(IEnumerable<Fridge> fridges);
    }
}
