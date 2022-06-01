using FridgeManager.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FridgeManager.Domain.Configuration
{
    public class FridgeConfig : IEntityTypeConfiguration<Fridge>
    {
        public void Configure(EntityTypeBuilder<Fridge> builder)
        {
            builder.HasData(DbInitializer.Fridges);
        }
    }
}
