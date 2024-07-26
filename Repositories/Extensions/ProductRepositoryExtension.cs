using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities.Models;

namespace Repositories.Extensions
{
    public static class ProductRepositoryExtension
    {
        public static IQueryable<Product> FilteredByCategoryId(
            this IQueryable<Product> products,
            int? categoryId
        )
        {
            if (categoryId is null)
            {
                return products;
            }
            else
            {
                return products.Where(prd => prd.CategoryId.Equals(categoryId));
            }
        }

        public static IQueryable<Product> FilteredBySearchTerm(
            this IQueryable<Product> products,
            string? searchTerm
        )
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                return products;
            }
            else
            {
                return products.Where(product =>
                    product.ProductName.ToLower().Contains(searchTerm.ToLower())
                );
            }
        }

        public static IQueryable<Product> FilteredByPrice(
            this IQueryable<Product> products,
            int? MinPrice,
            int? MaxPrice,
            bool isValidPrice
        )
        {
            if (isValidPrice)
            {
                return products.Where(prd =>
                    prd.ProductPrice >= MinPrice && prd.ProductPrice <= MaxPrice
                );
            }
            else
            {
                return products;
            }
        }

        public static IQueryable<Product> ToPaginate(
            this IQueryable<Product> products,
            int pageNumber,
            int pageSize
        )
        {
            return products.Skip(((pageNumber - 1) * pageSize)).Take(pageSize);
        }
    }
}
