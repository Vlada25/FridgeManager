using FridgeManager.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FridgeManager.Interfaces.Repositories
{
    public interface IFridgeRepository
    {
        IEnumerable<Fridge> GetAll(bool trackChanges);
        IEnumerable<Fridge> GetFridgesByModel(Guid modelId, bool trackChanges);
        IEnumerable<Fridge> SearchFridgesBySubstring(string substring, bool trackChanges);
        Fridge GetById(Guid id, bool trackChanges);
        int GetYearOfTheMostSpaciousFridge();
        void Create(Fridge model);
        void Delete(Fridge model);
    }
}
