<%@ Page Title="" Language="C#" MasterPageFile="~/Static/Master/Admin/Dashboard.master" AutoEventWireup="true" CodeFile="ThreadInsert.aspx.cs" Inherits="Web_Thread_ThreadInsert" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitlePlaceHolder" runat="Server">
    Insert Threads
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
        <h1 class="text-white mb-4 p-2">Create a new Topic
        </h1>

        <div class="container b-white p-4">

            <div class="form-group">
                <label>Title</label>
                <asp:TextBox ID="tb_ThreadTitle" runat="server" placeholder="Enter Title" CssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfv_ThreadTitle" runat="server" ControlToValidate="tb_ThreadTitle" ErrorMessage="Please enter Thread Title" ForeColor="Red" CssClass="invalid-feedback"></asp:RequiredFieldValidator>
            </div>

            <div class="form-group">
                <label>Description</label>
                <asp:TextBox ID="tb_ThreadDesc" runat="server" placeholder="Enter Description" CssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfv_ThreadDesc" runat="server" ControlToValidate="tb_ThreadDesc" ErrorMessage="Please enter Thread Description" ForeColor="Red" CssClass="invalid-feedback"></asp:RequiredFieldValidator>
            </div>

            <div class="form-group">
                <label>Category</label>
                <asp:DropDownList ID="ddl_ThreadCategory" runat="server" CssClass="form-control">
                    <asp:ListItem>English</asp:ListItem>
                    <asp:ListItem>Mathematics</asp:ListItem>
                    <asp:ListItem>Science</asp:ListItem>
                    <asp:ListItem>General Discussion</asp:ListItem>
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="rfv_ThreadCategory" runat="server" InitialValue="None" ControlToValidate="ddl_ThreadCategory" ErrorMessage="Please select Category" ForeColor="Red" CssClass="invalid-feedback"></asp:RequiredFieldValidator>
            </div>

            <div class="form-group">
                <div class="row justify-content-between mx-0">
                    <asp:Button ID="btn_Back" runat="server" Text="Back" CssClass="btn btn-danger w-100" OnClick="btn_Back_Click" Style="max-width: 100px;" CausesValidation="false"/>

                    <asp:Button ID="btn_Create" runat="server" Text="Create" class="btn btn-primary w-100" OnClick="btn_Create_Click" Style="max-width: 100px;"/>
                </div>
                <asp:ValidationSummary ID="ValidationSummary" runat="server" Font-Bold="True" ForeColor="Red"/>
            </div>
        </div>
    </div>
</asp:Content>

