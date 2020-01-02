using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web2Ass1Team5.App_Code.BLL;
using System.Data;
using System.Data.OleDb;

namespace Web2Ass1Team5.App_Code.DAL
{
    public class daProduct
    {

        // Method reads the connection string from web.config file
        // Then opens the connection and returns as a OleDBConnection object
        private static OleDbConnection openConnection()
        {
            // path to the root of the web site where the web.config file exists
            string configPath = "~";
            // access to web.config file
            System.Configuration.Configuration rootWebConfig =
             System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration(configPath);
            // declaring the connection string
            string strConn = null;

            // get the value(s) in the connection string
            if (rootWebConfig.ConnectionStrings.ConnectionStrings.Count > 0)
            {
                try
                {
                    strConn = rootWebConfig.ConnectionStrings.ConnectionStrings["c9ConnStr"].ToString();
                }
                catch (Exception ex)
                {
                    strConn = null;
                }

                if (strConn != null)
                {
                    HttpContext.Current.Trace.Warn("c9ConnStr connection string = \"{0}\"", strConn);

                    //Create an OleDbConnection object using the Connection String
                    OleDbConnection cn = new OleDbConnection(strConn);
                    //Open the connection.
                    cn.Open();
                    return cn;
                }
                else
                {
                    HttpContext.Current.Trace.Warn("No c9ConnStr connection string");
                    return null;
                }
            }

            return null;
        }// openConnection

        private static void closeConnection(OleDbConnection cn)
        {
            cn.Close();
        } //closeConnection

        public static DataSet getProducts()
        {
            OleDbConnection conn = openConnection();

            DataSet dsProds = new DataSet();

            string strSQL = "SELECT * FROM Products";

            //data adapter is bridge between database and dataset
            OleDbDataAdapter daProds = new OleDbDataAdapter(strSQL, conn);

            //populate the data table in the dataset 
            //with records from the database table
            daProds.Fill(dsProds, "Products");

            conn.Close();

            return dsProds;
        }//getProducts

        public static Product getProduct(string searchProduct)
        {
            Product tempProd = new Product();

            OleDbConnection conn = openConnection();

            int getProductById;
            string strSearchProduct;
            Int32.TryParse(searchProduct, out getProductById);
            OleDbCommand cmd;

            if (getProductById > 0)
            {
                strSearchProduct = "select * FROM Products WHERE ProductId= @ProductId";
                cmd = new OleDbCommand(strSearchProduct, conn);

                cmd.Parameters.AddWithValue("@ProductId", getProductById);
            }
            else
            {
                strSearchProduct = "select * FROM Products WHERE ProductName= @ProductName";
                cmd = new OleDbCommand(strSearchProduct, conn);

                cmd.Parameters.AddWithValue("@ProductName", searchProduct);
            }

            OleDbDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {


                tempProd.setProductId(Convert.ToInt32(reader["ProductId"]));
                tempProd.setProductName(reader["ProductName"].ToString());
                tempProd.setProductType(reader["ProductType"].ToString());
                tempProd.setProductDesc(reader["Description"].ToString());
                tempProd.setPrice(Convert.ToDouble(reader["Price"]));
                tempProd.setIsSale(reader["Sale"].Equals("Sale"));
                tempProd.setSalePrice(Convert.ToDouble(reader["SalePrice"]));
                tempProd.setStock(Convert.ToInt32(reader["CurrentStock"]));
                tempProd.setReOrdeLevel(Convert.ToInt32(reader["ReOrderLevel"]));
                tempProd.setImageFile(reader["ImageFile"].ToString());


            }//while

            reader.Close();
            closeConnection(conn);

            return tempProd;
        }//getProduct

        public static void createNewProduct(string prodName, string prodType, double price, Boolean sale, double salePrice, string desc, int currentStock, int reOrderLevel, string imageFile)
        {
            OleDbConnection conn = openConnection();

            Product newProduct = new Product(prodName, prodType, price, sale, salePrice, desc, currentStock, reOrderLevel, imageFile);

            string strCreateNewProduct = "INSERT INTO Products(ProductName, " +
                           " ProductType, Price, Sale, SalePrice, Description, CurrentStock, ReOrderLevel, ImageFile)" +
                           " VALUES(@ProductName, @ProductType, @Price, @Sale, @SalePrice, @Description, @CurrentStock, @ReOrderLevel, @ImageFile)";

            //create the command object using the SQL
            OleDbCommand cmd = new OleDbCommand(strCreateNewProduct, conn);
            cmd.Parameters.AddWithValue("@ProductName", newProduct.getProductName());
            cmd.Parameters.AddWithValue("@ProductType", newProduct.getProductType());
            cmd.Parameters.AddWithValue("@Price", newProduct.getPrice());
            cmd.Parameters.AddWithValue("@Sale", newProduct.isSale());
            cmd.Parameters.AddWithValue("@SalePrice", newProduct.getSalePrice());
            cmd.Parameters.AddWithValue("@Description", newProduct.getProductDesc());
            cmd.Parameters.AddWithValue("@CurrentStock", newProduct.getStock());
            cmd.Parameters.AddWithValue("@ReOrderLevel", newProduct.getReOrderLevel());
            cmd.Parameters.AddWithValue("@ImageFile", newProduct.getImageFile());


            cmd.ExecuteNonQuery(); // execute the insertion command
            //TODO
        }//TODO

        public static void removeProduct(Product removeProduct)
        {
            OleDbConnection conn = openConnection();

            string strRemoveProduct = "DELETE FROM Products WHERE ProductId=@ProductId";

            OleDbCommand cmd = new OleDbCommand(strRemoveProduct, conn);
            cmd.Parameters.AddWithValue("@ProductId", removeProduct.getProductId());

            cmd.ExecuteNonQuery(); // execute the insertion command
        }

        public static Product updateProduct(Product updateProduct)
        {
            OleDbConnection conn = openConnection();


            string strUpdateProduct = "UPDATE Products SET ProductName, ProductType, Price, Sale, SalePrice, Description  WHERE ProductId=@ProductId";

            OleDbCommand cmd = new OleDbCommand(strUpdateProduct, conn);
            cmd.Parameters.AddWithValue("@ProductName", updateProduct.getProductName());
            cmd.Parameters.AddWithValue("@ProductType", updateProduct.getProductType());
            cmd.Parameters.AddWithValue("@Price", updateProduct.getPrice());
            cmd.Parameters.AddWithValue("@Sale", updateProduct.isSale());
            cmd.Parameters.AddWithValue("@SalePrice", updateProduct.getSalePrice());
            cmd.Parameters.AddWithValue("@Description", updateProduct.getProductDesc());
            cmd.Parameters.AddWithValue("@CurrentStock", updateProduct.getStock());
            cmd.Parameters.AddWithValue("@ReOrderLevel", updateProduct.getReOrderLevel());
            cmd.Parameters.AddWithValue("@ImageFile", updateProduct.getImageFile());

            cmd.ExecuteNonQuery(); // execute the insertion command

            return updateProduct;
        }



    }

}
