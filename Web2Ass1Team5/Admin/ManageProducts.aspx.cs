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

        protected void dgvProducts_RowEditing(object sender, GridViewEditEventArgs e)
        {
            dgvProducts.EditIndex = e.NewEditIndex;
            refreshTable();

        }

        protected void dgvProducts_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

            //Finding the controls from Gridview for the row which is going to update  
            TextBox getproductName = dgvProducts.Rows[e.RowIndex].FindControl("ProductName") as TextBox;
            TextBox getproductPrice = dgvProducts.Rows[e.RowIndex].FindControl("Price") as TextBox;
            TextBox getproductType = dgvProducts.Rows[e.RowIndex].FindControl("ProductType") as TextBox;

            CheckBox getisSale = dgvProducts.Rows[e.RowIndex].FindControl("Sale") as CheckBox;
            TextBox getsalePrice = dgvProducts.Rows[e.RowIndex].FindControl("SalePrice") as TextBox;
            TextBox getdescription = dgvProducts.Rows[e.RowIndex].FindControl("Description") as TextBox;
            TextBox getcurrentStock = dgvProducts.Rows[e.RowIndex].FindControl("CurrentStock") as TextBox;
            TextBox getReOrderLevel = dgvProducts.Rows[e.RowIndex].FindControl("ReOrderLevel") as TextBox;
            TextBox getImageFile = dgvProducts.Rows[e.RowIndex].FindControl("ImageFile") as TextBox;

            Product newProduct = new Product();
            Product updateProduct = new Product(getproductName.Text, getproductType.Text, Convert.ToDouble(getproductPrice.Text), getisSale.Checked, Convert.ToDouble(getsalePrice.Text), getdescription.Text, Convert.ToInt32(getcurrentStock.Text), Convert.ToInt32(getReOrderLevel.Text), getImageFile.Text);
            newProduct.updateProduct(updateProduct);

            //Setting the EditIndex property to -1 to cancel the Edit mode in Gridview  
            dgvProducts.EditIndex = -1;
            //Call ShowData method for displaying updated data  
            refreshTable();


        }

        protected void dgvProducts_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            //Setting the EditIndex property to -1 to cancel the Edit mode in Gridview  
            dgvProducts.EditIndex = -1;
            refreshTable();
        }
    }
}