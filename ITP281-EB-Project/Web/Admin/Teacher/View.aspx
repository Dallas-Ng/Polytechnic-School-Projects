<%@ Page Title="" Language="C#" MasterPageFile="~/Static/Master/Admin/Dashboard.master" AutoEventWireup="true" CodeFile="View.aspx.cs" Inherits="Web_Admin_Users_View" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitlePlaceHolder" runat="Server">
    View Teachers
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="HeadPlaceHolder" runat="Server">
    <style>
        #teachers_btn {
            color: white;
        }
    </style>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="BodyPlaceHolder" runat="Server">
    <div class="container">
        <h1 class="text-white mb-4 p-2 text-center">
            <asp:Label ID="lbl_Title" runat="server"></asp:Label>
        </h1>
        <hr style="border: 1px solid white;" />

        <div class="container whiteout">
            <div class="d-flex justify-content-sm-center justify-content-lg-start flex-wrap">
                <div class="p-2">
                    <asp:TextBox ID="tb_Search" runat="server" CssClass="form-control d-inline md-2" Width="200px" placeholder="Search for anything.."></asp:TextBox>
                </div>

                <div class="p-2">
                    <asp:Button ID="btn_Search" runat="server" Text="Search" CssClass="btn btn-success d-inline ml-2 " OnClick="btn_Search_Click" Width="108px" CausesValidation="false" />
                </div>

                <div class="p-2">
                    <asp:Button ID="btn_Reset" runat="server" Text="Reset" CssClass="btn btn-danger d-inline ml-1 " OnClick="btn_Reset_Click" Width="108px" CausesValidation="false" />
                </div>
            </div>
        </div>
    </div>

    <div class="container">

        <div class="table-responsive">
            <asp:GridView ID="gvTeachers" runat="server" CssClass="table table-striped table-bordered table-condensed"
                OnSelectedIndexChanged="gvTeachers_SelectedIndexChanged"
                AutoGenerateColumns="False"
                DataKeyNames="Teacher_ID"
                OnRowCommand="gvTeachers_RowCommand" AllowPaging="True">

                <Columns>
                    <asp:BoundField DataField="Teacher_ID" HeaderText="ID" HeaderStyle-Width="50px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                        <HeaderStyle Width="50px"></HeaderStyle>
                    </asp:BoundField>

                    <asp:BoundField DataField="Name" HeaderText="Name" HeaderStyle-Width="150px">
                        <HeaderStyle Width="150px"></HeaderStyle>
                    </asp:BoundField>

                    <asp:BoundField DataField="Email" HeaderText="Email" HeaderStyle-Width="150px">
                        <HeaderStyle Width="150px"></HeaderStyle>
                    </asp:BoundField>

                    <asp:BoundField DataField="Login_ID" HeaderText="Login ID" HeaderStyle-Width="150px">
                        <HeaderStyle Width="150px"></HeaderStyle>
                    </asp:BoundField>

                    <asp:CommandField ShowSelectButton="True" HeaderStyle-Width="100px" SelectText="View" ItemStyle-HorizontalAlign="Center">
                        <HeaderStyle Width="100px"></HeaderStyle>
                    </asp:CommandField>

                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>

