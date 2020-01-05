<%@ Page Title="" Language="C#" MasterPageFile="~/VapeMaster.Master" AutoEventWireup="true" CodeBehind="EVapes.aspx.cs" Inherits="Web2Ass1Team5.EVapes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <link href="../BootStrap4/css/bootstrap-grid.min.css" rel="stylesheet" />
   <link href="../BootStrap4/css/bootstrap.min.css" rel="stylesheet" />
    <link href="styles/BootstrapStyles.css" rel="stylesheet" />
    <div class="container-fluid py-2">
            <div class="row">
                <div class="col-sm-12">
                    <div class="alert alert-light" role="alert">
                        <h5>Vape Kits</h5>
                    </div>
                </div>
                </div>
            </div>
    <div class="container-fluid py-2">
        <div class="row">
            <div class="col-sm-12">

            </div>
        </div>
        <div class="row">
            <div class ="col-sm-3 px-2">

              <p><strong>Filter Options:</strong></p>

            </div>
            <div class ="col-sm-3 px-2">

                 <asp:Label ID="lblVapeType" runat="server" Text="Type Of Vape:"></asp:Label>

                 <asp:DropDownList ID="ddlVapeType" runat="server">
                     <asp:ListItem Value="0">Select Type</asp:ListItem>
                     <asp:ListItem Value="1">Pen</asp:ListItem>
                     <asp:ListItem Value="2">Mod</asp:ListItem>
                     <asp:ListItem Value="3">Mech</asp:ListItem>
                     <asp:ListItem Value="4">Pods</asp:ListItem>
                </asp:DropDownList>

            </div>
            <div class ="col-sm-3 px-2">
                 <asp:Label ID="lblVapePrice" runat="server" Text="Vape Price Range:"></asp:Label>
                 <asp:DropDownList ID="ddlVapePrice" runat="server">
                     <asp:ListItem Value="0">Select Price</asp:ListItem>
                     <asp:ListItem Value="1">£0-£10</asp:ListItem>
                     <asp:ListItem Value="2">£10.01-£20</asp:ListItem>
                     <asp:ListItem Value="3">£20.01-£30</asp:ListItem>
                     <asp:ListItem Value="4">£30.01-£40</asp:ListItem>
                     <asp:ListItem Value="5">£40.01-£50</asp:ListItem>
                     <asp:ListItem Value="6">£50+</asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class ="col-sm-3 px-2">
                <button class="btn btn-primary" type="submit">Filter</button>
            </div>
        </div>
        <div class="row">
            <div class="col-sm-12">
                <asp:ListView ID="lvVapeList" runat="server"></asp:ListView>
            </div>
        </div>
    </div>
    <script src="https://code.jquery.com/jquery-3.4.1.slim.min.js"> </script>
    <script src="https://cdn.jsdelivr.net/npm/popper.js@1.16.0/dist/umd/popper.min.js" ></script>
    <script src="BootStrap4/js/bootstrap.min.js"></script>
</asp:Content>
