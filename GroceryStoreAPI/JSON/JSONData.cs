using GroceryStoreAPI.Customer;
using GroceryStoreAPI.Order;
using GroceryStoreAPI.Product;
using Newtonsoft.Json;
using System.Collections.Generic;


namespace GroceryStoreAPI.JSON
{
    public class JSONData
    {
        [JsonProperty("customers")]
        public List<Customer.Customer> Customers { get; set; }

        [JsonProperty("orders")]
        public List<Order.Order> Orders { get; set; }

        [JsonProperty("products")]
        public List<Product.Product> Products { get; set; }
    }
}
