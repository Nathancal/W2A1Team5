<%@ Page Title="" Language="C#" MasterPageFile="~/VapeMaster.Master" AutoEventWireup="true" CodeBehind="ELiquids.aspx.cs" Inherits="Web2Ass1Team5.ELiquids" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <link href="../BootStrap4/css/bootstrap-grid.min.css" rel="stylesheet" />
   <link href="../BootStrap4/css/bootstrap.min.css" rel="stylesheet" />
    <link href="styles/BootstrapStyles.css" rel="stylesheet" />
    <div class="container-fluid py-2">
        <div class="row">
            <div class="col-sm-3 px-2">

                <p><strong>Filter Options</strong></p>

            </div>
            <div class=" col-sm-3 px-2">
                  <asp:Label ID="lblPriceLiq" runat="server" Text="Price Range: "></asp:Label>
                <asp:DropDownList ID="ddlLiquidPrice" runat="server">
                    <asp:ListItem Value="0">Select Price</asp:ListItem>
                    <asp:ListItem Value="1">£0-£5</asp:ListItem>
                    <asp:ListItem Value="2">£5.01-£10</asp:ListItem>
                    <asp:ListItem Value="3">£10.01-£15</asp:ListItem>
                    <asp:ListItem Value="4">£15.01-£20</asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="col-sm-3 px-2">
                <asp:Label ID="lblLiquidName" runat="server" Text="Brand: "></asp:Label>
                <asp:DropDownList ID="ddlLiquidName" runat="server">
                    <asp:ListItem Value="0">Select Brand</asp:ListItem>
                    <asp:ListItem Value="1">Walled City</asp:ListItem>
                    <asp:ListItem Value="1">Titanic</asp:ListItem>
                    <asp:ListItem Value="3">Nasty Juice</asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="col-sm-3 px-2">
                <button class="btn btn-primary" type="submit">Filter</button>
            </div>
        </div>
        <div class="row py-2">
            <div class="col-sm-12 py-2">
                <asp:ListView ID="lvLiquidList" runat="server"></asp:ListView>
            </div>
        </div>
    </div>
    

        <script src="https://code.jquery.com/jquery-3.4.1.slim.min.js"> </script>
    <script src="https://cdn.jsdelivr.net/npm/popper.js@1.16.0/dist/umd/popper.min.js" ></script>
    <script src="BootStrap4/js/bootstrap.min.js"></script>
</asp:Content>
