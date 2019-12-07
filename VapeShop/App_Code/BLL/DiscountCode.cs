﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VapeShop.App_Code.DAL;

namespace VapeShop.App_Code.BLL
{
    public class DiscountCode
    {
        private DateTime dateActive, dateEnd;
        private int discountPerc, isActive;
        private string code;


        public DiscountCode(string code, DateTime dateActive, DateTime dateEnd, int discountPerc, int isActive) {
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

        public string getCode() {
            return code;
        }

        public int getDiscountPerc() {
            return discountPerc;
        }

        public DateTime getDateActive() {
            return dateActive;
        }

        public void setDateActive(DateTime dateActive) {
            this.dateActive = dateActive;
        }

        public DateTime getDateEnd() {
            return dateEnd;
        }

        public void setDateEnd(DateTime dateEnd) {
            this.dateEnd = dateEnd;
        }

        public void createNewDiscountCode(){
            DataAccess.createNewDiscountCode(code, dateActive, dateEnd, discountPerc);
        }

        public DiscountCode redeemDiscountCode(string pCode){

            DiscountCode dc1 = new DiscountCode();
            DataAccess.redeemDiscountCode(pCode);

            this.code =

        }



    }
}