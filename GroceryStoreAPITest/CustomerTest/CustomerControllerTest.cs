using GroceryStoreAPI.Customer;
using GroceryStoreAPI.JSON;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Moq;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace GroceryStoreAPITest.CustomerTest
{
    [TestClass]
    public class CustomerControllerTest
    {
        private ICustomerController customerController;

        private Mock<ICustomerRepository> customerRepository;

        [TestInitialize]
        public void Setup()
        {
            this.customerRepository = new Mock<ICustomerRepository>();
            this.customerController = new CustomerController(this.customerRepository.Object);
        }

        [TestMethod]
        public void TestList()
        {
            IEnumerable<Customer> existingCustomers = new List<Customer>()
            {
                new Customer()
                {
                    Id = 1
                }
            };

            this.customerRepository.Setup(cr => cr.List()).Returns(existingCustomers);

            IEnumerable<Customer> retrievedCustomers = this.customerController.List();

            Assert.AreEqual(existingCustomers.Count(), retrievedCustomers.Count());
            Assert.AreEqual(existingCustomers.First().Id, retrievedCustomers.First().Id);
        }

        [TestMethod]
        public void TestGetById()
        {
            Customer existingCustomer = new Customer()
            {
                Id = 1
            };

            this.customerRepository.Setup(cr => cr.Get(1)).Returns(existingCustomer);

            Customer retrievedCustomer = this.customerController.Get(1).Value;

            Assert.AreEqual(existingCustomer.Id, retrievedCustomer.Id);
        }

        [TestMethod]
        public void TestGetByIdWithMissingCustomer()
        {
            this.customerRepository.Setup(cr => cr.Get(1)).Returns((Customer)null);

            ActionResult<Customer> result = this.customerController.Get(1);

            Assert.IsTrue(result.Result is NotFoundResult);
        }

        [TestMethod]
        public void TestSaveCustomer()
        {
            Customer customerToSave = new Customer()
            {
                Id = 1
            };

            this.customerRepository.Setup(cr => cr.Save(customerToSave)).Returns(customerToSave);

            Customer savedCustomer = this.customerController.Save(customerToSave).Value;

            Assert.AreEqual(customerToSave.Id, savedCustomer.Id);
            this.customerRepository.Verify(cr => cr.Save(customerToSave));
        }
    }
}
