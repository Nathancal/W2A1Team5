using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using W2A1Team5.App_Code.BLL;
using System.IO;


namespace W2A1Team5
{
    public partial class TestFormProducts : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            //Use the dataset returned from the code to be the
            //data source of the grid view
            System.Data.DataSet ds = Product.getProducts();
            dgvProducts.DataSource = ds.Tables["Products"];//Links datasource of gridview to dataset with the appropriate table.


            dgvProducts.AllowPaging = true;
            dgvProducts.PageSize = 4;

            dgvProducts.DataBind();//Links dataset to the control

        }

        private void clearTextBoxes(){
            tbProductName.Text = "";
            cbOnSale.Checked = false;
            tbProductPrice.Text = "";
            tbSalePrice.Text = "";
            tbDescription.Text = "";
            tbCurrentStock.Text = "";
            tbReOrderLevel.Text = "";


        }

        protected void btnImage_Click(object sender, EventArgs e)
        {
            string pathName;

            if (FulImgUploadTxt.HasFile)
            {
                try
                {
                    string filename = FulImgUploadTxt.FileName;
                    FulImgUploadTxt.SaveAs(Server.MapPath("~/Images/ProductImages/" + filename));
                    pathName = Path.Combine("~/Images/ProductImages/" + filename);
                    if(pathName != null){
                        lblOutput.Text = "Item Successfully uploaded.";
                        Product newProduct = new Product(tbProductName.Text,
                        ddlType.SelectedValue.ToString(),
                        Convert.ToDouble(tbProductPrice.Text),
                        cbOnSale.Checked,
                        Convert.ToDouble(tbSalePrice.Text),
                        tbDescription.Text,
                        Convert.ToInt32(tbCurrentStock.Text),
                        Convert.ToInt32(tbReOrderLevel.Text),
                        pathName.ToString());

                        newProduct.createNewProduct();



                    }
                    else{
                        lblOutput.Text = "A file with this name already exists please try agian " + filename;

                    }

                }//TODO GET the path sorted so it returns a value to be saved in the DB
                catch (Exception ex)
                {
                    lblOutput.Text = ex.ToString();
                }

            }
            else
            {
                lblOutput.Text = "Upload status: please select a file to upload";
            }
            clearTextBoxes();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            clearTextBoxes();

            Product searchProduct = new Product();

            searchProduct.findProduct(tbSearch.Text);

            tbProductName.Text = searchProduct.getProductName();
            ddlType.SelectedValue = searchProduct.getProductType();
            tbProductPrice.Text = searchProduct.getPrice().ToString();
            cbOnSale.Checked = searchProduct.isSale();
            tbSalePrice.Text = searchProduct.getSalePrice().ToString();
            tbDescription.Text = searchProduct.getProductDesc();
            tbCurrentStock.Text = searchProduct.getStock().ToString();
            tbReOrderLevel.Text = searchProduct.getReOrderLevel().ToString();
        }

        protected void dgvProducts_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgvProducts.PageIndex = e.NewPageIndex;//Checks to see which page your on
            dgvProducts.DataBind();//Binds that page to the control
        }

        protected void dgvProducts_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["SelectedProductID"] = dgvProducts.Rows[dgvProducts.SelectedIndex].Cells[1].Text;
            lblProductId.Text = Session["SelectedProductID"].ToString();
        }

        protected void btnLoadProducts_Click(object sender, EventArgs e)
        {
            //Use the dataset returned from the code to be the
            //data source of the grid view
            System.Data.DataSet ds = Product.getProducts();
            dgvProducts.DataSource = ds.Tables["Products"];//Links datasource of gridview to dataset with the appropriate table.


            dgvProducts.AllowPaging = true;
            dgvProducts.PageSize = 4;

            dgvProducts.DataBind();//Links dataset to the control
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            clearTextBoxes();
        }
    }
}