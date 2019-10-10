using GroceryStoreAPI.JSON;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroceryStoreAPI.Customer
{
    public class CustomerRepository
    {
        private JSONDatabase jsonDatabase;

        public CustomerRepository(JSONDatabase jsonDatabase)
        {
            this.jsonDatabase = jsonDatabase;
        }

        public IEnumerable<Customer> List()
        {
            return this.jsonDatabase.loadJSONData().Customers;
        }

        public Customer Get(int id)
        {
            return this.jsonDatabase
                .loadJSONData()
                .Customers
                .Where(c => c.Id == id)
                .FirstOrDefault();
        }
    }
}
