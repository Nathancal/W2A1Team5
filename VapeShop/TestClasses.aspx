<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TestClasses.aspx.cs" Inherits="VapeShop.TestClasses" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <asp:TextBox ID="tbUsername" runat="server"></asp:TextBox>
            <asp:TextBox ID="tbFirstName" runat="server"></asp:TextBox>
            <asp:TextBox ID="tbSurname" runat="server"></asp:TextBox>

            <asp:Calendar ID="calDob" runat="server"></asp:Calendar>

            <asp:TextBox ID="tbAddress" runat="server"></asp:TextBox>
            <asp:TextBox ID="tbCity" runat="server"></asp:TextBox>

            <asp:TextBox ID="tbCounty" runat="server"></asp:TextBox>
            <asp:TextBox ID="tbCountry" runat="server"></asp:TextBox>
            <asp:TextBox ID="tbPostCode" runat="server"></asp:TextBox>

            <asp:TextBox ID="tbAccessLevel" runat="server"></asp:TextBox>
            <asp:TextBox ID="tbEmail" runat="server"></asp:TextBox>
            <asp:TextBox ID="tbPassword" runat="server"></asp:TextBox>


            <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" />

            <br />
            <br />
            <br />
            <asp:Label ID="lblOutput" runat="server" Text="Label"></asp:Label>

        </div>
    </form>
</body>
</html>
