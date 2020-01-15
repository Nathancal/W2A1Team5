using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using Web2Ass1Team5.App_Code.DAL;

namespace Web2Ass1Team5.App_Code.BLL
{
    public class Chat
    {
        private int userId, chatId, recepId;
        private string secondUsername;

        public Chat(int userId)
        {
            this.userId = userId;

        }
        public Chat(int userId, string secondUsername)
        {
            this.userId = userId;
            this.secondUsername = secondUsername;
        }

        public Chat(int userId, int recepId)
        {
            this.userId = userId;
            this.recepId = recepId;
        }

        public Chat()
        {

        }

        public static int returnUserChatsRecipientById(int chatId)
        {
            return daMessage.returnUserChatsRecipientById(chatId);
        }

        public static DataSet chatRecipientOnly(int userId) {
            return daMessage.chatRecipientOnly(userId);
        }

        public static int returnOtherUserByChatRecipient(int chatId)
        {
           return daMessage.returnOtherUserByChatRecipient(chatId);

        }

        public static DataSet returnUserChatById(int userId)
        {
            return daMessage.returnUserChatsById(userId);

        }


        public static DataSet getConversation(int chatId)
        {
            return daMessage.getConversation(chatId);
        }

        //public void viewMessages(int chatId, int userId)
        //{
        //    daMessage.ViewMessages(chatId, userId);
        //}

        public Chat checkForExistingChat(int creatorId, int recepId)
        {
            Chat foundChat = daMessage.checkForExistingChat(creatorId, recepId);

            return foundChat;
        }

        public void initiateChat(int creatorId, int recepientId)
        {
            daMessage.initiateChat(creatorId, recepientId);
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


        public void setRecepId(int recepId)
        {
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

        public void setChatId(int chatId)
        {
            this.chatId = chatId;
        }

        public int getChatId()
        {
            return chatId;
        }
    }
}