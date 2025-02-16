﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Web2Ass1Team5.App_Code.BLL;
using System.IO;


namespace Web2Ass1Team5.Admin
{
    public partial class Admin : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {


            Users userInfo = (Users)Session["userInfo"];

            userInfo.getUserId();

            lblAdminName.Text = userInfo.getFirstName();

            int accessLevel = Convert.ToInt32(userInfo.getUserAccessLevel());

            if (accessLevel == 0)
            {
                Response.Redirect("~/home.aspx");

            }

        }

        protected void lbHomeAdmin_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Home.aspx");
        }

        protected void lbDiscountCodes_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Admin/ManageDiscountCodes.aspx");
        }

        protected void lbProducts_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Admin/ManageProducts.aspx");
        }

        protected void lbProductRatings_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Admin/ProductRatings.aspx");

        }

        protected void lbUsers_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Admin/ManageUsers.aspx");
        }
    }
}