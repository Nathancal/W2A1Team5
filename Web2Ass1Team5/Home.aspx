<%@ Page Title="" Language="C#" MasterPageFile="~/VapeMaster.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="Web2Ass1Team5.Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../BootStrap4/css/bootstrap-grid.min.css" rel="stylesheet" />
    <link href="../BootStrap4/css/bootstrap.min.css" rel="stylesheet" />
    <link href="styles/style.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">




    <div class="container-fluid ">
        <div class="row">
            <div class="col-sm-12">
                <div class="jumbotron mt-1 shadow-lg pt-3 pb-3">

                    <div class="row pt-0">
                        <div class="col-sm-12">
                            <div class="card">

                                <div class="card-header alert-primary">
                                    <h3 class="card-title">Latest Products:</h3>
                                </div>



                                <asp:ListView ID="lvProducts" runat="server" OnItemCommand="lvProducts_ItemCommand" GroupItemCount="4" DataKeyNames="ProductId" GroupPlaceholderID="GroupPlaceHolder" ItemPlaceholderID="ProductPlaceholder">
                                    <LayoutTemplate>
                                        <div class="container-fluid pt-1">
                                            <div class="row">

                                                <asp:PlaceHolder ID="GroupPlaceHolder" runat="server" />

                                            </div>

                                        </div>
                                    </LayoutTemplate>

                                    <GroupTemplate>
                                        <asp:PlaceHolder ID="ProductPlaceholder" runat="server"></asp:PlaceHolder>



                                    </GroupTemplate>

                                    <ItemTemplate>
                                        <div class="col-sm-4 flex-grow-1">
                                            <div class="card shadow-lg border border-info m-3 align-items-stretch flex-grow-1">
                                                <div class="row">
                                                    <div class="col-sm col-md-2">
                                                    </div>
                                                    <div class="col-sm-12 col-md-8 flex-grow-1">
                                                        <img class="card-img-top img-fluid pt-1 flex-grow-1" style="max-height: 8rem; max-width: 8rem;" src="<%# Eval("ImageFile") %>" alt="<%#Eval("ProductName") %> Image Not Found">
                                                    </div>
                                                    <div class="col-sm col-md-2">
                                                    </div>
                                                </div>
                                                <div class="card-body">
                                                    <h5 class="card-title text-primary"><%#Eval("ProductName") %></h5>
                                                    <p class="alert-primary mb-0">Price</p>
                                                    <p class="card-text">£<%# Eval("Price") %></p>
                                                    <p class="card-text"><small class="text-muted"><%#Eval("ProductType") %></small></p>
                                                </div>
                                                <div class="row pl-4 pb-2">
                                                    <div class="col-sm-6">
                                                        <asp:LinkButton ID="btnProductDetails" CssClass="btn btn-primary" runat="server" Text="View Details" CommandName="Select" />
                                                    </div>
                                                </div>
                                            </div>



                                        </div>



                                    </ItemTemplate>


                                </asp:ListView>

                            </div>

                        </div>


                    </div>
                    <div class="row">


                        <div class="col-sm-12">
                            <div class="jumbotron jumbotron-fluid alert-primary mt-2 rounded-bottom shadow pt-1 pb-1 mb-2">
                                <h1 class="display-4 pl-3">Welcome to Cloud 9 Vapes!</h1>
                                <p class="lead pl-4">
                                    We are a retail Electronic cigarette and related products distributor.
                                        Set up in 2019 in Northern Ireland, we provide quality assured, leading brand electronic cigarette supplies, to the Uk and the European Union. 
                                        Please feel free to create an account, take advantage of our discount codes and avail of massive discounts on our wide range of products!
                                </p>
                            </div>

                        </div>
                    </div>

                    <div class="row " id="RegisterNewUser" runat="server">
                        <div class="col-sm-1">
                        </div>

                        <div class="col-sm-10">

                            <div class="card shadow mt-1">
                                <div class="card-header alert-warning">
                                    <h3 class="card-title">New user? Register an account!</h3>

                                </div>

                                <div class="card-body ">
                                    <div class="row">
                                        <div class="col-sm-12 col-md-6 text-justify">
                                            <div class="text-secondary">
                                                <h5>Take advantage of our daily discount codes, chat with friends and shop for your favourite vaping products by signing up for your free account Here!</h5>
                                            </div>
                                        </div>
                                        <div class="col-sm-12 col-md-6">
                                            <asp:Button ID="btnRegister" CssClass="btn btn-success btn-block" OnClick="btnRegister_Click" runat="server" Text="Register Here!" />

                                        </div>
                                    </div>
                                </div>

                            </div>



                        </div>
                        <div class="col-sm-1">
                        </div>



                    </div>


                    <div class="row">
                        <div class="col-sm-12 col-md-6">
                                        <div class="card shadow mt-2">
                                            <div class="card-header alert-primary">
                                                <h3 class="card-title">Latest Product Reviews
                                                </h3>

                                            </div>

                                            <div class="card-body ">
                                                <div class="row">

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
                         

                        <div class="col-sm-12 col-md-6">
                            <div class="card shadow mt-2">
                                <div class="card-header alert-primary">
                                    <h3 class="card-title">Testimonials
                                    </h3>

                                </div>

                                <div class="card-body ">
                                    <div class="row">
                                        <div class="col-sm-12 text-justify">
                                            <div class="text-secondary">
                                                <h5>Dont just take it from us, here are a selection of videos reviewing products we sell, have a look</h5>
                                                <div class="row">
                                                    <div class="col col-md-10 offset-md-1 col-lg-8 offset-lg-2">
                                                        <div id="youtubeCarousel" class="carousel slide shadow border-secondary">
                                                            <ol class="carousel-indicators">
                                                                <li data-target="#youtubeCarousel" data-slide-to="0" class="active"></li>
                                                                <li data-target="#youtubeCarousel" data-slide-to="1"></li>
                                                                <li data-target="#youtubeCarousel" data-slide-to="2"></li>
                                                            </ol>
                                                            <div class="carousel-inner border-secondary">
                                                                <div class="carousel-item active">
                                                                    <div class="embed-responsive embed-responsive-16by9">
                                                                        <iframe class="embed-responsive-item" src="https://www.youtube.com/embed/DUurSrfxcEo" allowfullscreen></iframe>
                                                                    </div>
                                                                </div>
                                                                <div class="carousel-item">
                                                                    <div class="embed-responsive embed-responsive-16by9">
                                                                        <iframe class="embed-responsive-item" src="https://www.youtube.com/embed/Arv7EisqnyM" allowfullscreen></iframe>
                                                                    </div>
                                                                </div>
                                                                <div class="carousel-item">
                                                                    <div class="embed-responsive embed-responsive-16by9">
                                                                        <iframe class="embed-responsive-item" src="https://www.youtube.com/embed/ZxVw7bvMd3s" allowfullscreen></iframe>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <a class="carousel-control-prev" href="#youtubeCarousel" role="button" data-slide="prev">
                                                                <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                                                                <span class="sr-only">Previous</span>
                                                            </a>
                                                            <a class="carousel-control-next" href="#youtubeCarousel" role="button" data-slide="next">
                                                                <span class="carousel-control-next-icon" aria-hidden="true"></span>
                                                                <span class="sr-only">Next</span>
                                                            </a>
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



            </div>



        </div>


    </div>
    <script src="https://code.jquery.com/jquery-3.4.1.slim.min.js"> </script>
    <script src="https://cdn.jsdelivr.net/npm/popper.js@1.16.0/dist/umd/popper.min.js"></script>
    <script src="BootStrap4/js/bootstrap.min.js"></script>
    <script src="BootStrap4/js/scripts.js"></script>
</asp:Content>
