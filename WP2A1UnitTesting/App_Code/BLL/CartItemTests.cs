using Microsoft.VisualStudio.TestTools.UnitTesting;
using Web2Ass1Team5.App_Code.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web2Ass1Team5.App_Code.BLL.Tests
{
    [TestClass()]
    public class CartItemTests
    {
   

        [TestMethod]
        public void Test_GetProductId()
        {
            CartItem testItem = new CartItem();
            testItem.setProdId(4);

            int expResult = 4;
            int actualResult = testItem.getProdId();
            Assert.AreEqual(expResult, actualResult);
        }
        
        [TestMethod]
        public void Test_GetProductName()
        {
            CartItem testItem = new CartItem();
            testItem.setProdName("Ecig");

            string expResult = "Ecig";
            string actualResult = testItem.getProdName();
            Assert.AreEqual(expResult, actualResult);
        }

        [TestMethod]
        public void Test_GetProductType()
        {
            CartItem testItem = new CartItem();
            testItem.setProdName("Ecig");

            string expResult = "Ecig";
            string actualResult = testItem.getProdName();
            Assert.AreEqual(expResult, actualResult);
        }

        [TestMethod]
        public void Test_GetProductPrice()
        {
            CartItem testItem = new CartItem();
            testItem.setProdPrice(9.99);

            double expResult = 9.99;
            double actualResult = testItem.getProdPrice();
            Assert.AreEqual(expResult, actualResult);
        }


    }
}