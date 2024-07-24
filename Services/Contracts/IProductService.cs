using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities.Models;
using Entities.Dtos;

namespace Services.Contracts
{
    public interface IProductService
    {
        IEnumerable<Product> GetAllProducts(bool trackChanges);
        Product? GetSelectedProduct(int id, bool trackChanges);
        void CreateNewProduct(ProductDtoForInsertion productDto);
        void UpdateSelectedProduct(ProductDtoForUpdate productDto);
        void DeleteSelectedProduct(int id);
        ProductDtoForUpdate? GetSelectedProductForUpdate(int id, bool trackChanges);
    }
}