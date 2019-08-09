<%@ Page Title="" Language="C#" MasterPageFile="~/Static/Master/Admin/Dashboard.master" AutoEventWireup="true" CodeFile="Dashboard.aspx.cs" Inherits="Web_Admin_Dashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitlePlaceHolder" runat="Server">
    Home
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="HeadPlaceHolder" runat="Server">
    <style>
        #lbtn_Home {
            color: white;
        }

        body {

        }
    </style>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="BodyPlaceHolder" runat="Server">

    <section>

        <div class="container">
            <h1 class="mb-4 p-2 text-white">Admin Dashboard
            </h1>
        </div>

        <div class="container">
            <div class="row justify-content-between">
                <div class="col-lg-8 col-sm-12 mb-3 shadow-lg bg-white">
                    <h4 class="mt-2">Recent Users</h4>
                    <asp:GridView ID="gvUsers" runat="server" CssClass="table table-striped table-bordered table-condensed"
                        AutoGenerateColumns="False"
                        DataKeyNames="Login_ID"
                        DataSourceID="SqlDataSource1">
                        <Columns>
                            <asp:TemplateField ItemStyle-Width="5%" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <%# Container.DataItemIndex + 1 %>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:BoundField DataField="Login_ID" HeaderText="Login ID" ItemStyle-Width="55%"></asp:BoundField>

                            <asp:BoundField DataField="Recent_Login" HeaderText="Recent Login" ItemStyle-Width="35%"></asp:BoundField>

                        </Columns>

                    </asp:GridView>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:EBP-Database %>"
                        SelectCommand="select TOP 10 * from users order by recent_login desc;"></asp:SqlDataSource>

                </div>

                <div class="col-lg-4 col-sm-10 mb-3 bg-white">
                    <div class="container py-3">
                        <h3 class="text-center mb-3">Recent Notifications</h3>

                        <asp:Repeater ID="Re1" runat="server">
                            <ItemTemplate>

                                <div class="card border-dark mb-3">
                                    <div class="card-body text-wrap">
                                        <asp:Label ID="lbl_Text" runat="server" Text='<%#Eval("Notification_Msg")%>'></asp:Label>
                                    </div>
                                    <div class="card-footer">
                                        <asp:Label ID="lbl_Date" runat="server" Text='<%#Eval("Notification_CreationDate")%>'></asp:Label>
                                    </div>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>

                    </div>
                </div>
            </div>
        </div>


    </section>

</asp:Content>

