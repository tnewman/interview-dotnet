using System.Collections.Generic;
using System.Linq;
using System.Text;
using GroceryStoreAPI.CustomerTest;
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

        }

        [TestMethod]
        public void TestGetWithId()
        {

        }

        [TestMethod]
        public void TestGetWithMissingId()
        {

        }
    }
}
