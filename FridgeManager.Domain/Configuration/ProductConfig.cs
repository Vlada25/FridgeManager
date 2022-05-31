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
    public class ProductConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData
            (
                new Product
                {
                    Id = new Guid("1da4a8a8-5ff8-4cb5-81a7-a9fe895046c5"),
                    Name = "Bread",
                    DefaultQuantity = 2
                },

                new Product
                {
                    Id = new Guid("d59a38ab-358a-4177-94c9-72f09f33fb32"),
                    Name = "Apple",
                    DefaultQuantity = 7
                },

                new Product
                {
                    Id = new Guid("fce56e5f-6719-4b19-a00e-0ab6ad0630b8"),
                    Name = "Yoghurt",
                    DefaultQuantity = 3
                },

                new Product
                {
                    Id = new Guid("2e142de1-cd70-4f27-b982-107eae517d15"),
                    Name = "Egg",
                    DefaultQuantity = 10
                },
                new Product
                {
                    Id = new Guid("14a7eff5-ea22-4116-ba12-0dd5fc5a6577"),
                    Name = "Cheese",
                    DefaultQuantity = 1
                },

                new Product
                {
                    Id = new Guid("40c30251-dbad-4078-8cae-db75cd69dfd0"),
                    Name = "Mashroom",
                    DefaultQuantity = 25
                },

                new Product
                {
                    Id = new Guid("0721b09e-4265-48b7-ac3a-fa83dd5b0748"),
                    Name = "Chicken leg",
                    DefaultQuantity = 4
                }
            );
        }
    }
}
