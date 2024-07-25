using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities.Models;

namespace Repositories.Contracts
{
    public interface IOrderRepository
    {
        IQueryable<Order> Orders { get; }

        Order? GetSelectedOrder(int id);

        void CompleteOrder(int id);

        void SaveOrder(Order order);

        int NumberOfInProgress { get; }
    }
}
