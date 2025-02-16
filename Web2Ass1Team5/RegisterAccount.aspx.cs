﻿using System;
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

            Users userInfo = (Users)Session["userInfo"];

            if (userInfo != null)
            {
                Response.Redirect("Home.aspx");

            }
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


                Users UserInfo = Users.verifyLogin(tbUsername.Text, tbPassword.Text);

                if (UserInfo != null)
                {

                    Session["userInfo"] = UserInfo;
                    System.Web.Security.FormsAuthentication.RedirectFromLoginPage(UserInfo.getUsername(),
                                                            false);

                }


            }
            catch (Exception ex)
            {
                lblErrorMessages.Text = ex.StackTrace;
            }



        }
    }
}