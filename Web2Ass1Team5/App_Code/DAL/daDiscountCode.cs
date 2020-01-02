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

            int isActive = 1;
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

        public static void createNewDiscountCode(string code, DateTime dateActive, DateTime dateEnd, int discountPerc)
        {
            OleDbConnection conn = openConnection();

            string strNewCode = "INSERT INTO DiscountCodes(Code, DateFrom, DateTo, DiscountPerc)" +
                           " VALUES(@Code, @DateFrom, @DateTo, @DiscountPerc)";

            //create the command object using the SQL
            OleDbCommand cmd = new OleDbCommand(strNewCode, conn);

            cmd.Parameters.AddWithValue("@Code", code);
            cmd.Parameters.AddWithValue("@DateFrom", dateActive);
            cmd.Parameters.AddWithValue("@DateTo", dateEnd);
            cmd.Parameters.AddWithValue("@DiscountPerc", discountPerc);

            cmd.ExecuteNonQuery(); // execute the insertion command
        }


        public static int redeemDiscountCode(string code, int userId, DateTime usedOn)
        {
            OleDbConnection conn = openConnection();

            string strCheckForRedeemedCode = "SELECT * FROM RedeemCode WHERE UserId=@UserId AND DiscountCode=@DiscountCode";

            OleDbCommand cmdSelect = new OleDbCommand(strCheckForRedeemedCode, conn);

            cmdSelect.Parameters.AddWithValue("@UserId", userId);
            cmdSelect.Parameters.AddWithValue("@DiscountCode", code);
            OleDbDataReader codeReader = cmdSelect.ExecuteReader();

            if (codeReader.Read())
            {
                DateTime dateUsed = Convert.ToDateTime(codeReader["UsedOn"]);
                return 0;
            }
            else
            {
                string strRedeemCode = "INSERT INTO RedeemCode(UserId, DiscountCode, UsedOn) VALUES(@UserId, @DiscountCode, @UsedOn)";
                OleDbCommand cmdRedeemCode = new OleDbCommand(strRedeemCode, conn);

                cmdRedeemCode.Parameters.AddWithValue("@UserId", userId);
                cmdRedeemCode.Parameters.AddWithValue("@DiscountCode", code);
                cmdRedeemCode.Parameters.AddWithValue("@UsedOn", usedOn);

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

        public static DiscountCode updateDiscountCode(string discCode, DateTime dateEnd, int discountPerc)
        {
            OleDbConnection conn = openConnection();


            string strUpdateDiscount = "UPDATE DisocuntCodes SET DateTo= @DateTo, DiscountPerc= @DiscountPerc WHERE Code=@Code";
            OleDbCommand cmdUpdate = new OleDbCommand(strUpdateDiscount, conn);
            cmdUpdate.Parameters.AddWithValue("@DateTo", dateEnd);
            cmdUpdate.Parameters.AddWithValue("@DiscountPerc", discountPerc);
            cmdUpdate.Parameters.AddWithValue("@Code", discCode);
            cmdUpdate.ExecuteNonQuery(); // execute the insertion command

            string strRetrieveUpdate = "SELECT * FROM DiscountCodes WHERE Code=@Code";

            OleDbCommand cmdSelect = new OleDbCommand(strRetrieveUpdate, conn);
            cmdSelect.Parameters.AddWithValue("@Code", discCode);

            OleDbDataReader disocuntReader = cmdSelect.ExecuteReader();
            DiscountCode disCodeObject = null;

            while (disocuntReader.Read())
            {
                string code = disocuntReader["Code"].ToString();
                DateTime dateActive = Convert.ToDateTime(disocuntReader["DateFrom"]);
                DateTime dateTo = Convert.ToDateTime(disocuntReader["DateTo"]);
                int discPerc = Convert.ToInt32(disocuntReader["UserId"]);


                disCodeObject = new DiscountCode(code, dateActive, dateTo, discPerc);
            }

            return disCodeObject;


        }
    }
}