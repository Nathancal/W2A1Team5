using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using Web2Ass1Team5.App_Code.BLL;

namespace Web2Ass1Team5.App_Code.DAL
{
    public class daDiscountCode
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

        public static DataSet getDiscountCodes()
        {
            OleDbConnection conn = openConnection();

            DataSet dsProds = new DataSet();

            string strSQL = "SELECT * FROM DiscountCodes";

            //data adapter is bridge between database and dataset
            OleDbDataAdapter daProds = new OleDbDataAdapter(strSQL, conn);

            //populate the data table in the dataset 
            //with records from the database table
            daProds.Fill(dsProds, "DiscountCodes");

            conn.Close();

            return dsProds;
        }//getProducts


        public static DiscountCode checkCodeExists(string code)
        {

            OleDbConnection conn = openConnection();

            Boolean isActive = true;
            string strCheckCodeExists = "SELECT * FROM DiscountCodes WHERE Code=@Code AND isActive=@isActive";
            OleDbCommand cmdCheckCode = new OleDbCommand(strCheckCodeExists, conn);

            cmdCheckCode.Parameters.AddWithValue("@Code", code);
            cmdCheckCode.Parameters.AddWithValue("@isActive", isActive);

            OleDbDataReader checkExistsReader = cmdCheckCode.ExecuteReader();

            DiscountCode discCode = new DiscountCode();

            if (checkExistsReader.Read())
            {
                discCode.setCode(Convert.ToString(checkExistsReader["Code"]));


            }


            return discCode;
        }

        public static void createNewDiscountCode(string code, DateTime dateActive, DateTime dateEnd, int discountPerc, Boolean isActive)
        {
            OleDbConnection conn = openConnection();

            DiscountCode createNewDiscCode = new DiscountCode(code, dateActive, dateEnd, discountPerc, isActive);

            string strNewCode = "INSERT INTO DiscountCodes(Code, DateFrom, DateTo, DiscountPerc, isActive)" +
                           " VALUES(@Code, @DateFrom, @DateTo, @DiscountPerc, @isActive)";

            //create the command object using the SQL
            OleDbCommand cmd = new OleDbCommand(strNewCode, conn);

            cmd.Parameters.AddWithValue("@Code", createNewDiscCode.getCode());
            cmd.Parameters.AddWithValue("@DateFrom", createNewDiscCode.getDateActive());
            cmd.Parameters.AddWithValue("@DateTo", createNewDiscCode.getDateEnd());
            cmd.Parameters.AddWithValue("@DiscountPerc", createNewDiscCode.getDiscountPerc());
            cmd.Parameters.AddWithValue("@isActive", Convert.ToInt32(createNewDiscCode.checkIsActive()));

            cmd.ExecuteNonQuery(); // execute the insertion command
        }


        public static int redeemDiscountCode(string code, int userId)
        {
            OleDbConnection conn = openConnection();

            DiscountCode redeemCode = new DiscountCode();

            redeemCode.setCode(code);

            Users redeemUser = new Users();

            redeemUser.setUserId(userId);

            string strCheckForRedeemedCode = "SELECT * FROM RedeemCode WHERE UserId=@UserId AND DiscountCodeId=@DiscountCodeId";

            OleDbCommand cmdSelect = new OleDbCommand(strCheckForRedeemedCode, conn);

            cmdSelect.Parameters.AddWithValue("@UserId", redeemUser.getUserId());
            cmdSelect.Parameters.AddWithValue("@DiscountCodeId", redeemCode.getCode());
            OleDbDataReader codeReader = cmdSelect.ExecuteReader();

            if (codeReader.Read())
            {
                return 0;

            }
            else
            {
                codeReader.Close();
                string strRedeemCode = "INSERT INTO RedeemCode(UserId, DiscountCodeId) VALUES(@UserId, @DiscountCodeId)";
                OleDbCommand cmdRedeemCode = new OleDbCommand(strRedeemCode, conn);

                cmdRedeemCode.Parameters.AddWithValue("@UserId", redeemUser.getUserId());
                cmdRedeemCode.Parameters.AddWithValue("@DiscountCodeId", redeemCode.getCode());

                cmdRedeemCode.ExecuteNonQuery();

                return 1;
            }
        }

