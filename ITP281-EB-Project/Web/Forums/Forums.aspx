<%@ Page Title="" Language="C#" MasterPageFile="~/Static/Master/User/Template.master" AutoEventWireup="true" CodeFile="Forums.aspx.cs" Inherits="Web_Forums_Forums" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitlePlaceHolder" runat="Server">
    Forums
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="HeadPlaceHolder" runat="Server">
    <style>
        #lbtn_Forums {
            color: black;
        }
    </style>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="HeaderPlaceHolder" runat="Server">
    Forums
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="BodyPlaceHolder" runat="Server">

    <div class="row mx-0 mb-5 justify-content-center">

        <div class="col-lg-7 col-sm-12">
            <h1 class="display-4 mb-3">Forums</h1>

            <div class="table-responsive">

                <asp:GridView ID="gv_ForumData" runat="server" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="Forum_ID" GridLines="None"
                    OnSelectedIndexChanged="gv_ForumData_SelectedIndexChanged"
                    CssClass="table table-striped table-bordered table-condensed">
                    <HeaderStyle HorizontalAlign="Center" />
                    <RowStyle HorizontalAlign="Center" />
                    <Columns>
                        <asp:BoundField DataField="Forum_ID" />
                        <asp:BoundField DataField="Forum_Title" HeaderText="Title"></asp:BoundField>
                        <asp:BoundField DataField="Forum_Category" HeaderText="Category"></asp:BoundField>
                        <asp:CommandField ShowSelectButton="True" SelectText="View" ItemStyle-HorizontalAlign="Center" HeaderText=""></asp:CommandField>
                    </Columns>
                </asp:GridView>

            </div>

        </div>
    </div>

</asp:Content>

