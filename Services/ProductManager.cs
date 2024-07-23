using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities.Models;
using Repositories.Contracts;
using Services.Contracts;

namespace Services
{
    public class ProductManager : IProductService
    {
        // Dependency Injection (DI)
        private readonly IRepositoryManager _manager;

        public ProductManager(IRepositoryManager manager)
        {
            _manager = manager;
        }
        // end

        public IEnumerable<Product> GetAllProducts(bool trackChanges)
        {
            return _manager.Product.GetAllProducts(trackChanges);
        }

        public Product? GetSelectedProduct(int id, bool trackChanges)
        {
            var product = _manager.Product.GetSelectedProduct(id, trackChanges) ?? throw new Exception("Product not found.");

            return product;
        }
    }
}