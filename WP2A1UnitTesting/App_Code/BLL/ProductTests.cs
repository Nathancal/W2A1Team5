using Microsoft.VisualStudio.TestTools.UnitTesting;
using Web2Ass1Team5.App_Code.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Web2Ass1Team5.App_Code.DAL;

namespace Web2Ass1Team5.App_Code.BLL.Tests
{
    [TestClass()]
    public class ProductTests
    {
        [TestMethod()]
        public void Test_getProducts()
        {
            DataSet products = daProduct.getProducts();

            Assert.IsNotNull(products);
            
        }

        [TestMethod()]
        public void Test_getProduct()
        {
            string productId = "31";
            Product getProduct = daProduct.getProduct(productId);

            int expResult = 31;
            int actResult = getProduct.getProductId();
            Assert.Equals(expResult, actResult);

        }


        [TestMethod()]
        public void Test_getProductName()
        {
            Product newProduct = new Product("TestProduct","Coils", 1, false, 1.99, "test", 10, 1, "test");

            string expResult = "TestProduct";
            string actResult = newProduct.getProductName();


            Assert.Equals(expResult, actResult);
        }

        [TestMethod()]
        public void Test_getProductDescription()
        {
            Product newProduct = new Product("TestProduct", "Coils", 1, false, 1.99,"Find this description", 10, 1, "test");

            string expResult = "Find this description";
            string actResult = newProduct.getProductName();

            Assert.Equals(expResult, actResult);

        }

        [TestMethod()]
        public void Test_getProductPrice()
        {
            Product newProduct = new Product("TestProduct", "Coils", 1, false, 1.99, "Find this description", 10, 1, "test");

            double expResult = 1;
            double actResult = newProduct.getPrice();

            Assert.Equals(expResult, actResult);

        }


    }
}