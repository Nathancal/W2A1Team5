<%@ Page Title="" Language="C#" MasterPageFile="~/VapeMaster.Master" AutoEventWireup="true" CodeBehind="Help.aspx.cs" Inherits="Web2Ass1Team5.Help" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      
    <link href="../BootStrap4/css/bootstrap-grid.min.css" rel="stylesheet" />
   <link href="../BootStrap4/css/bootstrap.min.css" rel="stylesheet" />
    <link href="styles/BootstrapStyles.css" rel="stylesheet" />
    <p></p>
<div class="container">
  <div class="row">
    <div class="col-sm-4">
      <h3 class="text1">Email Us!</h3>
      <p>Email your enquiry and we will get back to you asap!</p>
      <p>Email: info@cloud9vapour.com</p>
    </div>
    <div class="col-sm-4">
      <h3 class="text1">Live Chat</h3>
      <p>Live Chat with one of our specialists who are here to help with any issues.</p>
        <p></p>
        <p></p>
        <div>
        <a class="btn btn-primary" href="#" role="button" id="btnLiveChat">Live Chat</a>    
        </div>
    </div>
    <div class="col-sm-4">
      <h3 class="text1">Phone Us!</h3>
      <p>Phone Us to Discuss your inquiry</p>
      <p></p>
      <p>Open: Mon-Sat: 9am-6pm</p>
        <p>Telephone: +447465465354</p>
    </div>
  </div>
</div>
 
    <script src="https://code.jquery.com/jquery-3.4.1.slim.min.js"> </script>
    <script src="https://cdn.jsdelivr.net/npm/popper.js@1.16.0/dist/umd/popper.min.js" ></script>
    <script src="BootStrap4/js/bootstrap.min.js"></script>
</asp:Content>
