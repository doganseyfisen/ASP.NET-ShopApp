using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services.Contracts;

namespace ShopApp.Pages
{
    public class CartModel : PageModel
    {
        private readonly IServiceManager _manager;
        
        public Cart Cart { get; set; }

        public CartModel(IServiceManager manager, Cart cart)
        {
            _manager = manager;
            Cart = cart;
        }


        public string ReturnUrl { get; set; } = "/";

        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";
        }

        public IActionResult OnPost(int productId, string returnUrl)
        {
            Product? product = _manager.ProductService.GetSelectedProduct(productId, false);

            if (product is not null)
            {
                Cart.AddItemToCartLine(product, 1);
            }

            return Page();
        }

        public IActionResult OnPostRemove(int id, string returnUrl)
        {
            Cart.RemoveCartLine(Cart.Lines.First(cl => cl.Product.ProductId.Equals(id)).Product);

            return Page();
        }
    }
}