using FridgeManager.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FridgeManager.Interfaces
{
    public interface IRepositoryManager
    {
        IFridgeModelRepository FridgeModelRepository { get; }
        IFridgeRepository FridgeRepository { get; }
        IProductRepository ProductRepository { get; }
        IFridgeProductRepository FridgeProductRepository { get; }
        IUserRepository UserRepository { get; }

        void Save();
    }
}
