<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Inquiry.aspx.cs" Inherits="Web_Main_Inquiry" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Inquiry</title>
    <style>
        #Heading {
            font-size: 3.5rem;
            font-weight: 300;
            line-height: 1.2;
        }
    </style>

    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no" />
    <link rel="stylesheet" href="~/Content/bootstrap.css" />
    <link rel="stylesheet" type="text/css" href="~/Static/_Main/Main.css" />
    <link rel="shortcut icon" type="image" href="~/Static/_Main/Img/Icon.png" />
</head>
<body>
    <form id="form1" runat="server">

        <div class="container mt-4">
            <div class="row rounded text-white" style="margin-left: 33px; padding: 25px; margin-right: 32px; box-shadow: 3px 3px 2px #ccc; border-radius: 20px; margin-bottom: 15px; background-color: #001f3f">
                <p id="Heading"><b>Feel Free To Contact Us </b></p>
            </div>
        </div>

        <div class="container mb-4">

            <div class="row rounded" style="margin-left: 33px; padding: 25px; margin-right: 32px; box-shadow: 3px 3px 3px 3px #ccc; border-radius: 20px;">
                <div class="col-md-8">
                    <div class="well well-sm">

                        <div class="row">
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label for="name">
                                        <b>Name</b></label>
                                    <asp:TextBox ID="tb_Name" runat="server" MaxLength="64" CssClass="form-control d-inline" Width="300px" ToolTip="Enter Full Name" Style="margin-right: 150px;" required="required"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <label for="email">
                                        <b>Email Address</b></label>
                                    <div class="input-group">
                                        <span class="input-group-addon"><span class="glyphicon glyphicon-envelope"></span>
                                        </span>
                                        <asp:TextBox ID="tb_Email" runat="server" Width="350px" CssClass="form-control d-inline" ToolTip="Enter Email" type="email" placeholder="name@gmail.com" required="required"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label for="subject">
                                        <b>Issue Type</b>
                                        <asp:RequiredFieldValidator ID="rfv_ddl_Subject" runat="server" ErrorMessage="Please Select Issue Type" ControlToValidate="ddl_Category" ForeColor="Red" InitialValue="-1"></asp:RequiredFieldValidator></label>
                                    <asp:DropDownList ID="ddl_Category" runat="server" CssClass="btn btn-outline-primary dropdown-toggle form-control ">
                                        <asp:ListItem Value="-1">-- Select --</asp:ListItem>
                                        <asp:ListItem Value="Accounts">Accounts</asp:ListItem>
                                        <asp:ListItem Value="Transactions">Transactions</asp:ListItem>
                                        <asp:ListItem Value="Customers">Customers</asp:ListItem>
                                        <asp:ListItem Value="Others">Others</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label for="name">
                                        <b>Message</b></label>
                                    <asp:TextBox ID="tb_Message" runat="server" MaxLength="64" TextMode="MultiLine" CssClass="form-control" ToolTip="Enter Message" cols="25" required="required" Style="padding-bottom: 153px;"></asp:TextBox>


                                </div>
                            </div>
                            <div class="col-md-12">
                                <asp:Button ID="btn_SendMessage" runat="server" OnClick="btn_SendMessage_Click" Text="Send Message" CssClass="btn btn-success" Width="148px" />
                            </div>




                        </div>

                    </div>
                </div>
                <div class="col-md-4">
                    <address>
                        <strong>Certcess</strong><br />
                        795 Folsom Ave, Suite 600<br />
                        San Francisco, CA 94107<br />
                        Phone:
                    (123) 456-7890
           
                    </address>
                    <address>
                        <strong>Email</strong><br />
                        <p>group3ebusinessproj@gmail.com</p>
                    </address>

                </div>
            </div>
        </div>

    </form>

    <script src="/Scripts/jquery-3.0.0.slim.min.js"></script>
    <script src="/Scripts/umd/popper.min.js"></script>
    <script src="/Scripts/bootstrap.min.js"></script>

    <script>
        function signOut() {
            var auth2 = gapi.auth2.getAuthInstance();
            auth2.signOut().then(function () {
                console.log('User signed out.');
            });
        }
    </script>

    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <script>
        $(document).ready(function () {
            $(window).scroll(function () {
                if ($(this).scrollTop() > 100) {
                    $('#scroll').fadeIn();
                } else {
                    $('#scroll').fadeOut();
                }
            });
            $('#scroll').click(function () {
                $("html, body").animate({ scrollTop: 0 }, 600);
                return false;
            });
        });
    </script>
</body>
</html>
