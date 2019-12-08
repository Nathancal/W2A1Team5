using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VapeShop.App_Code.DAL;

namespace VapeShop.App_Code.BLL
{
    public class Invoice
    {

        private int invoiceNum;
        private string email, shipMethod;
        private DateTime orderDate;
        private double subTotal, shipping, totalCost;

        public Invoice(){ 
        }

        public Invoice(string invEmail, string invShipMethod, double invSubTotal, double invShipping){

            email = invEmail;
            shipMethod = invShipMethod;
            subTotal = invSubTotal;
            shipping = invShipping;
            orderDate = DateTime.Now;
            totalCost = subTotal + shipping;

        }

        public Invoice(int invoiceNum, string invEmail, string invShipMethod, double invSubTotal, double invShipping, DateTime invOrderDate, double invTotalCost)
        {

            email = invEmail;
            shipMethod = invShipMethod;
            subTotal = invSubTotal;
            shipping = invShipping;
            orderDate = invOrderDate;
            totalCost = invTotalCost;

        }

        public void createInvoice(){
            int invNum = DataAccess.createNewInvoice(email, shipMethod, orderDate, subTotal, shipping, totalCost);
            invoiceNum = invNum;
        }

        public Invoice returnNewInvoice(){
            DataAccess.returnNewInvoice(invoiceNum);
        }


    }
}