        public static void deactivateDiscountCode(string code)
        {
            OleDbConnection conn = openConnection();

            int isActive = 0;

            string strRemoveCode = "UPDATE DiscountCodes SET isActive= @isActive WHERE Code=@Code";

            OleDbCommand cmd = new OleDbCommand(strRemoveCode, conn);

            cmd.Parameters.AddWithValue("@Code", code);
            cmd.Parameters.AddWithValue("@isActive", isActive);

            cmd.ExecuteNonQuery(); // execute the insertion command
        }

        public static void updateDiscountCode(string discCode, DateTime dateStart, DateTime dateEnd, int discountPerc, Boolean isActive)
        {
            OleDbConnection conn = openConnection();


            string strUpdateDiscount = "UPDATE DiscountCodes SET  Code=@Code, DateFrom=@DateFrom, DateTo=@DateTo, DiscountPerc= @DiscountPerc, isActive= @isActive WHERE Code=@Code";
            OleDbCommand cmdUpdate = new OleDbCommand(strUpdateDiscount, conn);
            cmdUpdate.Parameters.AddWithValue("@Code", discCode);
            cmdUpdate.Parameters.AddWithValue("@DateFrom", dateStart);
            cmdUpdate.Parameters.AddWithValue("@DateTo", dateEnd);
            cmdUpdate.Parameters.AddWithValue("@DiscountPerc", discountPerc);
            cmdUpdate.Parameters.AddWithValue("@isActive", isActive);
            cmdUpdate.ExecuteNonQuery(); // execute the insertion command




        }

        public static DiscountCode selectDiscountCode(string discCode)
        {

            DiscountCode tempDiscCode = new DiscountCode();

            OleDbConnection conn = openConnection();

            string searchCode = discCode;

            OleDbCommand cmd;

            string strSearchProduct = "SELECT * FROM DiscountCodes WHERE Code= @Code ";

            cmd = new OleDbCommand(strSearchProduct, conn);

            cmd.Parameters.AddWithValue("@Code", searchCode);

            OleDbDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {


                tempDiscCode.setCode(reader["Code"].ToString());
                tempDiscCode.setDateActive(Convert.ToDateTime(reader["DateFrom"]));
                tempDiscCode.setDateEnd(Convert.ToDateTime(reader["DateTo"]));
                tempDiscCode.setDiscountPerc(Convert.ToInt32(reader["DiscountPerc"]));
            }//while

            reader.Close();
            closeConnection(conn);

            return tempDiscCode;
        }//getProduct

        public static DiscountCode randomDiscountCode(int userId) {

            OleDbConnection conn = openConnection();

            DiscountCode generatedDiscountCode = new DiscountCode();


            DiscountCode checkingCode = new DiscountCode();

            OleDbDataReader codeReader;
            do
            {
                OleDbCommand cmd;

                string strRandomDiscountCode = "SELECT TOP 1 * FROM DiscountCodes ORDER BY RND(-(100000*ID))";

                cmd = new OleDbCommand(strRandomDiscountCode, conn);


                OleDbDataReader readerRandom = cmd.ExecuteReader();
                
                while (readerRandom.Read())
                {
                    generatedDiscountCode.setCode(readerRandom["Code"].ToString());

                }//while

                readerRandom.Close();


                Users redeemUserCheck = new Users();

                redeemUserCheck.setUserId(userId);

                string strCheckForRedeemedCode = "SELECT * FROM RedeemCode WHERE UserId=@UserId AND DiscountCodeId=@DiscountCodeId";

                OleDbCommand cmdSelect = new OleDbCommand(strCheckForRedeemedCode, conn);


                cmdSelect.Parameters.AddWithValue("@UserId", redeemUserCheck.getUserId());
                cmdSelect.Parameters.AddWithValue("@DiscountCodeId", generatedDiscountCode.getCode());
                codeReader = cmdSelect.ExecuteReader();

                if (codeReader.Read() == true) {

                    while (codeReader.Read())
                    {


                        checkingCode.setCode(readerRandom["Code"].ToString());
                        checkingCode.setDateActive(Convert.ToDateTime(readerRandom["DateFrom"]));
                        checkingCode.setDateEnd(Convert.ToDateTime(readerRandom["DateTo"]));
                        checkingCode.setDiscountPerc(Convert.ToInt32(readerRandom["DiscountPerc"]));
                    }//while

                }
                else
                {
                    return generatedDiscountCode;

                }
             
           } while(generatedDiscountCode.getCode() == checkingCode.getCode());

            return generatedDiscountCode;

        }


    }
}
