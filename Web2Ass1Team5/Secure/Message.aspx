<%@ Page Title="" EnableEventValidation="false" Language="C#" MasterPageFile="~/VapeMaster.Master" AutoEventWireup="true" CodeBehind="Message.aspx.cs" Inherits="Web2Ass1_Team5.secure.Message" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../BootStrap4/css/bootstrap-grid.min.css" rel="stylesheet" />
    <link href="../BootStrap4/css/bootstrap.min.css" rel="stylesheet" />
    <link href="../styles/Message.css" rel="stylesheet" />

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <div class="row">
            <div class="col-sm-12">
                <div class="jumbotron jumbotron-fluid shadow mt-3 pt-3 px-0">
                    <div class="row">
                        <div class="col-sm col-md-1">
                        </div>
                        <div class="col-sm-12 col-md-4">
                            <div class="card shadow-sm">
                                <h5 class="card-header alert-primary">Active Chats:</h5>
                                <div class="card-body">
                                    <asp:ListView ID="lvChats" DataKeyNames="ChatId" runat="server">
                                        <LayoutTemplate>
                                            <div class="container-fluid">

                                                <asp:PlaceHolder ID="itemPlaceholder" runat="server" />

                                            </div>

                                        </LayoutTemplate>

                                        <SelectedItemTemplate>
                                            <div class="row">
                                            <div class="col-sm-12 list-group">
                                                    <div class="row">
                                                        <div class="col-sm-12 col-md-12 list-group pl-2 pr-0 flex-grow-1 pt-2">
                                                            <li class="list-group-item list-group-item-action">
                                                                <div class="card">
                                                                    <div class="card-header">
                                                                        <h4>Conversation with:</h4>
                                                                        <h5 runat="server" class="list-group-item-dark"><%# Eval("Username") %></h5>
                                                                        <asp:Button ID="btnSelectChat" runat="server" Text="Button" Visible="false" />

                                                                    </div>
                                                                    <div class="card-footer d-flex flex-row-reverse">
                                                                    </div>

                                                                </div>
                                                        </div>
                                                        </li>
                                                    </div>

                                                </div>



                                            </div>



                                        </SelectedItemTemplate>

                                        <ItemTemplate>
                                            <div class="row">
                                                <div class="col-sm-12 list-group">
                                                    <div class="row">
                                                        <div class="col-sm-12 col-md-12 list-group pl-2 pr-0 flex-grow-1 pt-2">
                                                            <li class="list-group-item list-group-item-action">
                                                                <div class="card">
                                                                    <div class="card-header">
                                                                        <h4>Conversation with:</h4>
                                                                        <h5 runat="server" class="list-group-item-dark"><%# Eval("Username") %></h5>
                                                                        <asp:Button ID="btnSelectChat" CommandName="Select" runat="server" Text="Button" Visible="false" />

                                                                    </div>
                                                                    <div class="card-footer d-flex flex-row-reverse">
                                                                        <asp:LinkButton ID="btnView" CssClass="btn btn-secondary" ToolTip='<%#Eval("ChatId")%>' CommandArgument='<%#Eval("ChatId")%>' CommandName="View" OnClick="btnView_Click" runat="server">View</asp:LinkButton>

                                                                    </div>

                                                                </div>
                                                        </div>
                                                        </li>
                                                    </div>

                                                </div>
                                            </div>


                                        </ItemTemplate>

                                        <ItemSeparatorTemplate>

                                        </ItemSeparatorTemplate>
                                    </asp:ListView>


                                </div>
                            </div>
                        </div>

                        <div class="col-sm-12 col-md-6">
                            <div class="card shadow-sm">
                                <h5 class="card-header alert-primary">Messages:</h5>
                                <div class="card-body">
                                    <div class="row">
                                        <div class="col-sm-12">
                                            <div class="card shadow-sm">
                                                <div class="card-body">
                                                    <asp:ListView ID="lvMessagesDisplay" DataKeyNames="ID" runat="server">
                                                        <LayoutTemplate>
                                                            <div class="container-fluid">

                                                                <asp:PlaceHolder ID="itemPlaceholder" runat="server" />

                                                            </div>

                                                        </LayoutTemplate>

                                                        <ItemTemplate>

                                                            <div class="row">
                                                                <div class="col-sm-12 list-group">
                                                                    <div class="row">
                                                                        <div class="col-sm-12 col-md-12 list-group pl-0 pr-0 flex-grow-1 pt-2">
                                                                            <li class="list-group-item">
                                                                                <div class="card">
                                                                                    <div class="card-header">
                                                                                    </div>
                                                                                        <div class="card-body">
                                                                                            <div class="col-sm-8">
                                                                                                <h5 runat="server" class="card-text"><%# Eval("MessageBody") %></h5>
                                                                                            </div>
                                                                                        </div>
                                                                                        <div class="card-footer">
                                                                                           <%# Eval("CreateDate") %>
                                                                                        </div>
                                                                                        
                                                                                           <div class="card-body">
                                                                                            <div class="col-sm-8">
                                                                                                <h5 runat="server" class="card-text"><%# Eval("MessageBody") %></h5>
                                                                                            </div>
                                                                                        </div>
                                                                                        <div class="card-footer">
                                                                                           <%# Eval("CreateDate") %>
                                                                                        </div>
                                                                                  
                                                                                </div>
                                                                            </li>
                                                                        </div>

                                                                    </div>



                                                                </div>
                                                            </div>

                                                        </ItemTemplate>
                                                        <AlternatingItemTemplate></AlternatingItemTemplate>

                                                        <ItemSeparatorTemplate>

                                                        </ItemSeparatorTemplate>
                                                    </asp:ListView>

                                                </div>
                                                <div class="card-footer pb-0">
                                                    <div class="row">
                                                        <div class="col-sm-8 pb-3">
                                                            <asp:TextBox ID="tbUsername" placeholder="enter receiver username here..." CssClass="form-control mb-1" runat="server"></asp:TextBox>

                                                            <asp:TextBox ID="tbMessageDetails" TextMode="MultiLine" CssClass="form-control" placeholder="Enter Message here.." runat="server"></asp:TextBox>


                                                        </div>
                                                        <div class="col-sm-4 pt-3">
                                                            <asp:Button ID="btnSendMessage" CssClass="btn btn-success" runat="server" Text="Send" OnClick="btnSendMessage_Click" />
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
        <script src="../BootStrap4/js/bootstrap.min.js"></script>
    </div>
</asp:Content>
