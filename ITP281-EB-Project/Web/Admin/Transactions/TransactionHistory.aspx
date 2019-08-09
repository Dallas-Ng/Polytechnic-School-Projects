<%@ Page Title="" Language="C#" MasterPageFile="~/Static/Master/Admin/Dashboard.master" AutoEventWireup="true" CodeFile="TransactionHistory.aspx.cs" Inherits="Web_Admin_Transactions_TransactionHistory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitlePlaceHolder" Runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="HeadPlaceHolder" Runat="Server">
    <style>
        #lbtn_Transactions{
            color: white;
        }
    </style>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="BodyPlaceHolder" Runat="Server">

    <div class="container table-responsive">
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
                <asp:BoundField HeaderText="Transaction ID" DataField="Transaction_ID" ReadOnly="true" />
                <asp:BoundField HeaderText="Transaction Creation Date" DataField="Transaction_Creation_Date" ReadOnly="true" />

                <asp:CommandField ShowDeleteButton="True" />
                <asp:CommandField ShowSelectButton="True" />
            </Columns>
        </asp:GridView>

    </div>
</asp:Content>

