using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.OleDb;
using VapeShop.App_Code.BLL;

namespace VapeShop.App_Code.DAL
{
    public class daMessage
    {


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

        public static void sendMessage(int creatorId, string subject, string messageBody, DateTime createDate, int parentId, string recepUsername)
        {
            OleDbConnection conn = openConnection();

            Message sendMessage = new Message(creatorId, subject, messageBody ,createDate ,parentId ,recepUsername);

            int recepId;

            string strReadRecepId = "select ID FROM Users WHERE Username=@Username";

            OleDbCommand cmdSelectId = new OleDbCommand(strReadRecepId, conn);
            cmdSelectId.Parameters.AddWithValue("@Username", recepUsername);

            OleDbDataReader recepIdReader = cmdSelectId.ExecuteReader();

            recepId = Convert.ToInt32(recepIdReader["UserId"]);

            string checkNewConversation = "SELECT ChatId" +
                                          "FROM Chats" +
                                          "WHERE CreatorId= @CreatorId AND RecipientId= @RecepId";
            OleDbCommand cmdCheckNewConvo = new OleDbCommand(checkNewConversation, conn);

            cmdCheckNewConvo.Parameters.AddWithValue("@CreatorId", sendMessage.getCreatorId());
            cmdCheckNewConvo.Parameters.AddWithValue("@RecepId", recepId);


            OleDbDataReader checkConvoReader = cmdCheckNewConvo.ExecuteReader();

            string conversation = checkConvoReader["ChatId"].ToString();

            string strInsertMessage;
            OleDbCommand cmdInsert;

            if (conversation == null)
            {
                string strInsertNewConvo = "INSERT INTO Chats(CreatorId, RecipientId)" +
                                           "VALUES(@CreatorId. @RecipientId)";

                OleDbCommand cmdInsertNewConvo = new OleDbCommand(strInsertNewConvo, conn);
                cmdInsertNewConvo.Parameters.AddWithValue("@CreatorId", sendMessage.getCreatorId());
                cmdInsertNewConvo.Parameters.AddWithValue("@RecipientId", recepId);

                cmdInsertNewConvo.ExecuteNonQuery();

                strInsertMessage = "INSERT INTO Message(CreatorId, " +
                "Subject, MessageBody, CreateDate, ParentMessageId)" +
                " VALUES(@CreatorId, @Subject, @MessageBody, @CreateDate, @ParentMessageId)";

                cmdInsert = new OleDbCommand(strInsertMessage, conn);
                cmdInsert.Parameters.AddWithValue("@ParentMessageId", null);

            }
            else
            {
                strInsertMessage = "INSERT INTO Message(CreatorId, " +
                "Subject, MessageBody, CreateDate, ParentMessageId)" +
                " VALUES(@CreatorId, @Subject, @MessageBody, @CreateDate, @ParentMessageId)";

                cmdInsert = new OleDbCommand(strInsertMessage, conn);
                            cmdInsert.Parameters.AddWithValue("@ParentMessageId", sendMessage.getParentMsgId());


            }


            cmdInsert.Parameters.AddWithValue("@CreatorId", sendMessage.getCreatorId());
            cmdInsert.Parameters.AddWithValue("@Subject", sendMessage.getSubject());
            cmdInsert.Parameters.AddWithValue("@MessageBody", sendMessage.getMessageBody());
            cmdInsert.Parameters.AddWithValue("@CreateDate", sendMessage.getCreateDate());


            cmdInsert.ExecuteNonQuery(); // execute the insertion command

            //create the command object using the SQL


            cmdInsert.CommandText = "Select @@Identity";

            int msgId = Convert.ToInt32(cmdInsert.ExecuteScalar());

            string strInsertRecep = "INSERT INTO MessageRecipient(RecipientId, " +
                                    "MessageId)" +
                                    " VALUES(@RecepId, @MessageId)";

            OleDbCommand cmdInsertRecep = new OleDbCommand(strInsertRecep, conn);
            cmdInsertRecep.Parameters.AddWithValue("@RecepId", recepId);
            cmdInsertRecep.Parameters.AddWithValue("@MessageId", msgId);
            
            cmdInsertRecep.ExecuteNonQuery();

            recepIdReader.Close();
            closeConnection(conn);
        }

        public static DataSet getMessages(int userId)
        {
            OleDbConnection conn = openConnection();
            //create dataset (virtual database)
            DataSet dsMessages = new DataSet();

            string strGetMessages = "SELECT Message.ID, Message.CreatorId, Message.MessageBody, Message.CreateDate, " +
                                    "MessageRecipient.RecipientId, MessageRecipient.isRead FROM Message" +
                                    "FROM Message" +
                                    "INNER JOIN MessageRecipient ON Message.ID = MessageRecipient.MessageId" +
                                    "WHERE Message.CreatorId=@UserId";

            //data adapter is bridge between database and dataset
            OleDbDataAdapter daMessages = new OleDbDataAdapter(strGetMessages, conn);

            daMessages.UpdateCommand.Parameters.AddWithValue("@UserId", userId);

            //populate the data table in the dataset 
            //with records from the database table
            daMessages.Fill(dsMessages, "Message");
            daMessages.Fill(dsMessages, "MessageRecipient");


            closeConnection(conn);

            return dsMessages;
        }

