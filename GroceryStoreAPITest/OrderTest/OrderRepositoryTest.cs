using GroceryStoreAPI.JSON;
using GroceryStoreAPI.Order;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GroceryStoreAPITest.OrderTest
{
    [TestClass]
    public class OrderRepositoryTest
    {
        private Mock<IJSONDatabase> jsonDatabase;

        private IOrderRepository orderRepository;

        [TestInitialize]
        public void Setup()
        {
            this.jsonDatabase = new Mock<IJSONDatabase>();
            this.orderRepository = new OrderRepository(this.jsonDatabase.Object);
        }

        [TestMethod]
        public void TestList()
        {
            IEnumerable<Order> ordersToRetrieve = new List<Order>()
            {
                new Order()
                {
                    Id = 1
                }
            };

            JSONData jsonData = new JSONData()
            {
                Orders = ordersToRetrieve
            };

            this.jsonDatabase.Setup(jd => jd.loadJSONData()).Returns(jsonData);

            IEnumerable<Order> retrievedOrders = this.orderRepository.List();

            Assert.AreEqual(ordersToRetrieve.Count(), retrievedOrders.Count());
            Assert.AreEqual(ordersToRetrieve.First().Id, retrievedOrders.First().Id);
        }

        [TestMethod]
        public void TestGetById()
        {
            IEnumerable<Order> ordersToRetrieve = new List<Order>()
            {
                new Order()
                {
                    Id = 1
                },
                new Order()
                {
                    Id = 2
                }
            };

            JSONData jsonData = new JSONData()
            {
                Orders = ordersToRetrieve
            };

            this.jsonDatabase.Setup(jd => jd.loadJSONData()).Returns(jsonData);

            Order retrievedOrder = this.orderRepository.Get(2);

            Assert.AreEqual(2, retrievedOrder.Id);
        }

        [TestMethod]
        public void TestGetByIdWithMissingId()
        {
            JSONData jsonData = new JSONData()
            {
                Orders = new List<Order>()
            };

            this.jsonDatabase.Setup(jd => jd.loadJSONData()).Returns(jsonData);

            Order retrievedOrder = this.orderRepository.Get(1);

            Assert.IsNull(retrievedOrder);
        }

        [TestMethod]
        public void TestGetByCustomer()
        {
            IEnumerable<Order> ordersToRetrieve = new List<Order>()
            {
                new Order()
                {
                    CustomerId = 1
                },
                new Order()
                {
                    CustomerId = 2
                }
            };

            JSONData jsonData = new JSONData()
            {
                Orders = ordersToRetrieve
            };

            this.jsonDatabase.Setup(jd => jd.loadJSONData()).Returns(jsonData);

            IEnumerable<Order> retrievedOrders = this.orderRepository.GetByCustomer(2);

            Assert.AreEqual(1, retrievedOrders.Count());
            Assert.AreEqual(2, retrievedOrders.First().CustomerId);
        }

        [TestMethod]
        public void TestGetByDate()
        {
            IEnumerable<Order> ordersToRetrieve = new List<Order>()
            {
                new Order()
                {
                    Date = DateTime.Today
                },
                new Order()
                {
                    Date = DateTime.FromOADate(0)
                }
            };

            JSONData jsonData = new JSONData()
            {
                Orders = ordersToRetrieve
            };

            this.jsonDatabase.Setup(jd => jd.loadJSONData()).Returns(jsonData);

            IEnumerable<Order> retrievedOrders = this.orderRepository.GetByDate(DateTime.Today);

            Assert.AreEqual(1, retrievedOrders.Count());
            Assert.AreEqual(DateTime.Today, retrievedOrders.First().Date);
        }
    }
}
