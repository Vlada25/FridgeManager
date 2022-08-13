﻿using FridgeManager.Domain.Models;
using FridgeManager.Interfaces.Repositories;

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
            GetByCondition(u => u.UserName.Equals(login), trackChanges).SingleOrDefault();

        public void Delete(User model) => DeleteEntity(model);
    }
}
