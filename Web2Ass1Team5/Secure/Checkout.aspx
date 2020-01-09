<%@ Page Title="" Language="C#" MasterPageFile="~/VapeMaster.Master" AutoEventWireup="true" CodeBehind="Checkout.aspx.cs" Inherits="Web2Ass1Team5.Secure.Checkout" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../BootStrap4/css/bootstrap-grid.min.css" rel="stylesheet" />
    <link href="../BootStrap4/css/bootstrap.min.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <div class="row">

            <asp:Label ID="lblTest" runat="server" Text="Label"></asp:Label>

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

                                                    <div class="col-sm-3 col-md-3 border-right-0">
                                                        <asp:Label ID="lblName" runat="server" Text="Name"></asp:Label>

                                                    </div>
                                                    <div class="col-sm-2 col-md-2 border-left-0 border-right-0">
                                                        <asp:Label ID="lblQuantity" runat="server" Text="Quantity"></asp:Label>

                                                    </div>
                                                    <div class="col-sm-3 col-md-3 border-left-0 border-right-0">
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
                                                        <div class="col-sm-3 col-md-3 list-group pl-1 pr-0">
                                                            <li class="list-group-item rounded-0 rounded-left border-secondary border-right-0"><%# Eval("ProductName") %></li>
                                                        </div>

                                                        <div class="col-sm-2 col-md-2 pl-0 pr-0 list-group">

                                                            <li class="list-group-item rounded-0 border-secondary  border-left-0 border-right-0"><%# Eval("ProductQuantity") %></li>

                                                        </div>


                                                        <div class="col-sm-3 col-md-3 px-0 list-group">
                                                            <li class="list-group-item rounded-0 border-secondary border-left-0 border-right-0"><%# Eval("ProductType") %></li>

                                                        </div>

                                                        <div class="col-sm-2 col-md-2 px-0 list-group">
                                                            <li class="list-group-item rounded-0 rounded-right border-secondary border-left-0 border-right-0"><%# Eval("LineCost") %></li>
                                                        </div>


                                                        <div class="col-sm-1 col-md-1 px-0 list-group border-left-0 ">
                                                            <asp:Button CommandName="removeFromBasket" CssClass="list-group-item rounded-0 border-secondary " runat="server" Text="Change Quantity" />
                                                        </div>

                                                        <div class="col-sm-1 col-md-1 px-0 list-group border-left-0 ">
                                                            <asp:LinkButton ID="lnkDelete" CssClass="list-group-item rounded-0 border-secondary border-left-0"
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
                                </div>



                                </form>
                            </div>
                        </div>

                        <div class="col-sm-12 col-md-6">

                            <div class="card shadow-sm">
                                <div class="">
                                    <h5 class="card-header alert-primary">Delivery Options:</h5>
                                </div>
                                <div class="card-body">
                                    <h5 class="card-title">Please Select from one of the following delivery options</h5>
                                    <asp:DropDownList OnSelectedIndexChanged="ddlDeliverySelect_SelectedIndexChanged" CssClass="dropdown btn-lg" ID="ddlDeliverySelect" runat="server">
                                    </asp:DropDownList>
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
                                            <h5 class="card-title">Discount Codes may be applied here:</h5>
                                            <asp:TextBox ID="tbDiscountCodeRedeem" CssClass="form-control" runat="server"></asp:TextBox>
                                            <asp:LinkButton ID="lbtnReedemCode" Text="Reedem" CssClass="btn btn-success offset-9 mt-3" runat="server"></asp:LinkButton>
                                                      
                                            
                                            <div class="card card-body alert-warning mt-2" id="DiscountRedeemSuccess">
                                            <h5 class="card-title text-dark my-0">Discount Code Applied:</h5>
                                                <asp:Label ID="lblDiscountCodeAmount" runat="server" Text="0"><span>% OFF</span></asp:Label>

                                            </div>

                                               <div class="card card-body alert-warning mt-2" id="DiscountRedeemFailure">
                                            <h5 class="card-title text-dark my-0">Discount Code Applied:</h5>
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
