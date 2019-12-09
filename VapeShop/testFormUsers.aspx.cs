using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VapeShop.App_Code.BLL;

namespace VapeShop
{
    public partial class testForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
         
            Users user1 = new Users(tbUsername.Text,
                tbFirstName.Text,
                tbSurname.Text,
                calDob.SelectedDate.ToString(),
                tbAddress.Text,
                tbCity.Text,
                tbCounty.Text,
                tbCountry.Text,
                tbPostCode.Text,
                tbAccessLevel.Text,
                tbEmail.Text,
                tbPassword.Text);

            user1.createNewUser();


            lblOutput.Text = tbUsername.Text;
            lblOutput2.Text = tbSurname.Text;

        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Users searchUsers = new Users();

            searchUsers.findUser(tbSearch.Text);

            lblFirstName.Text = searchUsers.getFirstName();
            lblSurname.Text = searchUsers.getSurname();
            lblUsername.Text = searchUsers.getUsername();

        }
    }
}