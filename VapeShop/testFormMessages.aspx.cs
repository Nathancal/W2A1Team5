using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VapeShop.App_Code.BLL;
using System.IO;

namespace VapeShop
{
    public partial class testFormMessages : System.Web.UI.Page
    {
        int userId;
        protected void Page_Load(object sender, EventArgs e)
        {
            userId = Convert.ToInt32(Session["userID"]);

            Label3.Text = userId.ToString();
            
        }

        protected void dgvProducts_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgvMessages.PageIndex = e.NewPageIndex;//Checks to see which page your on
            dgvMessages.DataBind();//Binds that page to the control
        }

        protected void btnSendMessage_Click(object sender, EventArgs e)
        {

            Chat getChat = new Chat();
            string recepientUsername = tbUsername.Text.ToString();
            DateTime date = DateTime.Now;

            int recepientId = getChat.getRecepientIdFromUsername(recepientUsername);
            Chat checkForChat = getChat.checkForExistingChat(userId, recepientUsername);
            int chatId = checkForChat.getChatId();


            Message newMessage = new Message();

            if (chatId > 0){

                newMessage.sendMessage(userId, tbMessageBody.Text, date, recepientId, chatId);
            }else{
                Chat createChat = new Chat();
                createChat.createNewChat(userId, recepientId);
                int newChatId = createChat.getChatId();
                newMessage.sendMessage(userId, tbMessageBody.Text, date, recepientId, newChatId);
                Label3.Text = newChatId.ToString();
            }


            lblTestUnreadCount.Text = newMessage.getUnreadMessageCount(userId).ToString();




        }

        protected void btnLoadConvos_Click(object sender, EventArgs e)
        {
            Chat getChat = new Chat();

            string recepientUsername = tbUsername.Text.ToString();
            int recepientId = getChat.getRecepientIdFromUsername(recepientUsername);


            System.Data.DataSet ds1 = Chat.getConversation(userId, recepientId);
            lvMessages.DataSource = ds1.Tables["Message"];//Links datasource of gridview to dataset with the appropriate table.
            lvMessages.DataSource = ds1.Tables["MessageRecipient"];//Links datasource of gridview to dataset with the appropriate table.

            lvMessages.DataBind();

            //Use the dataset returned from the code to be the
            //data source of the grid view
            System.Data.DataSet ds = Chat.getConversation(userId, recepientId);
            dgvMessages.DataSource = ds.Tables["Message"];//Links datasource of gridview to dataset with the appropriate table.
            dgvMessages.DataSource = ds.Tables["MessageRecipient"];//Links datasource of gridview to dataset with the appropriate table.



            dgvMessages.AllowPaging = true;
            dgvMessages.PageSize = 4;

            dgvMessages.DataBind();//Links dataset to the control
        }
    }
}