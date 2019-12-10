using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VapeShop.App_Code.DAL;
using System.Data;

namespace VapeShop.App_Code.BLL
{
    public class Conversation
    {
        private int userId;
        private int messageId;
        private string secondUsername;


        public Conversation(int userId, string secondUsername)
        {
            this.userId = userId;
            this.secondUsername = secondUsername;
        }

        public Conversation()
        {

        }

        public static DataSet getConversation(int userId, string searchRecep)
        {
            return daMessage.getConversation(userId, searchRecep);
        }

        public int getUserId()
        {
            return userId;
        }

        public string getUsername()
        {
            return secondUsername;
        }

        public void setUserId(int userID)
        {
            this.userId = userID;
        }

        public void setUsername(string username)
        {
            this.secondUsername = username;
        }
    }
}