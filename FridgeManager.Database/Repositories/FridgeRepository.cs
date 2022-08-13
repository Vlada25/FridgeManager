using FridgeManager.Domain.Models;
using FridgeManager.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FridgeManager.Database.Repositories
{
    public class FridgeRepository : BaseRepository<Fridge>, IFridgeRepository
    {
        public FridgeRepository(FridgeManagerDbContext dbContext)
            : base(dbContext) { }

        public void Create(Fridge model) => CreateEntity(model);

        public IEnumerable<Fridge> GetAll(bool trackChanges) =>
            GetAllEntities(trackChanges).Include(f => f.Model).OrderBy(f => f.Name);

        public Fridge GetById(Guid id, bool trackChanges) =>
            GetByCondition(f => f.Id.Equals(id), trackChanges).Include(f => f.Model).SingleOrDefault();

        public IEnumerable<Fridge> GetFridgesByModel(Guid modelId, bool trackChanges) =>
            GetByCondition(f => f.ModelId.Equals(modelId), trackChanges)
                .Include(f => f.Model).OrderBy(e => e.Name);

        public void Delete(Fridge model) => DeleteEntity(model);

        public int GetYearOfTheMostSpaciousFridge()
        {
            var param = new Microsoft.Data.SqlClient.SqlParameter
            {
                ParameterName = "@year",
                SqlDbType = System.Data.SqlDbType.Int,
                Direction = System.Data.ParameterDirection.Output,
                Size = 50
            };
            return (int)ExecuteScalar("dbo.YearOfTheMostSpaciousFridge @year OUT", param);
        }

        public IEnumerable<Fridge> SearchFridgesBySubstring(string substring, bool trackChanges) =>
            GetAllEntities(trackChanges).Where(f => f.Name.Contains(substring))
            .Include(f => f.Model).OrderBy(f => f.Name);

        public string GetFridgeWhichContainsTheMostKindsOfProducts()
        {
            var param = new Microsoft.Data.SqlClient.SqlParameter
            {
                ParameterName = "@outStr",
                SqlDbType = System.Data.SqlDbType.NVarChar,
                Direction = System.Data.ParameterDirection.Output,
                Size = 200
            };
            return (string)ExecuteScalar("dbo.FridgeWhichContainsTheMostKindsOfProducts @outStr OUT", param);
        }
    }
}
