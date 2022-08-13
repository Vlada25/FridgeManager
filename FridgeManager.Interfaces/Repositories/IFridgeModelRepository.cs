using FridgeManager.Domain.Models;

namespace FridgeManager.Interfaces.Repositories
{
    public interface IFridgeModelRepository
    {
        IEnumerable<FridgeModel> GetAll(bool trackChanges);
        FridgeModel GetById(Guid id, bool trackChanges);
        void Create(FridgeModel model);
        void Delete(FridgeModel model);
    }
}
