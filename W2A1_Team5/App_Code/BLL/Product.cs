using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using W2A1Team5.App_Code.DAL;
using System.Data;
using System.Data.OleDb;

namespace W2A1Team5.App_Code.BLL
{
    public class Product
    {
        private int productId, stock, reOrderLevel;
        private string productName, productDesc, productType, imageFile;
        private double price, salePrice;
        private Boolean sale;

        public Product(){
        }

        public Product(string productName, string productType, double price, Boolean sale, double salePrice, string prodDesc, int stock, int reOrderLevel, string imageFile){
            this.productName = productName;
            this.productType = productType;
            this.price = price;
            this.sale = sale;
            this.salePrice = salePrice;
            this.productDesc = prodDesc;
            this.stock = stock;
            this.reOrderLevel = reOrderLevel;
            this.imageFile = imageFile;
        }



        public static DataSet getProducts(){
            return daProduct.getProducts();
        }

      

        public Product findProduct(string searchProduct) {
            Product loadProduct = daProduct.getProduct(searchProduct);

            productId = loadProduct.getProductId();
            productName = loadProduct.getProductName();
            productDesc = loadProduct.getProductDesc();
            productType = loadProduct.getProductType();
            price = loadProduct.getPrice();
            sale = loadProduct.isSale();
            salePrice = loadProduct.getSalePrice();
            stock = loadProduct.getStock();
            imageFile = loadProduct.getImageFile();
            reOrderLevel = loadProduct.getReOrderLevel();

            return loadProduct;
        }//TODO

        public void createNewProduct() {
            daProduct.createNewProduct(productName, productType, price, sale, salePrice, productDesc, stock, reOrderLevel, imageFile);
        }

        public void removeProduct(Product removeProduct){
            daProduct.removeProduct(removeProduct);

        }

        public void updateProduct(Product updateProduct){
            daProduct.updateProduct(updateProduct);
        
        }


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