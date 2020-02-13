-<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Add-Programme.aspx.cs" Inherits="FLYTA.Add_Programme" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>FLY-TA</title>
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
                                <asp:TextBox ID="tb_Title" runat="server" placeholder="Programme Title" CssClass="form-control" autofocus="autofocus"></asp:TextBox>
                            </div>

                            <div class="form-group">
                                <asp:TextBox ID="tb_Description" runat="server" placeholder="Description" CssClass="form-control" TextMode="MultiLine" Height="100"></asp:TextBox>
                            </div>
                        </div>

                        <div class="col-md-6 pl-2">
                            <div class="form-group">
                                <asp:TextBox ID="tb_Duration" runat="server" placeholder="Duration" CssClass="form-control"></asp:TextBox>
                            </div>

                            <div class="form-group">
                                <asp:DropDownList runat="server" ID="ddl_Type" CssClass="form-control">
                                    <asp:ListItem Value="Home-Stay">Home-Stay</asp:ListItem>
                                    <asp:ListItem Value="Hostel">Hostel</asp:ListItem>
                                </asp:DropDownList>
                            </div>

                            <div class="form-group">
                                <asp:TextBox ID="tb_Quota" runat="server" placeholder="Quote" CssClass="form-control" TextMode="Number"></asp:TextBox>
                            </div>

                            <div class="form-group">
                                <asp:TextBox ID="tb_Fees" runat="server" placeholder="Programme Cost" CssClass="form-control" TextMode="Number"></asp:TextBox>
                            </div>
                        </div>
                    </div>


                    <div class="form-group">
                        <div class="d-flex flex-wrap flex-row justify-content-between">
                            <asp:Button runat="server" ID="btn_Back" OnClick="btn_Back_Click" Text="Go Back" CssClass="btn btn-danger" />
                            <asp:Button ID="btn_Create" runat="server" OnClick="btn_Create_Click" CssClass="btn btn-success" Text="Add new programme" />
                        </div>
                    </div>

                </div>
            </div>
        </div>
    </form>

    <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.7/umd/popper.min.js"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js"></script>
</body>
</html>
