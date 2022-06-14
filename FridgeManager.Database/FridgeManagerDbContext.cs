using FridgeManager.Domain.Configuration;
using FridgeManager.Domain.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FridgeManager.Database
{
    public class FridgeManagerDbContext : IdentityDbContext<User>
    {
        public FridgeManagerDbContext(DbContextOptions options)
            : base(options) { }

        public DbSet<Fridge> Fridges { get; set; }
        public DbSet<FridgeProduct> FridgeProducts { get; set; }
        public DbSet<FridgeModel> FridgeModels { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new FridgeModelConfig());
            modelBuilder.ApplyConfiguration(new FridgeConfig());
            modelBuilder.ApplyConfiguration(new ProductConfig());
            modelBuilder.ApplyConfiguration(new FridgeProductConfig());
            modelBuilder.ApplyConfiguration(new RoleConfig());
        }
    }
}
