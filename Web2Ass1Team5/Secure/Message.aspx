<%@ Page Title="" Language="C#" MasterPageFile="~/VapeMaster.Master" AutoEventWireup="true" CodeBehind="Message.aspx.cs" Inherits="Web2Ass1_Team5.secure.Message" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../BootStrap4/css/bootstrap-grid.min.css" rel="stylesheet" />
    <link href="../BootStrap4/css/bootstrap.min.css" rel="stylesheet" />
    <link href="../styles/Message.css" rel="stylesheet" />

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <div class="row">
            <div class="col-sm-12">
                <div class="jumbotron jumbotron-fluid shadow mt-3">
                    <div class="messaging">
                        <div class="inbox_msg">
                            <asp:ListView ID="lvUserChats" runat="server">
                                <LayoutTemplate>
                                    <div class="inbox_people">
                                        <div class="headind_srch">
                                            <div class="recent_heading">
                                                <h4>Recent</h4>
                                            </div>
                                            <div class="srch_bar">
                                                <div class="stylish-input-group">
                                                    <input type="text" class="search-bar" placeholder="Search">
                                                </div>
                                            </div>
                                        </div>
                                        <div class="inbox_chat scroll">
                                            <asp:PlaceHolder ID="itemPlaceholder" runat="server" />
                                </LayoutTemplate>



                                <ItemTemplate>
                                    <div class="chat_list">
                                        <div class="chat_people">
                                            <div class="chat_img">
                                                <img src="https://ptetutorials.com/images/user-profile.png" alt="sunil">
                                            </div>
                                            <div class="chat_ib">
                                                <h5><%Eval("") %> <span class="chat_date">Dec 25</span></h5>
                                                <p>
                                                    Test, which is a new approach to have all solutions 
				astrology under one roof.
                                                </p>
                                            </div>
                                        </div>
                                    </div>

                                    </div>


                                </ItemTemplate>
                        </div>

                        <div class="mesgs">
                            <div class="msg_history">
                                <div class="incoming_msg">
                                    <div class="incoming_msg_img">
                                        <img src="https://ptetutorials.com/images/user-profile.png" alt="sunil">
                                    </div>
                                    <div class="received_msg">
                                        <div class="received_withd_msg">
                                            <p>
                                                Test which is a new approach to have all
				solutions
                                            </p>
                                            <span class="time_date">11:01 AM    |    June 9</span>
                                        </div>
                                    </div>
                                </div>
                                <div class="outgoing_msg">
                                    <div class="sent_msg">
                                        <p>
                                            Test which is a new approach to have all
			  solutions
                                        </p>
                                        <span class="time_date">11:01 AM    |    June 9</span>
                                    </div>
                                </div>
                                <div class="incoming_msg">
                                    <div class="incoming_msg_img">
                                        <img src="https://ptetutorials.com/images/user-profile.png" alt="sunil">
                                    </div>
                                    <div class="received_msg">
                                        <div class="received_withd_msg">
                                            <p>Test, which is a new approach to have</p>
                                            <span class="time_date">11:01 AM    |    Yesterday</span>
                                        </div>
                                    </div>
                                </div>
                                <div class="outgoing_msg">
                                    <div class="sent_msg">
                                        <p>Apollo University, Delhi, India Test</p>
                                        <span class="time_date">11:01 AM    |    Today</span>
                                    </div>
                                </div>
                                <div class="incoming_msg">
                                    <div class="incoming_msg_img">
                                        <img src="https://ptetutorials.com/images/user-profile.png" alt="sunil">
                                    </div>
                                    <div class="received_msg">
                                        <div class="received_withd_msg">
                                            <p>
                                                We work directly with our designers and suppliers,
				and sell direct to you, which means quality, exclusive
				products, at a price anyone can afford.
                                            </p>
                                            <span class="time_date">11:01 AM    |    Today</span>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="type_msg">
                                <div class="input_msg_write">
                                    <input type="text" class="write_msg" placeholder="Type a message" />
                                    <button class="msg_send_btn" type="button"><i class="fa fa-paper-plane" aria-hidden="true"></i></button>
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
