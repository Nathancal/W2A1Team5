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

            int recepId;

            string strReadRecepId = "select ID FROM Users WHERE Username='" +
                                         recepUsername + "'";

            OleDbCommand cmdSelectId = new OleDbCommand(strReadRecepId, conn);
            OleDbDataReader recepIdReader = cmdSelectId.ExecuteReader();

            recepId = Convert.ToInt32(recepIdReader["UserId"]);

            string checkNewConversation = "SELECT ChatId" +
                                          "FROM Chats" +
                                          "WHERE CreatorId='" + creatorId + "' AND RecipientId='" + recepId + "'";
            OleDbCommand cmdCheckNewConvo = new OleDbCommand(checkNewConversation, conn);
            OleDbDataReader checkConvoReader = cmdCheckNewConvo.ExecuteReader();

            string conversation = checkConvoReader["ChatId"].ToString();

            string strInsertMessage;

            if (conversation == null)
            {
                string strInsertNewConvo = "INSERT INTO Chats(CreatorId, RecipientId)" +
                                           "VALUES('" + creatorId + "','" + recepId + ")";

                OleDbCommand cmdInsertNewConvo = new OleDbCommand(strInsertNewConvo, conn);
                cmdInsertNewConvo.ExecuteNonQuery();

                strInsertMessage = "INSERT INTO Message(CreatorId, " +
                "Subject, MessageBody, CreateDate, ParentMessageId)" +
                " VALUES('" + creatorId + "', '" + subject + "'," +
                messageBody + ",'" + createDate + ",'" + parentId + ")";
            }
            else
            {
                strInsertMessage = "INSERT INTO Message(CreatorId, " +
                "Subject, MessageBody, CreateDate, ParentMessageId)" +
                " VALUES('" + creatorId + "', '" + subject + "'," +
                messageBody + ",'" + createDate + ",'" + parentId + ")";
            }


            OleDbCommand cmdInsert = new OleDbCommand(strInsertMessage, conn);
            cmdInsert.ExecuteNonQuery(); // execute the insertion command

            //create the command object using the SQL


            cmdInsert.CommandText = "Select @@Identity";

            int msgId = Convert.ToInt32(cmdInsert.ExecuteScalar());

            string strInsertRecep = "INSERT INTO MessageRecipient(RecipientId, " +
                                    "MessageId)" +
                                    " VALUES('" + recepId + "', '" + msgId + ")";
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
                                    "WHERE userId='" + userId + "'";

            //data adapter is bridge between database and dataset
            OleDbDataAdapter daMessages = new OleDbDataAdapter(strGetMessages, conn);

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
                                  "WHERE Chats.CreatorId='" + userId + "'";

            //data adapter is bridge between database and dataset
            OleDbDataAdapter daConversation = new OleDbDataAdapter(strGetChats, conn);

            //populate the data table in the dataset 
            //with records from the database table
            daConversation.Fill(dsChats, "Users");
            daConversation.Fill(dsChats, "Chats");


            closeConnection(conn);

            return dsChats;


        }

        public static DataSet getConversation(int userId, int recepId)
        {
            OleDbConnection conn = openConnection();

            DataSet dsConversation = new DataSet();

            string strGetConversation = "SELECT Message.ID, Message.CreatorId, Message.MessageBody, Message.CreateDate, " +
                                    "MessageRecipient.RecipientId, MessageRecipient.isRead FROM Message" +
                                    "FROM Message" +
                                    "INNER JOIN MessageRecipient ON Message.ID = MessageRecipient.MessageId" +
                                    "WHERE (Message.CreatorId='" + userId + "' AND MessageRecipient.RecipientId='" + recepId + "') OR (Message.CreatorId='" + recepId + "' AND MessageRecipient.RecipientId='" + userId + "'" +
                                    "ORDER BY Message.ID DESC";

            //data adapter is bridge between database and dataset
            OleDbDataAdapter daConversation = new OleDbDataAdapter(strGetConversation, conn);

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

            string strGetMessageCount = "SELECT COUNT(isRead) FROM MessageRecipient WHERE RecipientId='"
                            + pUserId + "' AND isRead='" + 0 + "'";

            OleDbCommand cmd = new OleDbCommand(strGetMessageCount, conn);

            int countMessages = Convert.ToInt32(cmd.ExecuteScalar());
            closeConnection(conn);

            return countMessages;
        }

        public static Message ViewMessage(int msgId)
        {
            OleDbConnection conn = openConnection();
            string strMessageViewedUpdate = "UPDATE MessageRecipient SET isRead= 1 WHERE MessageId='" + msgId + "'";
            //create the command object using the SQL
            OleDbCommand cmdUpdate = new OleDbCommand(strMessageViewedUpdate, conn);
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

                cmdSelect.CommandText = "SELECT RecipientId FROM MessageRecipient WHERE MessageId='" + msgId + "'";
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