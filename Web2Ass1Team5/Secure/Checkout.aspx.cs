using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Web2Ass1Team5.App_Code.BLL;

namespace Web2Ass1Team5.Secure
{
    public partial class Checkout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            Users userInfo = (Users)Session["userInfo"];



            if (userInfo != null)
            {



                DataTable dt = displayItems(lvCheckout);
                if (!IsPostBack)
                {
                    ddlDeliverySelect.Items.Add("Standard UK (1-3 days)");
                    ddlDeliverySelect.Items.Add("Next day UK");
                    ddlDeliverySelect.Items.Add("Standard EU (3-5 days)");
                    ddlDeliverySelect.Items.Add("Next day EU");


                    ArrayList cartItems = (ArrayList)Session["ShoppingBasket"];

                    tbFirstName.Text = userInfo.getFirstName();
                    tbSurname.Text = userInfo.getSurname();
                    tbAddress.Text = userInfo.getAddress();
                    tbCity.Text = userInfo.getCity();
                    tbCounty.Text = userInfo.getCounty();
                    tbCountry.Text = userInfo.getCountry();
                    tbPostCode.Text = userInfo.getPostCode();

                    double subTotal = 0.0;


                    foreach (CartItem item in cartItems)
                    {

                            DataRow dr = dt.AsEnumerable()
                                           .SingleOrDefault(r => r.Field<int>("ProductId") == item.getProdId());


                            double currentCost = (double)dr["LineCost"];

                            
                            subTotal += currentCost;
                    }

                    

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
                col = new DataColumn("ImageFile");
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

                        Product findProductImage = new Product();

                        findProductImage.findProduct(item.getProdId().ToString());



                        DataRow row = dt.NewRow();

                        row["ProductName"] = item.getProdName();
                        row["ProductQuantity"] = item.getProdQuantity();
                        row["ProductType"] = item.getProdType();
                        row["LineCost"] = item.getProdQuantity() * item.getProdPrice();
                        row["ProductId"] = item.getProdId();
                        row["ImageFile"] = findProductImage.getImageFile();
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

                        lblTest.Text = lvCheckout.SelectedIndex.ToString();

                        ArrayList basket = (ArrayList)Session["ShoppingBasket"];

                        basket.RemoveAt(lvCheckout.SelectedIndex);
                        Session.Remove("ShoppingBasket");

                        Session["ShoppingBasket"] = basket;
                        displayItems(lvCheckout);
                    }


                }
                catch (Exception ex)
                {
                    lblTest.Text = ex.ToString();

                }
                Response.Redirect("Checkout.aspx");

            }

            if (String.Equals(e.CommandName, "emptyShoppingBasket"))
            {
                Session.Remove("ShoppingBasket");
                displayItems(lvCheckout);

                Response.Redirect("Checkout.aspx");

            }


            if (String.Equals(e.CommandName, "goToCheckout"))
            {
                Users userInfo = (Users)Session["userInfo"];
                ArrayList basket = (ArrayList)Session["ShoppingBasket"];



                //if (userInfo != null)
                //{
                if (basket != null)
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
        protected void ddlDeliverySelect_SelectedIndexChanged(object sender, EventArgs e)
        {




        }
    }
}