<%@ Page Title="" Language="C#" MasterPageFile="~/VapeMaster.Master" AutoEventWireup="true" CodeBehind="ProductsDetails.aspx.cs" Inherits="Web2Ass1Team5.ProductsDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../BootStrap4/css/bootstrap-grid.min.css" rel="stylesheet" />
    <link href="../BootStrap4/css/bootstrap.min.css" rel="stylesheet" />

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div class="container-fluid">

        <div class="row">
            <div class="col-sm-12 mt-3">
                <div class="alert alert-dark" role="alert">
                    <h5>Product Details</h5>
                </div>
            </div>
        </div>

        <div class="row">
            <div class="col-sm-12 col-md-8">

                <div class="card shadow p-4">
                    <div class="card-header">
                        <h3 class="card-title">Product Details</h3>
                    </div>
                    <div class="row">
                        <div class="col-sm-12">
                            <img src="" id="productImage" runat="server" class="card-img-top img-fluid pt-1" style="max-height: 32rem; max-width: 32rem;" alt="">

                        </div>

                    </div>
                    <div class="card-body">
                        <h4 class="alert-primary text-dark">Product Name:</h4>
                        <h5><asp:Label ID="lblProductName" CssClass="card-text text-dark" runat="server" Text=""></asp:Label></h5>
                        <h4 class="alert-primary text-dark">Product Name:</h4>
                        <h5><asp:Label ID="Label1" CssClass="card-text text-dark" runat="server" Text=""></asp:Label></h5>
                        <h4 class="alert-primary text-dark">Product Name:</h4>
                        <h5><asp:Label ID="Label2" CssClass="card-text text-dark" runat="server" Text=""></asp:Label></h5>
                        <h4 class="alert-primary text-dark">Price:
                            </h4>
                        <h5><asp:Label ID="lblProductPrice" runat="server" Text=""></asp:Label></h5>
                        <h4 class="alert-primary text-dark">
                            Total Quantity: </h4> 
                    <asp:DropDownList ID="ddlQuantity" CssClass="dropdown show alert-dark" runat="server">
                        <asp:ListItem>Choose Quantity</asp:ListItem>
                        <asp:ListItem>1</asp:ListItem>
                        <asp:ListItem>2</asp:ListItem>
                        <asp:ListItem>3</asp:ListItem>
                        <asp:ListItem>4</asp:ListItem>
                        <asp:ListItem>5</asp:ListItem>
                    </asp:DropDownList>


                        <button class="btn btn-primary" type="submit">Add To Cart</button>

                    </div>
                </div>
              
            </div>

              <div class="col-sm-12 col-md-4">
                         <div class="card shadow p-4">
                    <div class="card-header">
                        <h3 class="card-title">Shopping Basket</h3>
                    </div>
                             <div class="card-body">
                                 <asp:ListView ID="lvShoppingBasket" runat="server"></asp:ListView>



                             </div>
       
                    </div>
                </div>

        </div>
    </div>

    <script src="https://code.jquery.com/jquery-3.4.1.slim.min.js"> </script>
    <script src="https://cdn.jsdelivr.net/npm/popper.js@1.16.0/dist/umd/popper.min.js"></script>
    <script src="BootStrap4/js/bootstrap.min.js"></script>
</asp:Content>
