using Microsoft.VisualStudio.TestTools.UnitTesting;
using Web2Ass1Team5.App_Code.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web2Ass1Team5.App_Code.DAL;

namespace Web2Ass1Team5.App_Code.BLL.Tests
{
    [TestClass()]
    public class DiscountCodeTests
    {
        [TestMethod()]
        public void Test_GetDiscountCodeID()
        {
            DiscountCode newCode = new DiscountCode("HELLO2020");

            string expResults = "HELLO2020";
            string actualResult = newCode.getCode();

            Assert.Equals(expResults, actualResult);
        }

        [TestMethod()]
        public void Test_GetRandomDiscountCode()
        {
            DiscountCode newCode = daDiscountCode.randomDiscountCode(5);

            Assert.IsNotNull(newCode);

        }

        [TestMethod()]
        public void Test_CheckCodeExists()
        {
            DiscountCode newCode = new DiscountCode("HELLO2020", DateTime.Now, DateTime.Now, 20);

            daDiscountCode.createNewDiscountCode(newCode.getCode(), newCode.getDateActive(), newCode.getDateEnd(), newCode.getDiscountPerc(),true);

            DiscountCode expResults = newCode;
            DiscountCode actualResult = daDiscountCode.selectDiscountCode(newCode.getCode());

            Assert.Equals(expResults, actualResult);
        }


    }
}