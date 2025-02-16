﻿<%@ Page Title="" Language="C#" MasterPageFile="~/VapeMaster.Master" AutoEventWireup="true" CodeBehind="ProductsDetails.aspx.cs" Inherits="Web2Ass1Team5.ProductsDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="~/BootStrap4/css/bootstrap-grid.min.css" rel="stylesheet" />
    <link href="~/BootStrap4/css/bootstrap.min.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div class="container-fluid">

        <div class="row">
            <div class="col-sm-12 mt-3">
                <div class="alert alert-dark" role="alert">
                    <h5>Product Details</h5>
                </div>
            </div>
        </div>

        <div class="row">
            <div class="col-sm-12 col-md-6">

                <div class="card shadow p-4 ">
                    <div class="card-header">
                        <h3 class="card-title">Product Details</h3>
                    </div>

                    <div class="card-body ">
                        <div class="row">
                            <div class="col-sm-12 col-md-4 mr-5">

                                <img src="" id="productImage" runat="server" class="card-img-top img-fluid pt-1" style="max-height: 32rem; max-width: 32rem;" alt="">
                            </div>

                            <div class="col-sm-12 col-md-5">
                                <h4 class="alert-primary text-dark rounded-right">Product Name:</h4>
                                <h5>
                                    <asp:Label ID="lblProductName" CssClass="card-text text-dark" runat="server" Text=""></asp:Label></h5>
                                <h4 class="alert-primary text-dark rounded-right">Product Type:</h4>
                                <h5>
                                    <asp:Label ID="lblProductType" CssClass="card-text text-dark" runat="server" Text=""></asp:Label></h5>
                                <h4 class="alert-primary text-dark rounded-right">Product Description:</h4>
                                <h5>
                                    <asp:Label ID="lblProductDescription" CssClass="card-text text-dark" runat="server" Text=""></asp:Label></h5>
                                <h4 class="alert-primary text-dark rounded-right">Price:
                                </h4>
                                <h5>
                                    <asp:Label ID="lblProductPrice" runat="server" Text=""></asp:Label></h5>
                                <h4 class="alert-primary text-dark rounded-right">Total Quantity: </h4>
                                <asp:DropDownList ID="ddlQuantity" CssClass="dropdown show alert-dark" runat="server">
                                    <asp:ListItem>Choose Quantity</asp:ListItem>
                                    <asp:ListItem>1</asp:ListItem>
                                    <asp:ListItem>2</asp:ListItem>
                                    <asp:ListItem>3</asp:ListItem>
                                    <asp:ListItem>4</asp:ListItem>
                                    <asp:ListItem>5</asp:ListItem>
                                </asp:DropDownList>
                                <asp:Button ID="btnAddToCart" CssClass="btn btn-primary btn-lg mt-3" runat="server"  Text="Add to Cart" OnClick="btnAddToCart_Click" />
                            </div>

                            <div class="col-sm col-md-3"></div>

                        </div>


                    </div>
                </div>

            </div>

            <div class="col-sm-12 col-md-6">
                <div class="card shadow p-4">
                    <div class="card-header">
                        <h3 class="card-title">Shopping Basket</h3>
                    </div>
                    <div class="card-body rounded-bottom bg-light">
                        <div class="container-fluid ">

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

                                        <div class="row">
                                            <div class="col-sm-3 col-md-3 pt-3">
                                            </div>
                                            <div class="col-sm-3 col-md-3 pt-3">
                                            </div>
                                            <div class="col-sm-3 col-md-3 pt-3 pr-0">
                                                <asp:Button CommandName="goToCheckout" CssClass="btn btn-success" runat="server" Text="Checkout" />

                                            </div>
                                            <div class="col-sm-3 col-md-3 pt-3 pl-0">
                                                <asp:Button CommandName="emptyShoppingBasket" CssClass="btn btn-danger" runat="server" Text="Empty" />

                                            </div>

                                        </div>



                                    </div>

                                </LayoutTemplate>

                                <ItemTemplate>
                                    <div class="row">
                                        <div class="col-sm-12 list-group">
                                            <div class="row">
                                                <div class="col-sm-3 col-md-3 list-group pr-0 flex-grow-1">
                                                    <li class="list-group-item rounded-0 rounded-left border-secondary border-right-0 flex-grow-1"><%# Eval("ProductName") %></li>
                                                </div>

                                                <div class="col-sm-2 col-md-2 pl-0 pr-0 list-group flex-grow-1">

                                                    <li class="list-group-item rounded-0 border-secondary  border-left-0 border-right-0 flex-grow-1"><%# Eval("ProductQuantity") %></li>

                                                </div>


                                                <div class="col-sm-3 col-md-3 px-0 list-group flex-grow-1">
                                                    <li class="list-group-item rounded-0 border-secondary border-left-0 border-right-0 flex-grow-1"><%# Eval("ProductType") %></li>

                                                </div>

                                                <div class="col-sm-2 col-md-2 px-0 list-group flex-grow-1">
                                                    <li class="list-group-item rounded-0 rounded-right border-secondary border-left-0 border-right-0 flex-grow-1"><%# Eval("LineCost") %></li>
                                                </div>


                                                <div class="col-sm-2 col-md-2 px-0 list-group border-left-0 flex-grow-1">
                                                    <asp:Button CommandName="removeFromBasket" CssClass="list-group-item rounded-0 border-secondary border-left-0 flex-grow-1" runat="server" Text="X" />
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





        </div>
        <div class="row" id="RateProductRow" runat="server">
            <div class="col-sm-2">

            </div>


            <div class="col-sm-8">
                <div class="jumbotron jumbotron-fluid alert-primary mt-4">
                    <div class="container">
                        <h1 class="display-4">Recently made a purchase? Leave a Review!</h1>
                        <div class="card shadow-sm ">
                            <div class="card-body checkoutCardStyle">
                                <h5 class="card-title">Please tell us what you thought of this product:</h5>
                                <form class="border border-dark pl-2">
                          
                                    <div class="form-group px-3 py-2 m-0">
                                        <label for="tbProductType">
                                            Product Rating(out of 10): <span>
                                                <asp:DropDownList ID="ddlProductRating" CssClass="dropdown" runat="server">
                                                    <asp:ListItem>1</asp:ListItem>
                                                    <asp:ListItem>2</asp:ListItem>
                                                    <asp:ListItem>3</asp:ListItem>
                                                    <asp:ListItem>4</asp:ListItem>
                                                    <asp:ListItem>5</asp:ListItem>
                                                    <asp:ListItem>6</asp:ListItem>
                                                    <asp:ListItem>7</asp:ListItem>
                                                    <asp:ListItem>8</asp:ListItem>
                                                    <asp:ListItem>9</asp:ListItem>
                                                    <asp:ListItem>10</asp:ListItem>
                                                </asp:DropDownList></span></label>

                                    </div>
                                    <div class="form-group px-3 py-2 m-0">
                                        <label for="tbProductType">Give us a description of your experience?</label>
                                        <asp:TextBox ID="tbRatingDescription" TextMode="MultiLine" CssClass="form-control mb-1" placeholder="tell us more.." runat="server"></asp:TextBox>


                                    </div>
                                    <asp:Button ID="btnSubmitRating" runat="server" Text="Submit Product Rating" CssClass="btn btn-primary mt-1" OnClick="btnSubmitRating_Click" />
                                    <asp:Label ID="lblReviewSubmitted" CssClass="alert-danger" runat="server" Text=""></asp:Label>
                            </div>
                            </form>

                        </div>


                    </div>
                </div>




            </div>


        </div>
        <div class="row">
            <div class="col-sm col-md-3">
            </div>
            <div class="col-sm-12 col-md-6 pt-3 pb-3 mr-3" id="ProductReviewsDisplay" runat="server">
                <div class="row">
                    <div class="col-md-12 col-sm-12">

                        <div class="card shadow">
                            <h5 class="card-header">Product Review</h5>

                            <asp:ListView ID="lvProductReviewsDisplay" GroupItemCount="3" GroupPlaceholderID="GroupPlaceHolder" ItemPlaceholderID="ItemPlaceholder" runat="server">
                                <LayoutTemplate>

                                    <div class="col-md-12 col-sm-12">
                                        <div id="productReviews" class="carousel slide" data-ride="carousel">
                                            <div class="row">
                                                <div class="col-md-12 col-sm-12">
                                                    <asp:PlaceHolder ID="GroupPlaceHolder" runat="server" />
                                                </div>
                                            </div>

                                        </div>

                                    </div>


                                    <a class="carousel-control-prev" style="filter: invert(80%);" href="#productReviews" role="button" data-slide="prev">
                                        <span class="carousel-control-prev-icon alert-dark" aria-hidden="true"></span>
                                        <span class="sr-only">Previous</span>
                                    </a>
                                    <a class="carousel-control-next" style="filter: invert(80%);" href="#productReviews" role="button" data-slide="next">
                                        <span class="carousel-control-next-icon alert-dark" aria-hidden="true"></span>
                                        <span class="sr-only">Next</span>
                                    </a>


                                </LayoutTemplate>
                                <GroupTemplate>
                                    <div class="carousel-inner">

                                        <asp:PlaceHolder ID="itemPlaceholder" runat="server" />

                                    </div>

                                </GroupTemplate>
                                <ItemTemplate>
                                    <div class="carousel-item <%# (Container.DataItemIndex == 0 ? "active" : "") %> flex-grow-1">
                                        <div class="card-body">
                                            <div class="card">
                                                <div class="card-header alert-primary">

                                                    <h5 class="card-title"><span><%# Eval("FirstName") %> <%# Eval("Surname") %></span></h5>
                                                </div>

                                                <div class="card-body">
                                                    <p class="card-text h5"><span>Product Name:</span></p>

                                                    <p class="card-text"><span><%#Eval("ProductName") %></span></p>
                                                    <p class="card-text h5"><span>Description of experience:</span></p>

                                                    <p class="card-text"><span><%#Eval("RatingDesc") %></span></p>
                                                    <p class="card-text h5"><span>Rating out of 10:</span></p>

                                                    <p class="card-text"><span><%#Eval("Rating") %></span></p>
                                                    <div class="card-footer">
                                                        <p class="card-text"><small class="text-muted"><%#Eval("DateSubmitted") %></small></p>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </ItemTemplate>

                                <ItemSeparatorTemplate>
                                    <div class="mr-1"></div>

                                </ItemSeparatorTemplate>

                            </asp:ListView>

                        </div>
                    </div>
                </div>
            </div>
            <div class="col-sm col-md-3">
            </div>



        </div>


    </div>



    <script src="https://code.jquery.com/jquery-3.4.1.slim.min.js"> </script>
    <script src="https://cdn.jsdelivr.net/npm/popper.js@1.16.0/dist/umd/popper.min.js"></script>
    <script src="/BootStrap4/js/bootstrap.min.js"></script>
</asp:Content>
