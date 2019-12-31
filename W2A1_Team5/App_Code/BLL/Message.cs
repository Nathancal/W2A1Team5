﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using W2A1Team5.App_Code.DAL;
using System.Data;

namespace W2A1Team5.App_Code.BLL
{
    public class Message
    {
        private int msgId, creatorId, parentMessageId, recepId, chatId;
        private string messageBody, recepUsername;
        private DateTime createDate;

        public Message(int creatorId, string messageBody, DateTime createDate, string recepUsername) {
            this.creatorId = creatorId;
            this.messageBody = messageBody;
            this.createDate = createDate;
            this.recepUsername = recepUsername;
        }

        public Message(int creatorId, string messageBody, DateTime createDate,  int chatId)
        {
            this.creatorId = creatorId;
            this.messageBody = messageBody;
            this.createDate = createDate;
            this.chatId = chatId;

        }

        public Message(int msgId, int creatorId, string messageBody, DateTime createDate, int recepId){
            this.creatorId = creatorId;
            this.messageBody = messageBody;
            this.createDate = createDate;
            this.recepId = recepId;
        }

        public Message() { }

        public string getRecepUsername(){
            return recepUsername;
        }

        public void setMesageId(int msgId)
        {
            this.msgId = msgId;

        }

        public void setCreatorId(int creatorId){
            this.creatorId = creatorId;
        }

        public void sendMessage(int creatorId, string messageBody, DateTime createDate,int recepId, int chatId)
        {
            daMessage.sendMessage(creatorId, messageBody, createDate, recepId, chatId);
        }


        public int getUnreadMessageCount(int userId){
            int msgCount = daMessage.getUnreadMessageCount(userId);
            return msgCount;
        }

        public int getChatId(){
            return chatId;
        }



        public DataSet getMessages(int userId){
            return daMessage.getMessages(userId);
        }

        public int getMessageId(){
            return msgId;
        }

        public int getCreatorId(){
            return creatorId;
        }

        public int getParentMsgId() {
            return parentMessageId;
        }

        public void setParentMsgId(int msgId) {
            this.parentMessageId = msgId;
        }

        public string getMessageBody() {
            return messageBody;
        }

        public void setMessageBody(string messageBody) {
            this.messageBody = messageBody;
        }

        public DateTime getCreateDate() {
            return createDate;
        }

        public void setCreateDate(DateTime createDate) {
            this.createDate = createDate;
        }

        public void setRecepUsername(string recepUsername){
            this.recepUsername = recepUsername;
        }
    }
}