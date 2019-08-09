<%@ Page Title="" Language="C#" MasterPageFile="~/Static/Master/Admin/Dashboard.master" AutoEventWireup="true" CodeFile="ThreadView.aspx.cs" Inherits="Web_Thread_ThreadView" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitlePlaceHolder" runat="Server">
    View Threads
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="HeadPlaceHolder" runat="Server">
    <style>
        #lbtn_Forums {
            color: white;
        }
    </style>
</asp:Content>


<asp:Content ID="Content3" ContentPlaceHolderID="BodyPlaceHolder" runat="Server">

    <div class="container">
        <h1 class="text-white mb-4 p-2">
        <asp:Label ID="lbl_ForumTitle" runat="server" Text='<%#Eval("Forum_Title") %>'></asp:Label> <br />
        <!--Description:    <asp:Label ID="lbl_ForumDesc" runat="server" Text='<%#Eval("Forum_Desc") %>'></asp:Label> -->
        </h1>

        <div class="table-responsive">

            <div class=" b-white">
                <asp:GridView ID="gv_ThreadData" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-bordered table-condensed" DataKeyNames="Thread_ID" OnRowDeleting="gv_ThreadData_RowDeleting" OnSelectedIndexChanged="gv_ThreadData_SelectedIndexChanged" OnRowCancelingEdit="gv_ThreadData_RowCancelingEdit" OnRowEditing="gv_ThreadData_RowEditing" OnRowUpdating="gv_ThreadData_RowUpdating">
                    <HeaderStyle HorizontalAlign="Center" />
                    <RowStyle HorizontalAlign="Center" />
                    <Columns>
                        <asp:BoundField DataField="Thread_ID" HeaderText="Thread ID" ItemStyle-Width="20%" ReadOnly="true"/>
                        <asp:BoundField DataField="Thread_Title" HeaderText="Thread Title" ItemStyle-Width="60%"/>
                        <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" ShowSelectButton="True" SelectText="View" ItemStyle-Width="20%"/>
                    </Columns>
                </asp:GridView>
            </div>

        </div>

        <div class="row mx-0 justify-content-between">
            <asp:Button ID="btn_Back" runat="server" Text="Back" CssClass="btn btn-danger" OnClick="btn_Back_Click" Height="40px" Width="144px" />
            <asp:Button ID="btn_Create" runat="server" OnClick="btn_Create_Click" Text="Create" Width="148px" CssClass="btn btn-primary" Height="37px" />
        </div>
    </div>
</asp:Content>

