using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using Web2Ass1Team5.App_Code.BLL;

namespace Web2Ass1Team5.App_Code.DAL
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
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
                catch (Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
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
        public static int getRecepientIdFromUsername(string username)
        {

            OleDbConnection conn = openConnection();

            string strReadRecepId = "select * FROM Users WHERE Username=@Username";

            OleDbCommand cmdSelectId = new OleDbCommand(strReadRecepId, conn);

            cmdSelectId.Parameters.AddWithValue("@Username", username);

            OleDbDataReader recepIdReader = cmdSelectId.ExecuteReader();

            Users tempUser = new Users();
            while (recepIdReader.Read())
            {
                tempUser.setUserId(Convert.ToInt32(recepIdReader["UserId"]));
            }

            int userId = tempUser.getUserId();
            closeConnection(conn);

            return userId;


        }

        public static Chat checkForExistingChat(int creatorId, int recipientId)
        {
            OleDbConnection conn = openConnection();

            string strInsertNewConvo = "SELECT * FROM Chats WHERE(CreatorId=@CreatorId AND RecipientId=@RecepientId) OR (CreatorId=@RecepientId AND RecipientId=@CreatorId)";

            OleDbCommand cmdSelectConvo = new OleDbCommand(strInsertNewConvo, conn);
            cmdSelectConvo.Parameters.AddWithValue("@CreatorId", creatorId);
            cmdSelectConvo.Parameters.AddWithValue("@RecipientId", recipientId);

            OleDbDataReader selectChatReader = cmdSelectConvo.ExecuteReader();

            Chat selectChat = new Chat();
            while (selectChatReader.Read())
            {
                selectChat.setChatId(Convert.ToInt32(selectChatReader["ChatId"]));
                selectChat.setUserId(Convert.ToInt32(selectChatReader["CreatorId"]));
                selectChat.setRecepId(Convert.ToInt32(selectChatReader["RecipientId"]));
            }
            closeConnection(conn);

            return selectChat;


        }

        public static void createNewChat(int creatorId, int recipientId)
        {

            OleDbConnection conn = openConnection();

            string strCreateNewChat = "INSERT INTO Chats(CreatorId, RecipientId) VALUES(@CreatorId, @RecipientId)";

            OleDbCommand cmdCreateChat = new OleDbCommand(strCreateNewChat, conn);

            cmdCreateChat.Parameters.AddWithValue("@CreatorId", creatorId);
            cmdCreateChat.Parameters.AddWithValue("@RecipientId", recipientId);
            cmdCreateChat.ExecuteNonQuery();

            closeConnection(conn);
        }

        private static Message createNewMessage(int creatorId, string messageBody, DateTime createDate, int chatId)
        {
            OleDbConnection conn = openConnection();

            Message newMessage = new Message(creatorId, messageBody, createDate, chatId);

            string strInsertMessage = "INSERT INTO Message(CreatorId, MessageBody, CreateDate, ChatId) " +
               " VALUES(@CreatorId, @MessageBody, @CreateDate, @ChatId)";

            OleDbCommand cmdInsert = new OleDbCommand(strInsertMessage, conn);
            cmdInsert.Parameters.AddWithValue("@CreatorId", newMessage.getCreatorId());
            cmdInsert.Parameters.AddWithValue("@MessageBody", newMessage.getMessageBody());
            cmdInsert.Parameters.AddWithValue("@CreateDate", newMessage.getCreateDate().ToString());
            cmdInsert.Parameters.AddWithValue("@ChatId", newMessage.getChatId());
            cmdInsert.ExecuteNonQuery();

            closeConnection(conn);
            return newMessage;
        }

        private static Message getMessageId(int creatorId, DateTime createDate)
        {

            OleDbConnection conn = openConnection();

            Message getMessage = new Message();

            getMessage.setCreatorId(creatorId);
            getMessage.setCreateDate(createDate);

            string strGetMessageId = "SELECT ID FROM Message WHERE(CreatorId=@CreatorId AND CreateDate=@CreateDate)";

            OleDbCommand cmdSelectConvo = new OleDbCommand(strGetMessageId, conn);
            cmdSelectConvo.Parameters.AddWithValue("@CreatorId", getMessage.getCreatorId());
            cmdSelectConvo.Parameters.AddWithValue("@CreateDate", getMessage.getCreateDate().ToString());

            OleDbDataReader selectMessageReader = cmdSelectConvo.ExecuteReader();

            Message foundMessageId = new Message();
            while (selectMessageReader.Read())
            {
                foundMessageId.setMesageId(Convert.ToInt32(selectMessageReader["ID"]));
            }
            closeConnection(conn);

            return foundMessageId;
        }

        public static void sendMessage(int creatorId, string messageBody, DateTime createDate, int recepientId, int chatId)
        {
            OleDbConnection conn = openConnection();

            createNewMessage(creatorId, messageBody, createDate, chatId);
            Message selectMessageId = getMessageId(creatorId, createDate);


            string strInsertRecep = "INSERT INTO MessageRecipient(RecepientId, " +
                                    "MessageId)" +
                                    " VALUES(@RecepId, @MessageId)";

            OleDbCommand cmdInsertRecep = new OleDbCommand(strInsertRecep, conn);
            cmdInsertRecep.Parameters.AddWithValue("@RecepId", recepientId);
            cmdInsertRecep.Parameters.AddWithValue("@MessageId", selectMessageId.getMessageId());

            cmdInsertRecep.ExecuteNonQuery();

            closeConnection(conn);

        }



        public static DataSet getMessages(int userId)
        {
            OleDbConnection conn = openConnection();
            //create dataset (virtual database)
            DataSet dsMessages = new DataSet();

            string strGetMessages = "SELECT Message.ID, Message.CreatorId, Message.MessageBody, Message.CreateDate, " +
                                    "MessageRecipient.RecipientId, MessageRecipient.isRead FROM Message " +
                                    "INNER JOIN MessageRecipient ON Message.ID = MessageRecipient.MessageId " +
                                    "INNER JOIN Chats ON Message.ChatId = Chats.ChatId" +
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

        public static DataSet getConversation(int creatorId, int recepId)
        {
            OleDbConnection conn = openConnection();

            DataSet dsConversation = new DataSet();

            string strGetConversation = "SELECT Message.ID, Message.CreatorId, Message.MessageBody, Message.CreateDate, " +
                                    "MessageRecipient.RecepientId, MessageRecipient.isRead FROM Message " +
                                    " INNER JOIN MessageRecipient ON Message.ID = MessageRecipient.MessageId " +
                                    " WHERE (Message.CreatorId=@CreatorId AND MessageRecipient.RecepientId=@RecepId) OR (Message.CreatorId=@RecepId AND MessageRecipient.RecepientId=@CreatorId) " +
                                    "ORDER BY Message.ID DESC";

            //data adapter is bridge between database and dataset
            OleDbDataAdapter daConversation = new OleDbDataAdapter(strGetConversation, conn);

            daConversation.SelectCommand.Parameters.AddWithValue("@UserId", creatorId);
            daConversation.SelectCommand.Parameters.AddWithValue("@RecepId", recepId);


            //populate the data table in the dataset 
            //with records from the database table
            daConversation.Fill(dsConversation, "Message");
            daConversation.Fill(dsConversation, "MessageRecipient");


            closeConnection(conn);

            return dsConversation;

        }//TESTED

        public static int getUnreadMessageCount(int pUserId)
        {


            OleDbConnection conn = openConnection();

            int isRead = 0;

            string strGetMessageCount = "SELECT COUNT(ID) FROM MessageRecipient WHERE RecepientId=@pUserId AND isRead=@isRead";

            OleDbCommand cmd = new OleDbCommand(strGetMessageCount, conn);
            cmd.Parameters.AddWithValue("@pUserId", pUserId);
            cmd.Parameters.AddWithValue("@isRead", isRead);

            int countMessages = Convert.ToInt32(cmd.ExecuteScalar());
            closeConnection(conn);

            return countMessages;
        }

        //public static void ViewMessages(int chatId, int userId)
        //{
        //    OleDbConnection conn = openConnection();
        //    int isRead = 1;

        //    string strMessageViewedUpdate = "UPDATE MessageRecipient SET MessageRecipient.isRead=@isRead INNER JOIN Message ON MessageRecipient.MessageId = Message.ID WHERE Message.ChatId=@ chatId AND MessageRecipient.RecepientId=@ userId";

        //    OleDbCommand cmdUpdate = new OleDbCommand(strMessageViewedUpdate, conn);
        //    cmdUpdate.Parameters.AddWithValue("@chatId", chatId);
        //    cmdUpdate.Parameters.AddWithValue("@isRead", isRead);
        //    cmdUpdate.Parameters.AddWithValue("@userId", userId);

        //    cmdUpdate.ExecuteNonQuery(); // execute the insertion command
        //    closeConnection(conn);
        //}

        public static void removeMessage(int msgId)
        {
            OleDbConnection conn = openConnection();

            string strRemoveMessage = "DELETE FROM Message WHERE ID= @msgId";

            OleDbCommand cmd = new OleDbCommand(strRemoveMessage, conn);
            cmd.Parameters.AddWithValue("@msgId", msgId);

            cmd.ExecuteNonQuery(); // execute the insertion command
        }
    }
}