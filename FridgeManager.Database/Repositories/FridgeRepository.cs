﻿using FridgeManager.Domain;
using FridgeManager.Domain.Models;
using FridgeManager.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FridgeManager.Database.Repositories
{
    public class FridgeRepository : BaseRepository<Fridge>, IFridgeRepository
    {
        public FridgeRepository(FridgeManagerDbContext dbContext)
            : base(dbContext) { }

        public void Create(Fridge model) => Create(model);

        public IEnumerable<Fridge> GetAll(bool trackChanges) =>
            GetAll(trackChanges);

        public Fridge GetById(Guid id, bool trackChanges) =>
            GetByCondition(f => f.Id.Equals(id), trackChanges).SingleOrDefault();

        public void Delete(Fridge model) => Delete(model);
    }
}
