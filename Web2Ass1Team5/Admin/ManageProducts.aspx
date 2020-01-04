<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="ManageProducts.aspx.cs" Inherits="Web2Ass1Team5.Admin.ManageProducts" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
             <!-- Required meta tags -->
         <meta charset="utf-8">
        <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">

        <!-- Bootstrap CSS -->
         <link rel="stylesheet" href="../BootStrap4/css/bootstrap-grid.min.css">
        <link rel="stylesheet" href="../BootStrap4/css/bootstrap.min.css">
        <!--CSS-->
      <link rel="stylesheet" href="~/styles/AdminStyle.css">
    
      <!-- jQuery first, then Tether, then Bootstrap JS. -->
      <script src="https://code.jquery.com/jquery-3.1.1.slim.min.js"></script>
      <script src="https://cdnjs.cloudflare.com/ajax/libs/tether/1.4.0/js/tether.min.js"></script>
      <script src="../BootStrap4/js/bootstrap.min.js"></script>
    <!-- Bootstrap Date-Picker Plugin -->
    <script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-datepicker/1.4.1/js/bootstrap-datepicker.min.js"></script>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-datepicker/1.4.1/css/bootstrap-datepicker3.css"/>
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="contentPlaceHolder1" runat="server">
    

        <div class="container-fluid">
        <div class="row">
           <div class="col-sm-12 col-md-12">
              <div class="alert alert-dark" role="alert">
                <h5>Product Management:</h5>
              </div>
           </div>
        </div>

        <div class="row">
            <div class="col-sm-12 col-md-5">
             <div class="card">
                    <div class="card-header">
                        <h3 class="card-title">Create new Product</h3>
                    </div>
                    <div class="row"> 
                        <div class="col-sm-12">
                            <form>
                            <div class="form-group px-3 py-2 m-0">
                                <label for="productName">Product Name:</label>
                                <asp:TextBox ID="productName" placeholder="Product name..."  CssClass="form-control" runat="server" ></asp:TextBox>
                            </div>
                            <div class="row">
                                <div class="col-sm-6">
                                     <div class="form-group px-3 py-2 m-0">
                                        <label for="ddlProductType">Product Type:</label>
                                         <asp:DropDownList id="ddlProductType" cssClass="dropdown" runat="server">
                                             <asp:ListItem>Starter Kits</asp:ListItem>
                                             <asp:ListItem>Advanced Kits</asp:ListItem>
                                             <asp:ListItem>Mods</asp:ListItem>
                                             <asp:ListItem>Tanks</asp:ListItem>
                                             <asp:ListItem>Coils</asp:ListItem>
                                             <asp:ListItem>Accessories</asp:ListItem>
                                         </asp:DropDownList>
                                     </div>

                                </div>

                                <div class="col-sm-6">
                                    <div class="form-group px-3 py-2 m-0">
                                        <label for="exampleInputPassword1">Product Price:</label>
                                        <asp:TextBox ID="tbPrice" placeholder="Price in £..."  CssClass="form-control" runat="server" ></asp:TextBox>

                                    </div>

                                </div>
                            </div>
                                                         
                            <div class="form-group px-3 py-2 m-0">
                                <label for="checkSale">Check For Sale Item:</label>
                                <asp:CheckBox cssClass="form-check" runat="server"></asp:CheckBox>
                            </div>
                            <div class="form-group px-3 py-2 m-0">
                                <button type="submit" class="btn btn-primary">Submit</button>
                                <button type="reset" class="btn btn-primary">Clear</button>
                            </div>
                            </form>                           
                        </div>

                    </div> 
             </div>

            </div>


            <div class="col-sm-12 col-md-7">
                <div class="card">
                    <div class="card-header">
                        <h3 class="card-title">Current Discount Codes:</h3>
                    </div>

                    <div class="row">
                        <div class="col-sm-12">
                            <asp:GridView ID="dgvProducts" runat="server" AutoGenerateColumns="False" OnPageIndexChanging="dgvProducts_PageIndexChanging" OnSelectedIndexChanged="dgvProducts_SelectedIndexChanged">
                             <Columns>
                            <asp:CommandField ShowSelectButton="True" />
                            <asp:BoundField DataField="ProductID" HeaderText="ProductId" />
                            <asp:BoundField DataField="ProductName" HeaderText="ProductName" />
                            <asp:BoundField DataField="Price" DataFormatString="{0:c}" HeaderText="Price" />
                            <asp:BoundField DataField="ImageFile" HeaderText="ImageFile" Visible="False" />
                            <asp:ImageField DataImageUrlField="ImageFile" HeaderText="Product Image">
                            <ControlStyle Height="50px" Width="50px" />
                            </asp:ImageField>
                            </Columns>
                            </asp:GridView>
                        </div>

                    </div>

                </div>


            </div>
        </div>
    </div>





    
  <!-- jQuery first, then Tether, then Bootstrap JS. -->
  <script src="https://code.jquery.com/jquery-3.1.1.slim.min.js"></script>
  <script src="https://cdnjs.cloudflare.com/ajax/libs/tether/1.4.0/js/tether.min.js"></script>
  <script src="../BootStrap4/js/bootstrap.min.js"></script>
</asp:Content>
