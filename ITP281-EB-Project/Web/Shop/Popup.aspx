<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Popup.aspx.cs" Inherits="Web_Popup2" %>

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
    <h1>SUCCESSFULLY PURCHASED!</h1>
    <p>
        Thank you for purchasing from us!
    </p>
    <p>
        A email will be sent to you shortly!</p>
    <form id="form1" runat="server">
    <div>
    
    </div>
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Back to Courses" CssClass="btn btn-success" />
    </form>
</body>
</html>