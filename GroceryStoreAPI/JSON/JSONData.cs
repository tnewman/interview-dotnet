using System.Collections.Generic;


namespace GroceryStoreAPI.JSON
{
    public class JSONData
    {
        public JSONData()
        {
            this.Customers = new List<CustomerTest.Customer>();
            this.Orders = new List<OrderTest.Order>();
            this.Products = new List<ProductTest.Product>();
        }

        public IEnumerable<CustomerTest.Customer> Customers { get; set; }

        public IEnumerable<OrderTest.Order> Orders { get; set; }

        public IEnumerable<ProductTest.Product> Products { get; set; }
    }
}
