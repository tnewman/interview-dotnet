using GroceryStoreAPI.JSON;
using System.Collections.Generic;
using System.Linq;

namespace GroceryStoreAPI.Product
{
    public interface IProductRepository
    {
        IEnumerable<Product> List();

        Product Get(int id);

        Product Save(Product product);
    }

    public class ProductRepository : IProductRepository
    {
        private IJSONDatabase jsonDatabase;

        public ProductRepository(IJSONDatabase jsonDatabase)
        {
            this.jsonDatabase = jsonDatabase;
        }

        public IEnumerable<Product> List()
        {
            return this.jsonDatabase.loadJSONData().Products;
        }

        public Product Get(int id)
        {
            return this.jsonDatabase
                .loadJSONData()
                .Products
                .Where(p => p.Id == id)
                .FirstOrDefault();
        }

        public Product Save(Product product)
        {
            JSONData jsonData = this.jsonDatabase.loadJSONData();
            List<Product> products = jsonData.Products.Where(p => p.Id != product.Id).ToList();
            products.Add(product);

            jsonData.Products = products;

            this.jsonDatabase.saveJSONData(jsonData);

            return product;
        }
    }
}
