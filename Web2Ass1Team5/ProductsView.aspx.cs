using System;
using System.Collections;
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



            Users userInfo = (Users)Session["userInfo"];

            if (userInfo == null)
            {
                Response.Redirect("Login.aspx");


            }
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

                lvProducts.DataSource = productsDisplay;
                lvProducts.DataBind();

            }


        }

        protected void lvProducts_ItemCommand(object sender, ListViewCommandEventArgs e)
        {

            if (String.Equals(e.CommandName, "addToCart"))
            {

                ArrayList basket;

                ListViewDataItem dataItemAddToCart = (ListViewDataItem)e.Item;
                string productId = lvProducts.DataKeys[dataItemAddToCart.DisplayIndex].Value.ToString();

                Product productDetailView = new Product();

                productDetailView.findProduct(productId);
                double price;


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


    }
}