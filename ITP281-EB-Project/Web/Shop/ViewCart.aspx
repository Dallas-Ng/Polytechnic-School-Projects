<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ViewCart.aspx.cs" Inherits="ViewCart" %>

<!DOCTYPE html>

<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
        <asp:GridView ID="gv_CartView" runat="server" AutoGenerateColumns="False" DataKeyNames="ItemID" OnRowCommand="gv_CartView_RowCommand">
            <Columns>
                <asp:BoundField DataField="ItemID" HeaderText="Course ID" />
                <asp:BoundField DataField="Product_Name" HeaderText="Product Name" />
                <asp:BoundField DataField="Product_Desc" HeaderText="product desc" />
                <asp:BoundField DataField="ItemPrice" DataFormatString="{0:C}" HeaderText="Unit Price" />
            </Columns>
        </asp:GridView>

        <br />
        Total Price =
        <asp:Label ID="lbl_TotalPrice" runat="server"></asp:Label>
        <br />
        <br />
        <asp:Label ID="lbl_Error" runat="server"></asp:Label>
        <br />
        <br />
        Email Address (For Invoice):&nbsp;
        <asp:TextBox ID="tb_Email" runat="server" Width="321px" required="required" ></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="btn_CheckOut" runat="server" OnClick="btn_CheckOut_Click" Text="Checkout" />
        &nbsp;
        <asp:Button ID="btn_Update" runat="server" OnClick="btn_Update_Click" Text="Update Cart" Width="133px" />
        &nbsp;
        <asp:Button ID="btn_Clear" runat="server" OnClick="btn_Clear_Click" Text="Clear Cart" />
        &nbsp;
        <asp:Button ID="btn_Back" runat="server" Text="Back" OnClick="btn_Back_Click" />
    </form>
</body>
</html>
