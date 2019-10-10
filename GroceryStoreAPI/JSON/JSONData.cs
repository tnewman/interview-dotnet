using System.Collections.Generic;


namespace GroceryStoreAPI.JSON
{
    public class JSONData
    {
        public JSONData()
        {
            this.Customers = new List<Customer.Customer>();
            this.Orders = new List<Order.Order>();
            this.Products = new List<Product.Product>();
        }

        public IEnumerable<Customer.Customer> Customers { get; set; }

        public IEnumerable<Order.Order> Orders { get; set; }

        public IEnumerable<Product.Product> Products { get; set; }
    }
}
