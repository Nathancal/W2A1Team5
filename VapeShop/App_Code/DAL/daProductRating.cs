using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.OleDb;
using VapeShop.App_Code.BLL;

namespace VapeShop.App_Code.DAL
{
    public class daProductRating
    {

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

        public static int createNewRating(int productId, int rating, int userId, string userIp, string ratingDesc, DateTime dateSub)
        {
            OleDbConnection conn = openConnection();

            string strNewRating = "INSERT INTO ProductsRatings(ProductId, " +
                           " UserId, Rating, DateSubmitted, UserIP, RatingDesc)" +
                           " VALUES('" + productId + "', '" + userId + "'," +
                            rating + ",'" + dateSub + "',"
                            + userIp + ", " + ratingDesc + ")";

            //create the command object using the SQL
            OleDbCommand cmd = new OleDbCommand(strNewRating, conn);

            cmd.ExecuteNonQuery(); // execute the insertion command

            //change the SQL to return the new product rating
            cmd.CommandText = "Select @@Identity";
            //TODO

            int ratingNum = Convert.ToInt32(cmd.ExecuteScalar());

            closeConnection(conn); // close connection
            return ratingNum;
        }

        public static ProductRating updateRating(int ratingId, int rating, string ratingDesc)
        {
            OleDbConnection conn = openConnection();

            string strUpdateRating = "UPDATE ProductRatings SET Rating='" + rating + "'," + "RatingDesc='" + ratingDesc + "' WHERE ID='" + ratingId + "'";

            OleDbCommand cmdUpdate = new OleDbCommand(strUpdateRating, conn);
            cmdUpdate.ExecuteNonQuery(); // execute the insertion command

            string strRetrieveUpdate = "SELECT * FROM ProductsRating WHERE ID='" + ratingId + "'";

            OleDbCommand cmdSelect = new OleDbCommand(strRetrieveUpdate, conn);
            OleDbDataReader ratingReader = cmdSelect.ExecuteReader();
            ProductRating ratingObject = null;

            while (ratingReader.Read())
            {
                int rId = Convert.ToInt32(ratingReader["ID"]);
                int productId = Convert.ToInt32(ratingReader["ProductId"]);
                int rate = Convert.ToInt32(ratingReader["Rating"]);
                int userId = Convert.ToInt32(ratingReader["UserId"]);
                DateTime dateSub = Convert.ToDateTime(ratingReader["DateSubmitted"]);
                string userIp = ratingReader["UserIP"].ToString();
                string rDesc = ratingReader["RatingDesc"].ToString();

                ratingObject = new ProductRating(productId, userId, rating, userIp, rDesc, dateSub);
            }
            return ratingObject;
        }
    }
}