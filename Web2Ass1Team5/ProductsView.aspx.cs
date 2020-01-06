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
    public partial class ProductsView : System.Web.UI.Page
    {

        [System.ComponentModel.Browsable(false)]
        [System.Web.UI.TemplateContainer(typeof(System.Web.UI.WebControls.ListViewItem))]
        [System.Web.UI.PersistenceMode(System.Web.UI.PersistenceMode.InnerProperty)]
        public virtual System.Web.UI.ITemplate GroupTemplate { get; set; }


        protected void Page_Load(object sender, EventArgs e)
        {

            //Users userInfo = (Users)Session["userInfo"];

            //if (userInfo == null)
            //{
            //    Response.Redirect("Login.aspx");


            //}



            if (!IsPostBack)
            {
                DataSet productsDisplay = Product.getProducts();

                lvProducts.DataSource = productsDisplay;
                lvProducts.DataBind();

            }


        }

        protected void btnAddToCart_Click(object sender, EventArgs e)
        {

        }

        protected void lvProducts_ItemCommand(object sender, ListViewCommandEventArgs e)
        {


            if (String.Equals(e.CommandName, "Select"))
            {


                ListViewDataItem dataItem = (ListViewDataItem)e.Item;
                string productId = lvProducts.DataKeys[dataItem.DisplayIndex].Value.ToString();

                Product productDetailView = new Product();

                productDetailView.findProduct(productId);

                Session["ProductDetailView"] = productDetailView;

                Response.Redirect("ProductsDetails.aspx");

            }

        }
    }
}