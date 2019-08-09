<%@ Page Title="" Language="C#" MasterPageFile="~/Static/Master/Admin/Dashboard.master" AutoEventWireup="true" CodeFile="ForumInsert.aspx.cs" Inherits="Web_Admin_Forum_ForumInsert" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitlePlaceHolder" runat="Server">
    Insert Forums
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
        <h1 class="text-white mb-4 p-2">Create a new Forum
        </h1>

        <div class="container b-white p-4">

            <div class="form-group">
                <label>Forum Title</label>

                <asp:TextBox ID="tb_Forum_Title" runat="server" placeholder="Enter Forum Title" CssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfv_ForumTitle" runat="server" ControlToValidate="tb_Forum_Title" ErrorMessage="Please enter Forum Title" ForeColor="Red" CssClass="invalid-feedback"></asp:RequiredFieldValidator>
            </div>

            <div class="form-group">
                <label>Forum Category</label>

                <asp:DropDownList ID="ddl_ForumCategory" runat="server" CssClass="form-control">
                    <asp:ListItem>English</asp:ListItem>
                    <asp:ListItem>Mathematics</asp:ListItem>
                    <asp:ListItem>Science</asp:ListItem>
                    <asp:ListItem>General Questions</asp:ListItem>
                    <asp:ListItem>Top Questions</asp:ListItem>
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="rfv_ForumCategory" runat="server" InitialValue="None" ControlToValidate="ddl_ForumCategory" ErrorMessage="Please Select Forum Category" ForeColor="Red" CssClass="invalid-feedback"></asp:RequiredFieldValidator>
            </div>

            <div class="form-group">
                <label>Forum Description</label>

                <asp:TextBox ID="tb_Forum_Desc" runat="server" placeholder="Enter Forum Description" TextMode="MultiLine" CssClass="form-control" Height="200px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfv_ForumDesc" runat="server" ControlToValidate="tb_Forum_Desc" ErrorMessage="Please enter a description for the Forum" ForeColor="Red" CssClass="invalid-feedback"></asp:RequiredFieldValidator>
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

