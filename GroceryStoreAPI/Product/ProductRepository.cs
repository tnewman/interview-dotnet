using GroceryStoreAPI.JSON;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
    }
}
