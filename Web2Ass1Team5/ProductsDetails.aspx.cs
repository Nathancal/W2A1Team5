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
    public partial class ProductsDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {


            //Users userInfo = (Users)Session["userInfo"];



            //if (userInfo != null)
            //{

            Product productInfo = (Product)Session["ProductDetailView"];


            if (!IsPostBack)
            {
                Session["CheckoutListViewData"] = displayItems(lvCheckout);
            }



            if (productInfo != null)
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

                        lblProductName.Text = item.getProdType().ToString();

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

        protected void lvCheckout_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (String.Equals(e.CommandName, "removeFromBasket"))
            {

                try
                {
                    if (lvCheckout.SelectedIndex != -1)
                    {
                        ArrayList basket = (ArrayList)Session["ShoppingBasket"];

                        basket.RemoveAt(lvCheckout.SelectedIndex);
                        Session["ShoppingBasket"] = basket;

                        displayItems(lvCheckout);
                    }
                    else
                    {

                    }

                }
                catch (Exception ex)
                {
                    ex.ToString();

                }
                Response.Redirect("ProductsView.aspx");

            }

            if (String.Equals(e.CommandName, "emptyShoppingBasket"))
            {
                Session.Remove("ShoppingBasket");
                displayItems(lvCheckout);

                Response.Redirect("ProductsDetails.aspx");

            }


            if (String.Equals(e.CommandName, "goToCheckout"))
            {
                Users userInfo = (Users)Session["userInfo"];
                ArrayList basket = (ArrayList)Session["ShoppingBasket"];



                //if (userInfo != null)
                //{
                    if(basket != null)
                    {
                        Response.Redirect("Secure/Checkout.aspx");
                    }

                //}
                //else
                //{
                //    Response.Redirect("Login.aspx");
                //}
            }
        }
    }


}
