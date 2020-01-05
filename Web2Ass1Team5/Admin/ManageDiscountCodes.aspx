<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="ManageDiscountCodes.aspx.cs" Inherits="Web2Ass1Team5.Admin.ManageDiscountCodes" %>
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
                                <asp:TextBox ID="tbDiscountCodeId" placeholder="Enter Code Id"  CssClass="form-control" runat="server" ></asp:TextBox>
                            </div>
                            <div class="row">
                                <div class="col-sm-6">
                                     <div class="form-group px-3 py-2 m-0">
                                        <label for="exampleInputPassword1">Date Active</label>
                                        <asp:Calendar ID="calDateActive" CssClass="form-group" runat="server"></asp:Calendar>
                                     </div>

                                </div>

                                <div class="col-sm-6">
                                    <div class="form-group px-3 py-2 m-0">
                                        <label for="exampleInputPassword1">Date Ends</label>
                                        <asp:Calendar ID="calDateEnds" CssClass="form-group" runat="server"></asp:Calendar>
                                    </div>

                                </div>
                            </div>
                                                         
                            <div class="form-group px-3 py-2 m-0">
                                <label for="discountPerc">Discount Percentage (Whole Numbers)</label>
                                <asp:TextBox ID="tbDiscountPerc" placeholder="Enter Discount Amount"  CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                            <div class="form-group px-3 py-2 m-0">
                                <asp:Button ID="btnAddCode" runat="server" Text="Add Code" CssClass="btn btn-success" OnClick="btnAddCode_Click"/>
                                <asp:Button ID="btnClearForm" runat="server" Text="Clear Form" CssClass="btn btn-secondary" />

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
                            <asp:ScriptManager ID="scrPopupGridItems" runat="server"></asp:ScriptManager>
                             <asp:GridView ID="dgvDiscountCodes" CssClass="table table-striped table-dark table-hover" runat="server" AutoGenerateColumns="False" OnPageIndexChanging="dgvDiscountCodes_PageIndexChanging" OnRowEditing="dgvDiscountCodes_RowEditing">
                                <Columns>
                                    <asp:CommandField ShowEditButton="True" />
                                    <asp:BoundField DataField="Code" HeaderText="Code ID" />
                                    <asp:BoundField DataField="DateFrom" HeaderText="Date Active" />
                                    <asp:BoundField DataField="DateTo" HeaderText="Date Expires" />
                                    <asp:BoundField DataField="NumberUsed" HeaderText="Amount of Redemptions" />
                                    <asp:BoundField DataField="DiscountPerc" HeaderText="% discount" />
                                    <asp:BoundField DataField="isActive" HeaderText="Active or Not (1 Equals Active)" />

                                </Columns>
                            </asp:GridView>
                            <asp:Panel ID="Panel1" runat="server"></asp:Panel>
                        </div>

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
