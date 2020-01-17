<%@ Page Title="" Language="C#" MasterPageFile="~/VapeMaster.Master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="Web2Ass1_Team5.secure.Profile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../BootStrap4/css/bootstrap-grid.min.css" rel="stylesheet" />
    <link href="../BootStrap4/css/bootstrap.min.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <div class="row">
            <div class="col-sm-12 col-md-12">
                <div class="jumbotron shadow-lg pt-3 mt-3">
                    <div class="row">
                        <div class="col-sm-12 col-md-5">
                            <div class="card shadow p-4 ">
                                <div class="card-header">
                                    <h3 class="card-title">User Information</h3>
                                </div>

                                <div class="card-body ">
                                    <div class="row">

                                        <div class="col-sm-12 col-md-12">
                                            <form class="border border-dark">
                                                <div class="row">


                                                    <div class="col-md-6 col-sm-12">
                                                        <div class="form-group px-3 py-2 m-0">
                                                            <label class="text-success">Email:</label>
                                                            <div class="row">
                                                                <div class="col-sm-12">
                                                                    <asp:Label ID="lblEmail" CssClass="form-text" runat="server" Text="Label"></asp:Label>
                                                                </div>

                                                            </div>
                                                        </div>

                                                    </div>
                                                    <div class="col-md-6 col-sm-12">
                                                        <div class="form-group px-3 py-2 m-0">
                                                            <label class="text-success">Username</label>
                                                            <div class="row">
                                                                <div class="col-sm-12">
                                                                    <asp:Label ID="lblUsername" CssClass="form-text" runat="server" Text="Label"></asp:Label>
                                                                </div>

                                                            </div>
                                                        </div>

                                                    </div>


                                                </div>

                                                <div class="row">
                                                    <div class="col-md-6 col-sm-12">
                                                        <div class="form-group px-3 py-2 m-0 border-info">
                                                            <label class="text-success">First name</label>
                                                            <div class="row">
                                                                <div class="col-sm-12">
                                                                    <asp:Label ID="lblFirstName" CssClass="form-text" runat="server" Text="Label"></asp:Label>
                                                                </div>

                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="col-md-6 col-sm-12">
                                                        <div class="form-group px-3 py-2 m-0 border-info">
                                                            <label class="text-success">Surname</label>
                                                            <div class="row">
                                                                <div class="col-sm-12">
                                                                    <asp:Label ID="lblSurname" CssClass="form-text" runat="server" Text="Label"></asp:Label>
                                                                </div>

                                                            </div>
                                                        </div>

                                                    </div>
                                                </div>

                                                <div class="row">
                                                    <div class="col-md-6 col-sm-12">
                                                        <div class="form-group px-3 py-2 m-0 border-info">
                                                            <label class="text-success">Date Of Birth</label>
                                                            <asp:Label ID="lblDob" CssClass="form-text" runat="server" Text="Label"></asp:Label>
                                                        </div>
                                                    </div>
                                                    <div class="col-md-6 col-sm-12">
                                                        <div class="form-group px-3 py-2 m-0 border-info">
                                                            <label class="text-success">Address</label>
                                                            <div class="row">
                                                                <div class="col-sm-12">
                                                                    <asp:Label ID="lblAddress" CssClass="form-text" runat="server" Text="Label"></asp:Label>
                                                                </div>

                                                            </div>
                                                        </div>

                                                    </div>
                                                </div>

                                                <div class="row">
                                                    <div class="col-md-6 col-sm-12">
                                                        <div class="form-group px-3 py-2 m-0 border-info">
                                                            <label class="text-success">City</label>
                                                            <div class="row">
                                                                <div class="col-sm-12">
                                                                    <asp:Label ID="lblCity" CssClass="form-text" runat="server" Text="Label"></asp:Label>
                                                                </div>

                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="col-md-6 col-sm-12">
                                                        <div class="form-group px-3 py-2 m-0 border-info">
                                                            <label class="text-success">County</label>
                                                            <div class="row">
                                                                <div class="col-sm-12">
                                                                    <asp:Label ID="lblCounty" CssClass="form-text" runat="server" Text="Label"></asp:Label>
                                                                </div>

                                                            </div>
                                                        </div>

                                                    </div>
                                                </div>

                                                <div class="row">
                                                    <div class="col-md-6 col-sm-12">
                                                        <div class="form-group px-3 py-2 m-0 border-info">
                                                            <label class="text-success">Country</label>
                                                            <div class="row">
                                                                <div class="col-sm-12">
                                                                    <asp:Label ID="lblCountry" CssClass="form-text" runat="server" Text="Label"></asp:Label>
                                                                </div>

                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="col-md-6 col-sm-12">
                                                        <div class="form-group px-3 py-2 m-0 border-info">
                                                            <label class="text-success">PostCode</label>
                                                            <div class="row">
                                                                <div class="col-sm-12">
                                                                    <asp:Label ID="lblPostcode" CssClass="form-text" runat="server" Text="Label"></asp:Label>
                                                                </div>

                                                            </div>
                                                        </div>

                                                    </div>
                                           
                                                </div>
                                        </div>



                                        </form>


                                    </div>


                                </div>
                            </div>





                        </div>
                        <div class="col-sm-12 col-md-3">

                            <div class="card shadow p-4 mt-2">
                                <div class="card-header">
                                    <h3 class="card-title">Messages:</h3>

                                </div>

                                <div class="card-body ">
                                    <div class="row">
                                        <div class="col-sm-12 col-md-12">
                                            <div class="alert-warning rounded" id="unreadMessages">
                                                <h5>You have <span>
                                                    <asp:Label ID="lblUnreadMessages" runat="server" Text="--"></asp:Label></span> unread messages</h5>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="card-footer">
                                    <asp:Button ID="btnViewChats" CssClass="btn btn-outline-success" OnClick="btnViewChats_Click" runat="server" Text="Chats" />


                                </div>

                            </div>

                            <div class="card shadow p-4 mt-2 alert-warning">
                                <div class="row">
                                    <div class="col-sm-3">
                                    </div>
                                    <div class="col-sm-7">
                                        <h3 class="card-title text-primary">Mystery Offer</h3>


                                    </div>
                                    <div class="col-sm-2">
                                    </div>

                                </div>

                            <div class="card-body ">
                                <div class="row">
                                    <div class="col-sm-12 col-md-12">
                                        <h4 class="text-primary mr-3">Special offer use discount code: <span>
                                            <asp:Label ID="lblDiscountCodeRandom" CssClass="alert-danger ml-3" runat="server" Text="--"></asp:Label></span></h4>
                                    </div>
                                </div>
                            </div>
                            <div class="card-footer d-flex flex-column-reverse">
                                <asp:Button ID="btnViewProducts" CssClass="btn btn-danger" OnClick="btnViewProducts_Click" runat="server" Text="View Products" />


                            </div>

                        </div>
    </div>

                              <div class="col-sm-12 col-md-4">
                            <div class="card shadow p-4 ">
                                <div class="card-header">
                                    <h3 class="card-title">Order History:</h3>
                                </div>

                                <div class="card-body ">
                                    <div class="row">
                                        <div class="col-sm-12 col-md-12">




                                        </div>
                                    </div>
                                </div>

                            </div>

                        </div>


                    </div>


                </div>





            </div>




        </div>
        </div>
    <script src="https://code.jquery.com/jquery-3.4.1.slim.min.js"> </script>
    <script src="https://cdn.jsdelivr.net/npm/popper.js@1.16.0/dist/umd/popper.min.js"></script>
    <script src="../BootStrap4/js/bootstrap.min.js"></script>
</asp:Content>
