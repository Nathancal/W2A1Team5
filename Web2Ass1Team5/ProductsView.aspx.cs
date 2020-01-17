using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
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



            Users userInfo = (Users)Session["userInfo"];


            if (displayItems(lvCheckout) != null)
            {
                displayItems(lvCheckout);

            }
            else
            {

            }


            if (!IsPostBack)
            {
                DataSet productsDisplay = Product.getProducts();
                
                
                ViewState["Products"] = productsDisplay.Tables[0];

                lvProducts.DataSource = productsDisplay;
                lvProducts.DataBind();






            }

            NameValueCollection nvc = Request.QueryString;

            if (nvc.HasKeys())
            {
                string typeQueryFromNav = Request.QueryString["Type"];

                DataTable productsNoSearch = (DataTable)ViewState["Products"];

                DataTable dtSearchType = new DataTable();

                var filtered = productsNoSearch.AsEnumerable().Where(r => r.Field<String>("ProductType").Contains(typeQueryFromNav));

                if (filtered.Any())
                {
                    dtSearchType = filtered.CopyToDataTable();
                }

                lvProducts.DataSource = dtSearchType;
                lvProducts.DataBind();

            }


        }

        protected void lvProducts_ItemCommand(object sender, ListViewCommandEventArgs e)
        {

            if (String.Equals(e.CommandName, "addToCart"))
            {
                Users userInfo = (Users)Session["userInfo"];

                if (userInfo == null)
                {
                    Response.Redirect("Login.aspx");


                }

                ArrayList basket;

                ListViewDataItem dataItemAddToCart = (ListViewDataItem)e.Item;
                string productId = lvProducts.DataKeys[dataItemAddToCart.DisplayIndex].Value.ToString();

                Product productDetailView = new Product();

                productDetailView.findProduct(productId);

                CartItem item = new CartItem(productDetailView.getProductId(),
                             productDetailView.getProductName(), productDetailView.getProductType(), productDetailView.getPrice(), 1);


                if (Session["ShoppingBasket"] != null)//If a shopping basket doesnt already exist one is created.
                {
                    basket = (ArrayList)Session["ShoppingBasket"];
                }
                else
                {
                    basket = new ArrayList();
                }



                basket.Add(item);


                //create ShoppingBasket session variable
                Session["ShoppingBasket"] = basket;     

                Response.Redirect("ProductsView.aspx");


       
            }

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


        private DataTable displayItems(ListView lvControl)
        {
            ArrayList basket = (ArrayList)Session["ShoppingBasket"];
            DataTable dt = new DataTable();

            if (Session["ShoppingBasket"] != null)
            {


                DataColumn col = new DataColumn("ProductName");
                dt.Columns.Add(col);
                col = new DataColumn("ProductQuantity", typeof(Int32));
                dt.Columns.Add(col);
                col = new DataColumn("ProductType");
                dt.Columns.Add(col);
                col = new DataColumn("LineCost", typeof(double));
                dt.Columns.Add(col);
                col = new DataColumn("ProductId", typeof(Int32));
                dt.Columns.Add(col);
                dt.PrimaryKey = new DataColumn[] { dt.Columns["ProductId"] };

                lvControl.Items.Clear();

                foreach (CartItem item in basket)
                {
                    if (dt.Rows.Find(item.getProdId()) != null)
                    {
                        DataRow dr = dt.AsEnumerable()
                                       .SingleOrDefault(r => r.Field<int>("ProductId") == item.getProdId());

                        int currentQuantity = (int)dr["ProductQuantity"];
                        currentQuantity += 1;
                        dr["ProductQuantity"] = currentQuantity;

                        double currentCost = (double)dr["LineCost"];

                        double newCost = currentCost + item.getProdPrice();
                        dr["LineCost"] = newCost;
                    }
                    else
                    {

                        DataRow row = dt.NewRow();

                        row["ProductName"] = item.getProdName();
                        row["ProductQuantity"] = item.getProdQuantity();
                        row["ProductType"] = item.getProdType();
                        row["LineCost"] = item.getProdQuantity() * item.getProdPrice();
                        row["ProductId"] = item.getProdId();
                        dt.Rows.Add(row);
                    }
                }

                lvControl.DataSource = dt;
                lvControl.DataBind();

            }

            return dt;

        }

        protected void btnSearchProductName_Click(object sender, EventArgs e)
        {
            string productNameSearch = tbProductName.Text;

            DataTable productsNoSearch = (DataTable)ViewState["Products"];

            DataTable dtSearchName = new DataTable();

            var filtered = productsNoSearch.AsEnumerable().Where(r => r.Field<String>("ProductName").Contains(productNameSearch));

            if (filtered.Any())
            {
                dtSearchName = filtered.CopyToDataTable();
            }

            lvProducts.DataSource = dtSearchName;
            lvProducts.DataBind();

            tbProductName.Text = "";
            tbProductType.Text = "";
            tbProductPrice.Text = "";
        }

        protected void btnSearchProductType_Click(object sender, EventArgs e)
        {
            string productTypeSearch = tbProductType.Text;

            DataTable productsNoSearch = (DataTable)ViewState["Products"];

            DataTable dtSearchType = new DataTable();

            var filtered = productsNoSearch.AsEnumerable().Where(r => r.Field<String>("ProductType").Contains(productTypeSearch));

            if (filtered.Any())
            {
                dtSearchType = filtered.CopyToDataTable();
            }

            lvProducts.DataSource = dtSearchType;
            lvProducts.DataBind();

            tbProductName.Text = "";
            tbProductType.Text = "";
            tbProductPrice.Text = "";
        }

        protected void btnSearchProductPrice_Click(object sender, EventArgs e)
        {


            string productPriceSearch = tbProductPrice.Text;

            DataTable productsNoSearch = (DataTable)ViewState["Products"];

            DataTable dtSearchPrice = new DataTable();

            decimal priceDecimal = Convert.ToDecimal(productPriceSearch);

            var filtered = productsNoSearch.AsEnumerable().Where(r => r.Field<decimal>("Price").Equals(priceDecimal));

            if (filtered.Any())
            {
                dtSearchPrice = filtered.CopyToDataTable();
            }

            lvProducts.DataSource = dtSearchPrice;
            lvProducts.DataBind();


            tbProductName.Text = "";
            tbProductType.Text = "";
            tbProductPrice.Text = "";

        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            DataSet productsDisplay = Product.getProducts();

            lvProducts.DataSource = productsDisplay;
            lvProducts.DataBind();




        }

        protected void lvCheckout_ItemCommand(object sender, ListViewCommandEventArgs e)
        {

            if (String.Equals(e.CommandName, "Empty"))
            {
                Session.Remove("ShoppingBasket");
                displayItems(lvCheckout);

                Response.Redirect("ProductsView.aspx");

            }

            if (String.Equals(e.CommandName, "goToCheckout"))
            {
                Users userInfo = (Users)Session["userInfo"];
                ArrayList basket = (ArrayList)Session["ShoppingBasket"];



                if (userInfo != null)
                {
                    if (basket != null)
                    {
                        Response.Redirect("Secure/Checkout.aspx");
                    }
                    else
                    {
                        Response.Redirect("ProductsView.aspx");
                    }

                }
                else
                {
                    Response.Redirect("Login.aspx");
                }
            }

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

        protected void lvProducts_PagePropertiesChanged(object sender, EventArgs e)
        {
        }

        protected void lvProducts_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            DataPager dp = (DataPager)lvProducts.FindControl("lvProductsDataPager1");
            dp.SetPageProperties(e.StartRowIndex, e.MaximumRows, false);


            lvProducts.DataSource = Product.getProducts();
            lvProducts.DataBind();
        }
    }
}