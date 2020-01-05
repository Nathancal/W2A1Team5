using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Web2Ass1Team5.App_Code.BLL;

namespace Web2Ass1Team5.Admin
{
    public partial class ManageDiscountCodes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            //Use the dataset returned from the code to be the
            //data source of the grid view
            System.Data.DataSet ds = DiscountCode.getDiscountCodes();
            dgvDiscountCodes.DataSource = ds.Tables["DiscountCodes"];//Links datasource of gridview to dataset with the appropriate table.


            dgvDiscountCodes.AllowPaging = true;
            dgvDiscountCodes.PageSize = 4;

            dgvDiscountCodes.DataBind();//Links dataset to the control

        }

        private void clearTextBoxes() {
            tbDiscountCodeId.Text = "";
            calDateActive.SelectedDates.Clear();
            calDateEnds.SelectedDates.Clear();
            tbDiscountPerc.Text = "";
            lblSumbitSuccess.Text = "";
        }

        protected void dgvDiscountCodes_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgvDiscountCodes.PageIndex = e.NewPageIndex;//Checks to see which page your on
            dgvDiscountCodes.DataBind();//Binds that page to the control
        }

        protected void dgvDiscountCodes_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }

        protected void btnAddCode_Click(object sender, EventArgs e)
        {
            try {
                DiscountCode newCode = new DiscountCode(tbDiscountCodeId.Text, calDateActive.SelectedDate, calDateEnds.SelectedDate, Convert.ToInt32(tbDiscountPerc.Text));
                newCode.createNewDiscountCode(tbDiscountCodeId.Text, calDateActive.SelectedDate, calDateEnds.SelectedDate, Convert.ToInt32(tbDiscountPerc.Text));
                lblSumbitSuccess.Text = "Discount code" + tbDiscountCodeId.Text + " has been successfully created";
                clearTextBoxes();
                Response.Redirect(Request.RawUrl);

            }
            catch (Exception ex)
            {
                lblSumbitSuccess.Text = ex.Message;
            }


        }

    }
}