using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace GroceryStoreAPI.CustomerTest
{
    public class Customer
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
