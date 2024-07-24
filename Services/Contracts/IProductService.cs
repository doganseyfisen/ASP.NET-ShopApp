using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities.Models;

namespace Services.Contracts
{
    public interface IProductService
    {
        IEnumerable<Product> GetAllProducts(bool trackChanges);
        Product? GetSelectedProduct(int id, bool trackChanges);
        void CreateNewProduct(Product product);
        void UpdateSelectedProduct(Product product);
        void DeleteSelectedProduct(int id);
    }
}