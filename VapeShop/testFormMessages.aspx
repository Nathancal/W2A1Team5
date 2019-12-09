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
            <h3>Subject</h3>
            <asp:TextBox ID="tbSubject" runat="server"></asp:TextBox>
            <h3>Message Body:</h3>
            <asp:TextBox ID="tbMessageBody" runat="server"></asp:TextBox>
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


        </div>
    </form>
</body>
</html>
