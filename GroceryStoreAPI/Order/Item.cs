using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace GroceryStoreAPI.OrderTest
{
    public class Item
    {
        [Required]
        public int ProductId { get; set; }

        [Required]
        public int Quantity { get; set; }
    }
}
