using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Web2Ass1Team5.App_Code.BLL;

namespace W2A1Team5
{
    public partial class VapeMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            showAdminArea.Visible = false;


            Users userInfo = (Users)Session["userInfo"];

            if(userInfo != null)
            {
                if (Convert.ToInt32(userInfo.getUserAccessLevel()) > 0)
                {
                    showAdminArea.Visible = true;

                }


            }

        }

        protected void lnkTanksClick_Click(object sender, EventArgs e)
        {
            string type = "Tanks";

            Response.Redirect("~/ProductsView.aspx?Type=" + type);


        }

        protected void lnkStarterKits_Click(object sender, EventArgs e)
        {
            string type = "Starter Kits";

            Response.Redirect("~/ProductsView.aspx?Type=" + type);


        }

        protected void lnkAdvancedKits_Click(object sender, EventArgs e)
        {
            string type = "Advanced Kits";

            Response.Redirect("~/ProductsView.aspx?Type=" + type);


        }

        protected void lnkMods_Click(object sender, EventArgs e)
        {
            string type = "Mods";

            Response.Redirect("~/ProductsView.aspx?Type=" + type);

        }

        protected void lnkProducts_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ProductsView.aspx");
        }

        protected void imgbLogin_Click(object sender, ImageClickEventArgs e)
        {
            Users userInfo = (Users)Session["userInfo"];

            if (userInfo != null)
            {
                Response.Redirect("~/secure/Profile.aspx");

            }
            else
            {
                Response.Redirect("~/Login.aspx");

            }



        }

        protected void lbAdmin_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Admin/AdminHome.aspx");

        }

        protected void lnkHelp_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Help.aspx");
        }

        protected void lbHome_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Home.aspx");
        }
    }
}