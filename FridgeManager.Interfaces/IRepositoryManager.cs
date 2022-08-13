using FridgeManager.Interfaces.Repositories;

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
