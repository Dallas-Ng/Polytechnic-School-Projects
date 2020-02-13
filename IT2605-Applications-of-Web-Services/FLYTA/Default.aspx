<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="FLYTA.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>FLY-TA</title>
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="row no-gutters justify-content-center mt-5">
            <div class="col-12">
                <div class="container">
                    <div class="row no-gutters">
                        <h1>FLY-TA Programmes - Admin</h1>
                    </div>
                    <hr />
                    <div class="d-flex justify-content-between">
                        <asp:Button runat="server" ID="btn_Add" OnClick="btn_Add_Click" Text="Add New Programme" CssClass="btn btn-success btn-sm" />
                        <a href="http://localhost:61318/">Go NYP side</a>
                    </div>
                    <hr />
                    <br />
                    <asp:GridView ID="gv_Programmes" runat="server" DataKeyNames="Id" CssClass="table table-sm border" AutoGenerateColumns="False" OnSelectedIndexChanged="gv_Programmes_SelectedIndexChanged" AllowPaging="True" PageSize="3" OnPageIndexChanging="gv_Programmes_PageIndexChanging">
                        <Columns>
                            <asp:BoundField DataField="Id" HeaderText="Id" ItemStyle-Width="5%" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
                            <asp:TemplateField HeaderText="Title" ItemStyle-Width="10%">
                                <ItemTemplate>
                                    <asp:Label ID="Label1" runat="server" Text='<%# String.Format("{0} ({1})", Eval("Title"), Eval("Accommodation_Type")) %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle Width="10%"></ItemStyle>
                            </asp:TemplateField>
                            <asp:BoundField DataField="Description" HeaderText="Description" ItemStyle-Width="55%">
                                <ItemStyle Width="55%"></ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="Duration" HeaderText="Duration" ItemStyle-Width="35%">
                                <ItemStyle Width="35%"></ItemStyle>
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="Capacity">
                                <ItemTemplate>
                                    <asp:Label ID="Label2" runat="server" Text='<%# String.Format("{0} / {1}", Eval("No_Of_Registered"), Eval("Quota")) %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="Fees" HeaderText="Price" DataFormatString="{0:C0}" ItemStyle-Width="5%">
                                <ItemStyle Width="5%"></ItemStyle>
                            </asp:BoundField>
                            <asp:CommandField HeaderText="View Students" SelectText="View" ShowSelectButton="True" />
                        </Columns>
                        <HeaderStyle HorizontalAlign="Center" />
                        <RowStyle HorizontalAlign="Center" />
                    </asp:GridView>
                </div>
            </div>
        </div>
    </form>

    <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.7/umd/popper.min.js"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js"></script>
</body>
</html>
