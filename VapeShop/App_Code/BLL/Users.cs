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
        private string userFirstName, userSurname, userAddress, userCity, userCounty, userCountry, userPostCode, userAccessLevel;
        private DateTime UserDob;
        public Users() { 
        
        }

        public void findUser(int pUserId) {
            Users loadUser = DataAccess.getUser(pUserId);

            userId = loadUser.getUserId();
            userFirstName = loadUser.getFirstName();
            userSurname = loadUser.getSurname();
            UserDob = loadUser.getDob();
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
            return UserDob;
        }

        public void setDob(DateTime dob) {
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
    }
}