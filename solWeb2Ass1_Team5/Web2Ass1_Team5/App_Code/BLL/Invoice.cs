﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web2Ass1_Team5.App_Code.DAL;

namespace Web2Ass1_Team5.App_Code.BLL
{
    public class Invoice
    {

        private int invoiceNum, productId, quantity;
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

        public Invoice(int invoiceNum, string invEmail, string invShipMethod, double invSubTotal, double invShipping, DateTime invOrderDate, double invTotalCost, int productId, int quantity)
        {

            email = invEmail;
            shipMethod = invShipMethod;
            subTotal = invSubTotal;
            shipping = invShipping;
            orderDate = invOrderDate;
            totalCost = invTotalCost;

        }

        public void createInvoice()
        {
            int invNum = daInvoice.createNewInvoice(email, shipMethod, orderDate, subTotal, shipping, totalCost);
            invoiceNum = invNum;
        }

        public Invoice returnNewInvoice()
        {
            Invoice returnInvoice = daInvoice.returnNewInvoice(invoiceNum);

            return returnInvoice;
        }

        public void findInvoice()
        {

        }


    }
}