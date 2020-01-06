using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Web2Ass1Team5.App_Code.BLL;

namespace Web2Ass1Team5
{
    public partial class RegisterSuccessful : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            Users userInfo = (Users)Session["userInfo"];

            lblEmail.Text = userInfo.getEmail();

            lblName.Text = userInfo.getFirstName();


        }
    }
}