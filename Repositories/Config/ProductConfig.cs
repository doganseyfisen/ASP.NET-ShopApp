using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositories.Config
{
    public class ProductConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(product => product.ProductId);
            builder.Property(product => product.ProductName).IsRequired();
            builder.Property(product => product.ProductPrice).IsRequired();

            builder.HasData(
                new Product() { ProductId = 1, CategoryId = 1, ProductImageUrl = "/images/1.jpeg", ProductName = "GTA V", ProductPrice = 14.98m },
                new Product() { ProductId = 2, CategoryId = 1, ProductImageUrl = "/images/2.jpeg", ProductName = "The Witcher 3", ProductPrice = 29.99m },
                new Product() { ProductId = 3, CategoryId = 1, ProductImageUrl = "/images/3.jpeg", ProductName = "Celeste", ProductPrice = 10.49m },
                new Product() { ProductId = 4, CategoryId = 1, ProductImageUrl = "/images/4.jpeg", ProductName = "Paper, Please", ProductPrice = 9.99m },
                new Product() { ProductId = 5, CategoryId = 1, ProductImageUrl = "/images/5.jpeg", ProductName = "Don't Starve", ProductPrice = 3.29m },
                new Product() { ProductId = 6, CategoryId = 2, ProductImageUrl = "/images/6.jpeg", ProductName = "The Brothers Karamazov", ProductPrice = 19.95m },
                new Product() { ProductId = 7, CategoryId = 3, ProductImageUrl = "/images/7.jpeg", ProductName = "Lamy Fountain Pen", ProductPrice = 25.35m }
            );
        }
    }
}