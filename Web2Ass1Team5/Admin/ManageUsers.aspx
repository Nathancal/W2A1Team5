<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="ManageUsers.aspx.cs" Inherits="Web2Ass1Team5.Admin.ManageUsers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <!-- Required meta tags -->
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">

    <!-- Bootstrap CSS -->
    <link rel="stylesheet" href="../BootStrap4/css/bootstrap-grid.min.css">
    <link rel="stylesheet" href="../BootStrap4/css/bootstrap.min.css">
    <!--CSS-->
    <link rel="stylesheet" href="~/styles/AdminStyle.css">

    <!-- jQuery first, then Tether, then Bootstrap JS. -->
    <script src="https://code.jquery.com/jquery-3.1.1.slim.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/tether/1.4.0/js/tether.min.js"></script>
    <script src="../BootStrap4/js/bootstrap.min.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentPlaceHolder1" runat="server">


    <div class="container-fluid">
        <div class="row">
            <div class="col-sm-12 col-md-12">
                <div class="alert alert-dark" role="alert">
                    <h5>User Management:</h5>
                </div>
            </div>
        </div>

        <div class="row">
            <div class="col-sm-12 col-md-5">
                <div class="card">
                    <div class="card-header">
                        <h3 class="card-title">Create new User</h3>
                    </div>
                    <div class="row">
                        <div class="col-sm-12">
                            <form>
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

                                
                                <div class="row">
                                    <div class="col-md-6 col-sm-12">
                                        <div class="form-group px-3 py-2 m-0 border-info">
                                            <div class="row">
                                                <div class="col-sm-12">
                                                    <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
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


            <div class="col-sm-12 col-md-7">
                <div class="card">
                    <div class="card-header">
                        <h3 class="card-title">Current Discount Codes:</h3>
                    </div>

                    <div class="row">
                        <div class="col-sm-12">

                            <asp:GridView ID="gridUsers" runat="server" CssClass="table table-striped table-dark table-hover" AllowPaging="true" AutoGenerateColumns="false" GridLines="Vertical" OnPageIndexChanging="gridUsers_PageIndexChanging" OnSelectedIndexChanged="gridUsers_SelectedIndexChanged">
                                <Columns>
                                    <asp:TemplateField HeaderText="Username">
                                        <ItemTemplate>
                                            <asp:Label ID="lblCode" runat="server" Text='<%# Eval("Username") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Email">
                                        <ItemTemplate>
                                            <asp:Label ID="lblDateFrom" runat="server" Text='<%# Eval("Email") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="First Name">
                                        <ItemTemplate>
                                            <asp:Label ID="lblDateTo" runat="server" Text='<%# Eval("FirstName") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Surname">
                                        <ItemTemplate>
                                            <asp:Label ID="lblDiscountPerc" runat="server" Text='<%# Eval("Surname") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="DateOfBirth">
                                        <ItemTemplate>
                                            <asp:Label ID="lblDob" runat="server" Text='<%# Eval("DateOfBirth") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Address">
                                        <ItemTemplate>
                                            <asp:Label ID="lblAddress" runat="server" Text='<%# Eval("Address") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="City">
                                        <ItemTemplate>
                                            <asp:Label ID="lblCity" runat="server" Text='<%# Eval("City") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="County">
                                        <ItemTemplate>
                                            <asp:Label ID="lblCounty" runat="server" Text='<%# Eval("County") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Country">
                                        <ItemTemplate>
                                            <asp:Label ID="lblCountry" runat="server" Text='<%# Eval("Country") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="PostCode">
                                        <ItemTemplate>
                                            <asp:Label ID="lblPostCode" runat="server" Text='<%# Eval("PostCode") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="AccessLevel">
                                        <ItemTemplate>
                                            <asp:Label ID="lblAccessLevel" runat="server" Text='<%# Eval("AccessLevel") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="PWord">
                                        <ItemTemplate>
                                            <asp:Label ID="lblPWord" runat="server" Text='<%# Eval("PWord") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>

                            </asp:GridView>
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
