<%@ Page Title="" Language="C#" MasterPageFile="~/VapeMaster.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Web2Ass1Team5.Login" %>
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
     <div class="container-fliud py-1">
        <div class="row py-5">
            <div class="col-sm-12 col-md-4">
            </div>
            <div class="col-sm-12 col-md-4">
                <div class="row">
                    <div class="col-sm-12">
                        <form class="border border-dark">
                            <div class="form-group px-3 py-2 m-0 border-info">
                                <label for="tbUsername">Email or Username</label>
                                <asp:TextBox ID="tbUsername" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>


                            <div class="form-group px-3 py-2 m-0">
                                <label for="tbPassword">Password</label>
                                <asp:TextBox ID="tbPassword" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>

                            <div class="form-group px-3 py-2 m-0 align-content-center">
                                <div class="row">
                                    <div class="col-sm-0 col-md-4">
                                    </div>
                                    <div class="col-sm-12 col-md-4 align-content-sm-center">

                                        <asp:Label runat="server" ID="lblSumbitSuccess" CssClass="alert-success">---</asp:Label>
                                        <div class="row">
                                            <div class="col-sm-12">
                                                <h4 class="alert-heading">remember me?:</h4>
                                                <asp:CheckBox ID="chkPersist" runat="server" cssClass="custom-checkbox"/>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-sm-0 col-md-4">
                                    </div>
                                </div>                         

                            </div>

                            <div class="form-group px-3 py-2 m-0">
                                <div class="row align-content-center">
                                    <div class="col-sm-0 col-md-1">
                                    </div>
                                    <div class="col-sm-12 col-md-10 ">
                                        <label for="tbPassword" class="alert-secondary">If you are not yet registered please sign up here!</label>
                                        <asp:Button ID="btnSignUp" runat="server" CssClass="btn btn-secondary" Text="Register" />
                                    </div>
                                    <div class="col-sm-0 col-md1">
                                    </div>


                                </div>

                            </div>


                        </form>
                    </div>

                </div>

            </div>
            <div class="col-sm-12 col-md-4">
            </div>

        </div>


    </div>
</asp:Content>
