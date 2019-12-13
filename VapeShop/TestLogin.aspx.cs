using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VapeShop.App_Code.BLL;


namespace VapeShop
{
    public partial class TestLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                Users UserInfo = Users.verifyLogin(tbEmailUsername.Text, tbPassword.Text);

                if (UserInfo != null)
                {
                    Session["userID"] = Convert.ToInt32(UserInfo.getUserId());
                    Session["userEmail"] = UserInfo.getEmail();
                    Session["username"] = UserInfo.getUsername();

                    System.Web.Security.FormsAuthentication.RedirectFromLoginPage(UserInfo.getUsername(),
                                                            chkPersist.Checked);

                }
                else if(UserInfo.getUserId() < 1)
                {
                    lblRefuse.Text = "Invalid credentials. Please try again.";
                }
            }
            catch
            {


            }
            



        }
    }
}