using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.OleDb;
using VapeShop.App_Code.BLL;

namespace VapeShop.App_Code.DAL
{
    public class DataAccess
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
            //create dataset (virtual database)
            DataSet dsProds = new DataSet();

            string strSQL = "SELECT * FROM Products";

            //data adapter is bridge between database and dataset
            OleDbDataAdapter daProds = new OleDbDataAdapter(strSQL, conn);

            //populate the data table in the dataset 
            //with records from the database table
            daProds.Fill(dsProds, "dtProducts");

            conn.Close();

            return dsProds;
        }//getProducts

        public static Product getProduct(int pProductID)
        {
            Product tempProd = new Product();

            OleDbConnection conn = openConnection();

            string strSQL = "select * FROM Products WHERE ProductId='"
                            + pProductID + "'";

            OleDbCommand cmd = new OleDbCommand(strSQL, conn);

            OleDbDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                tempProd.setProductId(Convert.ToInt32(reader["ProductId"]));
                tempProd.setProductName(reader["ProductName"].ToString());
                tempProd.setProductType(reader["ProductType"].ToString());
                tempProd.setProductDesc(reader["Description"].ToString());
                tempProd.setPrice(Convert.ToInt32(reader["Price"]));
                tempProd.setIsSale(reader["Sale"].Equals("Sale"));
                tempProd.setSalePrice(Convert.ToDouble(reader["SalePrice"]));
                tempProd.setStock(Convert.ToInt32(reader["Stock"]));
                tempProd.setReOrdeLevel(Convert.ToInt32(reader["ReOrderLevel"]));
                tempProd.setImageFile(reader["ImageFile"].ToString());
            
            }//while

            reader.Close();
            closeConnection(conn);

            return tempProd;
        }//getProduct

        public static void createNewProduct(string prodName, string prodType, double price, Boolean sale, double salePrice, string desc, int currentStock, int reOrderLevel, string imageFile) {
            OleDbConnection conn = openConnection();

            string strSQL = "INSERT INTO Product(ProductName, " +
                           " ProductType, Price, Sale, SalePrice, Description, CurrentStock, ReOrderLevel, ImageFile)" +
                           " VALUES('" + prodName + "', '" + prodType + "'," +
                            price + ",'" + sale + "',"
                            + salePrice + ", " + desc +
                            ", "+ currentStock + ", " + reOrderLevel + ", " + imageFile + ")";

            //create the command object using the SQL
            OleDbCommand cmd = new OleDbCommand(strSQL, conn);

            cmd.ExecuteNonQuery(); // execute the insertion command

            //change the SQL to return the new product rating
            cmd.CommandText = "Select @@Identity";
            //TODO
        }//TODO

        public static DataSet getUsers()
        {
            OleDbConnection conn = openConnection();
            //create dataset (virtual database)
            DataSet dsUsers = new DataSet();

            string strSQL = "SELECT * FROM Users";

            //data adapter is bridge between database and dataset
            OleDbDataAdapter daUsers = new OleDbDataAdapter(strSQL, conn);

            //populate the data table in the dataset 
            //with records from the database table
            daUsers.Fill(dsUsers, "dtProducts");

            conn.Close();

            return dsUsers;
        }//get Users

        public static Users getUser(int pUserId)
        {
            Users tempUser = new Users();

            OleDbConnection conn = openConnection();

            string strSQL = "select * FROM Users WHERE UserId='"
                            + pUserId + "'";

            OleDbCommand cmd = new OleDbCommand(strSQL, conn);

            OleDbDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {

                tempUser.setUserId(Convert.ToInt32(reader["UserId"]));
                tempUser.setFirstName(reader["FirstName"].ToString());
                tempUser.setSurname(reader["Surname"].ToString());
                tempUser.setDob(Convert.ToDateTime(reader["Date Of Birth"]));
                tempUser.setAddress(reader["Address"].ToString());
                tempUser.setCity(reader["City"].ToString());
                tempUser.setCounty(reader["County"].ToString());
                tempUser.setCountry(reader["Country"].ToString());
                tempUser.setPostCode(reader["PostCode"].ToString());
                tempUser.setUserAccessLevel(reader["AccessLevel"].ToString());               
            }



            reader.Close();
            closeConnection(conn);

            return tempUser;
        }//get USER


        public static int createNewRating(int productId, int rating, int userId, string userIp, string ratingDesc, DateTime dateSub){
            OleDbConnection conn = openConnection();

            string strSQL = "INSERT INTO Products_Ratings(ProductId, " +
                           " UserId, Rating, DateSubmitted, UserIP, RatingDesc)" +
                           " VALUES('" + productId + "', '" + userId + "'," +
                            rating + ",'" + dateSub + "',"
                            + userIp + ", " + ratingDesc + ")";

            //create the command object using the SQL
            OleDbCommand cmd = new OleDbCommand(strSQL, conn);

            cmd.ExecuteNonQuery(); // execute the insertion command

            //change the SQL to return the new product rating
            cmd.CommandText = "Select @@Identity";
            //TODO

            int ratingNum = Convert.ToInt32(cmd.ExecuteScalar());

            closeConnection(conn); // close connection
            return ratingNum; 
        } //Add a product Rating



    }
}