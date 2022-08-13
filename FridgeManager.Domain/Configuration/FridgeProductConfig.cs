using FridgeManager.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FridgeManager.Domain.Configuration
{
    public class FridgeProductConfig : IEntityTypeConfiguration<FridgeProduct>
    {
        public void Configure(EntityTypeBuilder<FridgeProduct> builder)
        {
            builder.HasData(DbInitializer.FridgeProducts);
        }
    }
}
