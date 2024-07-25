using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities.Models;
using Entities.RequestParameters;

namespace Repositories.Contracts
{
    public interface IProductRepository : IRepositoryBase<Product>
    {
        IQueryable<Product> GetAllProducts(bool trackChanges);

        IQueryable<Product> GetAllProductsWithDetails(ProductRequestParameters product);

        Product? GetSelectedProduct(int id, bool trackChanges);

        IQueryable<Product> GetShowcaseProducts(bool trackChanges);

        void CreateNewProduct(Product product);

        void UpdateSelectedProduct(Product product);

        void DeleteSelectedProduct(Product product);
    }
}
