using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VapeShop.App_Code.DAL;

namespace VapeShop.App_Code
{
    public class Product
    {
        private int productId, stock, reOrderLevel;
        private string productName, productDesc, productType, imageFile;
        private double price, salePrice;
        private Boolean sale;


        public Product() { 
        }

        public void findProduct(int pProductId) {
            Product loadProduct = DataAccess.getProduct(pProductId);

            productId = loadProduct.getProductId();
            productName = loadProduct.getProductName();
            productDesc = loadProduct.getProductDesc();
            productType = loadProduct.getProductType();
            price = loadProduct.getPrice();
            salePrice = loadProduct.getSalePrice();
            reOrderLevel = loadProduct.getReOrderLevel();


        }//TODO

        public int getProductId() {
            return productId;
        }

        public void setProductId(int productId) {
            this.productId = productId;
        }

        public string getProductName() {
            return productName;
        }

        public void setProductName(string prodName) {
            this.productName = prodName;
        }

        public string getProductDesc() {
            return productDesc;
        }

        public void setProductDesc(string prodDesc) {
            this.productDesc = prodDesc;
        }

        public string getProductType(){
            return productType;
        }

        public void setProductType(string prodType) {
            this.productType = prodType;
        
        }

        public double getPrice() {
            return price;
        }

        public void setPrice(double price) {
            this.price = price;
        }

        public double getSalePrice() {
            return salePrice;
        
        }

        public void setSalePrice(double salePrice) {
            this.salePrice = salePrice;
            
        }

        public Boolean isSale() {
            return sale;
        }

        public void setIsSale(Boolean sale) {
            this.sale = sale;
        }

        public int getStock() {
            return stock;
        }

        public void setStock(int newStock) {
            this.stock = newStock;
        }

        public string getImageFile() {
            return imageFile;
        }

        public void setImageFile(string imageFile) {
            this.imageFile = imageFile;
        }

        public int getReOrderLevel() {
            return reOrderLevel;
        }

        public void setReOrdeLevel(int reOrder) {
            this.reOrderLevel = reOrder;
        }
    }
}