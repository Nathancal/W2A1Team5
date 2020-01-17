<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="AdminHome.aspx.cs" Inherits="Web2Ass1Team5.Admin.AdminHome" %>
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
                <div class="col-sm-12">
                    <div class="alert alert-dark" role="alert">
                        <h5>Administrator dashboard</h5>
                    </div>
                </div>

            </div>

            <div class="row">
             <div class="col-sm-12 col-md-3 my-0">
                <div class="card shadow p-4">
                 <div class="card-header">
                <h3 class="card-title">User Profile:</h3>
                </div>
                <img src="../Images/loginuser.png" class="card-img-top img-fluid" alt="...">
                <div class="card-body">
                <h6 class="card-title">Admin Name:</h6>
                <h6 class="card-title">$Admin Name</h6>
                <p class="card-text">Total Unread Messages:</p>
                <p class="card-text m-0 p-0">---</p>
                <a href="#" class="btn btn-primary">View Full Profile</a>
            </div>
        </div>
       </div>


        <div class="col-sm-12 col-md-3 my-0">
        <div class="card shadow p-4 h-100">
            <div class="card-header">
            <h3 class="card-title">Latest Product Reviews:</h3>
            </div>
            <asp:ListView ID="lvProductReviews" runat="server">

            </asp:ListView>
        </div>

        </div>

        <div class="col-sm-12 col-md-3 my-0">
        <div class="card shadow p-4 h-100">
            <div class="card-header">
            <h3 class="card-title">Live Chat</h3>
            </div>
            <asp:Button ID="btnChat" CssClass="btn btn-warning" runat="server" Text="View Latest Messages" />
        </div>
        </div>

        <div class="col-sm-12 col-md-3 my-0">
        <div class="card shadow p-4 h-100">
            <div class="card-header">
            <h3 class="card-title">Latest Errors</h3>
            </div>
            <asp:ListView ID="ListView3" runat="server">

            </asp:ListView>
        </div>
        </div>


      </div>
      </div>


  <!-- jQuery first, then Tether, then Bootstrap JS. -->
  <script src="https://code.jquery.com/jquery-3.1.1.slim.min.js"></script>
  <script src="https://cdnjs.cloudflare.com/ajax/libs/tether/1.4.0/js/tether.min.js"></script>
  <script src="../BootStrap4/js/bootstrap.min.js"></script>
</asp:Content>
