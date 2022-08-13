using FridgeManager.Domain.Models;

namespace FridgeManager.Interfaces.Repositories
{
    public interface IFridgeRepository
    {
        IEnumerable<Fridge> GetAll(bool trackChanges);
        IEnumerable<Fridge> GetFridgesByModel(Guid modelId, bool trackChanges);
        IEnumerable<Fridge> SearchFridgesBySubstring(string substring, bool trackChanges);
        Fridge GetById(Guid id, bool trackChanges);
        int GetYearOfTheMostSpaciousFridge();
        string GetFridgeWhichContainsTheMostKindsOfProducts();
        void Create(Fridge model);
        void Delete(Fridge model);
    }
}
