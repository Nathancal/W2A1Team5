﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="ManageDiscountCodes.aspx.cs" Inherits="Web2Ass1Team5.Admin.ManageDiscountCodes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <!-- Required meta tags -->
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">

    <!-- Bootstrap CSS -->
    <link rel="stylesheet" href="../BootStrap4/css/bootstrap-grid.min.css">
    <link rel="stylesheet" href="../BootStrap4/css/bootstrap.min.css">
    <!--CSS-->
    <link rel="stylesheet" href="~/styles/AdminStyle.css">

    <script src="https://code.jquery.com/jquery-3.1.1.slim.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/tether/1.4.0/js/tether.min.js"></script>
    <script src="../BootStrap4/js/bootstrap.min.js"></script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentPlaceHolder1" runat="server">

    <div class="container-fluid">
        <div class="row">
            <div class="col-sm-12 col-md-12">
                <div class="alert alert-dark" role="alert">
                    <h5>Discount Code Management:</h5>
                </div>
            </div>
        </div>

        <div class="row">
            <div class="col-sm-12 col-md-5">
                <div class="card">
                    <div class="card-header">
                        <h3 class="card-title">Create new Discount Code</h3>
                    </div>
                    <div class="row">
                        <div class="col-sm-12">
                            <form>
                                <div class="form-group px-3 py-2 m-0">
                                    <label for="discountCodeId">Discount Code ID</label>
                                    <asp:TextBox ID="tbDiscountCodeId" placeholder="Enter Code Id" CssClass="form-control" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvDiscountCodeId"  ValidationGroup="Discount" ControlToValidate="tbDiscountCodeId"  runat="server" ErrorMessage="RequiredFieldValidator"></asp:RequiredFieldValidator>
                                </div>
                                <div class="row">
                                    <div class="col-sm-6">
                                        <div class="form-group px-3 py-2 m-0">
                                            <label for="calDateActive">Date Active</label>
                                            <asp:Calendar ID="calDateActive" CssClass="form-group" runat="server"></asp:Calendar>
                                        </div>

                                    </div>

                                    <div class="col-sm-6">
                                        <div class="form-group px-3 py-2 m-0">
                                            <label for="calDateEnds">Date Ends</label>
                                            <asp:Calendar ID="calDateEnds" CssClass="form-group" runat="server"></asp:Calendar>
                                        </div>

                                    </div>
                                </div>

                                <div class="form-group px-3 py-2 m-0">
                                    <label for="discountPerc">Discount Percentage (Whole Numbers)</label>
                                    <asp:TextBox ID="tbDiscountPerc" placeholder="Enter Discount Amount" CssClass="form-control" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvDiscountPerc" ControlToValidate="tbDiscountPerc"  ValidationGroup="Discount" runat="server" ErrorMessage="RequiredFieldValidator"></asp:RequiredFieldValidator>
                                </div>

                                <div class="form-group px-3 py-2 m-0">
                                    <label for="discountPerc">Set Active (check for yes)</label>
                                    <asp:CheckBox ID="cbSetActive" runat="server" />

                                </div>
                                <div class="form-group px-3 py-2 m-0">
                                    <asp:Button ID="btnAddCode" runat="server" ValidationGroup="Discount" Text="Add Code" CssClass="btn btn-success" OnClick="btnAddCode_Click" />


                                    <asp:Button ID="btnClearForm" runat="server" CausesValidation="false" Text="Clear Form" CssClass="btn btn-danger" OnClick="btnClearForm_Click" />
                                    <asp:Label runat="server" ID="lblSumbitSuccess" CssClass="alert-success">---</asp:Label>
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

                            <asp:GridView ID="gridDiscountCodes" runat="server" CssClass="table table-striped table-dark table-hover" AllowPaging="true" AutoGenerateColumns="false" GridLines="Vertical" OnPageIndexChanging="gridDiscountCodes_PageIndexChanging">
                                <Columns>
                                    <asp:TemplateField HeaderText="Code Id">
                                        <ItemTemplate>
                                            <asp:Label ID="lblCode" runat="server" Text='<%# Eval("Code") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Date From">
                                        <ItemTemplate>
                                            <asp:Label ID="lblDateFrom" runat="server" Text='<%# Eval("DateFrom") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Date To">
                                        <ItemTemplate>
                                            <asp:Label ID="lblDateTo" runat="server" Text='<%# Eval("DateTo") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Discount %">
                                        <ItemTemplate>
                                            <asp:Label ID="lblDiscountPerc" runat="server" Text='<%# Eval("DiscountPerc") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Is Code Active">
                                        <ItemTemplate>
                                            <asp:label ID="cbIsActive" runat="server" Text='<%# Eval("isActive") %>'></asp:label>
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
