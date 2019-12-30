<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="testFormMessages.aspx.cs" Inherits="VapeShop.testFormMessages" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
         <h1>Start new Conversation</h1>
            <h3>Recipient Username:</h3>
            <asp:TextBox ID="tbUsername" runat="server"></asp:TextBox>
            <h3>Message Body:</h3>
            <asp:TextBox ID="tbMessageBody" runat="server" Height="115px" Width="231px"></asp:TextBox>
            <asp:Button ID="btnSendMessage" runat="server" OnClick="btnSendMessage_Click" Text="Send" />
            <br />
            <br />
            <br />



            <asp:ListView ID="lvMessages" runat="server">
                <ItemTemplate>
                    <div class="listConvoMessages">
                        <table>
                            <tr><td><%#Eval("ID")%></td><td><p><%#Eval("CreatorId")%></p></td><td> <%#Eval("MessageBody")%></td></tr>
                        </table>
                    </div>
                </ItemTemplate>
            </asp:ListView>

            <asp:GridView ID="dgvMessages" runat="server" AutoGenerateColumns="False" OnPageIndexChanging="dgvProducts_PageIndexChanging">
            <Columns>
                <asp:CommandField ShowSelectButton="True" />
                <asp:BoundField DataField="ID" HeaderText="MessageNum" />
                <asp:BoundField DataField="CreatorId" HeaderText="CreatorId" />
                <asp:BoundField DataField="MessageBody" HeaderText="MessageBody"/>
                <asp:BoundField DataField="CreateDate" HeaderText="CreateDate" />
                <asp:BoundField DataField="RecepientId" HeaderText="RecepientId" />
            </Columns>
            </asp:GridView>


            <asp:Button ID="btnLoadConvos" runat="server" Text="Load Conversation" OnClick="btnLoadConvos_Click" />


            <br />
            <br />
            <asp:Label ID="lblTestUnreadCount" runat="server" Text="Label"></asp:Label>
            <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
            <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>
            <asp:Label ID="Label4" runat="server" Text="Label"></asp:Label>
            <asp:Label ID="Label5" runat="server" Text="Label"></asp:Label>


        </div>
    </form>
</body>
</html>
