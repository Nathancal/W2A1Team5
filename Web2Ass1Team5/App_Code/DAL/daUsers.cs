using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using Web2Ass1Team5.App_Code.BLL;

namespace Web2Ass1Team5.App_Code.DAL
{
    public class daUsers
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

        public static DataSet getUsers()
        {
            OleDbConnection conn = openConnection();
            //create dataset (virtual database)
            DataSet dsUsers = new DataSet();

            string strSelectUsers = "SELECT * FROM Users";

            //data adapter is bridge between database and dataset
            OleDbDataAdapter daUsers = new OleDbDataAdapter(strSelectUsers, conn);

            //populate the data table in the dataset 
            //with records from the database table
            daUsers.Fill(dsUsers, "Users");

            conn.Close();

            return dsUsers;
        }//get Users

        public static Users getUser(string search)
        {
            Users tempUser = new Users();

            OleDbConnection conn = openConnection();

            int getUserById;
            string strGetUser;
            Int32.TryParse(search, out getUserById);
            OleDbCommand cmd;

            if (getUserById > 0)
            {
                strGetUser = "select * FROM Users WHERE UserId= @UserId";
                cmd = new OleDbCommand(strGetUser, conn);

                cmd.Parameters.AddWithValue("@UserId", getUserById);
            }
            else
            {
                strGetUser = "select * FROM Users WHERE Email= ?";
                cmd = new OleDbCommand(strGetUser, conn);

                cmd.Parameters.AddWithValue("@Email", search);
            }

            OleDbDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                tempUser.setUserId(Convert.ToInt32(reader["UserId"]));
                tempUser.setUsername(reader["Username"].ToString());
                tempUser.setFirstName(reader["FirstName"].ToString());
                tempUser.setSurname(reader["Surname"].ToString());
                tempUser.setDob(Convert.ToString(reader["DateOfBirth"]));
                tempUser.setAddress(reader["Address"].ToString());
                tempUser.setCity(reader["City"].ToString());
                tempUser.setCounty(reader["County"].ToString());
                tempUser.setCountry(reader["Country"].ToString());
                tempUser.setPostCode(reader["PostCode"].ToString());
                tempUser.setUserAccessLevel(reader["AccessLevel"].ToString());
                tempUser.setUserIp(reader["UserIp"].ToString());


            }

            reader.Close();
            closeConnection(conn);

            return tempUser;
        }//get USER

        private static string getUserIp()
        {

            System.Web.HttpContext context = System.Web.HttpContext.Current;
            string ipAddress = context.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];

            if (!string.IsNullOrEmpty(ipAddress))
            {
                string[] addresses = ipAddress.Split(',');
                if (addresses.Length != 0)
                {
                    return addresses[0];
                }
            }

            return context.Request.ServerVariables["REMOTE_ADDR"];
        }

        public static void createNewUser(string username, string userFirstName, string userSurname, string dob, string userAddress, string userCity, string userCounty, string userCountry, string userPostCode, string userAccessLevel, string userEmail, string userPword)
        {
            OleDbConnection conn = openConnection();

            Users newUser = new Users(username, userFirstName, userSurname, dob, userAddress, userCity, userCounty, userCountry, userPostCode, userAccessLevel, userEmail, userPword);

            string userIp = getUserIp();

            string strNewUser = "INSERT INTO Users(Username, Email, FirstName, Surname, DateOfBirth, Address, City, County, Country, PostCode, AccessLevel, PWord, UserIp)" +
                            "VALUES(@Username,@Email,@FirstName,@Surname,@DateOfBirth,@Address,@City,@County,@Country,@PostCode,@AccessLevel,@PWord,@UserIp)";


            OleDbCommand cmd = new OleDbCommand(strNewUser, conn);

            cmd.Parameters.AddWithValue("@Username", newUser.getUsername());
            cmd.Parameters.AddWithValue("@Email", newUser.getEmail());
            cmd.Parameters.AddWithValue("@FirstName", newUser.getFirstName());
            cmd.Parameters.AddWithValue("@Surname", newUser.getSurname());
            cmd.Parameters.AddWithValue("@DateOfBirth", newUser.getDob());
            cmd.Parameters.AddWithValue("@Address", newUser.getAddress());
            cmd.Parameters.AddWithValue("@City", newUser.getCity());
            cmd.Parameters.AddWithValue("@County", newUser.getCounty());
            cmd.Parameters.AddWithValue("@Country", newUser.getCountry());
            cmd.Parameters.AddWithValue("@PostCode", newUser.getPostCode());
            cmd.Parameters.AddWithValue("@AccessLevel", newUser.getUserAccessLevel());
            cmd.Parameters.AddWithValue("@Pword", newUser.getPassword());
            cmd.Parameters.AddWithValue("@UserIp", userIp);


            cmd.ExecuteNonQuery(); // execute the insertion command

            closeConnection(conn); // close connection

        }

        public static Users verifyLogin(string username, string pWord)
        {
            OleDbConnection conn = openConnection();
            string strSQL = "select * FROM Users WHERE (Username=@Username OR Email=@Username) AND PWord=@pWord";

            OleDbCommand cmd = new OleDbCommand(strSQL, conn);

            cmd.Parameters.AddWithValue("@Username", username);
            cmd.Parameters.AddWithValue("@pWord", pWord);
            OleDbDataReader reader = cmd.ExecuteReader();
            Users userObject = new Users();

            while (reader.Read())
            {

                int userId = Convert.ToInt32(reader["UserId"]);
                string firstName = reader["FirstName"].ToString();
                string surname = reader["Surname"].ToString();
                string dob = reader["DateOfBirth"].ToString();
                string address = reader["Address"].ToString();
                string city = reader["City"].ToString();
                string county = reader["County"].ToString();
                string country = reader["Country"].ToString();
                string postCode = reader["PostCode"].ToString();
                string accessLevel = reader["AccessLevel"].ToString();
                string userName = reader["Username"].ToString();
                string email = reader["Email"].ToString();
                string passWord = reader["PWord"].ToString();
                string userIp = reader["UserIp"].ToString();


                userObject = new Users(username, userId, firstName, surname, dob, address,
                                                    city, county, country, postCode, accessLevel, email, passWord, userIp);
            }

            reader.Close();
            closeConnection(conn);
            return userObject;
        }
    }
}