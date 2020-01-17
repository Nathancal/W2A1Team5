using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Web2Ass1Team5.App_Code.BLL;

namespace Web2Ass1_Team5.secure
{
    public partial class Profile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            Users userInfo = (Users)Session["userInfo"];


            if (userInfo == null) {

                Response.Redirect("~/Login.aspx");
            }

            lblEmail.Text = userInfo.getEmail();
            lblUsername.Text = userInfo.getUsername();
            lblFirstName.Text = userInfo.getFirstName();
            lblSurname.Text = userInfo.getSurname();
            lblAddress.Text = userInfo.getAddress();
            lblCity.Text = userInfo.getCity();
            lblCounty.Text = userInfo.getCounty();
            lblCountry.Text = userInfo.getCountry();
            lblPostcode.Text = userInfo.getPostCode();

            int unreadMessages = Messages.getUnreadMessageCount(userInfo.getUserId());


            if (unreadMessages > 0) {
                lblUnreadMessages.Text = Messages.getUnreadMessageCount(userInfo.getUserId()).ToString();
            }else
            {
                lblUnreadMessages.Text = "No new messages, start a chat!";
            }

            dgvInvoices.DataSource = Invoice.returnInvoices(userInfo.getEmail());
            dgvInvoices.DataBind();
            
            DiscountCode randomCode = DiscountCode.randomDiscountCode(userInfo.getUserId());

            lblDiscountCodeRandom.Text = randomCode.getCode();

        }

        protected void ddlDefaultDelivery_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        protected void btnViewProducts_Click(object sender, EventArgs e)
        {

            Response.Redirect("~/ProductsView.aspx");


        }

        protected void btnViewChats_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/secure/Message.aspx");
        }
    }
}