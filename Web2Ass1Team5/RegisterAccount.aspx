<%@ Page Title="" Language="C#" MasterPageFile="~/VapeMaster.Master" AutoEventWireup="true" CodeBehind="RegisterAccount.aspx.cs" Inherits="Web2Ass1Team5.RegisteredAccount" %>

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
         <div class="row">
                <div class="col-sm-12">
                    <asp:Label ID="lblErrorMessages" CssClass="col-form-label" runat="server" Text=""></asp:Label>

                </div>

            </div>
        <div class="row py-5">
           
            <div class="col-sm-12 col-md-4">
            </div>
            <div class="col-sm-12 col-md-4">
                <div class="row">
                    <div class="col-sm-12">
                        <div class="card border-dark">
                            <div class="card-header">
                                <h3 class="card-title align-content-center">Registration Form</h3>
                            </div>
                            <form class="border border-dark">
                                <div class="row">

                                    <div class="col-md-6 col-sm-12">
                                        <div class="form-group px-3 py-2 m-0">
                                            <label for="tbEmail">Email:</label>
                                            <div class="row">
                                                <div class="col-sm-12">
                                                    <asp:TextBox ID="tbEmail" TextMode="Email" CssClass="form-control" runat="server"></asp:TextBox>
                                                </div>

                                            </div>
                                        </div>

                                    </div>
                                    <div class="col-md-6 col-sm-12">
                                        <div class="form-group px-3 py-2 m-0">
                                            <label for="tbUsername">Username</label>
                                            <div class="row">
                                                <div class="col-sm-12">
                                                    <asp:TextBox ID="tbUsername" CssClass="form-control" runat="server"></asp:TextBox>
                                                </div>

                                            </div>
                                        </div>

                                    </div>


                                </div>

                                <div class="row">
                                    <div class="col-md-6 col-sm-12">
                                        <div class="form-group px-3 py-2 m-0 border-info">
                                            <label for="tbFirstName">First name</label>
                                            <div class="row">
                                                <div class="col-sm-12">
                                                    <asp:TextBox ID="tbFirstName" CssClass="form-control" runat="server"></asp:TextBox>
                                                </div>

                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-6 col-sm-12">
                                        <div class="form-group px-3 py-2 m-0 border-info">
                                            <label for="tbUsername">Surname</label>
                                            <div class="row">
                                                <div class="col-sm-12">
                                                    <asp:TextBox ID="tbSurname" CssClass="form-control" runat="server"></asp:TextBox>
                                                </div>

                                            </div>
                                        </div>

                                    </div>
                                </div>

                                <div class="row">
                                    <div class="col-md-6 col-sm-12">
                                        <div class="form-group px-3 py-2 m-0 border-info">
                                            <label for="calDob">Date Of Birth</label>
                                                    <asp:Calendar ID="calDob" runat="server"></asp:Calendar>

                                        </div>
                                    </div>
                                    <div class="col-md-6 col-sm-12">
                                        <div class="form-group px-3 py-2 m-0 border-info">
                                            <label for="tbUsername">Address</label>
                                            <div class="row">
                                                <div class="col-sm-12">
                                                    <asp:TextBox ID="tbAddress" CssClass="form-control" runat="server"></asp:TextBox>
                                                </div>

                                            </div>
                                        </div>

                                    </div>
                                </div>

                                <div class="row">
                                    <div class="col-md-6 col-sm-12">
                                        <div class="form-group px-3 py-2 m-0 border-info">
                                            <label for="tbFirstName">City</label>
                                            <div class="row">
                                                <div class="col-sm-12">
                                                    <asp:TextBox ID="tbCity" CssClass="form-control" runat="server"></asp:TextBox>
                                                </div>

                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-6 col-sm-12">
                                        <div class="form-group px-3 py-2 m-0 border-info">
                                            <label for="tbUsername">County</label>
                                            <div class="row">
                                                <div class="col-sm-12">
                                                    <asp:TextBox ID="tbCounty" CssClass="form-control" runat="server"></asp:TextBox>
                                                </div>

                                            </div>
                                        </div>

                                    </div>
                                </div>

                                <div class="row">
                                    <div class="col-md-6 col-sm-12">
                                        <div class="form-group px-3 py-2 m-0 border-info">
                                            <label for="tbFirstName">Country</label>
                                            <div class="row">
                                                <div class="col-sm-12">
                                                    <asp:TextBox ID="tbCountry" CssClass="form-control" runat="server"></asp:TextBox>
                                                </div>

                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-6 col-sm-12">
                                        <div class="form-group px-3 py-2 m-0 border-info">
                                            <label for="tbUsername">PostCode</label>
                                            <div class="row">
                                                <div class="col-sm-12">
                                                    <asp:TextBox ID="tbPostCode" CssClass="form-control" runat="server"></asp:TextBox>
                                                </div>

                                            </div>
                                        </div>

                                    </div>
                                </div>

                                <div class="row">
                                    <div class="col-md-6 col-sm-12">
                                        <div class="form-group px-3 py-2 m-0 border-info">
                                            <label for="tbFirstName" class="alert-danger">Password</label>
                                            <div class="row">
                                                <div class="col-sm-12">
                                                    <asp:TextBox ID="tbPassword" CssClass="form-control" runat="server"></asp:TextBox>
                                                </div>

                                            </div>
                                        </div>
                                    </div>                    
                                </div>





                                <div class="form-group px-3 py-2 m-0 align-content-center">
                                    <div class="row">

                                        <div class="col-sm-0 col-md-4">
                                        </div>
                                        <div class="col-sm-12 col-md-4 align-content-sm-center">

                                        <asp:Button ID="btnRegisterAccount" CssClass="btn btn-outline-success" runat="server" Text="Register Account" OnClick="btnRegisterAccount_Click" />

                                        </div>
                                        <div class="col-sm-0 col-md-4"></div>
                                    </div>

                                </div>

                                <div class="form-group px-3 py-2 m-0">
                                    <div class="row align-content-center">
                                        <div class="col-sm-0 col-md-1">
                                        </div>
                                        <div class="col-sm-12 col-md-10 ">
                                            <label for="btnLogin" class="alert-secondary">if you already have an account login here:</label>

                                            <asp:Button ID="btnReturnToLogin" CssClass="btn btn-outline-danger" runat="server" Text="Login Here" OnClick="btnReturnToLogin_Click" />
                                        </div>
                                        <div class="col-sm-0 col-md1">
                                        </div>


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
