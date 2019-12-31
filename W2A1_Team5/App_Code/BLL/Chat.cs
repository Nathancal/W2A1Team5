using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using W2A1Team5.App_Code.DAL;
using System.Data;

namespace W2A1Team5.App_Code.BLL
{
    public class Chat
    {
        private int userId, chatId, messageId, recepId;
        private string secondUsername;



        public Chat(int userId, string secondUsername)
        {
            this.userId = userId;
            this.secondUsername = secondUsername;
        }

        public Chat(int chatId){
            this.chatId = chatId;
        }

        public Chat(int userId, int recepId)
        {
            this.userId = userId;
            this.recepId = recepId;
        }

        public Chat()
        {

        }

        public static DataSet getConversation(int userId, int recepientId)
        {
            return daMessage.getConversation(userId, recepientId);
        }

        public void viewMessages(int chatId, int userId)
        {
            daMessage.ViewMessages(chatId, userId);
        }

        public Chat checkForExistingChat(int creatorId, string recepientUsername)
        {
            int recepId = getRecepientIdFromUsername(recepientUsername);
            Chat foundChat = daMessage.checkForExistingChat(creatorId, recepId);

            return foundChat;
        }

        public void createNewChat(int creatorId, int recepientId)
        {
            this.userId = creatorId;
            this.recepId = recepientId;
            daMessage.createNewChat(creatorId, recepientId);
        }


        public int getRecepientIdFromUsername(string username)
        {
            int recepId = daMessage.getRecepientIdFromUsername(username);
            return recepId;
        }

        public int getUserId()
        {
            return userId;
        }

        public int getRecepId()
        {
            return userId;
        }


        public void setRecepId(int recepId){
            this.recepId = recepId;
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

        public void setChatId(int chatId){
            this.chatId = chatId;
        }

        public int getChatId(){
            return chatId;
        }
    }
}