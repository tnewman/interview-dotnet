using System.Collections.Generic;


namespace GroceryStoreAPI.JSON
{
    public class JSONData
    {
        public IEnumerable<Customer.Customer> Customers { get; set; }

        public IEnumerable<Order.Order> Orders { get; set; }

        public IEnumerable<Product.Product> Products { get; set; }
    }
}
