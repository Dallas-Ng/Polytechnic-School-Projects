<%@ Page Title="" Language="C#" MasterPageFile="~/Static/Master/Admin/Dashboard.master" AutoEventWireup="true" CodeFile="View.aspx.cs" Inherits="Web_Admin_Users_View" EnableViewState="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitlePlaceHolder" runat="Server">
    View Accounts
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="HeadPlaceHolder" runat="Server">
    <style>
        #lbtn_Users {
            color: white;
        }
    </style>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="BodyPlaceHolder" runat="Server">
    <div class="container">
        <h1 class="text-white mb-4 p-2">
            <asp:Label ID="HeaderText" runat="server" Text="Registered"></asp:Label>
            Accounts
        </h1>

        <div class="container whiteout">
            <div class="d-flex justify-content-sm-center justify-content-start flex-wrap">
                <div class="pr-0 py-2 px-sm-0">
                    <asp:TextBox ID="tb_Search" runat="server" CssClass="form-control" Width="200px" placeholder="Search for anything.." CausesValidation="false" Style="border-radius: 0;"></asp:TextBox>
                </div>
                <div class="px-0 py-2 px-sm-0">
                    <asp:Button ID="btn_Search" runat="server" Text="Search" CssClass="btn btn-success" OnClick="btn_Search_Click" Width="100px" CausesValidation="false" Style="border-radius: 0;" />
                </div>

                <div class="p-2 ml-sm-0 ml-lg-auto">
                    <asp:Button ID="btn_Deleted" runat="server" Text="Deactivated Accounts" CssClass="btn btn-outline-warning" OnClick="btn_Deleted_Click" Width="200px" CausesValidation="false" />
                </div>

                <div class="p-2">
                    <div class="dropdown">
                        <button class="btn btn-outline-light dropdown-toggle" type="button" id="dropdownMenuButton" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false" style="width: 170px;">
                            Sort by:
                            <asp:Label ID="SortFilter" runat="server" Text="None"></asp:Label>
                        </button>
                        <div class="dropdown-menu" aria-labelledby="dropdownMenuButton">
                            <asp:LinkButton ID="LinkButton1" runat="server" CssClass="dropdown-item" OnClick="sortLoginID">Login ID</asp:LinkButton>
                            <asp:LinkButton ID="LinkButton2" runat="server" CssClass="dropdown-item" OnClick="sortName">Name</asp:LinkButton>
                        </div>
                    </div>
                </div>

                <div class="p-2">
                    <div class="dropdown">
                        <button class="btn btn-outline-light dropdown-toggle" type="button" id="dropdownMenuButton2" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false" style="width: 150px;">
                            Role: 
                            <asp:Label ID="RoleFilter" runat="server" Text="None"></asp:Label>
                        </button>
                        <div class="dropdown-menu" aria-labelledby="dropdownMenuButton">
                            <asp:LinkButton ID="LinkButton3" runat="server" CssClass="dropdown-item" OnClick="filterStudent">Student</asp:LinkButton>
                            <asp:LinkButton ID="LinkButton4" runat="server" CssClass="dropdown-item" OnClick="filterTeacher">Teacher</asp:LinkButton>
                            <asp:LinkButton ID="LinkButton5" runat="server" CssClass="dropdown-item" OnClick="filterAdmin">Admin</asp:LinkButton>
                        </div>
                    </div>
                </div>

                <div class="p-2">
                    <asp:Button ID="btn_Reset" runat="server" Text="Reset" CssClass="btn btn-danger" OnClick="btn_Reset_Click" Width="100px" CausesValidation="false" Style="border-radius: 0;" />
                </div>
            </div>
        </div>

        <div class="table-responsive">


            <asp:GridView ID="gvUsers" runat="server" CssClass="table table-striped table-bordered table-condensed"
                OnSelectedIndexChanged="gvUsers_SelectedIndexChanged"
                AutoGenerateColumns="False"
                DataKeyNames="Login_ID"
                OnPageIndexChanging="gvUsers_PageIndexChanging"
                AllowPaging="True">

                <Columns>

                    <asp:TemplateField HeaderStyle-Width="50px" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="50px">
                        <ItemTemplate>
                            <%# Container.DataItemIndex + 1 %>
                        </ItemTemplate>

                        <HeaderStyle Width="50px"></HeaderStyle>

                        <ItemStyle HorizontalAlign="Center" Width="50px"></ItemStyle>
                    </asp:TemplateField>

                    <asp:BoundField DataField="Login_ID" HeaderText="Login ID" HeaderStyle-Width="150px" ItemStyle-Width="150px">
                        <HeaderStyle Width="150px"></HeaderStyle>

                        <ItemStyle Width="150px"></ItemStyle>
                    </asp:BoundField>

                    <asp:BoundField DataField="Name" HeaderText="Name" HeaderStyle-Width="150px" ItemStyle-Width="150px">
                        <HeaderStyle Width="150px"></HeaderStyle>

                        <ItemStyle Width="150px"></ItemStyle>
                    </asp:BoundField>

                    <asp:BoundField DataField="Email" HeaderText="Email" HeaderStyle-Width="150px" ItemStyle-Width="150px">
                        <HeaderStyle Width="150px"></HeaderStyle>

                        <ItemStyle Width="150px"></ItemStyle>
                    </asp:BoundField>

                    <asp:BoundField DataField="Role" HeaderText="Role" HeaderStyle-Width="150px" ItemStyle-Width="150px">
                        <HeaderStyle Width="150px"></HeaderStyle>

                        <ItemStyle Width="150px"></ItemStyle>
                    </asp:BoundField>

                    <asp:CommandField CausesValidation="False" SelectText="View" ShowSelectButton="True" ItemStyle-HorizontalAlign="Center">
                        <HeaderStyle Width="50px" />
                        <ItemStyle Width="50px" />
                    </asp:CommandField>

                </Columns>

            </asp:GridView>

        </div>

        <asp:Button ID="btn_Add" runat="server" Text="Add User" OnClick="btn_Add_Click" CssClass="btn btn-success" />
    </div>

</asp:Content>

