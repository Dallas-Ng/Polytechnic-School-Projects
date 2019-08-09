<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Checkout_Successful.aspx.cs" Inherits="Web_Checkout_Successful" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            margin-top: 19px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <h1>YOUR ITEMS HAVE BEEN ORDERED!</h1>
            <p>
                You Have Purchased
            </p>
            <p>
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="auto-style1" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
                    <Columns>
                        <asp:BoundField DataField="Course_ID" HeaderText="Course ID" />
                        <asp:BoundField DataField="Course_Author" HeaderText="By" />
                        <asp:BoundField DataField="Course_Fee" HeaderText="Price" />
                    </Columns>
                </asp:GridView>
            </p>

        </div>
    </form>
</body>
</html>
