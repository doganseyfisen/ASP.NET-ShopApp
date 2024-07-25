using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services.Contracts;
using ShopApp.Infrastructure.Extensions;

namespace ShopApp.Pages
{
    public class CartModel : PageModel
    {
        private readonly IServiceManager _manager;
        
        public Cart Cart { get; set; }

        public CartModel(IServiceManager manager)
        {
            _manager = manager;
        }

        public string ReturnUrl { get; set; } = "/";

        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";
            Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
        }

        public IActionResult OnPost(int productId, string returnUrl)
        {
            Product? product = _manager.ProductService.GetSelectedProduct(productId, false);

            if (product is not null)
            {
                // Check Cart object from Session, if it's not existing create new
                Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
                // Add item to product
                Cart.AddItemToCartLine(product, 1);
                // Then write info to a Session
                HttpContext.Session.SetJson<Cart>("cart", Cart);
            }

            return Page();
        }

        public IActionResult OnPostRemove(int id, string returnUrl)
        {
            Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
            Cart.RemoveCartLine(Cart.Lines.First(cl => cl.Product.ProductId.Equals(id)).Product);
            HttpContext.Session.SetJson<Cart>("cart", Cart);

            return Page();
        }
    }
}