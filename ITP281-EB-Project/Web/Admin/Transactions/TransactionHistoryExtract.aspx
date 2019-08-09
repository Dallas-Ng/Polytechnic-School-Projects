<%@ Page Title="" Language="C#" MasterPageFile="~/Static/Master/Admin/Dashboard.master" AutoEventWireup="true" CodeFile="TransactionHistoryExtract.aspx.cs" Inherits="Web_Admin_Transactions_TransactionHistoryExtract" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitlePlaceHolder" runat="Server">
    Transaction History
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="HeadPlaceHolder" runat="Server">
    <style>
        #lbtn_Transactions {
            color: white;
        }
    </style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="BodyPlaceHolder" runat="Server">

    <div class="container">
        <h1 class="text-white mb-4 p-2">
            Transaction History
        </h1>

        <asp:GridView ID="gv_Transaction" runat="server"
            AutoGenerateColumns="False"
            OnSelectedIndexChanged="gv_Transaction_SelectedIndexChanged"
            DataKeyNames="Transaction_ID"
            OnRowCancelingEdit="gv_Transaction_RowCancelingEdit"
            OnRowDeleting="gv_Transaction_RowDeleting"
            OnRowEditing="gv_Transaction_RowEditing"
            OnRowUpdating="gv_Transaction_RowUpdating"
            CssClass="table table-striped table-bordered table-condensed"
            Height="284px">
            <Columns>
                <asp:BoundField DataField="Transaction_ID" HeaderText="Transaction ID" />
                <asp:BoundField DataField="Login_ID" HeaderText="Login ID" />
                <asp:BoundField DataField="Course_ID" HeaderText="Course ID" />
                <asp:BoundField DataField="Course_Desc" HeaderText="Course_Desc" />
                <asp:BoundField DataField="Course_Fee" HeaderText="Course_Fee" />
                <asp:BoundField DataField="Transaction_Creation_Date" HeaderText="Transaction Creation Date" />
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>

