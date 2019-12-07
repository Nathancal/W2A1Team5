using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VapeShop.App_Code.DAL;
using System.Data;

namespace VapeShop.App_Code.BLL
{
    public class Message
    {
        private int msgId, creatorId, parentMessageId, recepId;
        private string subject, messageBody, recepUsername;
        private DateTime createDate;

        public Message(int creatorId,  string subject, string messageBody, DateTime createDate, int parentId, string recepUsername) {
            this.creatorId = creatorId;
            this.parentMessageId = parentId;
            this.subject = subject;
            this.messageBody = messageBody;
            this.createDate = createDate;
        }

        public Message(int msgId, int creatorId, string subject, string messageBody, DateTime createDate, int parentId, int recepId){
            this.creatorId = creatorId;
            this.parentMessageId = parentId;
            this.subject = subject;
            this.messageBody = messageBody;
            this.createDate = createDate;
            this.recepId = recepId;
        }

        public Message() { }

        public void sendMessage(){
            DataAccess.sendMessage(creatorId, subject, messageBody, createDate, parentMessageId, recepUsername);
        }

        public static int getUnreadMessageCount(int userId){
            int msgCount = DataAccess.getUnreadMessageCount(userId);
            return msgCount;
        }

        public Message ViewMessage(int msgId) {
            Message viewMessage = DataAccess.ViewMessage(msgId);

            this.msgId = viewMessage.getMessageId();
            this.creatorId = viewMessage.getCreatorId();
            this.subject = viewMessage.getSubject();
            this.messageBody = viewMessage.getMessageBody();
            this.createDate = viewMessage.getCreateDate();
            this.parentMessageId = viewMessage.getParentMsgId();

            return viewMessage;
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

        public string getSubject() {
            return subject;
        }

        public void setSubject(string subject) {
            this.subject = subject;
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
    }
}