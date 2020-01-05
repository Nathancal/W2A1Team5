using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

using Web2Ass1Team5.App_Code.DAL;

namespace Web2Ass1Team5.App_Code.BLL
{
    public class DiscountCode
    {
        private DateTime dateActive, dateEnd;
        private int discountPerc, isActive;
        private string code;


        public DiscountCode(string code, DateTime dateActive, DateTime dateEnd, int discountPerc, int isActive)
        {
            this.code = code;
            this.dateActive = dateActive;
            this.dateEnd = dateEnd;
            this.discountPerc = discountPerc;
            this.isActive = isActive;
        }

        public DiscountCode(string code, DateTime dateActive, DateTime dateEnd, int discountPerc)
        {
            this.code = code;
            this.dateActive = dateActive;
            this.dateEnd = dateEnd;
            this.discountPerc = discountPerc;
        }

        public DiscountCode() { }

        public string getCode()
        {
            return code;
        }

        public static DataSet getDiscountCodes()
        {
            return daDiscountCode.getDiscountCodes();
        }

        public int getDiscountPerc()
        {
            return discountPerc;
        }

        public int checkIsActive()
        {
            return isActive;

        }

        public DateTime getDateActive()
        {
            return dateActive;
        }

        public void setDateActive(DateTime dateActive)
        {
            this.dateActive = dateActive;
        }

        public DateTime getDateEnd()
        {
            return dateEnd;
        }

        public void setDateEnd(DateTime dateEnd)
        {
            this.dateEnd = dateEnd;
        }

        public void setCode(string code)
        {
            this.code = code;
        }



        public void createNewDiscountCode(string code, DateTime dateActive, DateTime dateEnd, int discPerc)
        {
            daDiscountCode.createNewDiscountCode(code, dateActive, dateEnd, discPerc);
        }

        public String redeemDiscountCode(string code, int userId, DateTime current)
        {

            int redeemCodeStatus = daDiscountCode.redeemDiscountCode(code, userId, current);
            string statusInfo;

            if (redeemCodeStatus == 0)
            {
                statusInfo = "Im sorry but you have already used this discount code.";
            }
            else if (redeemCodeStatus == 1)
            {
                statusInfo = "discount applied";
            }
            else if (redeemCodeStatus == 2)
            {
                statusInfo = "Im sorry but this discount code does not exist, or is no longer active";
            }
            else
            {
                statusInfo = "Error";
            }

            return statusInfo;

        }

        public DiscountCode updateDiscountCode(string pCode, DateTime pDateEnd, int pDiscountPerc)
        {
            DiscountCode dc1 = daDiscountCode.updateDiscountCode(pCode, pDateEnd, pDiscountPerc);
            this.code = dc1.getCode();
            this.dateActive = dc1.getDateActive();
            this.dateEnd = dc1.getDateEnd();
            this.discountPerc = dc1.getDiscountPerc();
            this.isActive = dc1.checkIsActive();
            return dc1;
        }

    }
}