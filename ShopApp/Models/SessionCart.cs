using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Entities.Models;
using ShopApp.Infrastructure.Extensions;

namespace ShopApp.Models
{
    public class SessionCart : Cart
    {
        [JsonIgnore]
        public ISession? Session { get; set; }
    
        public static Cart GetCart(IServiceProvider services)
        {
            ISession? session = services.GetRequiredService<IHttpContextAccessor>().HttpContext?.Session;
            SessionCart cart = session?.GetJson<SessionCart>("cart") ?? new SessionCart();
            cart.Session = session;

            return cart;
        }

        public override void AddItemToCartLine(Product product, int quantity)
        {
            base.AddItemToCartLine(product, quantity);
            Session?.SetJson<SessionCart>("cart", this);
        }

        public override void EmptyCart()
        {
            base.EmptyCart();
            Session?.Remove("cart");
        }

        public override void RemoveCartLine(Product product)
        {
            base.RemoveCartLine(product);
            Session?.SetJson<SessionCart>("cart", this);
        }
    }
}