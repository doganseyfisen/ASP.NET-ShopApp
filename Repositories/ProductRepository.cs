using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities.Models;
using Entities.RequestParameters;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;

namespace Repositories
{
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(RepositoryContext context)
            : base(context) { }

        public void CreateNewProduct(Product product) => Create(product); // RepositoryBase

        public void UpdateSelectedProduct(Product entity) => Update(entity);

        public void DeleteSelectedProduct(Product product) => Remove(product);

        public IQueryable<Product> GetAllProducts(bool trackChanges) => FindAll(trackChanges);

        public Product? GetSelectedProduct(int id, bool trackChanges)
        {
            return FindByCondition(product => product.ProductId.Equals(id), trackChanges);
        }

        public IQueryable<Product> GetShowcaseProducts(bool trackChanges)
        {
            return FindAll(trackChanges).Where(product => product.ShowCase.Equals(true));
        }

        public IQueryable<Product> GetAllProductsWithDetails(ProductRequestParameters product)
        {
            return product.CategoryId is null
                ? _context.Products.Include(p => p.Category)
                : _context
                    .Products.Include(p => p.Category)
                    .Where(p => p.CategoryId.Equals(p.CategoryId));
        }
    }
}
