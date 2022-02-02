using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CompDevices.Domain.Entities;
using System.Data.Entity;

namespace CompDevices.Domain.Concrete
{
    public class EFDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductAttribute> ProductAttributes { get; set; }
        public DbSet<AttributeValue> AttributeValues { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().ToTable("Products");
            modelBuilder.Entity<ProductAttribute>().ToTable("ProductAttributes");
            modelBuilder.Entity<AttributeValue>().ToTable("AttributeValues");

            base.OnModelCreating(modelBuilder);
        }
    }
}
