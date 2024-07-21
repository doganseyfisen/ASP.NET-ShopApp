using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopApp.Models;

namespace ShopApp.Controllers
{
    public class ProductController : Controller
    {
        // Dependency Injection (DI) - start
        // Let's say I need RepositoryContext, so service handle this for me.
        private readonly RepositoryContext _context;

        public ProductController(RepositoryContext context)
        {
            _context = context;
        }
        // end

        public IActionResult Index()
        {
            /* Thanks to DI, I don't need these lines
            var context = new RepositoryContext(
                new DbContextOptionsBuilder<RepositoryContext>()
                .UseSqlite("Data Source = C:\\Users\\dogan\\MVC\\ProductDb.db")
                .Options
            );
            */

            var products = _context.Products.ToList();

            return View(products);
        }
    }
}