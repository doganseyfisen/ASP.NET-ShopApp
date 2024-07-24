using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace ShopApp.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
        private readonly IServiceManager _manager;

        public ProductController(IServiceManager manager)
        {
            _manager = manager;
        }

        [Area("Admin")]
        public IActionResult Index()
        {
            var model = _manager.ProductService.GetAllProducts(false);

            return View(model);
        }

        [Area("Admin")]
        public IActionResult Create()
        {
            return View();
        }

        [Area("Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([FromForm] Product product)
        {
            if (ModelState.IsValid)
            {
                _manager.ProductService.CreateNewProduct(product);
                return RedirectToAction("Index");
            }

            return View();
        }

        [Area("Admin")]
        public IActionResult Update([FromRoute(Name = "id")] int id)
        {
            var model = _manager.ProductService.GetSelectedProduct(id, false);

            return View(model);
        }

        [Area("Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(Product product)
        {
            if (ModelState.IsValid)
            {
                _manager.ProductService.UpdateSelectedProduct(product);
                return RedirectToAction("Index");
            }

            return View();
        }

        [Area("Admin")]
        public IActionResult Delete([FromRoute(Name = "id")] int id)
        {
            _manager.ProductService.DeleteSelectedProduct(id);

            return RedirectToAction("Index");
        }
    }
}