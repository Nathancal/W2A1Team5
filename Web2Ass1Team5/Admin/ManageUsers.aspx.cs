using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Web2Ass1Team5.App_Code.BLL;

namespace Web2Ass1Team5.Admin
{
    public partial class ManageUsers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            //Use the dataset returned from the code to be the
            //data source of the grid view
            System.Data.DataSet ds = Users.getUsers();
            gridUsers.DataSource = ds.Tables["Users"];//Links datasource of gridview to dataset with the appropriate table.


            gridUsers.AllowPaging = true;
            gridUsers.PageSize = 4;

            gridUsers.DataBind();//Links dataset to the control



        }

        private void clearTextBoxes()
        {
            tbUsername.Text = "";
            tbEmail.Text = "";
            tbFirstName.Text = "";
            tbSurname.Text = "";
            tbAddress.Text = "";
            tbCity.Text = "";
            tbCounty.Text = "";
            tbCountry.Text = "";
            tbPostCode.Text = "";
            tbPassword.Text = "";
            tbAccessLevel.Text = "";

        }

        protected void gridUsers_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridUsers.PageIndex = e.NewPageIndex;//Checks to see which page your on
            gridUsers.DataBind();//Binds that page to the control

        }

        protected void gridUsers_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {

            Users newUser = new Users(tbUsername.Text, tbFirstName.Text, tbSurname.Text, calDob.SelectedDate.ToString(), tbAddress.Text, tbCity.Text, tbCounty.Text, tbCountry.Text, tbPostCode.Text, tbAccessLevel.Text, tbEmail.Text, tbPassword.Text);


            newUser.createNewUser();
            clearTextBoxes();

        }
    }
}