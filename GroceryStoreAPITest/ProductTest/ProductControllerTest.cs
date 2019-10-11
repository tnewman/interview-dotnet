using GroceryStoreAPI.Product;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Linq;

namespace GroceryStoreAPITest.ProductTest
{
    [TestClass]
    public class ProductControllerTest
    {
        private Mock<IProductRepository> productRepository;

        private ProductController productController;

        [TestInitialize]
        public void Setup()
        {
            this.productRepository = new Mock<IProductRepository>();
            this.productController = new ProductController(this.productRepository.Object);
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

            this.productRepository.Setup(pr => pr.List()).Returns(productsToRetrieve);

            IEnumerable<Product> retrievedProducts = this.productController.List();

            Assert.AreEqual(productsToRetrieve.Count(), retrievedProducts.Count());
            Assert.AreEqual(productsToRetrieve.First().Id, retrievedProducts.First().Id);
        }

        [TestMethod]
        public void TestGetById()
        {
            Product productToRetrieve = new Product()
            {
                Id = 1
            };

            this.productRepository.Setup(pr => pr.Get(1)).Returns(productToRetrieve);

            Product retrievedProduct = this.productController.Get(1).Value;

            Assert.AreEqual(productToRetrieve.Id, retrievedProduct.Id);
        }

        [TestMethod]
        public void TestGetByIdWithMissingProduct()
        {
            this.productRepository.Setup(pr => pr.Get(1)).Returns((Product)null);

            ActionResult<Product> result = this.productController.Get(1);

            Assert.IsTrue(result.Result is NotFoundResult);
        }

        [TestMethod]
        public void TestSave()
        {
            Product productToSave = new Product()
            {
                Id = 1
            };

            this.productRepository.Setup(pr => pr.Save(productToSave)).Returns(productToSave);

            Product savedProduct = this.productController.Save(productToSave).Value;

            Assert.AreEqual(productToSave.Id, savedProduct.Id);
            this.productRepository.Verify(pr => pr.Save(productToSave));
        }
    }
}
