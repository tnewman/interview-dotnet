using GroceryStoreAPI.Customer;
using GroceryStoreAPI.JSON;
using GroceryStoreAPI.Order;
using GroceryStoreAPI.Product;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace GroceryStoreAPITest.JSONDatabaseTest
{
    [TestClass]
    public class JSONDatabaseTest
    {
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

            Assert.AreEqual(1, jsonData.Customers[0].Id);
            Equals("Bob", jsonData.Customers[0].Name);

            Assert.AreEqual(1, jsonData.Orders[0].Id);
            Assert.AreEqual(1, jsonData.Orders[0].CustomerId);
            Assert.AreEqual(1, jsonData.Orders[0].Items[0].ProductId);
            Assert.AreEqual(2, jsonData.Orders[0].Items[0].Quantity);

            Assert.AreEqual(1, jsonData.Products[0].Id);
            Equals("apple", jsonData.Products[0].Description);
            Assert.AreEqual(0.50m, jsonData.Products[0].Price);
        }
    }
}
