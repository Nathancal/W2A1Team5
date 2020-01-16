<%@ Page Title="" Language="C#" MasterPageFile="~/VapeMaster.Master" AutoEventWireup="true" CodeBehind="Invoices.aspx.cs" Inherits="Web2Ass1_Team5.secure.Invoices" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../BootStrap4/css/bootstrap-grid.min.css" rel="stylesheet" />
    <link href="../BootStrap4/css/bootstrap.min.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <div class="row">
            <div class="col-sm-12 px-4 pt-4">
                <div class="jumbotron jumbotron-fluid shadow">
                    <div class="container-fluid">
                        <div class="col-sm-12 col-md-6">
                            <div class="card text-black bg-light mb-3 shadow-sm">
                                <div class="card-header display-1">
                                </div>
                              
                                <asp:Panel ID="panelPdf" runat="server">
                                      <div class="card-body">
                                        <div class="card">
                                            <div class="card-body p-0">
                                                <div class="row p-5">
                                                    <div class="col-md-6">
                                                        <img src="../Images/Cloud9Logo.png" class="img-thumbnail"/>
                                                    </div>

                                                    <div class="col-md-6 text-right">
                                                        <p class="font-weight-bold mb-1">
                                                            Invoice <span>
                                                                <asp:Label ID="lblInvoiceNum" runat="server" Text="--"></asp:Label></span>
                                                        </p>
                                                        <p class="text-muted">
                                                            Due to: <span>
                                                                <asp:Label ID="lblInvoiceDate" runat="server" Text="--"></asp:Label></span>
                                                        </p>
                                                    </div>
                                                </div>

                                                <hr class="my-5">

                                                <div class="row pb-5 p-5">
                                                    <div class="col-md-6">
                                                        <p class="font-weight-bold mb-4">Customer Information</p>
                                                        <p class="mb-1">
                                                            <span>
                                                                <asp:Label ID="lblFullName" runat="server" Text="--"></asp:Label></span>
                                                        </p>
                                                        <p>
                                                            <span>
                                                                <asp:Label ID="lblAddress" runat="server" Text="--"></asp:Label></span>
                                                        </p>

                                                        <p class="mb-1">
                                                            <span>
                                                                <asp:Label ID="lblCity" runat="server" Text="--"></asp:Label></span>
                                                        </p>
                                                        <p class="mb-1">
                                                            <span>
                                                                <asp:Label ID="lblCounty" runat="server" Text="--"></asp:Label></span>
                                                        </p>
                                                        <p class="mb-1">
                                                            <span>
                                                                <asp:Label ID="lblCountry" runat="server" Text="--"></asp:Label></span>
                                                        </p>
                                                        <p class="mb-1">
                                                            <span>
                                                                <asp:Label ID="lblPostCode" runat="server" Text="--"></asp:Label></span>
                                                        </p>
                                                    </div>

                                                    <div class="col-md-6 text-right">
                                                        <p class="font-weight-bold mb-4">Payable To:</p>
                                                        <p class="mb-1"><span class="text-muted">Cloud 9 Vapour</span></p>
                                                        <p class="mb-1"><span class="text-muted">121 Millfield Road</span></p>
                                                        <p class="mb-1"><span class="text-muted">Belfast</span></p>
                                                        <p class="mb-1"><span class="text-muted">Antrim</span></p>
                                                    </div>
                                                </div>

                                                <div class="row p-5">
                                                    <div class="col-md-12">
                                                        <asp:ListView ID="lvInvoiceItemDisplay" DataKeyNames="ProductId" runat="server">
                                                            <LayoutTemplate>
                                                                <div class="container-fluid">
                                                                    <table class="table">

                                                                        <thead>
                                                                            <tr>
                                                                                <th class="border-0 text-uppercase small font-weight-bold">ID</th>
                                                                                <th class="border-0 text-uppercase small font-weight-bold">Name</th>
                                                                                <th class="border-0 text-uppercase small font-weight-bold">Type</th>
                                                                                <th class="border-0 text-uppercase small font-weight-bold">Quantity</th>
                                                                                <th class="border-0 text-uppercase small font-weight-bold">Unit Cost</th>
                                                                                <th class="border-0 text-uppercase small font-weight-bold">Total</th>
                                                                            </tr>
                                                                        </thead>


                                                                        <asp:PlaceHolder ID="itemPlaceholder" runat="server" />

                                                                    </table>



                                                                </div>

                                                            </LayoutTemplate>
                                                            <ItemTemplate>
                                                                <tbody>
                                                                    <tr>
                                                                        <td><%#Eval("ProductId") %></td>
                                                                        <td><%#Eval("ProductName") %></td>
                                                                        <td><%#Eval("ProductType") %></td>
                                                                        <td><%#Eval("ProductQuantity") %></td>
                                                                        <td><%#Eval("ProductPrice") %></td>
                                                                        <td><%#Eval("LineCost") %></td>
                                                                    </tr>
                                                                </tbody>

                                                            </ItemTemplate>

                                                        </asp:ListView>
                                                        

                                                                    <div class="d-flex flex-row-reverse bg-dark text-white p-4">
                                                                        <div class="py-3 px-5 text-right">
                                                                            <div class="mb-2">Total</div>
                                                                            <div class="h2 font-weight-light">£<span><asp:Label ID="lblTotalFinal" runat="server" Text="--"></asp:Label></span></div>
                                                                        </div>

                                                                        <div class="py-3 px-5 text-right">
                                                                            <div class="mb-2">Discount Applied</div>
                                                                            <div class="h2 font-weight-light"><span><asp:Label ID="lblDiscountApplied" runat="server" Text="--"></asp:Label></span></div>
                                                                        </div>

                                                                        <div class="py-3 px-5 text-right">
                                                                            <div class="mb-2">Sub - Total amount</div>
                                                                            <div class="h2 font-weight-light"><span><asp:Label ID="lblSubTotal" runat="server" Text="--"></asp:Label></span></div>
                                                                        </div>

                                                                         <div class="py-3 px-5 text-right">
                                                                            <div class="mb-2">Delivery Cost</div>
                                                                            <div class="h2 font-weight-light"><span><asp:Label ID="lblDeliveryCost" runat="server" Text="--"></asp:Label></span></div>
                                                                        </div>
                                                                    </div>



                                                    </div>
                                                </div>


                                            </div>
                                            <div class="row">
                                                <div class="col-sm-12 col-md-5">
                                                </div>
                                                <div class="col-sm-12 col-md-2">
                                                    <asp:Button ID="btnPrint" CssClass="btn btn-info" runat="server" Text="Print Invoice" />


                                                </div>
                                                <div class="col-sm-12 col-md-5"></div>

                                            </div>

                                        </div>
                                </div>


                                </asp:Panel>


                            </div>
                        </div>
                        <div class="col-sm col-md-6">
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
