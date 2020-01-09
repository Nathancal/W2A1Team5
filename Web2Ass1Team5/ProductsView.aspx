<%@ Page Title="" EnableEventValidation="false" Language="C#" MasterPageFile="~/VapeMaster.Master" AutoEventWireup="true" CodeBehind="ProductsView.aspx.cs" Inherits="Web2Ass1Team5.ProductsView" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">


    <!-- Required meta tags -->
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">

    <!-- Bootstrap CSS -->
    <link rel="stylesheet" href="../BootStrap4/css/bootstrap-grid.min.css">
    <link rel="stylesheet" href="../BootStrap4/css/bootstrap.min.css">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <div class="row mt-4">
            <div class="col-sm-12">
                <div class="alert alert-success align-self-center" role="alert">
                    <h3>Use discount code 10PERCENTOFF for... 10% off!!</h3>
                </div>

            </div>
        </div>
    </div>

    <div class="row pl-3">
        <div class="col-md-4 col-sm-4 pt-5">
            <div class="card shadow-sm">
                <h5 class="card-header">Products</h5>
                <div class="card-body checkoutCardStyle">
                    <h5 class="card-title">Welcome to Cloud 9 Vape!</h5>
                    <p class="card-text">Here at Cloud 9 vape we strive to provide you with the highest quality and most cost effective products available online!</p>
                    <p class="card-text">Available for sale on our site we have a variety of products including tanks, kits both starter and advanced, mods, coils accessories and much more!</p>

                    <a href="#" class="btn btn-primary">Take a Look---></a>
                </div>
            </div>

            <div class="row">
                <div class="col-sm-12 pt-3">
                    <div class="card shadow-sm ">
                        <h5 class="card-header">Search for Products:</h5>
                        <div class="card-body checkoutCardStyle">
                            <h5 class="card-title">Please search for products here based on several criteria</h5>
                            <form class="border border-dark pl-2">
                            <div class="form-group px-3 pl-2 py-2 m-0">
                                <label for="tbUsername">Product name</label>
                                <asp:TextBox ID="tbProductName" CssClass="form-control mb-1" placeholder="Search by product name." runat="server"></asp:TextBox>
                                        <asp:Button ID="btnSearchProductName" runat="server" Text="Search Name" cssClass="btn btn-primary mt-1"/>                             
                            </div>


                            <div class="form-group px-3 py-2 m-0">
                                <label for="tbProductType">Product Type</label>
                                <asp:TextBox ID="tbProductType" CssClass="form-control mb-1" placeholder="Search by product type." runat="server"></asp:TextBox>
                                <asp:Button ID="btnSearchProductType" runat="server" Text="Search Type"  cssClass="btn btn-primary mt-1"/>                             

                            </div>
                                      <div class="form-group px-3 py-2 m-0">
                                <label for="tbProductType">Maximum product price</label>
                                <asp:TextBox ID="tbProductPrice" CssClass="form-control mb-1" placeholder="Enter maximum price." runat="server"></asp:TextBox>
                                <asp:Button ID="btnSearchProductPrice" runat="server" Text="Search Price"  cssClass="btn btn-primary mt-1"/>                             

                            </div>                           
                        </div>                 
                        </form>

                       </div>
                    </div>

                </div>

            <div class="row">
                <div class="col-sm-12 pt-3 ">
                       <div class="card shadow-sm">
                        <h5 class="card-header">Shopping Basket</h5>
                        <div class="card-body checkoutCardStyle">
              <asp:ListView  ID="lvCheckout" DataKeyNames="ProductId" runat="server">
                                <LayoutTemplate>
                                    <div class="container-fluid">
                                        <div class="row">

                                            <div class="col-sm-3 col-md-3 border-right-0">
                                                <asp:Label ID="lblName" runat="server" CssClass= Text="Name"></asp:Label>

                                            </div>
                                            <div class="col-sm-3 col-md-3 border-left-0 border-right-0">
                                                <asp:Label ID="lblQuantity" runat="server" Text="Quantity"></asp:Label>

                                            </div>
                                            <div class="col-sm-3 col-md-3 border-left-0 border-right-0">
                                                <asp:Label ID="lblType" runat="server" Text="Type"></asp:Label>

                                            </div>
                                            <div class="col-sm-3 col-md-3 border-left-0">
                                                <asp:Label ID="lblLineCost" runat="server" Text="Line Cost"></asp:Label>

                                            </div>


                                        </div>

                                        <asp:PlaceHolder ID="itemPlaceholder" runat="server" />

                                        <div class="row">
                                               <div class="col-sm-3 col-md-3 pt-3">
                                            </div>
                                            <div class="col-sm-3 col-md-3 pt-3">
                                            </div>
                                               <div class="col-sm-3 col-md-3 pt-3 pr-0">
                                                                                                            <asp:Button  CommandName="goToCheckout" CssClass="btn btn-success" runat="server" Text="Checkout" />

                                            </div>
                                             <div class="col-sm-3 col-md-3 pt-3 pl-0">
                                                                                                          <asp:Button  CommandName="goToCheckout" CssClass="btn btn-secondary" runat="server" Text="Empty" />

                                            </div>

                                        </div>


                                    </div>

                                </LayoutTemplate>

                                <ItemTemplate>
                                    <div class="row">
                                        <div class="col-sm-12 list-group ">
                                            <div class="row">
                                            <div class="col-sm-3 col-md-3 list-group pr-0 ">
                                                        <li class="list-group-item rounded-0 rounded-left border-secondary border-right-0 flex-md-grow-1"><%# Eval("ProductName") %></li>
                                                </div>

                                                <div class="col-sm-3 col-md-3 pl-0 pr-0 list-group">
                                                 
                                                        <li class="list-group-item rounded-0 border-secondary border-left-0 border-right-0 flex-md-grow-1"><%# Eval("ProductQuantity") %></li>

                                                </div>


                                                <div class="col-sm-3 col-md-3 px-0 list-group">
                                                        <li class="list-group-item rounded-0 border-secondary border-left-0 border-right-0 flex-md-grow-1"><%# Eval("ProductType") %></li>

                                                </div>

                                                <div class="col-sm-3 col-md-3 px-0 list-group">
                                                        <li class="list-group-item rounded-0 border-secondary border-left-0 flex-md-grow-1"><%# Eval("LineCost") %></li>
                                                </div>

                                     
                             


                                            </div>
                                 


                                        </div>
                      

                                    </div>

                                </ItemTemplate>

                                <ItemSeparatorTemplate>
                                    <div class="pt-1"></div>

                                </ItemSeparatorTemplate>
                            </asp:ListView>                        </div>                 
                        </form>

                       </div>

                </div>


            </div>

            </div>

           <asp:Label ID="lblTest" runat="server" Text=""></asp:Label>

        

        <div class="col-md-8">
            <div class="row ml-2 mr-0 pr-0">
                <div class="col-sm-12">
                    <asp:ListView ID="lvProducts" runat="server" OnItemCommand="lvProducts_ItemCommand" DataKeyNames="ProductId" GroupItemCount="12" GroupPlaceholderID="GroupPlaceHolder" ItemPlaceholderID="ProductPlaceholder">
                        <LayoutTemplate>
                            <div class="container-fluid pt-4">
                                <div class="row">
                                    <div class="col-md-4 col-sm-12"></div>

                                    <div class="col-md-4 col-sm-12"></div>
                                    <div class="col-md-4 col-sm-12"></div>

                                    <asp:PlaceHolder ID="GroupPlaceHolder" runat="server" />

                                </div>
                                <div class="row m-4">
                                    <div class="col-sm-4"></div>
                                    <div class="col-sm-4">
                                        <asp:DataPager runat="server" PageSize="10">
                                            <Fields>
                                                <asp:NextPreviousPagerField
                                                    ButtonType="Link"
                                                    ButtonCssClass="btn btn-outline-primary text-primary"
                                                    ShowFirstPageButton="true"
                                                    ShowLastPageButton="true" />
                                                <asp:NumericPagerField ButtonType="Link" CurrentPageLabelCssClass="alert-primary" NumericButtonCssClass="btn btn-outline-primary text-primary" />
                                            </Fields>
                                        </asp:DataPager>

                                    </div>
                                    <div class="col-sm-4"></div>

                                </div>
                            </div>
                        </LayoutTemplate>
                        <ItemSeparatorTemplate>
                            <div class="m-3"></div>

                        </ItemSeparatorTemplate>
                        <GroupTemplate>
                            <asp:PlaceHolder ID="ProductPlaceholder" runat="server"></asp:PlaceHolder>







                        </GroupTemplate>

                        <ItemTemplate>

                            <div class="card card-columns shadow-lg border border-info m-3">
                                <div class="row">
                                    <div class="col-sm col-md-2">
                                    </div>
                                    <div class="col-sm-12 col-md-8">
                                        <img class="card-img-top img-fluid pt-1" style="max-height: 16rem; max-width: 16rem;" src="<%# Eval("ImageFile") %>" alt="<%#Eval("ProductName") %> Image Not Found">
                                    </div>
                                    <div class="col-sm col-md-2">
                                    </div>
                                </div>
                                <div class="card-body">
                                    <h5 class="card-title text-primary"><%#Eval("ProductName") %></h5>

                                    <p class="alert-primary mb-0">Description</p>
                                    <p class=""><%# Eval("Description") %></p>
                                    <p class="alert-primary mb-0">Price</p>
                                    <p class="card-text">£<%# Eval("Price") %></p>
                                    <p class="card-text"><small class="text-muted"><%#Eval("ProductType") %></small></p>
                                </div>
                                <div class="row pl-4 pb-2">
                                    <div class="col-sm-6">
                                        <asp:LinkButton ID="btnProductDetails" CssClass="btn btn-primary" runat="server" Text="View Details" CommandName="Select"/>
                                    </div>
                                    <div class="col-sm-6">
                                        <asp:Button ID="btnAddToCart" CssClass="btn btn-success" runat="server" Text="Add To Cart" CommandName="addToCart"/>
                                    </div>

                                </div>
                            </div>


                        </ItemTemplate>

                        <ItemSeparatorTemplate>
                            <div class="m-2"></div>

                        </ItemSeparatorTemplate>


                    </asp:ListView>

                </div>

            </div>


        </div>


        </div>

       
    

    <script src="https://code.jquery.com/jquery-3.4.1.slim.min.js"> </script>
    <script src="https://cdn.jsdelivr.net/npm/popper.js@1.16.0/dist/umd/popper.min.js"></script>
    <script src="/BootStrap4/js/bootstrap.min.js"></script>


</asp:Content>
