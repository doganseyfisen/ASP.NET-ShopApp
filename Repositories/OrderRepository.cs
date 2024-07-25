using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;

namespace Repositories
{
    public class OrderRepository : RepositoryBase<Order>, IOrderRepository
    {
        public OrderRepository(RepositoryContext context)
            : base(context) { }

        public IQueryable<Order> Orders =>
            _context
                .Orders.Include(order => order.Lines)
                .ThenInclude(cartLine => cartLine.Product)
                .OrderBy(order => order.OrderShipped)
                .ThenByDescending(order => order.OrderId);

        public int NumberOfInProgress =>
            _context.Orders.Count(order => order.OrderShipped.Equals(false));

        public void CompleteOrder(int id)
        {
            var order = FindByCondition(order => order.OrderId.Equals(id), true);

            if (order is null)
            {
                throw new Exception("Order not found.");
            }
            order.OrderShipped = true;
        }

        public Order? GetSelectedOrder(int id)
        {
            return FindByCondition(order => order.OrderId.Equals(id), false);
        }

        public void SaveOrder(Order order)
        {
            _context.AttachRange(order.Lines.Select(line => line.Product));

            if (order.OrderId == 0)
            {
                _context.Orders.Add(order);
            }
            _context.SaveChanges();
        }
    }
}
