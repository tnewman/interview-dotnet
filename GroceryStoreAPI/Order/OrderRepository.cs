using GroceryStoreAPI.JSON;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GroceryStoreAPI.Order
{
    public interface IOrderRepository
    {
        IEnumerable<Order> List();

        Order Get(int id);

        IEnumerable<Order> GetByCustomer(int customerId);

        IEnumerable<Order> GetByDate(DateTime date);
    }

    public class OrderRepository : IOrderRepository
    {
        private IJSONDatabase jsonDatabase;

        public OrderRepository(IJSONDatabase jsonDatabase)
        {
            this.jsonDatabase = jsonDatabase;
        }

        public IEnumerable<Order> List()
        {
            return this.jsonDatabase.loadJSONData().Orders;
        }

        public Order Get(int id)
        {
            return this.jsonDatabase
                .loadJSONData()
                .Orders
                .Where(o => o.Id == id)
                .FirstOrDefault();
        }

        public IEnumerable<Order> GetByCustomer(int customerId)
        {
            return this.jsonDatabase
                .loadJSONData()
                .Orders
                .Where(o => o.CustomerId == customerId);
        }

        public IEnumerable<Order> GetByDate(DateTime date)
        {
            return this.jsonDatabase
                .loadJSONData()
                .Orders
                .Where(o => o.Date == date);
        }
    }
}
