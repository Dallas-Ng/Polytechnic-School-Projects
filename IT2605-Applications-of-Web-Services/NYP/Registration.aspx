<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="NYP.Registration" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>NYP</title>
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css" />

</head>
<body>
    <form id="form1" runat="server">
        <div class="row no-gutters justify-content-center mt-5">
            <div class="col-10">
                <div class="container">
                    <h1>Insert Programme</h1>
                    <hr />
                    <br />

                    <div class="row no-gutters justify-content-center">
                        <div class="col-md-6">
                            <div class="form-group">
                                <asp:TextBox ID="tb_Admin" runat="server" placeholder="Your Admin" CssClass="form-control" autofocus="autofocus"></asp:TextBox>
                            </div>

                            <div class="form-group">
                                <asp:TextBox ID="tb_Name" runat="server" placeholder="Your Name" CssClass="form-control"></asp:TextBox>
                            </div>

                            <div class="form-group">
                                <asp:TextBox ID="tb_Course" runat="server" placeholder="Your Course" CssClass="form-control"></asp:TextBox>
                            </div>

                            <div class="form-group">
                                <asp:TextBox ID="tb_Contact" runat="server" placeholder="Your Contact" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>

                        <div class="col-md-6 pl-2">
                            <div class="form-group">
                                <asp:TextBox ID="tb_PEM" runat="server" placeholder="PEM Group" CssClass="form-control"></asp:TextBox>
                            </div>

                            <div class="form-group">
                                <asp:TextBox ID="tb_EmergencyPerson" runat="server" placeholder="Emergency Person" CssClass="form-control"></asp:TextBox>
                            </div>

                            <div class="form-group">
                                <asp:TextBox ID="tb_EmergencyContact" runat="server" placeholder="Emergency Contact" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="d-flex flex-wrap flex-row justify-content-between">
                            <asp:Button runat="server" ID="btn_Back" OnClick="btn_Back_Click" Text="Go Back" CssClass="btn btn-danger" />
                            <asp:Button ID="btn_Register" runat="server" OnClick="btn_Register_Click" CssClass="btn btn-success" Text="Register" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>

<script src="https://code.jquery.com/jquery-3.3.1.slim.min.js"></script>
<script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.7/umd/popper.min.js"></script>
<script src="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js"></script>
</html>
