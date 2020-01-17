using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Web2Ass1Team5.App_Code.DAL;

namespace Web2Ass1Team5.App_Code.BLL
{
    public class Invoice
    {

        private int invoiceNum, discountApplied;
        private string email, shipMethod;
        private DateTime orderDate;
        private double subTotal, shipping, totalCost;

        public Invoice()
        {
        }

        public Invoice(string invEmail, string invShipMethod, double invSubTotal, double invShipping)
        {

            email = invEmail;
            shipMethod = invShipMethod;
            subTotal = invSubTotal;
            shipping = invShipping;
            orderDate = DateTime.Now;
            totalCost = subTotal + shipping;

        }

        public Invoice(string invEmail, string invShipMethod, double invSubTotal, double invShipping, double invTotalCost, int discountApplied)
        {

            email = invEmail;
            shipMethod = invShipMethod;
            subTotal = invSubTotal;
            shipping = invShipping;
            orderDate = DateTime.Now;
            totalCost = invTotalCost;
            this.discountApplied = discountApplied;

        }

        public Invoice(int invoiceNum, string invEmail, string invShipMethod, double invSubTotal, double invShipping,  double invTotalCost, int discountApplied)
        {
            this.invoiceNum = invoiceNum;
            email = invEmail;
            shipMethod = invShipMethod;
            subTotal = invSubTotal;
            shipping = invShipping;
            orderDate = DateTime.Now;
            totalCost = invTotalCost;
            this.discountApplied = discountApplied;

        }

        public int createInvoice()
        {
            int invNum = daInvoice.createNewInvoice(email, shipMethod, subTotal, shipping, totalCost, discountApplied);
            return invNum;
        }

        public double getShipping() {
            return shipping;
        }


        public void setInvoiceNum(int invoiceNum)
        {
            this.invoiceNum = invoiceNum;

        }
        public static Invoice returnNewInvoice(int invoiceNum)
        {
            Invoice returnInvoice = daInvoice.returnNewInvoice(invoiceNum);

            return returnInvoice;
        }

        public static DataSet returnInvoices(string email) {
            return daInvoice.returnUserInvoices(email); 
        }

        public int getInvoiceNum()
        {
            return invoiceNum;

        }

        public string getEmail()
        {
            return email;

        }

        public string getShipMethod()
        {
            return shipMethod;

        }


        public double getSubTotal()
        {
            return subTotal;

        }

        public double getShippingCost() {
            return shipping;
        }

        public DateTime getOrderDate()
        {

            return orderDate;

        }

        public double getTotalCost()
        {
            return totalCost;

        }

        public int getDiscountAmount()
        {
            return discountApplied;

        }





    }
}