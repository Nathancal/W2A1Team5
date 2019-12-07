﻿using System;
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

            string strSQL = "INSERT INTO ProductsRatings(ProductId, " +
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

        public static void createNewDiscountCode(string code, DateTime dateActive, DateTime dateEnd, int discountPerc)
        {
            OleDbConnection conn = openConnection();

            string strNewCode = "INSERT INTO DiscountCodes(Code, " +
                           " DateFrom, DateTo, NumberUsed, DiscountPerc)" +
                           " VALUES('" + code + "', '" + dateActive + "'," +
                            dateEnd + ",'" + discountPerc + ")";

            //create the command object using the SQL
            OleDbCommand cmd = new OleDbCommand(strNewCode, conn);

            cmd.ExecuteNonQuery(); // execute the insertion command
        } //Create a new discount code
        
        
        public static DiscountCode redeemDiscountCode(string pCode) {
            OleDbConnection conn = openConnection();
            
            string strRedeemCode = "SELECT * FROM DiscountCodes WHERE Code='" + pCode + "'" +
                                   "' AND isActive='" + 1 + "'";

            OleDbCommand cmdSelect = new OleDbCommand(strRedeemCode, conn);
            OleDbDataReader codeReader = cmdSelect.ExecuteReader();

            DiscountCode redeemCode = null;

            while (codeReader.Read()){
                string code = codeReader["Code"].ToString();
                DateTime dateActive = Convert.ToDateTime(codeReader["DateFrom"]);
                DateTime dateEnd = Convert.ToDateTime(codeReader["DateTo"]);
                int discountPerc = Convert.ToInt32(codeReader["DiscountPerc"]);


                redeemCode = new DiscountCode(code, dateActive, dateEnd, discountPerc);
            }

            return redeemCode;
        }

        public static void removeDiscountCode(string pCode) {
            OleDbConnection conn = openConnection();

            string strRedeemCode = "DELETE FROM DiscountCodes WHERE Code='" + pCode + "'" +



        }

        public static void sendMessage(int creatorId,  string subject, string messageBody, DateTime createDate, int parentId, string recepUsername) {
            OleDbConnection conn = openConnection();

            int recepId;

            string strInsertMessage = "INSERT INTO Message(CreatorId, " +
                           " , Subject, MessageBody, CreateDate, ParentMessageId)" +
                           " VALUES('" + creatorId + "', '" + subject + "'," +
                            messageBody + ",'" + createDate + ",'" + parentId + ")";

            //create the command object using the SQL
            OleDbCommand cmdInsert = new OleDbCommand(strInsertMessage, conn);

            cmdInsert.ExecuteNonQuery(); // execute the insertion command

            cmdInsert.CommandText = "Select @@Identity";

            int msgId = Convert.ToInt32(cmdInsert.ExecuteScalar());

            string strReadRecepId = "select ID FROM Users WHERE Username='" +
                                         recepUsername + "'";

            OleDbCommand cmd = new OleDbCommand(strReadRecepId, conn);
            OleDbDataReader recepIdReader = cmd.ExecuteReader();

            recepId = Convert.ToInt32(recepIdReader["UserId"]);
                       
            string strInsertRecep = "INSERT INTO MessageRecipient(RecipientId " +
                                    "MessageId)" +
                                    " VALUES('" + recepId + "', '" + msgId + ")";

           
            recepIdReader.Close();
            closeConnection(conn);

        }//TODO NEEDS FINISHED

        public static DataSet getMessages() {
            OleDbConnection conn = openConnection();
            //create dataset (virtual database)
            DataSet dsMessages = new DataSet();

            string strGetMessages = "SELECT Message.ID, Message.CreatorId, Message.MessageBody, Message.CreateDate, " +
                                    "MessageRecipient.RecipientId, MessageRecipient.isRead FROM Message" +
                                    "FROM Message" +
                                    "INNER JOIN MessageRecipient ON Message.ID = MessageRecipient.MessageId";

            //data adapter is bridge between database and dataset
            OleDbDataAdapter daMessages = new OleDbDataAdapter(strGetMessages, conn);

            //populate the data table in the dataset 
            //with records from the database table
            daMessages.Fill(dsMessages, "Message");

            closeConnection(conn);

            return dsMessages;
        }

        public static int getUnreadMessageCount(int pUserId) {

            OleDbConnection conn = openConnection();

            string strGetMessageCount = "select COUNT(isRead) FROM MessageRecipient WHERE RecipientId='"
                            + pUserId + "' AND isRead='" + 0 + "'";

            OleDbCommand cmd = new OleDbCommand(strGetMessageCount, conn);

            int countMessages = Convert.ToInt32(cmd.ExecuteScalar());
            closeConnection(conn);

            return countMessages;

        }

        public static Message ViewMessage(int msgId){
            OleDbConnection conn = openConnection();
            string strMessageViewedUpdate = "UPDATE MessageRecipient SET isRead= 1 WHERE MessageId='" + msgId + "'";
            //create the command object using the SQL
            OleDbCommand cmdUpdate= new OleDbCommand(strMessageViewedUpdate, conn);
            cmdUpdate.ExecuteNonQuery(); // execute the insertion command

            string strRetrieveMessage = "SELECT * FROM Message WHERE ID='" + msgId + "'";                       

            OleDbCommand cmdSelect = new OleDbCommand(strRetrieveMessage, conn);
            OleDbDataReader messageReader = cmdSelect.ExecuteReader();
            Message msgObject = null;
    
            while (messageReader.Read()){
                int messageId= Convert.ToInt32(messageReader["ID"]);
                int creatorId = Convert.ToInt32(messageReader["CreatorId"]);
                string subject = messageReader["Subject"].ToString();
                string messageBody = messageReader["MessageBody"].ToString();
                DateTime createDate = Convert.ToDateTime(messageReader["CreateDate"]);
                int parentMsgId = Convert.ToInt32(messageReader["ParentMessageId"]);

                cmdSelect.CommandText = "SELECT RecipientId FROM MessageRecipient WHERE MessageId='" + msgId + "'";
                messageReader = cmdSelect.ExecuteReader();

                while (messageReader.Read())
                {
                    int recepId = Convert.ToInt32(messageReader["RecipientId"]);
                    msgObject = new Message(messageId, creatorId, subject, messageBody, createDate, parentMsgId, recepId);
                }
            }

            messageReader.Close();
            closeConnection(conn);

            return msgObject;
        }

        public static Users verifyLogin(string username, string pWord) {
            OleDbConnection conn = openConnection();
            string strSQL = "select * FROM Users WHERE Username='" +
                                         username + "' AND Password='" + pWord + "'";

            OleDbCommand cmd = new OleDbCommand(strSQL, conn);
            OleDbDataReader reader = cmd.ExecuteReader();
            Users userObject = null;

            while (reader.Read()){
                int userId = Convert.ToInt32(reader["UserId"]);
                string firstName = reader["First Name"].ToString();
                string surname = reader["Surname"].ToString();
                DateTime dob = Convert.ToDateTime(reader["Date Of Birth"]);
                string address = reader["Address"].ToString();
                string city = reader["City"].ToString();
                string county = reader["County"].ToString();
                string country = reader["Country"].ToString();
                string postCode = reader["PostCode"].ToString();
                string accessLevel = reader["AccessLevel"].ToString();
                string userName = reader["Username"].ToString();
                string passWord = reader["Password"].ToString();

                userObject = new Users(userId, firstName, surname, dob, address,
                                                    city, county, country, postCode, accessLevel, userName, passWord);
            }

            reader.Close();
            closeConnection(conn);
            return userObject;
        }
    }
}