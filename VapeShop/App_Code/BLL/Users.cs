using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VapeShop.App_Code.DAL;

namespace VapeShop.App_Code.BLL
{
    public class Users
    {

        private int userId;
        private string userFirstName, userSurname, userAddress, userCity, userCounty, userCountry, userPostCode, userAccessLevel, userIp, username;
        private string userEmail, pWord;
        private string UserDob;
        public Users() { 
        
        }

        public Users(string username, int userId, string userFirstName,string userSurname, String dob, string userAddress,string userCity,string userCounty,string userCountry,string userPostCode,string userAccessLevel, string email, string pWord, string userIp)
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
            daUsers.createNewUser(username, userFirstName, userSurname, UserDob, userAddress, userCity, userCounty, userCountry, userPostCode, userAccessLevel, userEmail, pWord);


        }//SEND



        public void findUser(string search) {
            Users loadUser = daUsers.getUser(search);

            userId = loadUser.getUserId();
            userFirstName = loadUser.getFirstName();
            userSurname = loadUser.getSurname();
            UserDob = Convert.ToString(loadUser.getDob());
        }


        public int getUserId() {
            return userId;
        }

        public void setUserId(int userId) {
            this.userId = userId;
        }

        public string getFirstName() {
            return userFirstName;
        }

        public void setFirstName(string firstName) {
            this.userFirstName = firstName;
        }

        public string getSurname(){
            return userSurname;
        }

        public void setSurname(string surname) {
            this.userSurname = surname;
        }

        public DateTime getDob(){
            return Convert.ToDateTime(UserDob);
        }

        public void setDob(string dob) {
            this.UserDob = dob;
        }

        public string getAddress() {
            return userAddress;
        }

        public void setAddress(string address) {
            this.userAddress = address;
        }

        public string getCity() {
            return userCity;
        }

        public void setCity(string city) {
            this.userCity = city;
        }

        public string getCounty() {
            return userCounty;
        }

        public void setCounty(string county) {
            this.userCounty = county;
        }

        public string getCountry() {
            return userCountry;
        }

        public void setCountry(string country) {
            this.userCountry = country;
            
        }

        public string getPostCode() {
            return userPostCode;
        }

        public void setPostCode(string postCode) {
            this.userPostCode = postCode;
        }

        public string getUserAccessLevel() {
            return userAccessLevel;
        }

        public void setUserAccessLevel(string accessLevel) {
            this.userAccessLevel = accessLevel;
     
        }

        public void setUserIp(string userIp) {
            this.userIp = userIp;
        }
        
        public static Users verifyLogin(string email, string pWord)
        {
            return daUsers.verifyLogin(email, pWord);
        }
    }
}