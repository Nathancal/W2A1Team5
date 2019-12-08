using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VapeShop.App_Code.BLL;


namespace VapeShop
{
    public partial class TestClasses : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            DateTime testDate = new DateTime(1960, 2, 17);

            string date = testDate.ToString("mm-dd-yyyy");



            Users user1 = new Users(tbUsername.Text, tbFirstName.Text, tbSurname.Text, date, tbAddress.Text, tbCity.Text, tbCounty.Text, tbCountry.Text, tbPostCode.Text, tbAccessLevel.Text, tbEmail.Text, tbPassword.Text);

            user1.findUser("nathan@email.com");

            lblOutput.Text = Convert.ToString(user1.getUserId());

            
        }



    }
}