using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GroceryStoreAPI.JSON;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GroceryStoreAPI.Product
{
    [Route("api/product")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private JSONDatabase jsonDatabase;

        public ProductController(JSONDatabase jsonDatabase)
        {
            this.jsonDatabase = jsonDatabase;
        }

        [HttpGet]
        public IEnumerable<Product> List()
        {
            return this.jsonDatabase.loadJSONData().Products;
        }

        [HttpGet("{id}")]
        public ActionResult<Product> Get(int id)
        {
            Product product = this.jsonDatabase
                .loadJSONData()
                .Products
                .Where(p => p.Id == id)
                .FirstOrDefault();

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }
    }
}
