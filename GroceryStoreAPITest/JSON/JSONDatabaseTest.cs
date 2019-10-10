using GroceryStoreAPI.Customer;
using GroceryStoreAPI.JSON;
using GroceryStoreAPI.Order;
using GroceryStoreAPI.Product;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace GroceryStoreAPITest.JSONDatabaseTest
{
    [TestClass]
    public class JSONDatabaseTest
    {
        // NOTE(tnewman): This is really an integration test

        private JSONDatabase jsonDatabase;

        [TestInitialize]
        public void Setup()
        {
            this.jsonDatabase = new JSONDatabase();
        }

        [TestMethod]
        public void TestLoadsJSONData()
        {
            JSONData jsonData = this.jsonDatabase.loadJSONData();

            Assert.IsNotNull(jsonData);

            Customer customer = jsonData.Customers.First();
            Assert.AreEqual(1, customer.Id);
            Equals("Bob", customer.Name);

            Order order = jsonData.Orders.First();
            Assert.AreEqual(1, order.Id);
            Assert.AreEqual(1, order.CustomerId);
            Assert.AreEqual(1, order.Items.First().ProductId);
            Assert.AreEqual(2, order.Items.First().Quantity);

            Product product = jsonData.Products.First();
            Assert.AreEqual(1, product.Id);
            Equals("apple", product.Description);
            Assert.AreEqual(0.50m, product.Price);
        }

        [TestMethod]
        public void TestSavesJSONData()
        {
            JSONData currentJSONData = this.jsonDatabase.loadJSONData();
            currentJSONData.Orders.First().Date = DateTime.Now;

            this.jsonDatabase.saveJSONData(currentJSONData);
            JSONData newJSONData = this.jsonDatabase.loadJSONData();

            Assert.AreEqual(currentJSONData.Orders.First().Date, newJSONData.Orders.First().Date);
        }
    }
}
