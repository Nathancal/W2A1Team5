using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Web2Ass1Team5.App_Code.BLL;
using System.IO;

namespace Web2Ass1Team5.Admin
{
    public partial class AdminHome : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            Users userInfo = (Users)Session["userInfo"];

            int accessLevel = Convert.ToInt32(userInfo.getUserAccessLevel());
            if (userInfo == null)
            {
                if (accessLevel == 0)
                {
                    Response.Redirect("~/home.aspx");

                }


            }



        }

        protected void btnChat_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/secure/Message.aspx");
        }
    }
}