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

            string strInsertNewConvo = "SELECT Chats.ChatId, Chats.CreatorId, ChatsRecipient.RecipientId FROM Chats " +
                "INNER JOIN ChatsRecipient ON ChatsRecipient.ChatID = Chats.ChatId " +
                "WHERE(Chats.CreatorId=@CreatorId AND ChatsRecipient.RecipientId=@RecipientId) OR (Chats.CreatorId=@RecipientId AND ChatsRecipient.RecipientId=@CreatorId)";

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


        public static DataSet returnUserChatsById(int userId)
        {
            OleDbConnection conn = openConnection();

            DataSet selectChat = new DataSet();

            string strGetChatId = "SELECT ChatId, CreatorId FROM Chats  " +
                                            "WHERE CreatorId=@UserId " +
                                            "ORDER BY ChatId DESC";

            //data adapter is bridge between database and dataset
            OleDbDataAdapter daChats = new OleDbDataAdapter(strGetChatId, conn);

            daChats.SelectCommand.Parameters.AddWithValue("@UserId", userId);
            //populate the data table in the dataset 
            //with records from the database table
            daChats.Fill(selectChat, "Chats");

            conn.Close();

            return selectChat;

        }

        public static DataSet chatRecipientOnly(int userId) {
            OleDbConnection conn = openConnection();

            DataSet selectChat = new DataSet();

            string strGetUserId = "SELECT ChatId, RecipientId FROM ChatsRecipient  " +
                                            "WHERE RecipientId=@UserId " +
                                            "ORDER BY ChatId DESC";

            //data adapter is bridge between database and dataset
            OleDbDataAdapter daChats = new OleDbDataAdapter(strGetUserId, conn);

            daChats.SelectCommand.Parameters.AddWithValue("@UserId", userId);
            //populate the data table in the dataset 
            //with records from the database table
            daChats.Fill(selectChat, "ChatsRecipient");

            conn.Close();

            return selectChat;


        }

        public static int returnOtherUserByChatRecipient(int chatId) {
            OleDbConnection conn = openConnection();

            string strGetUserId = "SELECT CreatorId FROM Chats " +
                                            "WHERE ChatId=@ChatId " +
                                            "ORDER BY ChatId DESC";

            //data adapter is bridge between database and dataset

            OleDbCommand cmdSelect = new OleDbCommand(strGetUserId, conn);

            cmdSelect.Parameters.AddWithValue("@ChatId", chatId);


            OleDbDataReader chatReader = cmdSelect.ExecuteReader();

            int otherUserId = 0;

            while (chatReader.Read())
            {
                otherUserId = Convert.ToInt32(chatReader["CreatorId"]);
            }

            chatReader.Close();

            return otherUserId;

        }

        public static int returnUserChatsRecipientById(int chatId)
        {
            OleDbConnection conn = openConnection();

            string strGetRatingInformation = "SELECT RecipientId FROM ChatsRecipient  " +
                                            "WHERE ChatId=@ChatId " +
                                            "ORDER BY ChatId DESC";

            //data adapter is bridge between database and dataset

            OleDbCommand cmdSelect = new OleDbCommand(strGetRatingInformation, conn);

            cmdSelect.Parameters.AddWithValue("@ChatId", chatId);


            OleDbDataReader chatReader = cmdSelect.ExecuteReader();

            int recipientId = 0;

            while (chatReader.Read())
            {
                recipientId = Convert.ToInt32(chatReader["RecipientId"]);
            }

            chatReader.Close();

            return recipientId;

        }


        public static Chat createNewChat(int creatorId)
        {

            OleDbConnection conn = openConnection();

            Chat newChat = new Chat(creatorId);

            string strCreateNewChat = "INSERT INTO Chats (CreatorId) VALUES (@CreatorId)";

            OleDbCommand cmdCreateChat = new OleDbCommand(strCreateNewChat, conn);

            cmdCreateChat.Parameters.AddWithValue("@CreatorId", creatorId);
            cmdCreateChat.ExecuteNonQuery();

            cmdCreateChat.CommandText = "SELECT @@Identity";

            int retChatId = Convert.ToInt32(cmdCreateChat.ExecuteScalar());


            newChat.setChatId(retChatId);

            closeConnection(conn);

            return newChat;
        }

        public static void initiateChat(int creatorId, int recepId)
        {
            OleDbConnection conn = openConnection();

            Chat newChatId = createNewChat(creatorId);

            string strAddChatRecep = "INSERT INTO ChatsRecipient(ChatId, RecipientId) VALUES(@ChatId, @RecipientId)";

            OleDbCommand cmdInsertChatRecep = new OleDbCommand(strAddChatRecep, conn);
            cmdInsertChatRecep.Parameters.AddWithValue("@ChatId", newChatId.getChatId());
            cmdInsertChatRecep.Parameters.AddWithValue("@RecipientId", recepId);

            cmdInsertChatRecep.ExecuteNonQuery();
            closeConnection(conn);

        }

        private static Messages createNewMessage(int creatorId, string messageBody, DateTime createDate, int chatId)
        {
            OleDbConnection conn = openConnection();

            Messages newMessage = new Messages(creatorId, messageBody, createDate, chatId);

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


        public static void sendMessage(int creatorId, string messageBody, DateTime createDate, int recepientId, int chatId)
        {
            OleDbConnection conn = openConnection();

            createNewMessage(creatorId, messageBody, createDate, chatId);
            Messages selectMessageId = getMessageId(creatorId, createDate);


            string strInsertRecep = "INSERT INTO MessageRecipient(RecepientId, " +
                                    "MessageId)" +
                                    " VALUES(@RecepId, @MessageId)";

            OleDbCommand cmdInsertRecep = new OleDbCommand(strInsertRecep, conn);
            cmdInsertRecep.Parameters.AddWithValue("@RecepId", recepientId);
            cmdInsertRecep.Parameters.AddWithValue("@MessageId", selectMessageId.getMessageId());

            cmdInsertRecep.ExecuteNonQuery();

            closeConnection(conn);

        }


        private static Messages getMessageId(int creatorId, DateTime createDate)
        {

            OleDbConnection conn = openConnection();

            Messages getMessage = new Messages();

            getMessage.setCreatorId(creatorId);
            getMessage.setCreateDate(createDate);

            string strGetMessageId = "SELECT ID FROM Message WHERE(CreatorId=@CreatorId AND CreateDate=@CreateDate)";

            OleDbCommand cmdSelectConvo = new OleDbCommand(strGetMessageId, conn);
            cmdSelectConvo.Parameters.AddWithValue("@CreatorId", getMessage.getCreatorId());
            cmdSelectConvo.Parameters.AddWithValue("@CreateDate", getMessage.getCreateDate().ToString());

            OleDbDataReader selectMessageReader = cmdSelectConvo.ExecuteReader();

            Messages foundMessageId = new Messages();
            while (selectMessageReader.Read())
            {
                foundMessageId.setMesageId(Convert.ToInt32(selectMessageReader["ID"]));
            }
            closeConnection(conn);

            return foundMessageId;
        }



        public static DataSet getMessages(int userId)
        {
            OleDbConnection conn = openConnection();
            //create dataset (virtual database)
            DataSet dsMessages = new DataSet();

            string strGetMessages = "SELECT Message.ID, Message.CreatorId, Message.MessageBody, Message.CreateDate, " +
                                    "MessageRecipient.RecipientId, MessageRecipient.isRead FROM Message " +
                                    "INNER JOIN MessageRecipient ON Message.ID = MessageRecipient.MessageId " +
                                    "INNER JOIN Chats ON Message.ChatId = Chats.ChatId " +
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

        public static DataSet getConversation(int chatId)
        {
            OleDbConnection conn = openConnection();

            DataSet dsConversation = new DataSet();

            string strGetConversation = "SELECT Message.ID, Message.CreatorId, Message.MessageBody, Message.CreateDate, " +
                                    "MessageRecipient.RecepientId, MessageRecipient.isRead FROM Message " +
                                    " INNER JOIN MessageRecipient ON Message.ID = MessageRecipient.MessageId " +
                                    " WHERE ChatId=@ChatId " +
                                    "ORDER BY Message.ID DESC";

            //data adapter is bridge between database and dataset
            OleDbDataAdapter daConversation = new OleDbDataAdapter(strGetConversation, conn);

            daConversation.SelectCommand.Parameters.AddWithValue("@ChatId", chatId);


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

            string strGetMessageCount = "SELECT COUNT(ID) FROM MessageRecipient WHERE RecepientId=@UserId AND isRead=@isRead";

            OleDbCommand cmd = new OleDbCommand(strGetMessageCount, conn);
            cmd.Parameters.AddWithValue("@UserId", pUserId);
            cmd.Parameters.AddWithValue("@isRead", isRead);

            int countMessages = Convert.ToInt32(cmd.ExecuteScalar());
            closeConnection(conn);

            return countMessages;
        }

        public static void ViewMessages(int chatId, int userId)
        {
            OleDbConnection conn = openConnection();
            int isRead = 1;

            string strMessageViewedUpdate = "UPDATE MessageRecipient " +
                "SET MessageRecipient.isRead=@isRead " +
                "WHERE MessageRecipient.RecepientId=@UserId";

            OleDbCommand cmdUpdate = new OleDbCommand(strMessageViewedUpdate, conn);
            cmdUpdate.Parameters.AddWithValue("@isRead", isRead);
            cmdUpdate.Parameters.AddWithValue("@UserId", userId);

            cmdUpdate.ExecuteNonQuery(); // execute the insertion command
            closeConnection(conn);
        }

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