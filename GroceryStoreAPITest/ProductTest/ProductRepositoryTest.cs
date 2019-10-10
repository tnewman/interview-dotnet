using GroceryStoreAPI.JSON;
using GroceryStoreAPI.ProductTest;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GroceryStoreAPITest.ProductTest
{
    [TestClass]
    public class ProductRepositoryTest
    {
        private IProductRepository productRepository;

        private Mock<IJSONDatabase> jsonDatabase;

        [TestInitialize]
        public void Setup()
        {
            this.jsonDatabase = new Mock<IJSONDatabase>();
            this.productRepository = new ProductRepository(this.jsonDatabase.Object);
        }

        [TestMethod]
        public void TestList()
        {
            IEnumerable<Product> productsToRetrieve = new List<Product>()
            {
                new Product()
                {
                    Id = 1
                }
            };

            JSONData jsonData = new JSONData()
            {
                Products = productsToRetrieve
            };

            this.jsonDatabase.Setup(jd => jd.loadJSONData()).Returns(jsonData);

            IEnumerable<Product> retrievedProducts = this.productRepository.List();

            Assert.AreEqual(productsToRetrieve.Count(), retrievedProducts.Count());
            Assert.AreEqual(productsToRetrieve.First().Id, retrievedProducts.First().Id);
        }

        [TestMethod]
        public void TestGetById()
        {
            IEnumerable<Product> productsToRetrieve = new List<Product>()
            {
                new Product()
                {
                    Id = 1
                },
                new Product()
                {
                    Id = 2
                }
            };

            JSONData jsonData = new JSONData()
            {
                Products = productsToRetrieve
            };

            this.jsonDatabase.Setup(jd => jd.loadJSONData()).Returns(jsonData);

            Product retrievedProduct = this.productRepository.Get(2);

            Assert.AreEqual(2, retrievedProduct.Id);
        }

        [TestMethod]
        public void TestGetByIdWithMissingId()
        {
            IEnumerable<Product> productsToRetrieve = new List<Product>();

            JSONData jsonData = new JSONData()
            {
                Products = productsToRetrieve
            };

            this.jsonDatabase.Setup(jd => jd.loadJSONData()).Returns(jsonData);

            Product retrievedProduct = this.productRepository.Get(2);

            Assert.IsNull(retrievedProduct);
        }

        [TestMethod]
        public void TestSaveInsert()
        {
            JSONData jsonData = new JSONData();

            this.jsonDatabase.Setup(jd => jd.loadJSONData()).Returns(jsonData);

            Product productToSave = new Product()
            {
                Id = 1
            };

            Product savedProduct = this.productRepository.Save(productToSave);

            Assert.AreEqual(productToSave.Id, savedProduct.Id);
            this.jsonDatabase.Verify(jd => jd.saveJSONData(jsonData));
        }

        [TestMethod]
        public void TestSaveOverwrite()
        {
            JSONData jsonData = new JSONData()
            {
                Products = new List<Product>()
                {
                    new Product()
                    {
                        Id = 1,
                        Description = "Test"
                    }
                }
            };

            this.jsonDatabase.Setup(jd => jd.loadJSONData()).Returns(jsonData);

            Product productToSave = new Product()
            {
                Id = 1,
                Description = "Test2"
            };

            Product savedProduct = this.productRepository.Save(productToSave);

            Assert.AreEqual(productToSave.Id, savedProduct.Id);
            this.jsonDatabase.Verify(jd => jd.saveJSONData(jsonData));
        }
    }
}
