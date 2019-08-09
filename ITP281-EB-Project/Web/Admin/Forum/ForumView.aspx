<%@ Page Title="" Language="C#" MasterPageFile="~/Static/Master/Admin/Dashboard.master" AutoEventWireup="true" CodeFile="ForumView.aspx.cs" Inherits="Web_Thread_ForumView" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitlePlaceHolder" runat="Server">
    View Forums
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
            Forums
        </h1>

        <div class="table-responsive">

            <asp:GridView ID="gv_ForumData" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                DataKeyNames="Forum_ID" 
                OnRowCancelingEdit="gv_ForumData_RowCancelingEdit"
                OnRowDeleting="gv_ForumData_RowDeleting" 
                OnRowEditing="gv_ForumData_RowEditing"
                OnRowUpdating="gv_ForumData_RowUpdating" 
                OnSelectedIndexChanged="gv_ForumData_SelectedIndexChanged" 
                CssClass="table table-striped table-bordered table-condensed">
                <HeaderStyle HorizontalAlign="Center" />
                <RowStyle HorizontalAlign="Center" />
                <Columns>
                    <asp:BoundField DataField="Forum_ID" HeaderText="Forum ID" ReadOnly="true" ItemStyle-Width="20%"/>
                    <asp:BoundField DataField="Forum_Title" HeaderText="Forum Title" ItemStyle-Width="40%" />
                    <asp:BoundField DataField="Forum_Category" HeaderText="Forum Category" ItemStyle-Width="40%" />
                    <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" ShowSelectButton="True" SelectText="View" ItemStyle-Width="20%"/>

                </Columns>
            </asp:GridView>
        </div>


        <asp:Button ID="btn_CreateForum" runat="server" Text="Create Forum" class="btn btn-primary" OnClick="btn_CreateForum_Click" CausesValidation="false"/>
    </div>
</asp:Content>

