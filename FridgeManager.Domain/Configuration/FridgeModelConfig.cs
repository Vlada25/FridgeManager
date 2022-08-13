using FridgeManager.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FridgeManager.Domain.Configuration
{
    public class FridgeModelConfig : IEntityTypeConfiguration<FridgeModel>
    {
        public void Configure(EntityTypeBuilder<FridgeModel> builder)
        {
            builder.HasData(DbInitializer.FridgeModels);
        }
    }
}
