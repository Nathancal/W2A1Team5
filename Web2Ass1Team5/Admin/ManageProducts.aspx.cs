using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Web2Ass1Team5.App_Code.BLL;

namespace Web2Ass1Team5.Admin
{
    public partial class ManageProducts : System.Web.UI.Page
    {
        private void refreshTable()
        {

            //Use the dataset returned from the code to be the
            //data source of the grid view
            System.Data.DataSet ds = Product.getProducts();
            dgvProducts.DataSource = ds.Tables["Products"];//Links datasource of gridview to dataset with the appropriate table.


            dgvProducts.AllowPaging = true;
            dgvProducts.PageSize = 4;

            dgvProducts.DataBind();//Links dataset to the control


        }

        private void clearTextBoxes()
        {
            productName.Text = "";
            ddlProductType.SelectedValue = null;
            cbCheckSaleItem.Checked = false;
            tbPrice.Text = "";
            tbSalePrice.Text = "";
            tbProductDescription.Text = "";
            tbCurrentStockLevel.Text = "";
            tbReOrderLevel.Text = "";


        }

        protected void Page_Load(object sender, EventArgs e)
        {
            refreshTable();
        }

        protected void dgvProducts_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgvProducts.PageIndex = e.NewPageIndex;//Checks to see which page your on
            dgvProducts.DataBind();//Binds that page to the control

        }

        protected void dgvProducts_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {

            string pathName;

            if (FulImgUploadTxt.HasFile)
            {
                try
                {
                    string filename = FulImgUploadTxt.FileName;
                    FulImgUploadTxt.SaveAs(Server.MapPath("../Images/ProductImages/" + filename));
                    pathName = Path.Combine("../Images/ProductImages/" + filename);
                    if (pathName != null)
                    {
                        lblSumbitSuccess.Text = "Item Successfully uploaded.";
                        Product newProduct = new Product(productName.Text,
                        ddlProductType.SelectedValue.ToString(),
                        Convert.ToDouble(tbPrice.Text),
                        cbCheckSaleItem.Checked,
                        Convert.ToDouble(tbSalePrice.Text),
                        tbProductDescription.Text,
                        Convert.ToInt32(tbCurrentStockLevel.Text),
                        Convert.ToInt32(tbReOrderLevel.Text),
                        pathName.ToString());

                        newProduct.createNewProduct(productName.Text, ddlProductType.SelectedValue.ToString(), Convert.ToDouble(tbPrice.Text), cbCheckSaleItem.Checked, Convert.ToDouble(tbSalePrice.Text), tbProductDescription.Text, Convert.ToInt32(tbCurrentStockLevel.Text), Convert.ToInt32(tbReOrderLevel.Text), pathName.ToString());
                    }
                    else
                    {
                        lblSumbitSuccess.Text = "A file with this name already exists please try agian " + filename;

                    }

                }//TODO GET the path sorted so it returns a value to be saved in the DB
                catch (Exception ex)
                {
                    lblSumbitSuccess.Text = ex.ToString();
                }

            }
            else
            {
                lblSumbitSuccess.Text = "Upload status: please select a file to upload";
            }
            clearTextBoxes();

        }

 
    }
}