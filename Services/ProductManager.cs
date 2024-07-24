using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Entities.Dtos;
using Entities.Models;
using Repositories.Contracts;
using Services.Contracts;

namespace Services
{
    public class ProductManager : IProductService
    {
        // Dependency Injection (DI)
        private readonly IRepositoryManager _manager;

        private readonly IMapper _mapper;

        public ProductManager(IRepositoryManager manager, IMapper mapper)
        {
            _mapper = mapper;
            _manager = manager;
        }
        // end

        public void CreateNewProduct(ProductDtoForInsertion productDto)
        {   
            Product product = _mapper.Map<Product>(productDto);
            _manager.Product.Create(product);
            _manager.Save();
        }

        public void DeleteSelectedProduct(int id)
        {
            Product product = GetSelectedProduct(id, false);
            if (product is not null)
            {
                _manager.Product.DeleteSelectedProduct(product);
                _manager.Save();
            }
        }

        public IEnumerable<Product> GetAllProducts(bool trackChanges)
        {
            return _manager.Product.GetAllProducts(trackChanges);
        }

        public Product? GetSelectedProduct(int id, bool trackChanges)
        {
            var product = _manager.Product.GetSelectedProduct(id, trackChanges) ?? throw new Exception("Product not found.");

            return product;
        }

        public void UpdateSelectedProduct(Product product)
        {
            var model = _manager.Product.GetSelectedProduct(product.ProductId, true);
            model.ProductName = product.ProductName;
            model.ProductPrice = product.ProductPrice;
            _manager.Save();
        }
    }
}