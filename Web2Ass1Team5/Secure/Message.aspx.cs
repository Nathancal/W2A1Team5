using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Web2Ass1Team5.App_Code.BLL;
using System.Collections;
using System.Windows;

namespace Web2Ass1_Team5.secure
{
    public partial class Message : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            Users userInfo = (Users)Session["userInfo"];



            DataSet chatIds = Chat.returnUserChatById(userInfo.getUserId());



            lvChats.DataSource = displayChats();
            lvChats.DataBind();
        }


        private DataTable displayChats()
        {
            Users userInfo = (Users)Session["userInfo"];

            DataSet chatIds = Chat.returnUserChatById(userInfo.getUserId());

            DataTable convoUserIds = new DataTable();
            DataColumn col = new DataColumn("ChatId", typeof(Int32));
            convoUserIds.Columns.Add(col);
            col = new DataColumn("UserId", typeof(Int32));
            convoUserIds.Columns.Add(col);
            col = new DataColumn("OtherUserId", typeof(Int32));
            convoUserIds.Columns.Add(col);

            convoUserIds.PrimaryKey = new DataColumn[] { convoUserIds.Columns["ChatId"] };
            int mrRow = 0;

            DataSet recipientOnlyChats = Chat.chatRecipientOnly(userInfo.getUserId());


            if (chatIds.Tables[0].Rows.Count == 0)
            {

                foreach (DataRow chatId in recipientOnlyChats.Tables[0].Rows)
                {
                    int chatIdStore = Convert.ToInt32(recipientOnlyChats.Tables[0].Rows[mrRow]["ChatId"]);
                    int userId = Convert.ToInt32(recipientOnlyChats.Tables[0].Rows[mrRow]["RecipientId"]);

                    int otherUserIdStore = Chat.returnOtherUserByChatRecipient(chatIdStore);

                    DataRow addRowElse = convoUserIds.NewRow();
                    addRowElse["ChatId"] = chatIdStore;
                    addRowElse["UserId"] = userId;
                    addRowElse["OtherUserId"] = otherUserIdStore;
                    convoUserIds.Rows.Add(addRowElse);

                    mrRow++;
                }
            }
            else if (chatIds.Tables[0].Rows.Count != 0 && recipientOnlyChats.Tables[0].Rows.Count != 0)
            {
                foreach (DataRow chatId in recipientOnlyChats.Tables[0].Rows)
                {
                    int chatIdStore = Convert.ToInt32(recipientOnlyChats.Tables[0].Rows[mrRow]["ChatId"]);
                    int userId = Convert.ToInt32(recipientOnlyChats.Tables[0].Rows[mrRow]["RecipientId"]);

                    int otherUserIdStore = Chat.returnOtherUserByChatRecipient(chatIdStore);

                    DataRow addRowElse = convoUserIds.NewRow();
                    addRowElse["ChatId"] = chatIdStore;
                    addRowElse["UserId"] = userId;
                    addRowElse["OtherUserId"] = otherUserIdStore;
                    convoUserIds.Rows.Add(addRowElse);

                    mrRow++;
                }
                foreach (DataRow chatId in chatIds.Tables[0].Rows)
                {
                    int chatIdStore = Convert.ToInt32(chatIds.Tables[0].Rows[mrRow][0]);
                    int userId = Convert.ToInt32(chatIds.Tables[0].Rows[mrRow][1]);

                    int otherUserIdStore = Chat.returnUserChatsRecipientById(chatIdStore);

                    DataRow addRowElse = convoUserIds.NewRow();

                    addRowElse["ChatId"] = chatIdStore;
                    addRowElse["UserId"] = userId;
                    addRowElse["OtherUserId"] = otherUserIdStore;
                    convoUserIds.Rows.Add(addRowElse);

                    mrRow++;
                }
            }
            else
            {
                foreach (DataRow chatId in chatIds.Tables[0].Rows)
                {
                    int chatIdStore = Convert.ToInt32(chatIds.Tables[0].Rows[mrRow][0]);
                    int userId = Convert.ToInt32(chatIds.Tables[0].Rows[mrRow][1]);

                    int otherUserIdStore = Chat.returnUserChatsRecipientById(chatIdStore);

                    DataRow addRowElse = convoUserIds.NewRow();

                    addRowElse["ChatId"] = chatIdStore;
                    addRowElse["UserId"] = userId;
                    addRowElse["OtherUserId"] = otherUserIdStore;
                    convoUserIds.Rows.Add(addRowElse);

                    mrRow++;
                }
            }
            return getOtherUserInfoForChats(convoUserIds);
        }

        private DataTable getOtherUserInfoForChats(DataTable convoUserIds)
        {

            DataTable TableWithOtherUserInfo = new DataTable();

            DataColumn col2 = new DataColumn("OtherUserId", typeof(int));
            TableWithOtherUserInfo.Columns.Add(col2);
            col2 = new DataColumn("Username", typeof(string));
            TableWithOtherUserInfo.Columns.Add(col2);
            col2 = new DataColumn("ChatId", typeof(int));
            TableWithOtherUserInfo.Columns.Add(col2);
            col2 = new DataColumn("FirstName", typeof(string));
            TableWithOtherUserInfo.Columns.Add(col2);
            col2 = new DataColumn("Surname", typeof(string));
            TableWithOtherUserInfo.Columns.Add(col2);
            TableWithOtherUserInfo.PrimaryKey = new DataColumn[] { TableWithOtherUserInfo.Columns["ChatId"] };

            int finalRow = 0;

            foreach (DataRow dr in convoUserIds.Rows)
            {
                DataRow addRowUserInfo = TableWithOtherUserInfo.NewRow();

                Users findUserDetails = new Users();

                int findUser = Convert.ToInt32(convoUserIds.Rows[finalRow]["OtherUserId"]);
                int chatId = Convert.ToInt32(convoUserIds.Rows[finalRow]["ChatId"]);

                findUserDetails.findUser(findUser.ToString());

                addRowUserInfo["ChatId"] = chatId;
                addRowUserInfo["OtherUserId"] = findUserDetails.getUserId();
                addRowUserInfo["Username"] = findUserDetails.getUsername();
                addRowUserInfo["FirstName"] = findUserDetails.getFirstName();
                addRowUserInfo["Surname"] = findUserDetails.getSurname();
                TableWithOtherUserInfo.Rows.Add(addRowUserInfo);

                finalRow++;
            }
            return TableWithOtherUserInfo;
        }

        protected void btnSendMessage_Click(object sender, EventArgs e)
        {
            Users userInfo = (Users)Session["userInfo"];

            Chat getChat = new Chat();
            DateTime date = DateTime.Now;

            int recepientId = getChat.getRecepientIdFromUsername(tbUsername.Text);
            Chat checkForChat = getChat.checkForExistingChat(userInfo.getUserId(), recepientId);
            int chatId = checkForChat.getChatId();

            Messages newMessage = new Messages();

            if (chatId > 0)
            {
                newMessage.sendMessage(userInfo.getUserId(), tbMessageDetails.Text, DateTime.Now, recepientId, chatId);
            }
            else
            {

                Chat createChat = new Chat();
                createChat.initiateChat(userInfo.getUserId(), recepientId);
                int newChatId = createChat.getChatId();
                newMessage.sendMessage(userInfo.getUserId(), tbMessageDetails.Text, DateTime.Now, recepientId, newChatId);
            }

            DataSet chatIds = Chat.returnUserChatById(userInfo.getUserId());

            tbMessageDetails.Text = "";


        }


        protected void lvChats_SelectedIndexChanging(object sender, ListViewSelectEventArgs e)
        {

        }

        protected void btnView_Click(object sender, EventArgs e)
        {
            Users userInfo = (Users)Session["userInfo"];

            LinkButton btn = sender as LinkButton;
            string chatIdString = btn.CommandArgument;

            int chatId = Convert.ToInt32(chatIdString);

            Session["ChatId"] = chatId;
            Messages.viewMessages(chatId, userInfo.getUserId());

            DataSet conversationMessages = Chat.getConversation(chatId);
       
            lvMessagesDisplay.DataSource = conversationMessages;
           
            lvMessagesDisplay.DataBind();

        }


        //private void formatAndDisplayMessages(DataSet messageCollection) {

        //    Users userInfo = (Users)Session["userInfo"];

        //    DataTable messages = messageCollection.Tables["Message"];

        //    foreach (DataRow row in messages.Rows)
        //    {
        //        int checkCreator = Convert.ToInt32(row["CreatorId"]);
        //        string messageBody = row["MessageBody"].ToString();
        //        DateTime messageDate = Convert.ToDateTime(row["CreateDate"]);

        //        if (checkCreator != userInfo.getUserId()) {
        //            Panel otherUserMessages = (Panel)lvMessagesDisplay.FindControl("otherUserMessage");
        //            otherUserMessages.Attributes.Remove("cssClass");
        //            otherUserMessages.Attributes.Add("cssClass", "row d-flex flex-row-reverse");               
        //        }
        //    }

        //    lvMessagesDisplay.DataSource = messages;
        //    lvMessagesDisplay.DataBind();

        //}


    }
}