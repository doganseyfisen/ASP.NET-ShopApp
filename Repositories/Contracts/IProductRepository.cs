using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities.Models;

namespace Repositories.Contracts
{
    public interface IProductRepository : IRepositoryBase<Product>
    {
        IQueryable<Product> GetAllProducts(bool trackChanges);

        Product? GetSelectedProduct(int id, bool trackChanges);

        IQueryable<Product> GetShowcaseProducts(bool trackChanges);

        void CreateNewProduct(Product product);

        void UpdateSelectedProduct(Product product);

        void DeleteSelectedProduct(Product product);
    }
}
