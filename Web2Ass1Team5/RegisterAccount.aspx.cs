using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Web2Ass1Team5.App_Code.BLL;

namespace Web2Ass1Team5
{
    public partial class RegisteredAccount : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

       


        }


        protected void btnReturnToLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }

        protected void btnRegisterAccount_Click(object sender, EventArgs e)
        {

            try
            {
                Users newUserAccount = new Users(tbUsername.Text,
                                        tbFirstName.Text,
                                        tbSurname.Text,
                                        calDob.SelectedDate.ToString(),
                                        tbAddress.Text,
                                        tbCity.Text,
                                        tbCounty.Text,
                                        tbCountry.Text,
                                        tbPostCode.Text,
                                        tbEmail.Text,
                                        tbPassword.Text);

                newUserAccount.createNewUserNoAccess();

                if(newUserAccount != null)
                {
                    try
                    {
                        Users UserInfo = Users.verifyLogin(tbUsername.Text, tbPassword.Text);

                        if (newUserAccount != null)
                        {

                            Session["userInfo"] = newUserAccount;

                        }
                        else if (UserInfo.getFirstName() == "")
                        {
                            lblErrorMessages.Text = "Invalid credentials. Please try again.";


                        }//TODO needs fixed not reaching else statement if login details incorrect. the page refreshes and nothing happens
                    }
                    catch (Exception ex)
                    {
                        lblErrorMessages.Text = ex.Message;

                    }


                }


                Response.Redirect("RegisterSuccessful.aspx");

            }
            catch (Exception ex)
            {
                lblErrorMessages.Text = ex.StackTrace;
            }


        }
    }
}