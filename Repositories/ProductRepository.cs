using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities.Models;
using Repositories.Contracts;

namespace Repositories
{
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(RepositoryContext context) : base(context)
        {

        }

        public void CreateNewProduct(Product product) => Create(product); // RepositoryBase

        public void UpdateSelectedProduct(Product entity) => Update(entity);

        public void DeleteSelectedProduct(Product product) => Remove(product);

        public IQueryable<Product> GetAllProducts(bool trackChanges) => FindAll(trackChanges);

        public Product? GetSelectedProduct(int id, bool trackChanges)
        {
            return FindByCondition(product => product.ProductId.Equals(id), trackChanges);
        }
    }
}