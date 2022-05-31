using FridgeManager.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
