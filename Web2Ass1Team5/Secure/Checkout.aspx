<%@ Page Title="" Language="C#" MasterPageFile="~/VapeMaster.Master" AutoEventWireup="true" CodeBehind="Checkout.aspx.cs" Inherits="Web2Ass1Team5.Secure.Checkout" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../BootStrap4/css/bootstrap-grid.min.css" rel="stylesheet" />
    <link href="../BootStrap4/css/bootstrap.min.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <div class="row">
            <div class="col-sm-12">

                <div class="jumbotron jumbotron-fluid shadow">
                    <div class="card card-header mx-3 alert-primary shadow-sm">
                        <h1 class="display-4">Checkout Area</h1>
                        <p class="lead">Please Review your order, select your delivery type and apply any discount codes here:</p>

                    </div>
                    <div class="row mx-2  pt-2">
                        <div class="col-sm-12">
                            <div class="card shadow-sm">
                                <h5 class="card-header alert-primary">Items in cart:</h5>
                                <div class="card-body">
                                    <asp:ListView ID="lvCheckout" OnItemCommand="lvCheckout_ItemCommand" DataKeyNames="ProductId" runat="server">
                                        <LayoutTemplate>
                                            <div class="container-fluid">
                                                <div class="row">
                                                    <div class="col-sm-3 col-md-2 border-right-0">
                                                    </div>

                                                    <div class="col-sm-3 col-md-2 border-right-0">
                                                        <asp:Label ID="lblName" runat="server" Text="Name"></asp:Label>

                                                    </div>
                                                    <div class="col-sm-2 col-md-2 border-left-0 border-right-0">
                                                        <asp:Label ID="lblQuantity" runat="server" Text="Quantity"></asp:Label>

                                                    </div>
                                                    <div class="col-sm-3 col-md-2 border-left-0 border-right-0">
                                                        <asp:Label ID="lblType" runat="server" Text="Type"></asp:Label>

                                                    </div>
                                                    <div class="col-sm-2 col-md-2 border-left-0 border-right-0">
                                                        <asp:Label ID="lblLineCost" runat="server" Text="Line Cost"></asp:Label>

                                                    </div>



                                                </div>

                                                <asp:PlaceHolder ID="itemPlaceholder" runat="server" />

                                            </div>

                                        </LayoutTemplate>

                                        <ItemTemplate>
                                            <div class="row">
                                                <div class="col-sm-12 list-group">
                                                    <div class="row">
                                                        <div class="col-sm-3 col-md-2 list-group pl-1 pr-0 flex-grow-1">
                                                            <li class="list-group-item rounded-0 rounded-left border-secondary border-right-0">
                                                                <img class="img-thumbnail img-fluid pr-0" style="max-height: 8rem; max-width: 8rem;" src="<%# Eval("ImageFile") %>" alt="<%#Eval("ProductName") %> Image Not Found">
                                                            </li>
                                                        </div>

                                                        <div class="col-sm-3 col-md-2 list-group pl-0 pr-0 flex-grow-1">
                                                            <li class="list-group-item rounded-0 rounded-left border-secondary border-left-0 border-right-0 flex-grow-1"><%# Eval("ProductName") %></li>
                                                        </div>

                                                        <div class="col-sm-2 col-md-2 pl-0 pr-0 list-group flex-grow-1">

                                                            <li class="list-group-item rounded-0 border-secondary  border-left-0 border-right-0 flex-grow-1"><%# Eval("ProductQuantity") %></li>

                                                        </div>


                                                        <div class="col-sm-3 col-md-2 px-0 list-group flex-grow-1">
                                                            <li class="list-group-item rounded-0 border-secondary border-left-0 border-right-0 flex-grow-1"><%# Eval("ProductType") %></li>

                                                        </div>

                                                        <div class="col-sm-2 col-md-2 px-0 list-group flex-grow-1">
                                                            <li class="list-group-item rounded-0 rounded-right border-secondary border-left-0 border-right-0 flex-grow-1"><%# Eval("LineCost") %></li>
                                                        </div>


                                                        <div class="col-sm-1 col-md-1 px-0 list-group border-left-0  flex-grow-1">
                                                            <asp:Button CommandName="removeFromBasket" CssClass="list-group-item rounded-0 border-secondary flex-grow-1 " runat="server" Text="Change Quantity" />
                                                        </div>

                                                        <div class="col-sm-1 col-md-1 px-0 list-group border-left-0 flex-grow-1 ">
                                                            <asp:LinkButton ID="lnkDelete" CssClass="list-group-item rounded-0 border-secondary border-left-0 flex-grow-1"
                                                                runat="server" Text="X"
                                                                CommandArgument='<%#Eval("ProductId") %>'
                                                                CommandName="removeFromBasket">  
                                                            </asp:LinkButton>
                                                        </div>



                                                    </div>



                                                </div>


                                            </div>

                                        </ItemTemplate>

                                        <ItemSeparatorTemplate>
                                            <div class="pt-1"></div>

                                        </ItemSeparatorTemplate>
                                    </asp:ListView>


                                </div>
                            </div>
                        </div>



                    </div>
                    <div class="row mx-2  pt-2">


                        <div class="col-sm-12 col-md-6">
                            <div class="card shadow-sm">
                                <div class="">
                                    <h5 class="card-header alert-primary">Personal Details<h5>
                                </div>
                                <div class="card-body">
                                    <h5 class="card-title pl-3">Can we confirm delivery information is correct?</h5>
                                    <form class="border border-dark">


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

                                            <div class="col-md-12 col-sm-12">
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
                                                    <label for="tbCounty">County</label>
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
                                                    <label for="tbCountry">Country</label>
                                                    <div class="row">
                                                        <div class="col-sm-12">
                                                            <asp:TextBox ID="tbCountry" CssClass="form-control" runat="server"></asp:TextBox>
                                                        </div>

                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-6 col-sm-12">
                                                <div class="form-group px-3 py-2 m-0 border-info">
                                                    <label for="tbPostCode">PostCode</label>
                                                    <div class="row">
                                                        <div class="col-sm-12">
                                                            <asp:TextBox ID="tbPostCode" CssClass="form-control" runat="server"></asp:TextBox>
                                                        </div>

                                                    </div>
                                                </div>

                                            </div>
                                        </div>
                                </div>



                                </form>
                            </div>
                            <div class="row">
                                <div class="col-sm-12">

                                    <div class="card mt-3">
                                        <div class="card-body">

                                            <asp:Button ID="btnCompleteTransaction" CssClass="btn btn-outline-success" runat="server" Text="Complete Transaction" OnClick="btnCompleteTransaction_Click" />
                                            <asp:Button ID="btnCancelTransaction" CssClass="btn btn-outline-warning" runat="server" Text="Cancel Transaction" />

                                        </div>


                                    </div>



                                </div>


                            </div>

                        </div>

                        <div class="col-sm-12 col-md-6">

                            <div class="card shadow-sm">
                                <div class="">
                                    <h5 class="card-header alert-primary">Delivery Options:</h5>
                                </div>
                                <div class="card-body">
                                    <h5 class="card-title">Please Select from one of the following delivery options</h5>
                                    <asp:DropDownList CssClass="dropdown btn-lg" ID="ddlDeliverySelect" AutoPostBack="true" runat="server" OnSelectedIndexChanged="ddlDeliverySelect_SelectedIndexChanged">
                                        <asp:ListItem>Standard UK (1-3 days)</asp:ListItem>
                                        <asp:ListItem>Next day UK</asp:ListItem>
                                        <asp:ListItem>Standard EU (3-5 days)</asp:ListItem>
                                        <asp:ListItem>Next day EU</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:Label ID="lblHiddenCost" runat="server" Visible="false"></asp:Label>
                                                                        <asp:Label ID="lblHiddenDelivery" runat="server" Visible="false"></asp:Label>

                                </div>
                                <div class="card-footer text-muted">
                                </div>
                            </div>
                            <div class="card shadow-sm mt-3">
                                <div class="">
                                    <h5 class="card-header alert-primary">Order Summary:</h5>
                                </div>
                                <div class="card-body">
                                    <div class="row">
                                        <div class="col-sm-12 col-md-6 border-right form-group">
                                            <asp:Label ID="lblTestDiscount" runat="server" Text="Label"></asp:Label>

                                            <h5 class="card-title">Discount Codes may be applied here:</h5>
                                            <asp:TextBox ID="tbDiscountCodeRedeem" CssClass="form-control" runat="server"></asp:TextBox>

                                            <asp:Button ID="btnRedeemCode" runat="server" Text="Reedem" onclick="btnRedeemCode_Click" CssClass="btn btn-success offset-9 mt-3"/>

                                            <div class="card card-body alert-warning mt-2" id="toggleCodeApplied" runat="server">
                                                <h5 class="card-title text-dark my-0">Discount Code Applied:</h5>
                                                <asp:Label ID="lblDiscountCodeAmount" runat="server" Text=""><span>% OFF</span></asp:Label>

                                            </div>

                                            <div class="card card-body alert-danger mt-2" id="DiscountRedeemFailure" runat="server">
                                                <h5 class="card-title text-dark my-0">Discount Code Failed! Please Try again.</h5>
                                                <asp:Label ID="lblDiscountCodeFail" runat="server" Text=""><span></span></asp:Label>

                                            </div>

                                        </div>
                                        <div class="col-sm col-md-1">
                                        </div>
                                        <div class="col-sm-12 col-md-5">
                                            <div class="card card-body alert-info">
                                                <h5 class="card-title text-dark my-0">Sub-Total:</h5>
                                                <asp:Label ID="lblSubTotal" runat="server" Text="0.00"></asp:Label>
                                                <h5 class="card-title text-dark my-0">VAT:</h5>
                                                <asp:Label ID="lblVat" runat="server" Text="0.00"></asp:Label>
                                                <h5 class="card-title text-dark my-0">Delivery:</h5>
                                                <asp:Label ID="lblDelivery" runat="server" Text="0.00"></asp:Label>

                                            </div>




                                            <div class="card shadow-sm mt-3">
                                                <div class="">
                                                    <h5 class="card-header alert-success">Total:</h5>
                                                </div>
                                                <div class="card-body">
                                                    <div class="row">
                                                        <div class="col-sm col-md-4">
                                                        </div>
                                                        <div class="col-sm-12 col-md-1 border-right form-group">
                                                            £
                                                        </div>
                                                        <div class="col-sm-12 col-md-6 form-group">
                                                            <asp:Label ID="lblTotal" CssClass="text-info" runat="server" Text="0.00"></asp:Label>
                                                            <asp:Label ID="lblDiscountTotalIndicator" runat="server" CssClass="alert-success" Text=""></asp:Label>
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
                </div>
    <script src="https://code.jquery.com/jquery-3.4.1.slim.min.js"> </script>
                <script src="https://cdn.jsdelivr.net/npm/popper.js@1.16.0/dist/umd/popper.min.js"></script>
                <script src="../BootStrap4/js/bootstrap.min.js"></script>
</asp:Content>
