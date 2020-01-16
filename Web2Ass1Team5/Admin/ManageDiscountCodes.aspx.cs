using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Web2Ass1Team5.App_Code.BLL;

namespace Web2Ass1Team5.Admin
{
    public partial class ManageDiscountCodes : System.Web.UI.Page
    {
        private void Refresh()
        {


            System.Data.DataSet ds = DiscountCode.getDiscountCodes();
            gridDiscountCodes.DataSource = ds.Tables["DiscountCodes"];//Links datasource of gridview to dataset with the appropriate table.


            gridDiscountCodes.AllowPaging = true;
            gridDiscountCodes.PageSize = 10;

            gridDiscountCodes.DataBind();//Links dataset to the control

        }

        protected void Page_Load(object sender, EventArgs e)
        {   
            System.Data.DataSet ds = DiscountCode.getDiscountCodes();
            gridDiscountCodes.DataSource = ds.Tables["DiscountCodes"];//Links datasource of gridview to dataset with the appropriate table.

            gridDiscountCodes.AllowPaging = true;
            gridDiscountCodes.PageSize = 10;

            gridDiscountCodes.DataBind();//Links dataset to the control
        }



        private void clearTextBoxes()
        {
            tbDiscountCodeId.Text = "";
            calDateActive.SelectedDates.Clear();
            calDateEnds.SelectedDates.Clear();
            tbDiscountPerc.Text = "";
            lblSumbitSuccess.Text = "";
        }

        protected void btnAddCode_Click(object sender, EventArgs e)
        {

            if (calDateActive.SelectedDate != null && calDateEnds.SelectedDate != null)
            {
                try
                {



                    DiscountCode newCode = new DiscountCode(tbDiscountCodeId.Text, calDateActive.SelectedDate, calDateEnds.SelectedDate, Convert.ToInt32(tbDiscountPerc.Text), cbSetActive.Checked);
                    newCode.createNewDiscountCode(tbDiscountCodeId.Text, calDateActive.SelectedDate, calDateEnds.SelectedDate, Convert.ToInt32(tbDiscountPerc.Text), cbSetActive.Checked);
                    lblSumbitSuccess.Text = "Discount code" + tbDiscountCodeId.Text + " has been successfully created";
                    clearTextBoxes();
                    Refresh();

                }
                catch (Exception ex)
                {
                    lblSumbitSuccess.Text = ex.Message;
                }
            }
            else
            {
                lblSumbitSuccess.Text = "No Dates Selected";

            }

            Response.Redirect("/Admin/ManageDiscountCodes.aspx");

        }

        protected void btnClearForm_Click(object sender, EventArgs e)
        {
            clearTextBoxes();
        }

        protected void lnkBtnEdit_Click(object sender, EventArgs e)
        {

        }

        protected void gridDiscountCodes_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }

        protected void gridDiscountCodes_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridDiscountCodes.PageIndex = e.NewPageIndex;//Checks to see which page your on
            gridDiscountCodes.DataBind();//Binds that page to the control
        }

    }
}