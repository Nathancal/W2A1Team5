using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Web2Ass1Team5.App_Code.BLL;

namespace Web2Ass1Team5
{
    public partial class ProductsDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            //Users userInfo = (Users)Session["userInfo"];

            Product productInfo = (Product)Session["ProductDetailView"];


            //if (userInfo != null)
            //{

            if(productInfo != null)
            {
                productImage.Src = productInfo.getImageFile();
                lblProductName.Text = productInfo.getProductName();
                lblProductPrice.Text = productInfo.getPrice().ToString();
                lblProductDescription.Text = productInfo.getProductDesc();
                lblProductType.Text = productInfo.getProductType();
            }
            else
            {
                Response.Redirect("ProductsView.aspx");
            }



            //}
            //else
            //{
            //    Response.Redirect("Login.aspx");

            //}

        }
    }
}