<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TestLogin.aspx.cs" Inherits="VapeShop.TestLogin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>

            Email/Username:<br />
            <asp:TextBox ID="tbEmailUsername" runat="server"></asp:TextBox><br />
            Password:<br />
            <asp:TextBox ID="tbPassword" runat="server"></asp:TextBox><br />
            <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" />
                  
            <h3>Remember me:</h3>
            <asp:CheckBox ID="chkPersist" runat="server" />


            <br />
            <asp:Label ID="lblRefuse" runat="server" Text="Label"></asp:Label>
        </div>
    </form>
</body>
</html>
