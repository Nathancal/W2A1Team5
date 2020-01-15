using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Web2Ass1Team5.App_Code.DAL;

namespace Web2Ass1Team5.App_Code.BLL
{
    public class Messages
    {

        private int msgId, creatorId, parentMessageId, recepId, chatId;
        private string messageBody, recepUsername;
        private DateTime createDate;

        public Messages(int creatorId, string messageBody, DateTime createDate, string recepUsername)
        {
            this.creatorId = creatorId;
            this.messageBody = messageBody;
            this.createDate = createDate;
            this.recepUsername = recepUsername;
        }

        public Messages(int creatorId, string messageBody, DateTime createDate, int chatId)
        {
            this.creatorId = creatorId;
            this.messageBody = messageBody;
            this.createDate = createDate;
            this.chatId = chatId;

        }

        public Messages( int creatorId, string messageBody, DateTime createDate, int recepId, int chatId)
        {
            this.creatorId = creatorId;
            this.messageBody = messageBody;
            this.createDate = createDate;
            this.recepId = recepId;
            this.chatId = chatId;
        }

        public Messages() { }

        public void sendMessage(int creatorId, string messageBody, DateTime createDate, int recepId, int chatId)
        {
            daMessage.sendMessage(creatorId, messageBody, createDate, recepId, chatId);
        }

        public string getRecepUsername()
        {
            return recepUsername;
        }

        public void setMesageId(int msgId)
        {
            this.msgId = msgId;

        }

        public void setCreatorId(int creatorId)
        {
            this.creatorId = creatorId;
        }



        public static int getUnreadMessageCount(int userId)
        {
            int msgCount = daMessage.getUnreadMessageCount(userId);
            return msgCount;
        }

        public int getChatId()
        {
            return chatId;
        }


        public DataSet getMessages(int userId)
        {
            return daMessage.getMessages(userId);
        }

        public int getMessageId()
        {
            return msgId;
        }

        public int getCreatorId()
        {
            return creatorId;
        }

        public int getParentMsgId()
        {
            return parentMessageId;
        }

        public void setParentMsgId(int msgId)
        {
            this.parentMessageId = msgId;
        }

        public string getMessageBody()
        {
            return messageBody;
        }

        public void setMessageBody(string messageBody)
        {
            this.messageBody = messageBody;
        }

        public DateTime getCreateDate()
        {
            return createDate;
        }

        public void setCreateDate(DateTime createDate)
        {
            this.createDate = createDate;
        }

        public void setRecepUsername(string recepUsername)
        {
            this.recepUsername = recepUsername;
        }

        public static void viewMessages(int chatId, int userId) {
            
            
            daMessage.ViewMessages(chatId, userId);
        
        }


    }
}