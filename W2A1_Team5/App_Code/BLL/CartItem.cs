using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using W2A1Team5.App_Code.DAL;

namespace W2A1Team5.App_Code.BLL
{
    public class CartItem
    {
        private string productName, productType;
        private double price;
        private int productId, quantity;

        public CartItem(int prodId, string prodName, string prodType, double price, int prodQuantity) {
            this.productId = prodId;
            this.productName = prodName;
            this.productType = prodType;
            this.price = price;
            this.quantity = prodQuantity;
        }

        public int getProdId() {
            return productId;
        }

        public void setProdId(int prodId) {
            this.productId = prodId;
        }

        public string getProdName() {
            return productName;
        }

        public void setProdName(string name) {
            this.productName = name;
        }

        public string getProdType(){
            return productType;
        }

        public void setProdType(string type){
            this.productType = type;
        }

        public double getProdPrice() {
            return price;
        }

        public void setProdPrice(double price) {
            this.price = price;
        }

        public int getProdQuantity(){
            return quantity;
        }

        public void setProdQuantity(int quantity){
            this.quantity = quantity;
        }

        public void createOrderItem(int invoiceNum) {
            daCartItem.createOrderItem(this, invoiceNum);
        }
    
    }
}