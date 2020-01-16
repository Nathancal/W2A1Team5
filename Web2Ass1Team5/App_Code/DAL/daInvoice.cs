using System;
using System.Collections.Generic;
using System.Data;
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


        public static int createNewInvoice(string invEmail, string invShipMethod, double invSubTotal, double invShipping, double invTotalCost, int discountApplied)
        {
            OleDbConnection conn = openConnection();

            Invoice newInvoice = new Invoice(invEmail, invShipMethod, invSubTotal, invShipping, invTotalCost, discountApplied);

            string strCreateInvoice = "INSERT INTO Invoices(Email, OrderDate, SubTotal, ShipMethod, Shipping, TotalCost,DiscountApplied) " +
                "VALUES(@Email, @OrderDate, @SubTotal, @ShipMethod, @Shipping, @TotalCost, @DiscountApplied)";

            OleDbCommand cmdInsert = new OleDbCommand(strCreateInvoice, conn);

            cmdInsert.Parameters.AddWithValue("@Email", newInvoice.getEmail());
            cmdInsert.Parameters.AddWithValue("@OrderDate", DateTime.Now.ToString());
            cmdInsert.Parameters.AddWithValue("@SubTotal", newInvoice.getSubTotal());
            cmdInsert.Parameters.AddWithValue("@ShipMethod", newInvoice.getShipMethod());
            cmdInsert.Parameters.AddWithValue("@Shipping", newInvoice.getShippingCost());
            cmdInsert.Parameters.AddWithValue("@TotalCost", newInvoice.getTotalCost());
            cmdInsert.Parameters.AddWithValue("@DiscountApplied", newInvoice.getDiscountAmount());


            cmdInsert.ExecuteNonQuery(); // execute the insertion command

            cmdInsert.CommandText = "SELECT @@Identity";

            int retInvNum = Convert.ToInt32(cmdInsert.ExecuteScalar());
            closeConnection(conn);


            return retInvNum;
        }

        public static DataSet returnUserInvoices(int userId) {
           
            OleDbConnection conn = openConnection();

            DataSet dsInvoices = new DataSet();


            string strCreateInvoice = "SELECT * FROM Invoices WHERE Email=@Email";

            //data adapter is bridge between database and dataset
            OleDbDataAdapter daInvoices = new OleDbDataAdapter(strCreateInvoice, conn);

            //populate the data table in the dataset 
            //with records from the database table
            daInvoices.Fill(dsInvoices, "Invoices");

            conn.Close();

            return dsInvoices;
        
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
                double shipping = Convert.ToDouble(invReader["Shipping"]);
                double totalCost = Convert.ToDouble(invReader["TotalCost"]);
                int discountApplied = Convert.ToInt32(invReader["DiscountApplied"]);

                invObject = new Invoice(invoiceNum, email, shipMethod, subTotal, shipping, totalCost, discountApplied);
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
                double shipping = Convert.ToDouble(FindInvReader["Shipping"]);
                double totalCost = Convert.ToDouble(FindInvReader["TotalCost"]);
                int discountApplied = Convert.ToInt32(FindInvReader["DiscountApplied"]);


                findInvObject = new Invoice(invoiceNum, email, shipMethod, subTotal, shipping, totalCost, discountApplied);
            }

            FindInvReader.Close();
            closeConnection(conn);

            return findInvObject;
        }

        public static void createOrderItem(CartItem item, int intInvoiceNum)
        {
            OleDbConnection conn = openConnection();
            double lineTotal = item.getProdQuantity() * item.getProdPrice();


            string strSQL = "INSERT INTO Orders(InvoiceNum, ProductId, Quantity, TotalItemCost)" +
                           " VALUES(@InvoiceNum, @ProductId, @Quantity, @TotalItemCost)";

            OleDbCommand cmd = new OleDbCommand(strSQL, conn);

            cmd.Parameters.AddWithValue("@InvoiceNum", intInvoiceNum);
            cmd.Parameters.AddWithValue("@ProductId", item.getProdId());
            cmd.Parameters.AddWithValue("@Quantity", item.getProdQuantity());
            cmd.Parameters.AddWithValue("@TotalItemCost", lineTotal);

            cmd.ExecuteNonQuery();
            closeConnection(conn);
        } //createOrderItem
    }
}