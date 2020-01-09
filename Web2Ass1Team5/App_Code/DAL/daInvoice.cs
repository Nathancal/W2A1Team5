using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using Web2Ass1Team5.App_Code.BLL;

namespace Web2Ass1Team5.App_Code.DAL
{
    public class daInvoice
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


        public static int createNewInvoice(string email, string shipMethod, DateTime orderDate, double subTotal, double shipping, double totalCost)
        {
            OleDbConnection conn = openConnection();

            string strCreateInvoice = "INSERT INTO Invoices(Email, OrderDate, SubTotal, ShipMethod, Shipping, Total Cost)" +
                              " VALUES(@Email, @OrderDate, @SubTotal, @Shipping, @TotalCost)";

            OleDbCommand cmdInsert = new OleDbCommand(strCreateInvoice, conn);

            cmdInsert.Parameters.AddWithValue("@Email", email);
            cmdInsert.Parameters.AddWithValue("@OrderDate", orderDate);
            cmdInsert.Parameters.AddWithValue("@SubTotal", subTotal);
            cmdInsert.Parameters.AddWithValue("@Shipping", shipping);
            cmdInsert.Parameters.AddWithValue("@TotalCost", totalCost);

            cmdInsert.ExecuteNonQuery(); // execute the insertion command

            cmdInsert.CommandText = "SELECT @@Identity";

            int retInvNum = Convert.ToInt32(cmdInsert.ExecuteScalar());
            closeConnection(conn);


            return retInvNum;
        }


        public static Invoice returnNewInvoice(int invNum)
        {
            OleDbConnection conn = openConnection();

            string strSelectInvoice = "SELECT * FROM Invoices WHERE InvoiceNum=@InvoiceNum";

            OleDbCommand cmdSelect = new OleDbCommand(strSelectInvoice, conn);

            cmdSelect.Parameters.AddWithValue("@InvoiceNum", invNum);


            OleDbDataReader invReader = cmdSelect.ExecuteReader();
            Invoice invObject = null;

            while (invReader.Read())
            {
                int invoiceNum = Convert.ToInt32(invReader["InvoiceNum"]);
                string email = invReader["Email"].ToString();
                DateTime orderDate = Convert.ToDateTime(invReader["OrderDate"]);
                double subTotal = Convert.ToDouble(invReader["SubTotal"]);
                string shipMethod = invReader["ShipMethod"].ToString();
                double shipping = Convert.ToDouble(invReader["ParentMessageId"]);
                double totalCost = Convert.ToDouble(invReader["Total Cost"]);

                cmdSelect.CommandText = "SELECT ProductId, Quantity FROM Orders WHERE InvoiceNum=@InvoiceNum";
                invReader = cmdSelect.ExecuteReader();

                while (invReader.Read())
                {
                    int productId = Convert.ToInt32(invReader["ProductId"]);
                    int quantity = Convert.ToInt32(invReader["Quantity"]);

                    invObject = new Invoice(invoiceNum, email, shipMethod, subTotal, shipping, orderDate, totalCost, productId, quantity);
                }
            }

            invReader.Close();

            return invObject;
        }//TODO finish to allow for the product information to be brought into the invoice also

        public static Invoice findInvoice(string search)
        {

            OleDbConnection conn = openConnection();

            int retInvNum;

            Int32.TryParse(search, out retInvNum);

            string strFindInvoice;
            OleDbCommand cmdSelect;


            if (retInvNum > 0)
            {
                strFindInvoice = "SELECT * FROM Invoices WHERE InvoiceNum= @InvoiceNum";
                cmdSelect = new OleDbCommand(strFindInvoice, conn);

                cmdSelect.Parameters.AddWithValue("@InvoiceNum", retInvNum);
            }
            else
            {
                strFindInvoice = "SELECT * FROM Invoices WHERE Email= @Email";
                cmdSelect = new OleDbCommand(strFindInvoice, conn);

                cmdSelect.Parameters.AddWithValue("@Email", search);
            }

            OleDbDataReader FindInvReader = cmdSelect.ExecuteReader();
            Invoice findInvObject = null;

            while (FindInvReader.Read())
            {
                int invoiceNum = Convert.ToInt32(FindInvReader["InvoiceNum"]);
                string email = FindInvReader["Email"].ToString();
                DateTime orderDate = Convert.ToDateTime(FindInvReader["OrderDate"]);
                double subTotal = Convert.ToDouble(FindInvReader["SubTotal"]);
                string shipMethod = FindInvReader["ShipMethod"].ToString();
                double shipping = Convert.ToDouble(FindInvReader["ParentMessageId"]);
                double totalCost = Convert.ToDouble(FindInvReader["Total Cost"]);

                cmdSelect.CommandText = "SELECT ProductId, Quantity FROM Orders WHERE InvoiceNum='" + invoiceNum + "'";
                FindInvReader = cmdSelect.ExecuteReader();

                while (FindInvReader.Read())
                {
                    int productId = Convert.ToInt32(FindInvReader["ProductId"]);
                    int quantity = Convert.ToInt32(FindInvReader["Quantity"]);

                    findInvObject = new Invoice(invoiceNum, email, shipMethod, subTotal, shipping, orderDate, totalCost, productId, quantity);
                }
            }

            FindInvReader.Close();
            closeConnection(conn);

            return findInvObject;
        }
    }
}