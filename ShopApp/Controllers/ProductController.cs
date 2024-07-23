using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Repositories;
using Entities.Models;
using Repositories.Contracts;

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

        private readonly IRepositoryManager _manager;

        public ProductController(IRepositoryManager manager)
        {
            _manager = manager;
        }

        public IActionResult Index()
        {
            /* Thanks to DI, I don't need these lines
            var context = new RepositoryContext(
                new DbContextOptionsBuilder<RepositoryContext>()
                .UseSqlite("Data Source = C:\\Users\\dogan\\MVC\\ProductDb.db")
                .Options
            );
            */

            var products = _manager.Product.GetAllProducts(false);

            return View(products);
        }

        public IActionResult Get(int id)
        {
            // Product product = _context.Products.First(p => p.ProductId.Equals(id));

            // return View(product);
            var model = _manager.Product.GetSelectedProduct(id, false);
            return View(model);
        }
    }
}