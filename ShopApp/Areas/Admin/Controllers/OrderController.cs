using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Services.Contracts;

namespace ShopApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class OrderController : Controller
    {
        private readonly IServiceManager _manager;

        public OrderController(IServiceManager manager)
        {
            _manager = manager;
        }

        public IActionResult Index()
        {
            var orders = _manager.OrderService.Orders;

            return View(orders);
        }

        [HttpPost]
        public IActionResult CompleteOrder([FromForm] int id)
        {
            _manager.OrderService.CompleteOrder(id);

            return RedirectToAction("Index");
        }
    }
}
