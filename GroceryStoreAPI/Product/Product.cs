using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace GroceryStoreAPI.Product
{
    public class Product
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public decimal Price { get; set; }
    }
}
