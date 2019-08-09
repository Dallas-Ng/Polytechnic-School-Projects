<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Invoice.aspx.cs" Inherits="Web_Invoice" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css"/>

    <link href="https://fonts.googleapis.com/css?family=Muli:300,400,700,900" rel="stylesheet" />
    <link rel="stylesheet" type="text/css" href="/Static/_Index/Css/bootstrap.min.css" />
    <link rel="stylesheet" type="text/css" href="/Static/_Index/Css/jquery-ui.css" />
    <link rel="stylesheet" type="text/css" href="/Static/_Index/Css/owl.carousel.min.css" />
    <link rel="stylesheet" type="text/css" href="/Static/_Index/Css/owl.theme.default.min.css" />
    <link rel="stylesheet" type="text/css" href="/Static/_Index/Css/aos.css" />
    <link rel="stylesheet" type="text/css" href="/Static/_Index/Css/style.css" />
    <link rel="stylesheet" type="text/css" href="/Static/_Index/Css/flaticon.css" />
</head>
<body>
    <form id="form2" runat="server">
    <div>
    
        <h1>SUCCESSFULLY PURCHASED!</h1>
    
    </div>
        <p>
            You have purchased the following course(s):</p>
        
            &nbsp;
        <asp:GridView ID="gv_Invoice" runat="server" 
            AutoGenerateColumns="False" 
            OnSelectedIndexChanged="gv_Invoice_SelectedIndexChanged"
            OnRowUpdating="gv_Invoice_RowUpdating"
            DataKeyNames="Transaction_ID">
            <Columns>
                <asp:BoundField DataField="Transaction_ID" HeaderText="Transaction ID" />
                <asp:BoundField DataField="Course_ID" HeaderText="Course ID" />
                <asp:BoundField DataField="Course_Desc" HeaderText="Course Description" />
                <asp:BoundField DataField="Course_Fee" HeaderText="Course Fee" />
                <asp:BoundField DataField="Transaction_Creation_Date" HeaderText="Date" />
            </Columns>
        </asp:GridView>
        <br/>
    <p>Thank you for purchasing from us!</p>
        <p>
            <asp:Button ID="btn_Back" runat="server" Text="Back" class="btn btn-primary" OnClick="btn_Back_Click" Height="43px" Width="99px" />
        </p>
        </form>
    </body>
</html> 
