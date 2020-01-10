using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using Web2Ass1Team5.App_Code.BLL;

namespace Web2Ass1Team5.App_Code.DAL
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
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
                catch (Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
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


        public static DataSet getRatingsForProduct(int productId)
        {
            OleDbConnection conn = openConnection();

            DataSet dsRatings = new DataSet();

            int storeProductId = productId;

            string strGetRatingInformation = "SELECT ProductsRatings.UserId, ProductsRatings.DateSubmitted, ProductsRatings.Rating, ProductsRatings.RatingDesc, Users.FirstName, Users.Surname, Users.Country, " +
                                            "Products.ProductName, Products.ProductType FROM (ProductsRatings " +
                                            "INNER JOIN Products ON ProductsRatings.ProductId = Products.ProductId) " +
                                            "INNER JOIN Users ON ProductsRatings.UserId = Users.UserId " +
                                            "WHERE ProductsRatings.ProductId=@ProductId " +
                                            "ORDER BY ProductsRatings.DateSubmitted DESC";


            //data adapter is bridge between database and dataset
            OleDbDataAdapter daRatings = new OleDbDataAdapter(strGetRatingInformation, conn);

            daRatings.SelectCommand.Parameters.AddWithValue("@ProductId", storeProductId);

            //populate the data table in the dataset 
            //with records from the database table
            daRatings.Fill(dsRatings, "ProductsRatings");
            daRatings.Fill(dsRatings, "Users");
            daRatings.Fill(dsRatings, "Products");



            closeConnection(conn);

            return dsRatings;


        }


        public static ProductRating createNewRating(int productId, int rating, int userId, string ratingDesc)
        {
            OleDbConnection conn = openConnection();

            ProductRating newRating = new ProductRating(productId, rating, userId, ratingDesc);

            string strNewRating = "INSERT INTO ProductsRatings(ProductId,UserId, Rating,DateSubmitted, RatingDesc) VALUES(@ProductId,@UserId, @Rating,@DateSub,@RatingDesc)";

            //create the command object using the SQL
            OleDbCommand cmd = new OleDbCommand(strNewRating, conn);

            cmd.Parameters.AddWithValue("@ProductId", newRating.getProductId());
            cmd.Parameters.AddWithValue("@UserId", newRating.getUserId());
            cmd.Parameters.AddWithValue("@Rating", newRating.getRating());
            cmd.Parameters.AddWithValue("@DateSub", DateTime.Now.ToString());
            cmd.Parameters.AddWithValue("@RatingDesc", newRating.getRatingDesc());
            cmd.ExecuteNonQuery(); // execute the insertion command

            closeConnection(conn); // close connection

            return newRating;
        }

        public static void removeRatingById(int ratingId)
        {
            OleDbConnection conn = openConnection();

            int ratingToRemove = ratingId;

            string removeRating = "DELETE FROM ProductsRatings WHERE ID=@RatingId";

            //create the command object using the SQL
            OleDbCommand cmd = new OleDbCommand(removeRating, conn);

            cmd.Parameters.AddWithValue("@RatingId", ratingToRemove);
            cmd.ExecuteNonQuery();
            closeConnection(conn);

        }

        public static void removeRatingByUserAndProduct(int productId, int passUserId)
        {
            OleDbConnection conn = openConnection();

            int prodId = productId;
            int userId = passUserId;

            string removeRating = "DELETE FROM ProductsRatings WHERE ProductId=@ProductId AND UserId= @UserId";

            OleDbCommand cmd = new OleDbCommand(removeRating, conn);

            cmd.Parameters.AddWithValue("@ProductId", prodId);
            cmd.Parameters.AddWithValue("@UserId", userId);

            cmd.ExecuteNonQuery();
            closeConnection(conn);
        }


        public static ProductRating returnRating(int productId, int userId)
        {
            OleDbConnection conn = openConnection();

            int storeProductId = productId;
            int storeUserId = userId;

            string strRetrieveUpdate = "SELECT * FROM ProductsRatings WHERE ProductId=@ProductId AND UserId=@UserId";

            OleDbCommand cmdCheckRating = new OleDbCommand(strRetrieveUpdate, conn);

            cmdCheckRating.Parameters.AddWithValue("@ProductId", storeProductId);
            cmdCheckRating.Parameters.AddWithValue("@UserId", storeUserId);

            OleDbDataReader ratingReader = cmdCheckRating.ExecuteReader();

            ProductRating checkIfProductRated = null;

            while (ratingReader.Read())
            {
                checkIfProductRated = new ProductRating();

                checkIfProductRated.setRatingId(Convert.ToInt32(ratingReader["ID"]));
                checkIfProductRated.setProductId(Convert.ToInt32(ratingReader["ProductId"]));
                checkIfProductRated.setUserId(Convert.ToInt32(ratingReader["UserId"]));
                checkIfProductRated.setRating(Convert.ToInt32(ratingReader["Rating"]));
                checkIfProductRated.setDateSubmitted(Convert.ToDateTime(ratingReader["DateSubmitted"]));
                checkIfProductRated.setRatingDescription(ratingReader["RatingDesc"].ToString());

            }

            return checkIfProductRated;

        }


        public static ProductRating updateRating(int ratingId, int rating, string ratingDesc)
        {
            OleDbConnection conn = openConnection();

            string strUpdateRating = "UPDATE ProductRatings SET Rating=@Rating RatingDesc=@RatingDesc WHERE ID=@RatingId";

            OleDbCommand cmdUpdate = new OleDbCommand(strUpdateRating, conn);

            cmdUpdate.Parameters.AddWithValue("@Rating", rating);
            cmdUpdate.Parameters.AddWithValue("@RatingDesc", ratingDesc);
            cmdUpdate.Parameters.AddWithValue("@RatingId", ratingId);
            cmdUpdate.ExecuteNonQuery(); // execute the insertion command

            string strRetrieveUpdate = "SELECT * FROM ProductsRatings WHERE ID=@RatingId";

            OleDbCommand cmdSelect = new OleDbCommand(strRetrieveUpdate, conn);
            cmdSelect.Parameters.AddWithValue("@RatingId", ratingId);

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

                ratingObject = new ProductRating(productId, userId, rating, rDesc, dateSub);
            }
            return ratingObject;
        }
    }
}