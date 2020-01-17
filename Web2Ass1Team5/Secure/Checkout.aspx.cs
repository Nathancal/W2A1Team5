using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Globalization;
using Web2Ass1Team5.App_Code.BLL;

namespace Web2Ass1Team5.Secure
{
    public partial class Checkout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            //Creates the user session
            Users userInfo = (Users)Session["userInfo"];

            //Initialy set in invisible
            toggleCodeApplied.Visible = false;
            DiscountRedeemFailure.Visible = false;

            //If the user is logged in
            if (userInfo != null)
            {


                //Creates datatable from displayitems method, with the checkout listview as a parameter
                DataTable dt = displayItems(lvCheckout);
                if (!IsPostBack)
                {

                    //Initialises the cart items array list with the session
                    ArrayList cartItems = (ArrayList)Session["ShoppingBasket"];

                    //Fills out user information giving user the opportunity to change
                    tbFirstName.Text = userInfo.getFirstName();
                    tbSurname.Text = userInfo.getSurname();
                    tbAddress.Text = userInfo.getAddress();
                    tbCity.Text = userInfo.getCity();
                    tbCounty.Text = userInfo.getCounty();
                    tbCountry.Text = userInfo.getCountry();
                    tbPostCode.Text = userInfo.getPostCode();

                    //Initialises variables
                    double subTotal = 0.0;
                    double storedCost = 0.00;

                    //Loops through the arraylist
                    foreach (CartItem item in cartItems)
                    {


                        DataRow dr = dt.AsEnumerable()
                                       .SingleOrDefault(r => r.Field<int>("ProductId") == item.getProdId());

                        //takes the value of each item and stores it
                        double currentCost = item.getProdPrice();



                        //Adds item cost to running total
                        storedCost += currentCost;
                    }


                    subTotal = storedCost;
                    
                    //Divides the various costs and displays in labels
                    double vat = (subTotal / 100) * 20;
                    double beforeVat = subTotal / 100 * 80;
                    lblSubTotal.Text = beforeVat.ToString("£##.00");
                    lblVat.Text = vat.ToString("£##.00");
                    lblHiddenCost.Text = subTotal.ToString();

                    double deliveryCost = Convert.ToDouble(this.lblDelivery.Text);
                    double total = subTotal + deliveryCost;

                    lblTotal.Text = total.ToString();

                }

            }
            else
            {   //if user not logged in redirect
                Response.Redirect("~/Login.aspx");

            }
        }

        private DataTable displayItems(ListView lvControl)
        {
            ArrayList basket = (ArrayList)Session["ShoppingBasket"];
            DataTable dt = new DataTable();

            if (Session["ShoppingBasket"] != null)
            {

                //Instantiates table
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
                    //Checks to see if the item already exists in the datatable, if so
                    //the item is not added for a second time, but the quantity is updated
                    if (dt.Rows.Find(item.getProdId()) != null)
                    {
                        //Identifies the row with the duplicate item
                        DataRow dr = dt.AsEnumerable()
                                              .SingleOrDefault(r => r.Field<int>("ProductId") == item.getProdId());
                        //Updates quantity
                        int currentQuantity = (int)dr["ProductQuantity"];
                        currentQuantity += 1;
                        dr["ProductQuantity"] = currentQuantity;

                        double currentCost = (double)dr["LineCost"];

                        //updates line cost
                        double newCost = currentCost + item.getProdPrice();
                        dr["LineCost"] = newCost;
                    }
                    else
                    {

                        Product findProductImage = new Product();

                        findProductImage.findProduct(item.getProdId().ToString());


                        //If the item does not already exist in the data table a new row is created.
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

                //Listview is rebound to the datatable
                lvControl.DataSource = dt;
                lvControl.DataBind();

            }
            //Datatable returned
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
                        Session.Remove("ShoppingBasket");

                        Session["ShoppingBasket"] = basket;
                        displayItems(lvCheckout);
                    }


                }
                catch (Exception ex)
                {
                    lblTotal.Text = ex.ToString();

                }
                Response.Redirect("Checkout.aspx");

            }//Not working

            //Allows the user to empty their shopping basket of all items
            if (String.Equals(e.CommandName, "emptyShoppingBasket"))
            {
                Session.Remove("ShoppingBasket");
                displayItems(lvCheckout);

                Response.Redirect("Checkout.aspx");

            }
        }

        //Allows the user to select their delivery preference.
        protected void ddlDeliverySelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            double delivery = 0;
            switch (ddlDeliverySelect.SelectedIndex)
            {
                case 0:
                     delivery = 0;
                    lblDelivery.Text = "0";
                    lblHiddenDelivery.Text = "0";
                    break;
                case 1:
                    delivery = 5;

                    lblDelivery.Text = "5";
                    lblHiddenDelivery.Text = "5";
                    break;
                case 2:
                    delivery = 8;

                    lblDelivery.Text = "8";
                    lblHiddenDelivery.Text = "8";
                    break;
                case 3:
                    delivery = 15;
                    lblDelivery.Text = "15";
                    lblHiddenDelivery.Text = "15";
                    break;
            }//switch
            ViewState["Delivery"] = delivery;
        }

        //This is evoked when the user applies a discount code.
        protected void btnRedeemCode_Click(object sender, EventArgs e)
        {

            try
            {

                Users userInfo = (Users)Session["userInfo"];

                string discountCodeEntered = tbDiscountCodeRedeem.Text;

                DiscountCode selectCode = new DiscountCode();


                selectCode = DiscountCode.selectDiscountCode(discountCodeEntered);

                //If the discount code redeem is successful then the values are applied.
                if (selectCode.redeemDiscountCode(selectCode.getCode(), userInfo.getUserId()) == 1)
                {

                    Session["RedeemedDiscountCode"] = selectCode;

                    toggleCodeApplied.Visible = true;
                    DiscountRedeemFailure.Visible = false;
                    lblDiscountCodeAmount.Text = selectCode.getDiscountPerc().ToString() + "% Off with discount code " + selectCode.getCode();
                    
                    double subTotal = 0.0;
                    double storedCost = 0.00;
                    
                    ArrayList cartItems = (ArrayList)Session["ShoppingBasket"];

                    DataTable dt = displayItems(lvCheckout);

                    //total cost is recalculated before the discount is applied
                    foreach (CartItem item in cartItems)
                    {

                        DataRow dr = dt.AsEnumerable()
                                       .SingleOrDefault(r => r.Field<int>("ProductId") == item.getProdId());


                        double currentCost = item.getProdPrice();

                        storedCost += currentCost;
                    }


                    subTotal = storedCost;



                    int remainder = 100 - selectCode.getDiscountPerc();
                    double total = (subTotal / 100) * remainder;


                    lblDiscountTotalIndicator.Text = selectCode.getDiscountPerc().ToString() + "% Discount";
                    lblTotal.Text = total.ToString("£##.00");


                }//If the discount code has already been used by the user error shown
                else if (selectCode.redeemDiscountCode(selectCode.getCode(), userInfo.getUserId()) == 0)
                {
                    toggleCodeApplied.Visible = false;
                    DiscountRedeemFailure.Visible = true;
                    lblDiscountCodeFail.Text = "You have already used this discount code";

                }
                else
                {
                    toggleCodeApplied.Visible = false;
                    DiscountRedeemFailure.Visible = true;
                    lblDiscountCodeFail.Text = "Discount Code does not exist";

                }
            }
            catch (Exception ex)
            {
                toggleCodeApplied.Visible = false;
                DiscountRedeemFailure.Visible = true;
                lblDiscountCodeFail.Text = ex.ToString();
            }
        }

        protected void btnCompleteTransaction_Click(object sender, EventArgs e)
        {

            Users userInfo = (Users)Session["userInfo"];

            ArrayList cartItems = (ArrayList)Session["ShoppingBasket"];

            DataTable dt = displayItems(lvCheckout);

            DiscountCode selectCode = (DiscountCode)Session["RedeemedDiscountCode"];
           
            double subTotal = 0.0;
            double storedCost = 0.00;

            foreach (CartItem item in cartItems)
            {

                DataRow dr = dt.AsEnumerable()
                               .SingleOrDefault(r => r.Field<int>("ProductId") == item.getProdId());

                double currentCost = item.getProdPrice() * item.getProdQuantity();

                storedCost += currentCost;
            }

            subTotal = storedCost;

            double deliveryCost = Convert.ToDouble(this.lblDelivery.Text);
      
            int invoiceNum;
            double total;

            if (selectCode != null)
            {
                int remainder = 100 - selectCode.getDiscountPerc();
                total = ((subTotal / 100) * remainder) + deliveryCost;
                Invoice myInvoice = new Invoice(userInfo.getFirstName(), ddlDeliverySelect.SelectedValue.ToString(), subTotal, deliveryCost,  total, selectCode.getDiscountPerc()); ;
                invoiceNum = myInvoice.createInvoice();
                myInvoice.setInvoiceNum(invoiceNum);
                Session["invObj"] = myInvoice;
            }
            else
            {
                total = subTotal + deliveryCost;
                Invoice myInvoice = new Invoice(userInfo.getFirstName(), ddlDeliverySelect.SelectedValue.ToString(), subTotal, deliveryCost,  total, 0); ;
                invoiceNum = myInvoice.createInvoice();
                myInvoice.setInvoiceNum(invoiceNum);
                Session["invObj"] = myInvoice;
            }

            ArrayList basket = null; //create an ArrayList called basket
            if (Session["ShoppingBasket"] != null)
            {
                basket = (ArrayList)Session["ShoppingBasket"];
                // go through each item in basket and add to tblOrderItems
                foreach (CartItem item in basket)
                {


                    // Add item to tblOrderItems
                    item.createOrderItem(invoiceNum);
                }//for each
            } // if

            //updateStock method returns the number of changed records
            int updated = Product.updateStock(basket);

            Session["InvoiceItems"] = basket;

            //Shopping basket is now emptied
            Session.Remove("ShoppingBasket");

            //Open the invoice details page and pass across query string
            Response.Redirect("Invoices.aspx?recordsUpdated=" +
                                        Server.UrlEncode(updated.ToString()));

        }
    }
}