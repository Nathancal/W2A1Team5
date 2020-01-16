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


            Users userInfo = (Users)Session["userInfo"];
            ArrayList invoiceItemsReview = (ArrayList)Session["InvoiceItems"];


            if (userInfo != null)
            {

                Product productInfo = (Product)Session["ProductDetailView"];

                if (productInfo != null)
                {
                    productImage.Src = productInfo.getImageFile();
                    lblProductName.Text = productInfo.getProductName();
                    lblProductPrice.Text = productInfo.getPrice().ToString();
                    lblProductDescription.Text = productInfo.getProductDesc();
                    lblProductType.Text = productInfo.getProductType();

                    ProductRating getRating = new ProductRating();
                    

                    lvProductReviewsDisplay.DataSource = ProductRating.getRatingsForProduct(productInfo.getProductId());
                    lvProductReviewsDisplay.DataBind();
                }
                else
                {
                    Response.Redirect("ProductsView.aspx");
                }




                if (invoiceItemsReview != null)
                {
                    foreach (CartItem item in invoiceItemsReview)
                    {
                        if (item.getProdId() == productInfo.getProductId())
                        {
                            ProductRating rateProduct = new ProductRating();
                            ProductRating checkDB = new ProductRating();

                            checkDB.setProductId(productInfo.getProductId());
                            checkDB.setUserId(userInfo.getUserId());

                            if (rateProduct.returnRating(checkDB.getProductId(), checkDB.getUserId()) == null)
                            {

                                RateProductRow.Visible = true;
                                break;
                            }
                            else
                            {
                                RateProductRow.Visible = false;

                            }

                        }
                        else
                        {
                            RateProductRow.Visible = false;
                        }

                    }
                }
                else
                {
                    RateProductRow.Visible = false;

                }

                if (!IsPostBack)
                {
                    Session["CheckoutListViewData"] = displayItems(lvCheckout);
                }




            }
            else
            {
                Response.Redirect("Login.aspx");

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



                if (userInfo != null)
                {
                    if (basket != null)
                    {
                        Response.Redirect("Secure/Checkout.aspx");
                    }

                }
                else
                {
                    Response.Redirect("Login.aspx");
                }
            }
        }

        protected void btnSubmitRating_Click(object sender, EventArgs e)
        {
            Product productInfo = (Product)Session["ProductDetailView"];
            Users userInfo = (Users)Session["userInfo"];
            ProductRating checkRating = null;

            if (Session["ShoppingBasket"] == null && Session["InvoiceItems"] != null)
            {
                ArrayList invoiceItemsReview = (ArrayList)Session["InvoiceItems"];


                RateProductRow.Visible = true;

                int ddlSelectedValue = Convert.ToInt32(ddlProductRating.SelectedValue);

                ProductRating createNewRating = new ProductRating();
                checkRating = createNewRating.createRating(productInfo.getProductId(), ddlSelectedValue, userInfo.getUserId(), tbRatingDescription.Text);



            }


            if(checkRating != null)
            {
                RateProductRow.Visible = false;
            }

        }

        protected void btnAddToCart_Click(object sender, EventArgs e)
        {
            Users userInfo = (Users)Session["userInfo"];

            if (userInfo == null)
            {
                Response.Redirect("Login.aspx");


            }

            ArrayList basket;

            Product productInfo = (Product)Session["ProductDetailView"];

            string productId = productInfo.getProductId().ToString();

            Product productDetailView = new Product();

            productDetailView.findProduct(productId);

            CartItem item = new CartItem(productDetailView.getProductId(),
                         productDetailView.getProductName(), productDetailView.getProductType(), productDetailView.getPrice(), Convert.ToInt32(ddlQuantity.SelectedValue));


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
    }
}



