<%@ Page Title="" Language="C#" MasterPageFile="~/VapeMaster.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="Web2Ass1Team5.Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <link href="../BootStrap4/css/bootstrap-grid.min.css" rel="stylesheet" />
    <link href="../BootStrap4/css/bootstrap.min.css" rel="stylesheet" />


    <div class="container-fluid ">
        <div class="row">
            <div class="col-sm-12">

                <asp:Image class="imgBanner" runat="server" ImageUrl="~/Images/Nasty-Banner-Yummy.png" />

            </div>
        </div>
    </div>
    <div class="container-fluid py-04">
        <div class="row py-4">
            <div class="col-sm-12">
                <p class="bsell"><strong>BEST SELLERS</strong></p>
            </div>
            <div class="col-sm-12">

                <asp:ListView ID="ListView1" runat="server">
                </asp:ListView>

            </div>

        </div>
    </div>
    <div class="container-fluid py-2">
        <div class="row">
            <div class="col-sm-4">
                <div class="wrapper">
                    <asp:ImageButton class="imgHome hover" runat="server" ImageUrl="~/Images/liquids1.jpg" />
                    <div class="overlay">
                        <div class="text">Liquids</div>
                    </div>
                </div>
            </div>
            <div class="col-sm-4">
                <div class="wrapper">
                    <asp:ImageButton class="imgHome" runat="server" ImageUrl="~/Images/vapes.jpg" />
                    <div class="overlay">
                        <div class="text">Vape Kits</div>
                    </div>
                </div>
            </div>
            <div class="col-sm-4">
                <div class="wrapper">
                    <asp:ImageButton class="imgHome" runat="server" ImageUrl="~/Images/coils.jpg" />
                    <div class="overlay">
                        <div class="text">Coils</div>
                    </div>
                </div>
            </div>
        </div>
    </div>


    <script src="https://code.jquery.com/jquery-3.4.1.slim.min.js"> </script>
    <script src="https://cdn.jsdelivr.net/npm/popper.js@1.16.0/dist/umd/popper.min.js"></script>
    <script src="BootStrap4/js/bootstrap.min.js"></script>
</asp:Content>
