<%@ Page Title="" EnableEventValidation="true" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="ManageProducts.aspx.cs" Inherits="Web2Ass1Team5.Admin.ManageProducts" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <!-- Required meta tags -->
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">

    <!-- Bootstrap CSS -->
    <link rel="stylesheet" href="../BootStrap4/css/bootstrap-grid.min.css">
    <link rel="stylesheet" href="../BootStrap4/css/bootstrap.min.css">
    <!--CSS-->
    <link rel="stylesheet" href="~/styles/AdminStyle.css">

    <script src="https://code.jquery.com/jquery-3.1.1.slim.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/tether/1.4.0/js/tether.min.js"></script>
    <script src="../BootStrap4/js/bootstrap.min.js"></script>
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="contentPlaceHolder1" runat="server">


    <div class="container-fluid mb-3">
        <div class="row">
            <div class="col-sm-12 col-md-12">
                <div class="alert alert-dark" role="alert">
                    <h5>Product Management:</h5>
                </div>
            </div>
        </div>

        <div class="row">
            <div class="col-sm-12 col-md-4">
                <div class="card">
                    <div class="card-header">
                        <h3 class="card-title">Create new Product</h3>
                    </div>
                    <div class="row">
                        <div class="col-sm-12">
                            <form>
                                <div class="form-group px-3 py-2 m-0">
                                    <label for="productName">Product Name:</label>
                                    <asp:TextBox ID="productName" placeholder="Product name..." CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                                <div class="row">
                                    <div class="col-sm-12 col-md-6">
                                        <div class="form-group px-3 py-2 m-0">
                                            <label for="ddlProductType">Product Type:</label>
                                            <asp:DropDownList ID="ddlProductType" CssClass="dropdown" runat="server">
                                                <asp:ListItem>Starter Kits</asp:ListItem>
                                                <asp:ListItem>Advanced Kits</asp:ListItem>
                                                <asp:ListItem>Mods</asp:ListItem>
                                                <asp:ListItem>Tanks</asp:ListItem>
                                                <asp:ListItem>Coils</asp:ListItem>
                                                <asp:ListItem>Accessories</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>

                                    </div>

                                    <div class="col-sm-12 col-md-6">
                                        <div class="form-group px-3 py-2 m-0">
                                            <label for="tbPrice">Product Price:</label>
                                            <asp:TextBox ID="tbPrice" placeholder="Price in £..." CssClass="form-control" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>

                                <div class="row">
                                    <div class="col-sm-12 col-md-6">
                                        <div class="form-group px-3 py-2 m-0">
                                            <label for="checkSale">Check For Sale Item:</label>
                                            <asp:CheckBox ID="cbCheckSaleItem" CssClass="form-check" runat="server"></asp:CheckBox>
                                        </div>
                                    </div>

                                    <div class="col-sm-12 col-md-6">
                                        <div class="form-group px-3 py-2 m-0">
                                            <label for="checkSale">Sale Price</label>
                                            <asp:TextBox ID="tbSalePrice" placeholder="Price WHEN ON SALE £..." CssClass="form-control" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>

                                <div class="form-group px-3 py-2 m-0">
                                    <label for="checkSale">Product Description:</label>
                                    <asp:TextBox ID="tbProductDescription" placeholder="Please provide a brief summary of each product" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>


                                <div class="row">
                                    <div class="col-sm-12 col-md-6">
                                        <div class="form-group px-3 py-2 m-0">
                                            <label for="checkSale">Current Stock Level:</label>
                                            <asp:TextBox ID="tbCurrentStockLevel" placeholder="Total number in stock" CssClass="form-control" runat="server"></asp:TextBox>

                                        </div>
                                    </div>

                                    <div class="col-sm-12 col-md-6">
                                        <div class="form-group px-3 py-2 m-0">
                                            <label for="checkSale">Re-Order Level</label>
                                            <asp:TextBox ID="tbReOrderLevel" placeholder="Minimum reachable amount before reorder" CssClass="form-control" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>

                                <div class="form-group px-3 py-2 m-0">
                                    <label for="checkSale">Upload Product Image:</label>
                                    <asp:FileUpload ID="FulImgUploadTxt" CssClass="form-control-file" runat="server" />

                                </div>


                                <div class="form-group px-3 py-2 m-0">
                                    <asp:Label runat="server" ID="lblSumbitSuccess" CssClass="alert-success">---</asp:Label>
                                </div>


                                <div class="form-group px-3 py-2 m-0">
                                    <asp:Button ID="btnAdd" runat="server" CssClass="btn btn-primary" Text="Add Product" OnClick="btnAdd_Click" />
                                    <asp:Button ID="btnClear" runat="server" CssClass="btn btn-primary" Text="Clear" />

                                </div>
                            </form>
                        </div>

                    </div>
                </div>

            </div>


            <div class="col-sm-12 col-md-8">
                <div class="card">
                    <div class="card-header">
                        <h3 class="card-title">Current Products:</h3>
                    </div>

                    <div class="row">
                        <div class="col-sm-12">
                            <asp:GridView ID="dgvProducts" runat="server" DataKeyNames="ProductId" CssClass="table table-striped table-dark table-hover" AutoGenerateColumns="False" OnPageIndexChanging="dgvProducts_PageIndexChanging" OnSelectedIndexChanged="dgvProducts_SelectedIndexChanged">
                                <Columns>              
                                    <asp:CommandField ShowEditButton="true" />
    
                                    <asp:BoundField DataField="ProductName" HeaderText="ProductName" />
                                    <asp:BoundField DataField="Price" DataFormatString="{0:c}" HeaderText="Price" />
                                    <asp:BoundField DataField="Sale" HeaderText="Sale" />
                                    <asp:BoundField DataField="ProductType" HeaderText="Type" />

                                    <asp:BoundField DataField="SalePrice" DataFormatString="{0:c}" HeaderText="Price on Sale" />
                                    <asp:BoundField DataField="Description" HeaderText="Description" />
                                    <asp:BoundField DataField="CurrentStock" HeaderText="Current Stock Level" />
                                    <asp:BoundField DataField="ReOrderLevel" HeaderText="Re-Order Level" />

                                    <asp:BoundField DataField="ImageFile" HeaderText="ImageFile" Visible="False" />
                                    <asp:ImageField DataImageUrlField="ImageFile" HeaderText="Product Image">
                                        <ControlStyle Height="50px" Width="50px" />
                                    </asp:ImageField>

                                    <asp:BoundField />

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
