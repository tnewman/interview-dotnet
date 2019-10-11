using GroceryStoreAPI.JSON;
using System.Collections.Generic;
using System.Linq;

namespace GroceryStoreAPI.Customer
{
    public interface ICustomerRepository
    {
        IEnumerable<Customer> List();

        Customer Get(int id);

        Customer Save(Customer customer);
    }

    public class CustomerRepository : ICustomerRepository
    {
        private IJSONDatabase jsonDatabase;

        public CustomerRepository(IJSONDatabase jsonDatabase)
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

        public Customer Save(Customer customer)
        {
            JSONData jsonData = this.jsonDatabase.loadJSONData();
            jsonData.Customers = jsonData.Customers.Where(c => c.Id != customer.Id);

            // Upsert the Customer
            jsonData.Customers.Append(customer);

            this.jsonDatabase.saveJSONData(jsonData);

            return customer;
        }
    }
}
