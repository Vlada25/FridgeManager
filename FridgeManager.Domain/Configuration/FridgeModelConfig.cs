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
    public class FridgeModelConfig : IEntityTypeConfiguration<FridgeModel>
    {
        public void Configure(EntityTypeBuilder<FridgeModel> builder)
        {
            builder.HasData
            (
                new FridgeModel
                {
                    Id = new Guid("80abbca8-664d-4b20-b5de-024705497d4a"),
                    Name = "TH-803",
                    Year = 2011
                },

                new FridgeModel
                {
                    Id = new Guid("86dba8c0-d178-41e7-938c-ed49778fb52a"),
                    Name = "514-NWE",
                    Year = 2017
                },

                new FridgeModel
                {
                    Id = new Guid("047a52f9-d94d-4358-ab3f-ee429221be4b"),
                    Name = "RC-55",
                    Year = 2015
                }
            );
        }
    }
}
