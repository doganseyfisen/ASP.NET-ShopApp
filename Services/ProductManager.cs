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

        public ProductDtoForUpdate GetSelectedProductForUpdate(int id, bool trackChanges)
        {
            var product = GetSelectedProduct(id, trackChanges);
            var productDto = _mapper.Map<ProductDtoForUpdate>(product);

            return productDto;
        }

        public IEnumerable<Product> GetShowcaseProducts(bool trackChanges)
        {
            var product = _manager.Product.GetShowcaseProducts(trackChanges);

            return product;
        }

        public void UpdateSelectedProduct(ProductDtoForUpdate productDto)
        {
            // var model = _manager.Product.GetSelectedProduct(productDto.ProductId, true);
            // model.ProductName = productDto.ProductName;
            // model.ProductPrice = productDto.ProductPrice;
            // model.CategoryId = productDto.CategoryId;

            var model = _mapper.Map<Product>(productDto);
            _manager.Product.UpdateSelectedProduct(model);
            _manager.Save();
        }
    }
}