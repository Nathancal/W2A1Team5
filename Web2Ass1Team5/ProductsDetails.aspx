<%@ Page Title="" Language="C#" MasterPageFile="~/VapeMaster.Master" AutoEventWireup="true" CodeBehind="ProductsDetails.aspx.cs" Inherits="Web2Ass1Team5.ProductsDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
       <link href="../BootStrap4/css/bootstrap-grid.min.css" rel="stylesheet" />
   <link href="../BootStrap4/css/bootstrap.min.css" rel="stylesheet" />
    <link href="styles/BootstrapStyles.css" rel="stylesheet" />

    <div class="container-fluid">
            <div class="row">
                <div class="col-sm-12">
                    <div class="alert alert-dark" role="alert">
                        <h5>Product Details</h5>
                    </div>
                </div>
            </div>
        <div class="row">
            <div class="col-sm">

            </div>
             <div class="col-sm-6">

                 <div class="card shadow p-4">
                 <div class="card-header">
                <h3 class="card-title">Product Details</h3>
                </div>
                <img src="" class="card-img-top img-fluid" alt="...">
                <div class="card-body">
                <p class="card-text m-0 p-0">Product Name: <asp:Label ID="lblProductName" runat="server" Text=""></asp:Label></p>
                  <p class="card-text m-0 p-0">Price: <asp:Label ID="lblProductPrice" runat="server" Text=""></asp:Label></p>
                <p class="card-text m-0 p-0">Total Quantity:  
                    <asp:DropDownList ID="ddlQuantity" runat="server">
                        <asp:ListItem>Choose Quantity</asp:ListItem>
                        <asp:ListItem>1</asp:ListItem>
                        <asp:ListItem>2</asp:ListItem>
                        <asp:ListItem>3</asp:ListItem>
                        <asp:ListItem>4</asp:ListItem>
                        <asp:ListItem>5</asp:ListItem>
                    </asp:DropDownList>
                    </p>
                <button class="btn btn-primary" type="submit">Add To Cart</button>

            </div>
           </div>
             <div class="col-sm">

            </div>
        </div>
            </div>
        </div>

    <script src="https://code.jquery.com/jquery-3.4.1.slim.min.js"> </script>
    <script src="https://cdn.jsdelivr.net/npm/popper.js@1.16.0/dist/umd/popper.min.js" ></script>
    <script src="BootStrap4/js/bootstrap.min.js"></script>
</asp:Content>
