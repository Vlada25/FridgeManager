using FridgeManager.Domain.Models.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
