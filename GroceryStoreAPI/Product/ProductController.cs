using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace GroceryStoreAPI.Product
{
    public interface IProductController
    {
        IEnumerable<Product> List();

        ActionResult<Product> Get(int id);

        ActionResult<Product> Save([FromBody] Product product);
    }

    [Route("api/product")]
    [ApiController]
    public class ProductController : ControllerBase, IProductController
    {
        private IProductRepository productRepository;

        public ProductController(IProductRepository productRepository)
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

            return product;
        }

        [HttpPost]
        public ActionResult<Product> Save([FromBody] Product product)
        {
            Product savedProduct = this.productRepository.Save(product);

            return savedProduct;
        }
    }
}
