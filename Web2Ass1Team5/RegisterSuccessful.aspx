<%@ Page Title="" Language="C#" MasterPageFile="~/VapeMaster.Master" AutoEventWireup="true" CodeBehind="RegisterSuccessful.aspx.cs" Inherits="Web2Ass1Team5.RegisterSuccessful" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <!-- Required meta tags -->
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">

    <!-- Bootstrap CSS -->
    <link rel="stylesheet" href="../BootStrap4/css/bootstrap-grid.min.css">
    <link rel="stylesheet" href="../BootStrap4/css/bootstrap.min.css">
    <!--CSS-->

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid my-5">
        <div class="row my-1">
            <div class="col-sm col-md-2"></div>

            <div class="col-sm-12 col-md-8">
                <div class="jumbotron jumbotron-fluid shadow-sm">
                    <div class="container">
                        <h1 class="display-8">Account successfully created by: </h1><asp:Label ID="lblEmail" runat="server" Text="UserEmail"></asp:Label>

                        <p class="lead pt-3">Thank you for signing up to cloud 9 vape <span> <asp:Label ID="lblName" runat="server" Text="UserName"></asp:Label></span>! please click below to be redirected to your new user profile</p>

                    </div>
                </div>


            </div>
            <div class="col-sm col-md-2">
            </div>
        </div>


    </div>


</asp:Content>
