using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.OleDb;
using VapeShop.App_Code.BLL;

namespace VapeShop.App_Code.DAL
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
        }

        public static DiscountCode redeemDiscountCode(string pCode)
        {
            OleDbConnection conn = openConnection();

            string strRedeemCode = "SELECT * FROM DiscountCodes WHERE Code='" + pCode + "'" +
                                   "' AND isActive='" + 1 + "'";

            OleDbCommand cmdSelect = new OleDbCommand(strRedeemCode, conn);
            OleDbDataReader codeReader = cmdSelect.ExecuteReader();

            DiscountCode redeemCode = null;

            while (codeReader.Read())
            {
                string code = codeReader["Code"].ToString();
                DateTime dateActive = Convert.ToDateTime(codeReader["DateFrom"]);
                DateTime dateEnd = Convert.ToDateTime(codeReader["DateTo"]);
                int discountPerc = Convert.ToInt32(codeReader["DiscountPerc"]);


                redeemCode = new DiscountCode(code, dateActive, dateEnd, discountPerc);
            }

            return redeemCode;
        }

        public static void removeDiscountCode(string pCode)
        {
            OleDbConnection conn = openConnection();

            string strRemoveCode = "DELETE FROM DiscountCodes WHERE Code='" + pCode + "'";

            OleDbCommand cmd = new OleDbCommand(strRemoveCode, conn);

            cmd.ExecuteNonQuery(); // execute the insertion command
        }

        public static DiscountCode updateDiscountCode(string pCode, DateTime pDateEnd, int pDiscountPerc)
        {
            OleDbConnection conn = openConnection();


            string strUpdateDiscount = "UPDATE DisocuntCodes SET DateTo='" + pDateEnd + "'," + "DiscountPerc='" + pDiscountPerc + "' WHERE Code='" + pCode + "'";
            OleDbCommand cmdUpdate = new OleDbCommand(strUpdateDiscount, conn);
            cmdUpdate.ExecuteNonQuery(); // execute the insertion command

            string strRetrieveUpdate = "SELECT * FROM DiscountCodes WHERE ID='" + pCode + "'";

            OleDbCommand cmdSelect = new OleDbCommand(strRetrieveUpdate, conn);
            OleDbDataReader disocuntReader = cmdSelect.ExecuteReader();
            DiscountCode disCodeObject = null;

            while (disocuntReader.Read())
            {
                string code = disocuntReader["Code"].ToString();
                DateTime dateActive = Convert.ToDateTime(disocuntReader["DateFrom"]);
                DateTime dateEnd = Convert.ToDateTime(disocuntReader["DateTo"]);
                int userId = Convert.ToInt32(disocuntReader["UserId"]);


                disCodeObject = new DiscountCode();
            }

            return disCodeObject;


        }
    }
}