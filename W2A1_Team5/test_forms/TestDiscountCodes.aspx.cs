using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using W2A1Team5.App_Code.BLL;

namespace VapeShop
{
    public partial class TestDiscountCodes : System.Web.UI.Page
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

        protected void dgvDiscountCodes_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }
    }
}