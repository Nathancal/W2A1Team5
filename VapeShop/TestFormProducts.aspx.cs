using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VapeShop.App_Code.BLL;
using System.IO;


namespace VapeShop
{
    public partial class TestFormProducts : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

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


 

        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Product searchProduct = new Product();

            searchProduct.findProduct(tbSearch.Text);

            lblProductName1.Text = searchProduct.getProductName();
            lblProductType1.Text = searchProduct.getProductType();
            lblProductPrice1.Text = searchProduct.getPrice().ToString();



        }
    }
}