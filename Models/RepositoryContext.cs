using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ShopApp.Models
{
    public class RepositoryContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public RepositoryContext(DbContextOptions<RepositoryContext> options) : base(options)
        {

        }

        public RepositoryContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Product>().HasData(
                new Product() { ProductId = 1, ProductName = "GTA V", ProductPrice = 14.98m },
                new Product() { ProductId = 2, ProductName = "The Witcher 3", ProductPrice = 29.99m },
                new Product() { ProductId = 3, ProductName = "Celeste", ProductPrice = 10.49m },
                new Product() { ProductId = 4, ProductName = "Paper, Please", ProductPrice = 9.99m },
                new Product() { ProductId = 5, ProductName = "Don't Starve", ProductPrice = 3.29m }
            );
        }
    }
}