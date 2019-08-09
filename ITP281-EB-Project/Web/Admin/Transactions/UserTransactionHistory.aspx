<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UserTransactionHistory.aspx.cs" Inherits="Web_UserTransactionHistory" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    </div>
        <asp:GridView ID="gv_UserTransaction" runat="server" AutoGenerateColumns="False"
            OnSelectedIndexChanged="gv_UserTransaction_SelectedIndexChanged"
            DataKeyNames="Login_ID"
            OnRowUpdating="gv_UserTransaction_RowUpdating"
            CssClass="table table-striped table-bordered table-condensed"
            Height="284px">
            <Columns>
                <asp:BoundField DataField="Login_ID" HeaderText="Login ID" />
                <asp:BoundField DataField="User_ID" HeaderText="User ID" />
                <asp:BoundField DataField="Transaction_ID" HeaderText="Transaction ID" />
                <asp:BoundField DataField="Transaction_Date" HeaderText="Transaction Date" />
            </Columns>
        </asp:GridView>
    </form>
</body>
</html>
