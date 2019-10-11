using System.Collections.Generic;
using System.Linq;
using System.Text;
using GroceryStoreAPI.Customer;
using GroceryStoreAPI.JSON;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace GroceryStoreAPITest.CustomerTest
{
    [TestClass]
    public class CustomerRepositoryTest
    {
        private Mock<IJSONDatabase> jsonDatabase;

        private ICustomerRepository customerRepository;

        [TestInitialize]
        public void Setup()
        {
            this.jsonDatabase = new Mock<IJSONDatabase>();
            this.customerRepository = new CustomerRepository(this.jsonDatabase.Object);
        }

        [TestMethod]
        public void TestList()
        {
            IEnumerable<Customer> customersToRetrieve = new List<Customer>()
            {
                new Customer()
                {
                    Id = 1
                }
            };

            JSONData jsonData = new JSONData()
            {
                Customers = customersToRetrieve
            };

            this.jsonDatabase.Setup(jd => jd.loadJSONData()).Returns(jsonData);

            IEnumerable<Customer> retrievedCustomers = this.customerRepository.List();

            Assert.AreEqual(customersToRetrieve.Count(), retrievedCustomers.Count());
            Assert.AreEqual(customersToRetrieve.First().Id, retrievedCustomers.First().Id);
        }

        [TestMethod]
        public void TestGetWithId()
        {
            IEnumerable<Customer> customersToRetrieve = new List<Customer>()
            {
                new Customer()
                {
                    Id = 1
                },
                new Customer()
                {
                    Id = 2
                }
            };

            JSONData jsonData = new JSONData()
            {
                Customers = customersToRetrieve
            };

            this.jsonDatabase.Setup(jd => jd.loadJSONData()).Returns(jsonData);

            Customer retrievedCustomer = this.customerRepository.Get(2);

            Assert.AreEqual(2, retrievedCustomer.Id);
        }

        [TestMethod]
        public void TestGetWithMissingId()
        {
            IEnumerable<Customer> customersToRetrieve = new List<Customer>();

            JSONData jsonData = new JSONData()
            {
                Customers = customersToRetrieve
            };

            this.jsonDatabase.Setup(jd => jd.loadJSONData()).Returns(jsonData);

            Customer retrievedCustomer = this.customerRepository.Get(2);

            Assert.IsNull(retrievedCustomer);
        }

        [TestMethod]
        public void TestSaveInsert()
        {
            JSONData jsonData = new JSONData();

            this.jsonDatabase.Setup(jd => jd.loadJSONData()).Returns(jsonData);

            Customer customerToSave = new Customer()
            {
                Id = 1
            };

            Customer savedCustomer = this.customerRepository.Save(customerToSave);

            Assert.AreEqual(customerToSave.Id, savedCustomer.Id);
            this.jsonDatabase.Verify(jd => jd.saveJSONData(jsonData));
        }

        [TestMethod]
        public void TestSaveOverwrite()
        {
            JSONData jsonData = new JSONData()
            {
                Customers = new List<Customer>()
                {
                    new Customer()
                    {
                        Id = 1,
                        Name = "Test"
                    }
                }
            };

            this.jsonDatabase.Setup(jd => jd.loadJSONData()).Returns(jsonData);

            Customer customerToSave = new Customer()
            {
                Id = 1,
                Name = "Test2"
            };

            Customer savedCustomer = this.customerRepository.Save(customerToSave);

            Assert.AreEqual(customerToSave.Id, savedCustomer.Id);
            this.jsonDatabase.Verify(jd => jd.saveJSONData(jsonData));
        }
    }
}
