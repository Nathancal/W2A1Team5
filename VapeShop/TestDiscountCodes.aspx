<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TestDiscountCodes.aspx.cs" Inherits="VapeShop.TestDiscountCodes" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Test Discount Codes</h1>
            <br />
            <h3>Code ID</h3>
            <asp:TextBox ID="tbInputCodeId" runat="server"></asp:TextBox>
            <br />
            <h3>Date Active</h3>
            <asp:Calendar ID="calDateActive" runat="server"></asp:Calendar>
            <br />
            <h3>Date Ends</h3>
            <asp:Calendar ID="calDateEnd" runat="server"></asp:Calendar>
            <br />
            <h3>Discount Amount(Whole Numbers)</h3>
            <asp:TextBox ID="tbDiscountAmount" runat="server"></asp:TextBox>
            <br />
            <asp:Button ID="btnSubmit" runat="server" Text="Create New Discount Code" />

            <br />
            <br />


            <h1>Display discount codes</h1>
            <asp:GridView ID="dgvDiscountCodes" runat="server" AutoGenerateColumns="False" OnPageIndexChanging="dgvProducts_PageIndexChanging" OnSelectedIndexChanged="dgvProducts_SelectedIndexChanged">
            <Columns>
                <asp:CommandField ShowSelectButton="True" />
                <asp:BoundField DataField="Code" HeaderText="Code ID" />
                <asp:BoundField DataField="DateFrom" HeaderText="Date Active" />
                <asp:BoundField DataField="DateTo" HeaderText="Date Expires" />
                <asp:BoundField DataField="NumberUsed" HeaderText="Amount of Redemptions" />
                <asp:BoundField DataField="DiscountPerc" HeaderText="% discount" />
                <asp:BoundField DataField="isActive" HeaderText="Active or Not" />

            </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
