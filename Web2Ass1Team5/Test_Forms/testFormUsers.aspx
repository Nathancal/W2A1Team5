<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="testFormUsers.aspx.cs" Inherits="Web2Ass1Team5.testForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Test new user</h1>
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
            <asp:Label ID="lblOutput2" runat="server" Text="Label"></asp:Label>

            <h1>Test Find User</h1>
            <h2>Enter either an ID or an Email</h2>

            <asp:TextBox ID="tbSearch" runat="server"></asp:TextBox>
            <asp:Button ID="btnSearch" runat="server" Text="Button" OnClick="btnSearch_Click" />

            <asp:Label ID="lblFirstName" runat="server" Text="Label"></asp:Label>
            <asp:Label ID="lblSurname" runat="server" Text="Label"></asp:Label>
            <asp:Label ID="lblUsername" runat="server" Text="Label"></asp:Label>





        </div>
    </form>
</body>
</html>
