using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.OleDb;
using W2A1Team5.App_Code.BLL;


namespace W2A1Team5.App_Code.DAL
{
    public class daCartItem
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

        public static void createOrderItem(CartItem item, int invoiceNum)
        {
            OleDbConnection conn = openConnection();

            double totalItemCost = item.getProdQuantity() * item.getProdPrice();

            string strInsertOrderItems = "INSERT INTO Orders(InvoiceNum, ProductId, Quantity, TotalItemCost)" +
                                         "VALUES(@InvoiceNum, @ProductId, @Quantity, @TotalItemCost)";

            OleDbCommand cmdInsert = new OleDbCommand(strInsertOrderItems, conn);
            cmdInsert.Parameters.AddWithValue("@InvoiceNum", invoiceNum);
            cmdInsert.Parameters.AddWithValue("@ProductId", item.getProdId());
            cmdInsert.Parameters.AddWithValue("@Quantity", item.getProdQuantity());
            cmdInsert.Parameters.AddWithValue("@TotalItemCost", totalItemCost);

            cmdInsert.ExecuteNonQuery();
            closeConnection(conn);

        }




    }
}