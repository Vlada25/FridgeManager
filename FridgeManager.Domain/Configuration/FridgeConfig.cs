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
            builder.HasData
            (
                new Fridge
                {
                    Id = new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"),
                    Name = "Atlant",
                    OwnerName = "Vlada",
                    ModelId = new Guid("80abbca8-664d-4b20-b5de-024705497d4a"),
                },

                new Fridge
                {
                    Id = new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"),
                    Name = "Phylips",
                    OwnerName = "Anna",
                    ModelId = new Guid("86dba8c0-d178-41e7-938c-ed49778fb52a"),
                },

                new Fridge
                {
                    Id = new Guid("02ed6fb1-a1dd-4c14-8e2a-1f36558877f7"),
                    Name = "Samsung",
                    OwnerName = "Andrew",
                    ModelId = new Guid("047a52f9-d94d-4358-ab3f-ee429221be4b"),
                },

                new Fridge
                {
                    Id = new Guid("5b954203-ce83-4d81-9635-fde5cea9170e"),
                    Name = "Phylips",
                    OwnerName = "Polyna",
                    ModelId = new Guid("80abbca8-664d-4b20-b5de-024705497d4a"),
                },

                new Fridge
                {
                    Id = new Guid("42498fda-616c-47bd-b045-b98cbab20d0c"),
                    Name = "Stinol",
                    OwnerName = "Nastya",
                    ModelId = new Guid("047a52f9-d94d-4358-ab3f-ee429221be4b"),
                }
            );
        }
    }
}
