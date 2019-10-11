using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GroceryStoreAPI.Order
{
    public class Order
    {
        [Required]
        public DateTime Date { get; set; }

        [Required]
        public int Id { get; set; }

        [Required]
        public int CustomerId { get; set; }

        [Required]
        public IEnumerable<Item> Items { get; set; }
    }
}