        public static DataSet getChats(int userId)
        {
            OleDbConnection conn = openConnection();

            DataSet dsChats = new DataSet();

            string strGetChats = "SELECT Chats.ChatId, Chats.RecipientId, Users.FirstName, Users.Surname" +
                                  "FROM Chats" +
                                  "INNER JOIN Users ON Users.UserId = Chats.RecipientId" +
                                  "WHERE Chats.CreatorId=@UserId";

            //data adapter is bridge between database and dataset
            OleDbDataAdapter daConversation = new OleDbDataAdapter(strGetChats, conn);
            daConversation.UpdateCommand.Parameters.AddWithValue("@UserId", userId);

            //populate the data table in the dataset 
            //with records from the database table
            daConversation.Fill(dsChats, "Users");
            daConversation.Fill(dsChats, "Chats");


            closeConnection(conn);

            return dsChats;


        }

        public static DataSet getConversation(int userId, string username)
        {
            OleDbConnection conn = openConnection();

            string strGetUserId = "SELECT ID FROM Users WHERE Username=@Username";
            OleDbCommand cmdFetchUSerId = new OleDbCommand(strGetUserId, conn);

            cmdFetchUSerId.Parameters.AddWithValue("@Username", username);

            int id = Convert.ToInt32(cmdFetchUSerId.ExecuteReader());


            DataSet dsConversation = new DataSet();

            string strGetConversation = "SELECT Message.ID, Message.CreatorId, Message.MessageBody, Message.CreateDate, " +
                                    "MessageRecipient.RecipientId, MessageRecipient.isRead FROM Message" +
                                    "FROM Message" +
                                    "INNER JOIN MessageRecipient ON Message.ID = MessageRecipient.MessageId" +
                                    "WHERE (Message.CreatorId=@UserId AND MessageRecipient.RecipientId=@RecepId) OR (Message.CreatorId=@RecepId AND MessageRecipient.RecipientId=@UserId" +
                                    "ORDER BY Message.ID DESC";

            //data adapter is bridge between database and dataset
            OleDbDataAdapter daConversation = new OleDbDataAdapter(strGetConversation, conn);

            daConversation.UpdateCommand.Parameters.AddWithValue("@UserId", userId);
            daConversation.UpdateCommand.Parameters.AddWithValue("@RecepId", id);


            //populate the data table in the dataset 
            //with records from the database table
            daConversation.Fill(dsConversation, "Message");
            daConversation.Fill(dsConversation, "MessageRecipient");


            closeConnection(conn);

            return dsConversation;
        }

        public static int getUnreadMessageCount(int pUserId)
        {

            OleDbConnection conn = openConnection();

            string strGetMessageCount = "SELECT COUNT(ID) FROM MessageRecipient WHERE RecipientId=@RecepientId AND isRead=@isRead";

            OleDbCommand cmd = new OleDbCommand(strGetMessageCount, conn);
            cmd.Parameters.AddWithValue("@RecepientId", pUserId);
            cmd.Parameters.AddWithValue("@isRead", 0);

            int countMessages = Convert.ToInt32(cmd.ExecuteScalar());
            closeConnection(conn);

            return countMessages;
        }

        public static Message ViewMessage(int msgId)
        {
            OleDbConnection conn = openConnection();
            string strMessageViewedUpdate = "UPDATE MessageRecipient SET isRead= 1 WHERE MessageId=@MessageId";
            //create the command object using the SQL
            OleDbCommand cmdUpdate = new OleDbCommand(strMessageViewedUpdate, conn);
            cmdUpdate.Parameters.AddWithValue("@MessageId", msgId);

            cmdUpdate.ExecuteNonQuery(); // execute the insertion command

            string strRetrieveMessage = "SELECT * FROM Message WHERE ID='" + msgId + "'";

            OleDbCommand cmdSelect = new OleDbCommand(strRetrieveMessage, conn);
            OleDbDataReader messageReader = cmdSelect.ExecuteReader();
            Message msgObject = null;

            while (messageReader.Read())
            {
                int messageId = Convert.ToInt32(messageReader["ID"]);
                int creatorId = Convert.ToInt32(messageReader["CreatorId"]);
                string subject = messageReader["Subject"].ToString();
                string messageBody = messageReader["MessageBody"].ToString();
                DateTime createDate = Convert.ToDateTime(messageReader["CreateDate"]);
                int parentMsgId = Convert.ToInt32(messageReader["ParentMessageId"]);

                cmdSelect.CommandText = "SELECT RecipientId FROM MessageRecipient WHERE MessageId=@msgId";

                cmdSelect.Parameters.AddWithValue("@msgId", messageId);
                messageReader = cmdSelect.ExecuteReader();
                


                while (messageReader.Read())
                {
                    int recepId = Convert.ToInt32(messageReader["RecipientId"]);
                    msgObject = new Message(messageId, creatorId, subject, messageBody, createDate, parentMsgId, recepId);
                }
            }

            messageReader.Close();
            closeConnection(conn);

            return msgObject;
        }

        public static void removeMessage(int msgId)
        {
            OleDbConnection conn = openConnection();

            string strRemoveMessage = "DELETE FROM Message WHERE ID='" + msgId + "'";

            OleDbCommand cmd = new OleDbCommand(strRemoveMessage, conn);

            cmd.ExecuteNonQuery(); // execute the insertion command
        }

    }
}