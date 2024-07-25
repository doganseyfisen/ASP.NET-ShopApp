using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities.Models;
using Repositories.Contracts;
using Services.Contracts;

namespace Services
{
    public class OrderManager : IOrderService
    {
        private readonly IRepositoryManager _manager;

        public OrderManager(IRepositoryManager manager)
        {
            _manager = manager;
        }

        public IQueryable<Order> Orders => _manager.Order.Orders;

        public int NumberOfInProgress => _manager.Order.NumberOfInProgress;

        public void CompleteOrder(int id)
        {
            _manager.Order.CompleteOrder(id);
            _manager.Save();
        }

        public Order? GetSelectedOrder(int id)
        {
            return _manager.Order.GetSelectedOrder(id);
        }

        public void SaveOrder(Order order)
        {
            _manager.Order.SaveOrder(order);
        }
    }
}
