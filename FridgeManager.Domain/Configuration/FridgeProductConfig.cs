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
    public class FridgeProductConfig : IEntityTypeConfiguration<FridgeProduct>
    {
        public void Configure(EntityTypeBuilder<FridgeProduct> builder)
        {
            builder.HasData
            (
                new FridgeProduct
                {
                    Id = new Guid("cb74712d-d2a3-4270-b633-360b121363ec"),
                    FridgeId = new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"),
                    ProductId = new Guid("d59a38ab-358a-4177-94c9-72f09f33fb32"),
                    Quantity = 5
                },

                new FridgeProduct
                {
                    Id = new Guid("7951fcbc-62dc-4138-81e4-0cac5c2b7e60"),
                    FridgeId = new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"),
                    ProductId = new Guid("fce56e5f-6719-4b19-a00e-0ab6ad0630b8"),
                    Quantity = 0
                },

                new FridgeProduct
                {
                    Id = new Guid("1a4f8023-1df7-4d41-8c7b-ae5c7b54f7f0"),
                    FridgeId = new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"),
                    ProductId = new Guid("40c30251-dbad-4078-8cae-db75cd69dfd0"),
                    Quantity = 25
                },

                new FridgeProduct
                {
                    Id = new Guid("50b08830-599e-42a9-a587-7d60b0611283"),
                    FridgeId = new Guid("5b954203-ce83-4d81-9635-fde5cea9170e"),
                    ProductId = new Guid("d59a38ab-358a-4177-94c9-72f09f33fb32"),
                    Quantity = 3
                },

                new FridgeProduct
                {
                    Id = new Guid("c51647bf-9f3b-48e6-a4dc-0396b5a5a869"),
                    FridgeId = new Guid("02ed6fb1-a1dd-4c14-8e2a-1f36558877f7"),
                    ProductId = new Guid("fce56e5f-6719-4b19-a00e-0ab6ad0630b8"),
                    Quantity = 7
                },

                new FridgeProduct
                {
                    Id = new Guid("49372f41-be0b-4c75-87bd-981f04bb1d16"),
                    FridgeId = new Guid("02ed6fb1-a1dd-4c14-8e2a-1f36558877f7"),
                    ProductId = new Guid("40c30251-dbad-4078-8cae-db75cd69dfd0"),
                    Quantity = 20
                },

                new FridgeProduct
                {
                    Id = new Guid("02ed6fb1-a1dd-4c14-8e2a-1f36558877f7"),
                    FridgeId = new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"),
                    ProductId = new Guid("d59a38ab-358a-4177-94c9-72f09f33fb32"),
                    Quantity = 17
                },

                new FridgeProduct
                {
                    Id = new Guid("659ae01a-3a5e-4fda-bc56-81f929b18232"),
                    FridgeId = new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"),
                    ProductId = new Guid("14a7eff5-ea22-4116-ba12-0dd5fc5a6577"),
                    Quantity = 1
                },

                new FridgeProduct
                {
                    Id = new Guid("42498fda-616c-47bd-b045-b98cbab20d0c"),
                    FridgeId = new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"),
                    ProductId = new Guid("1da4a8a8-5ff8-4cb5-81a7-a9fe895046c5"),
                    Quantity = 0
                }
            );
        }
    }
}
