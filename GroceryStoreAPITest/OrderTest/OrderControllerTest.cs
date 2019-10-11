using GroceryStoreAPI.Order;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GroceryStoreAPITest.OrderTest
{
    [TestClass]
    public class OrderControllerTest
    {
        private Mock<IOrderRepository> orderRepository;

        private IOrderController orderController;

        [TestInitialize]
        public void Setup()
        {
            this.orderRepository = new Mock<IOrderRepository>();
            this.orderController = new OrderController(this.orderRepository.Object);
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

            this.orderRepository.Setup(or => or.List()).Returns(ordersToRetrieve);

            IEnumerable<Order> retrievedOrders = this.orderController.List();

            Assert.AreEqual(ordersToRetrieve.Count(), retrievedOrders.Count());
            Assert.AreEqual(ordersToRetrieve.First().Id, retrievedOrders.First().Id);
        }

        [TestMethod]
        public void TestGetById()
        {
            Order orderToRetrieve = new Order()
            {
                Id = 1
            };

            this.orderRepository.Setup(or => or.Get(1)).Returns(orderToRetrieve);

            Order retrievedOrder = this.orderController.Get(1).Value;

            Assert.AreEqual(orderToRetrieve.Id, retrievedOrder.Id);
        }

        [TestMethod]
        public void TestGetByIdWithMissingId()
        {
            this.orderRepository.Setup(or => or.Get(1)).Returns((Order)null);

            ActionResult<Order> result = this.orderController.Get(1);

            Assert.IsTrue(result.Result is NotFoundResult);
        }

        [TestMethod]
        public void TestGetByCustomerId()
        {
            IEnumerable<Order> ordersToRetrieve = new List<Order>()
            {
                new Order()
                {
                    CustomerId = 1
                }
            };

            this.orderRepository.Setup(or => or.GetByCustomer(1)).Returns(ordersToRetrieve);

            IEnumerable<Order> retrievedOrders = this.orderController.GetByCustomer(1);

            Assert.AreEqual(ordersToRetrieve.Count(), retrievedOrders.Count());
            Assert.AreEqual(ordersToRetrieve.First().CustomerId, retrievedOrders.First().CustomerId);
        }

        [TestMethod]
        public void TestGetByDate()
        {
            DateTime currentDate = DateTime.Now;

            IEnumerable<Order> ordersToRetrieve = new List<Order>()
            {
                new Order()
                {
                    Date = currentDate
                }
            };

            this.orderRepository.Setup(or => or.GetByDate(currentDate)).Returns(ordersToRetrieve);

            IEnumerable<Order> retrievedOrders = this.orderController.GetByDate(currentDate);

            Assert.AreEqual(ordersToRetrieve.Count(), retrievedOrders.Count());
            Assert.AreEqual(ordersToRetrieve.First().Date, retrievedOrders.First().Date);
        }
    }
}
