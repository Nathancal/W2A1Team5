using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Web2Ass1Team5.App_Code.BLL;

namespace Web2Ass1Team5
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {


            Users userInfo = (Users)Session["userInfo"];


            if(userInfo != null)
            {

                RegisterNewUser.Visible = false;


            }

            DataSet productsDisplay = Product.getProducts();

            DataTable productsDisplayThree = productsDisplay.Tables["Products"];

            DataTable dtReturnLatestThree = new DataTable();

            var filtered = productsDisplayThree.AsEnumerable().Reverse().Take(3).OrderByDescending(r => r.Field<int>("ProductId"));

            if (filtered.Any())
            {
                dtReturnLatestThree = filtered.CopyToDataTable();
            }

                
            lvProducts.DataSource = dtReturnLatestThree;
            lvProducts.DataBind();

            lvProductReviewsDisplay.DataSource = ProductRating.getLatestRatings();
            lvProductReviewsDisplay.DataBind();


        }

        protected void lvProducts_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (String.Equals(e.CommandName, "Select"))
            {

                ListViewDataItem dataItemProductDetails = (ListViewDataItem)e.Item;
                string productId = lvProducts.DataKeys[dataItemProductDetails.DisplayIndex].Value.ToString();

                Product productDetailView = new Product();

                productDetailView.findProduct(productId);

                Session["ProductDetailView"] = productDetailView;


                Response.Redirect("ProductsDetails.aspx");

            }



        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {

            Response.Redirect("RegisterAccount.aspx");

        }
    }
}