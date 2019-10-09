using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroceryStoreAPI.Order
{
    public class Order
    {
        public DateTime Date { get; set; }

        public int Id { get; set; }

        public int CustomerId { get; set; }

        public List<Item> Items { get; set; }
    }
}
