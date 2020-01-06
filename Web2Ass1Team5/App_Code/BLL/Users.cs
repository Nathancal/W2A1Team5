using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web2Ass1Team5.App_Code.DAL;

namespace Web2Ass1Team5.App_Code.BLL
{
    public class Users
    {

        private int userId;
        private string userFirstName, userSurname, userAddress, userCity, userCounty, userCountry, userPostCode, userAccessLevel, userIp, username;
        private string userEmail, pWord;
        private string UserDob;
        public Users()
        {

        }

        public Users(string username, int userId, string userFirstName, string userSurname, string dob, string userAddress, string userCity, string userCounty, string userCountry, string userPostCode, string userAccessLevel, string email, string pWord, string userIp)
        {
            this.userId = userId;
            this.userFirstName = userFirstName;
            this.userSurname = userSurname;
            this.UserDob = dob;
            this.userAddress = userAddress;
            this.userCity = userCity;
            this.userCounty = userCounty;
            this.userCountry = userCountry;
            this.userPostCode = userPostCode;
            this.userAccessLevel = userAccessLevel;
            this.username = username;
            this.userEmail = email;
            this.pWord = pWord;

        }//Return

        public Users(string username, string userFirstName, string userSurname, string dob, string userAddress, string userCity, string userCounty, string userCountry, string userPostCode, string userAccessLevel, string email, string pWord)
        {
            this.userFirstName = userFirstName;
            this.userSurname = userSurname;
            this.UserDob = dob;
            this.userAddress = userAddress;
            this.userCity = userCity;
            this.userCounty = userCounty;
            this.userCountry = userCountry;
            this.userPostCode = userPostCode;
            this.userAccessLevel = userAccessLevel;
            this.username = username;
            this.userEmail = email;
            this.pWord = pWord;

        }//SEND

        public Users(string username, string userFirstName, string userSurname, string dob, string userAddress, string userCity, string userCounty, string userCountry, string userPostCode,string email, string pWord)
        {
            this.userFirstName = userFirstName;
            this.userSurname = userSurname;
            this.UserDob = dob;
            this.userAddress = userAddress;
            this.userCity = userCity;
            this.userCounty = userCounty;
            this.userCountry = userCountry;
            this.userPostCode = userPostCode;
            this.username = username;
            this.userEmail = email;
            this.pWord = pWord;

        }//SEND

        public void createNewUser()
        {

            daUsers.createNewUser(username, userFirstName, userSurname, UserDob, userAddress, userCity, userCounty, userCountry, userPostCode, userAccessLevel, userEmail, pWord);

        }

        public void createNewUserNoAccess()
        {

            daUsers.createNewUserNoAccess(username, userFirstName, userSurname, UserDob, userAddress, userCity, userCounty, userCountry, userPostCode, userEmail, pWord);

        }

        public static Users verifyLogin(string emailUname, string pWord)
        {

            Users userInfo = daUsers.verifyLogin(emailUname, pWord);

            return userInfo;
        }




        public Users findUser(string search)
        {
            Users loadUser = daUsers.getUser(search);

            userId = loadUser.getUserId();
            userFirstName = loadUser.getFirstName();
            userSurname = loadUser.getSurname();
            UserDob = loadUser.getDob();
            username = loadUser.getUsername();
            userEmail = loadUser.getEmail();
            userPostCode = loadUser.getPostCode();
            userCounty = loadUser.getCounty();
            userCountry = loadUser.getCountry();
            userAccessLevel = loadUser.getUserAccessLevel();
            userIp = loadUser.getUserIp();

            return loadUser;
        }


        public int getUserId()
        {
            return userId;
        }

        public string getUserIp()
        {
            return userIp;
        }

        public string getUsername()
        {
            return username;
        }

        public string getEmail()
        {
            return userEmail;
        }

        public void setUserId(int userId)
        {
            this.userId = userId;
        }

        public string getFirstName()
        {
            return userFirstName;
        }

        public void setFirstName(string firstName)
        {
            this.userFirstName = firstName;
        }

        public string getSurname()
        {
            return userSurname;
        }

        public void setSurname(string surname)
        {
            this.userSurname = surname;
        }

        public void setUsername(string username)
        {
            this.username = username;
        }
        public string getDob()
        {
            return UserDob;
        }

        public void setDob(string dob)
        {
            this.UserDob = dob;
        }

        public string getAddress()
        {
            return userAddress;
        }

        public void setAddress(string address)
        {
            this.userAddress = address;
        }

        public string getCity()
        {
            return userCity;
        }

        public void setCity(string city)
        {
            this.userCity = city;
        }

        public string getCounty()
        {
            return userCounty;
        }

        public void setCounty(string county)
        {
            this.userCounty = county;
        }

        public string getCountry()
        {
            return userCountry;
        }

        public void setCountry(string country)
        {
            this.userCountry = country;

        }

        public string getPostCode()
        {
            return userPostCode;
        }

        public void setPostCode(string postCode)
        {
            this.userPostCode = postCode;
        }

        public string getUserAccessLevel()
        {
            return userAccessLevel;
        }

        public void setUserAccessLevel(string accessLevel)
        {
            this.userAccessLevel = accessLevel;

        }

        public string getPassword()
        {
            return pWord;
        }

        public void setUserIp(string userIp)
        {
            this.userIp = userIp;
        }
    }
}