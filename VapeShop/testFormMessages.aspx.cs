using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VapeShop.App_Code.BLL;
using System.IO;

namespace VapeShop
{
    public partial class testFormMessages : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            //Use the dataset returned from the code to be the
            //data source of the grid view
            System.Data.DataSet ds = Message.getConversation(005, "joe123");
            lvMessages.DataSource = ds.Tables["Message"];//Links datasource of gridview to dataset with the appropriate table.


            lvMessages.DataBind();//Links dataset to the control

        }


    }
}