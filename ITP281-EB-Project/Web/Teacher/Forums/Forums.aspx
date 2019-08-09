<%@ Page Title="" Language="C#" MasterPageFile="~/Static/Master/Teacher/Dashboard.master" AutoEventWireup="true" CodeFile="Forums.aspx.cs" Inherits="Web_Forums_Forums" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitlePlaceHolder" runat="Server">
    Forums
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="HeadPlaceHolder" runat="Server">
    <style>
        #lbtn_Forums {
            color: white;
        }

        body {
            margin-top: 4.5rem;
        }
    </style>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="BodyPlaceHolder" runat="Server">

    <div class="row mx-0 my-4 justify-content-center">

        <div class="col-lg-6 col-sm-10">
            <h1 class="display-4 mb-3">Forums</h1>

            <div class="table-responsive">

                <asp:GridView ID="gv_ForumData" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                    DataKeyNames="Forum_ID"
                    OnSelectedIndexChanged="gv_ForumData_SelectedIndexChanged"
                    CssClass="table table-striped table-bordered table-condensed">
                    <Columns>
                        <asp:BoundField DataField="Forum_ID" />
                        <asp:BoundField DataField="Forum_Title" HeaderText="Forum Title" HeaderStyle-Width="40%" ItemStyle-Width="40%" />
                        <asp:BoundField DataField="Forum_Category" HeaderText="Forum Category" HeaderStyle-Width="40%" ItemStyle-Width="40%" />
                        <asp:CommandField ShowSelectButton="True" SelectText="View Thread" HeaderStyle-Width="15%" ItemStyle-Width="15%" ItemStyle-HorizontalAlign="Center" />
                    </Columns>
                </asp:GridView>

            </div>

        </div>
    </div>

</asp:Content>

