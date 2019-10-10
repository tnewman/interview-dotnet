using GroceryStoreAPI.JSON;
using System.Collections.Generic;
using System.Linq;

namespace GroceryStoreAPI.Product
{
    public class ProductRepository
    {
        private JSONDatabase jsonDatabase;

        public ProductRepository(JSONDatabase jsonDatabase)
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

            Dictionary<int, Product> productsById = new Dictionary<int, Product>();

            foreach(Product currentProduct in jsonData.Products)
            {
                productsById[currentProduct.Id] = currentProduct;
            }

            // Upsert the Product
            productsById[product.Id] = product;

            jsonData.Products = productsById.Values;

            this.jsonDatabase.saveJSONData(jsonData);

            return product;
        }
    }
}
