<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TestFormProducts.aspx.cs" Inherits="VapeShop.TestFormProducts" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Test Add Products</h1>
            <asp:TextBox ID="tbProductName" runat="server"></asp:TextBox><br />
            <asp:DropDownList ID="ddlType" runat="server">
                <asp:ListItem>Starter Kits</asp:ListItem>
                <asp:ListItem>Advanced Kits</asp:ListItem>
                <asp:ListItem>Mods</asp:ListItem>
                <asp:ListItem>Tanks</asp:ListItem>
                <asp:ListItem>Coils</asp:ListItem>
                <asp:ListItem>Accessories</asp:ListItem>
                <asp:ListItem>Liquid</asp:ListItem>
            </asp:DropDownList><br />
            <asp:TextBox ID="tbProductPrice" runat="server"></asp:TextBox><br />
            <asp:CheckBox ID="cbOnSale" runat="server" /><br />
            <asp:TextBox ID="tbSalePrice" runat="server"></asp:TextBox><br />
            <asp:TextBox ID="tbDescription" runat="server"></asp:TextBox><br />
            <asp:TextBox ID="tbCurrentStock" runat="server"></asp:TextBox><br />
            <asp:TextBox ID="tbReOrderLevel" runat="server"></asp:TextBox><br />

            <asp:FileUpload ID="FulImgUploadTxt" runat="server" />

            <asp:Button ID="btnImage" runat="server" Text="Button" OnClick="btnImage_Click" /><br />

            <asp:Label ID="lblOutput" runat="server" Text="Label"></asp:Label>


            <asp:Label ID="lblProductName" runat="server" Text="Label"></asp:Label>
            <asp:Label ID="lblProductType" runat="server" Text="Label"></asp:Label>
            <asp:Label ID="lblProductCurrentSTock" runat="server" Text="Label"></asp:Label>

            <br />
            <br />
            <br />


            <asp:Label ID="lblSearch" runat="server" Text="Search"></asp:Label><asp:TextBox ID="tbSearch" runat="server"></asp:TextBox>
            <asp:Button ID="btnSearch" runat="server" Text="Search Products" OnClick="btnSearch_Click" />



        </div>
        <asp:Label ID="lblProductName1" runat="server" Text="Label"></asp:Label>
        <asp:Label ID="lblProductType1" runat="server" Text="Label"></asp:Label>
        <asp:Label ID="lblProductPrice1" runat="server" Text="Label"></asp:Label>
        <asp:Label ID="lblProductIsSale" runat="server" Text="Label"></asp:Label>
    </form>
</body>
</html>
