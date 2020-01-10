using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Web2Ass1Team5.App_Code.BLL;

namespace Web2Ass1_Team5.secure
{
    public partial class Invoices : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ArrayList invoiceItems = (ArrayList)Session["InvoiceItems"];
          
            Users userInfo = (Users)Session["userInfo"];

            if (userInfo != null)
            {
                Invoice invoiceInfo = (Invoice)Session["invObj"];
                if(invoiceInfo != null)
                {
                    DataTable dt = displayItems(lvInvoiceItemDisplay);
                    lblFullName.Text = userInfo.getFirstName() + " " + userInfo.getSurname().ToString();
                    lblAddress.Text = userInfo.getAddress();
                    lblCity.Text = userInfo.getCity();
                    lblCounty.Text = userInfo.getCounty();
                    lblCountry.Text = userInfo.getCountry();
                    lblPostCode.Text = userInfo.getPostCode();

                    lblInvoiceNum.Text = invoiceInfo.getInvoiceNum().ToString();

                    lblInvoiceDate.Text = invoiceInfo.getOrderDate().ToString();

                    lblTotalFinal.Text = invoiceInfo.getTotalCost().ToString();
                    lblSubTotal.Text = invoiceInfo.getSubTotal().ToString();
                    lblDiscountApplied.Text = invoiceInfo.getDiscountAmount().ToString();
                }
                else
                {
                    lblInvoiceNum.Text = "No invoice found";

                }
            }
        }

        private DataTable displayItems(ListView lvControl)
        {
            ArrayList invoiceItems = (ArrayList)Session["InvoiceItems"];
            DataTable dt = new DataTable();

            if (Session["InvoiceItems"] != null)
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
                col = new DataColumn("ProductPrice", typeof(double));
                dt.Columns.Add(col);

                dt.PrimaryKey = new DataColumn[] { dt.Columns["ProductId"] };

                lvControl.Items.Clear();

                foreach (CartItem item in invoiceItems)
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
                        row["ProductPrice"] = findProductImage.getPrice();
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