using FridgeManager.Domain;
using FridgeManager.Domain.Models.Authorization;
using FridgeManager.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FridgeManager.Database.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(FridgeManagerDbContext dbContext)
            : base(dbContext) { }

        public void Create(User model) => CreateEntity(model);

        public IEnumerable<User> GetAll(bool trackChanges) =>
            GetAllEntities(trackChanges);

        public User GetById(Guid id, bool trackChanges) =>
            GetByCondition(u => u.Id.Equals(id), trackChanges).SingleOrDefault();

        public User GetByLogin(string login, bool trackChanges) =>
            GetByCondition(u => u.Login.Equals(login), trackChanges).SingleOrDefault();

        public void Delete(User model) => DeleteEntity(model);
    }
}
