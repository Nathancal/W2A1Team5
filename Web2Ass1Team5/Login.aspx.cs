using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Web2Ass1Team5.App_Code.BLL;

namespace Web2Ass1Team5
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                Users UserInfo = Users.verifyLogin(tbUsername.Text, tbPassword.Text);

                if (UserInfo != null)
                {

                    Session["userInfo"] = UserInfo;
                    System.Web.Security.FormsAuthentication.RedirectFromLoginPage(UserInfo.getUsername(),
                                                            chkPersist.Checked);

                }
                else if (UserInfo.getFirstName() == "")
                {
                    lblSumbitSuccess.Text = "Invalid credentials. Please try again.";


                }//TODO needs fixed not reaching else statement if login details incorrect. the page refreshes and nothing happens
            }
            catch (Exception ex)
            {
                lblSumbitSuccess.Text = ex.Message;

            }
        }
    }
}