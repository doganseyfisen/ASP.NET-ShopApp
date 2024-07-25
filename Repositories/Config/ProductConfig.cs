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
                new Product()
                {
                    ProductId = 1,
                    CategoryId = 1,
                    ProductImageUrl = "/images/1.jpg",
                    ProductName = "GTA V",
                    ProductPrice = 14.98m,
                    ShowCase = false
                },
                new Product()
                {
                    ProductId = 2,
                    CategoryId = 1,
                    ProductImageUrl = "/images/2.jpg",
                    ProductName = "The Witcher 3",
                    ProductPrice = 29.99m,
                    ShowCase = false
                },
                new Product()
                {
                    ProductId = 3,
                    CategoryId = 1,
                    ProductImageUrl = "/images/3.jpg",
                    ProductName = "Celeste",
                    ProductPrice = 10.49m,
                    ShowCase = false
                },
                new Product()
                {
                    ProductId = 4,
                    CategoryId = 1,
                    ProductImageUrl = "/images/4.jpg",
                    ProductName = "Paper, Please",
                    ProductPrice = 9.99m,
                    ShowCase = false
                },
                new Product()
                {
                    ProductId = 5,
                    CategoryId = 1,
                    ProductImageUrl = "/images/5.jpg",
                    ProductName = "Don't Starve",
                    ProductPrice = 3.29m,
                    ShowCase = false
                },
                new Product()
                {
                    ProductId = 6,
                    CategoryId = 2,
                    ProductImageUrl = "/images/6.jpg",
                    ProductName = "The Brothers Karamazov",
                    ProductPrice = 19.95m,
                    ShowCase = false
                },
                new Product()
                {
                    ProductId = 7,
                    CategoryId = 3,
                    ProductImageUrl = "/images/7.jpg",
                    ProductName = "Lamy Fountain Pen",
                    ProductPrice = 25.35m,
                    ShowCase = false
                },
                new Product()
                {
                    ProductId = 8,
                    CategoryId = 1,
                    ProductImageUrl = "/images/5.jpg",
                    ProductName = "Don't Starve",
                    ProductPrice = 1.67m,
                    ShowCase = true
                },
                new Product()
                {
                    ProductId = 9,
                    CategoryId = 2,
                    ProductImageUrl = "/images/6.jpg",
                    ProductName = "The Brothers Karamazov",
                    ProductPrice = 17.42m,
                    ShowCase = true
                },
                new Product()
                {
                    ProductId = 10,
                    CategoryId = 3,
                    ProductImageUrl = "/images/7.jpg",
                    ProductName = "Lamy Fountain Pen",
                    ProductPrice = 34.35m,
                    ShowCase = true
                }
            );
        }
    }
}
