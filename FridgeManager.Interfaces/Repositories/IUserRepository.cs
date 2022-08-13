using FridgeManager.Domain.Models;

namespace FridgeManager.Interfaces.Repositories
{
    public interface IUserRepository
    {
        IEnumerable<User> GetAll(bool trackChanges);
        User GetById(Guid id, bool trackChanges);
        User GetByLogin(string login, bool trackChanges);
        void Create(User model);
        void Delete(User model);
    }
}
