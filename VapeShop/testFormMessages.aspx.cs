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
        Conversation getConvo; 

        protected void Page_Load(object sender, EventArgs e)
        {
            getConvo = new Conversation(005, tbUsername.Text);

            System.Data.DataSet ds = Conversation.getConversation(getConvo.getUserId(), getConvo.getUsername());
            dgvProducts.DataSource = ds.Tables["Message"];//Links datasource of gridview to dataset with the appropriate table.


            dgvProducts.DataBind();//Links dataset to the control

        }

        protected void dgvProducts_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgvProducts.PageIndex = e.NewPageIndex;//Checks to see which page your on
            dgvProducts.DataBind();//Binds that page to the control
        }

        protected void btnSendMessage_Click(object sender, EventArgs e)
        {
            getConvo = new Conversation(005, tbUsername.Text);


            if (Conversation.getConversation(getConvo.getUserId(), getConvo.getUsername()) == null)
            {
                Message newMessage = new Message(getConvo.getUserId(), tbSubject.Text, tbMessageBody.Text, DateTime.Now, tbUsername.Text);
            }
            else
            {

            }

            System.Data.DataSet ds = Conversation.getConversation(getConvo.getUserId(), getConvo.getUsername());
            dgvProducts.DataSource = ds.Tables["Message"];//Links datasource of gridview to dataset with the appropriate table.
        }
    }
}