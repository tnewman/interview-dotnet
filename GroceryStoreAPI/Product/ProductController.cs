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
        private ProductRepository productRepository;

        public ProductController(ProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        [HttpGet]
        public IEnumerable<Product> List()
        {
            return this.productRepository.List();
        }

        [HttpGet("{id}")]
        public ActionResult<Product> Get(int id)
        {
            Product product = this.productRepository.Get(id);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }
    }
}
