using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Cart
    {
        public List<CartLine> Lines { get; set; }

        public Cart()
        {
            Lines = new List<CartLine>();
        }

        public virtual void AddItemToCartLine(Product product, int quantity)
        {
            CartLine? line = Lines.Where(line => line.Product.ProductId.Equals(product.ProductId)).FirstOrDefault();

            if (line is null)
            {
                Lines.Add(new CartLine()
                {
                    Product = product,
                    Quantity = quantity
                });
            }
            else
            {
                line.Quantity += quantity;
            }
        }

        public virtual void RemoveCartLine(Product product) => Lines.RemoveAll(line => line.Product.ProductId.Equals(product.ProductId));

        public decimal CalculateTotalCartValue() => Lines.Sum(entity => entity.Product.ProductPrice * entity.Quantity);

        public virtual void EmptyCart() => Lines.Clear();
    }
}