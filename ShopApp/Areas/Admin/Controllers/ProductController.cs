using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities.Dtos;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
            ViewBag.Categories = new SelectList(_manager.CategoryService.GetAllCategories(false), "CategoryId", "CategoryName", "1");

            return View();
        }

        private SelectList GetCategoriesSelectList()
        {
            return new SelectList(_manager.CategoryService.GetAllCategories(false), "CategoryId", "CategoryName", "1");
        }

        [Area("Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([FromForm] ProductDtoForInsertion productDto)
        {
            if (ModelState.IsValid)
            {
                _manager.ProductService.CreateNewProduct(productDto);

                return RedirectToAction("Index");
            }

            return View();
        }

        [Area("Admin")]
        public IActionResult Update([FromRoute(Name = "id")] int id)
        {
            ViewBag.Categories = GetCategoriesSelectList();
            var model = _manager.ProductService.GetSelectedProductForUpdate(id, false);

            return View(model);
        }

        [Area("Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update([FromForm] ProductDtoForUpdate product)
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