using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities.Models;
using Entities.RequestParameters;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using ShopApp.Models;

namespace ShopApp.Controllers
{
    public class ProductController : Controller
    {
        // // Dependency Injection (DI) - start
        // // Let's say I need RepositoryContext, so service handle this for me.
        // private readonly RepositoryContext _context;

        // public ProductController(RepositoryContext context)
        // {
        //     _context = context;
        // }
        // // end

        private readonly IServiceManager _manager;

        public ProductController(IServiceManager manager)
        {
            _manager = manager;
        }

        public IActionResult Index(ProductRequestParameters product)
        {
            /* Thanks to DI, I don't need these lines
            var context = new RepositoryContext(
                new DbContextOptionsBuilder<RepositoryContext>()
                .UseSqlite("Data Source = C:\\Users\\dogan\\MVC\\ProductDb.db")
                .Options
            );
            */

            var model = _manager.ProductService.GetAllProductsWithDetails(product);
            var pagination = new Pagination()
            {
                CurrentPage = product.PageNumber,
                ItemsPerPage = product.PageSize,
                TotalItems = _manager.ProductService.GetAllProducts(false).Count()
            };

            return View(new ProductListViewModel() { Products = model, Pagination = pagination });
        }

        public IActionResult Get([FromRoute(Name = "id")] int id)
        {
            // Product product = _context.Products.First(p => p.ProductId.Equals(id));

            // return View(product);
            var product =
                _manager.ProductService.GetSelectedProduct(id, false)
                ?? throw new Exception("Product not found.");

            return View(product);
        }
    }
}
