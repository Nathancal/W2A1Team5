using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.OleDb;
using VapeShop.App_Code.BLL;


namespace VapeShop.App_Code.DAL
{
    public class daLogin
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

        public static Users verifyLogin(string username, string pWord)
        {
            OleDbConnection conn = openConnection();
            string strSQL = "select * FROM Users WHERE Username='" +
                                         username + "' AND Password='" + pWord + "'";

            OleDbCommand cmd = new OleDbCommand(strSQL, conn);
            OleDbDataReader reader = cmd.ExecuteReader();
            Users userObject = null;

            while (reader.Read())
            {

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
                string userIp = reader["UserIp"].ToString();


                userObject = new Users(userId, firstName, surname, dob, address,
                                                    city, county, country, postCode, accessLevel, userName, passWord, userIp);
            }

            reader.Close();
            closeConnection(conn);
            return userObject;
        }
    }
}