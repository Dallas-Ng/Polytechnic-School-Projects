<%@ Page Title="" Language="C#" MasterPageFile="~/Static/Master/Admin/Dashboard.master" AutoEventWireup="true" CodeFile="Courses.aspx.cs" Inherits="Web_Admin_Course_Courses" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitlePlaceHolder" runat="Server">
    Courses
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="HeadPlaceHolder" runat="Server">
    <style>
        #lbtn_Courses {
            color: white;
        }
    </style>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="BodyPlaceHolder" runat="Server">

    <div class="container">
        <h1 class="text-white mb-4 p-2">Viewing Courses
        </h1>

        <div class="container whiteout">
            <div class="d-flex flex-wrap flex-row p-2">
                <asp:TextBox ID="tb_Search" runat="server" Width="210px" placeholder=" Search.." Style="border-radius: 0;" CssClass="form-control"></asp:TextBox>

                <asp:Button ID="btn_Search" runat="server" Text="Search" OnClick="btn_Search_Click" Width="108px" Style="border-radius: 0;" CssClass="btn btn-success" />

                <asp:Button ID="btn_Reset" runat="server" Text="Reset" OnClick="btn_Reset_Click" Width="108px" Style="border-radius: 0;" CssClass="btn btn-danger ml-auto" />
            </div>

        </div>

        <div class="table-responsive">
            <asp:GridView ID="gvCourse" runat="server" CssClass="table table-striped table-bordered table-condensed"
                OnSelectedIndexChanged="gvCourse_SelectedIndexChanged"
                AutoGenerateColumns="False"
                DataKeyNames="Course_ID"
                OnRowCommand="gvCourse_RowCommand"
                OnRowCancelingEdit="gvCourse_RowCancelingEdit"
                OnRowDeleting="gvCourse_RowDeleting"
                OnRowEditing="gvCourse_RowEditing"
                OnRowUpdating="gvCourse_RowUpdating" AllowPaging="True" OnPageIndexChanging="gvCourse_PageIndexChanging">
                <Columns>


                    <asp:BoundField DataField="Course_ID" HeaderText="Course_ID" HeaderStyle-Width="20%" ReadOnly="True">
                        <HeaderStyle Width="20%"></HeaderStyle>
                    </asp:BoundField>
                    <asp:BoundField DataField="Course_Title" HeaderText="Course_Title" HeaderStyle-Width="20%">
                        <HeaderStyle Width="20%"></HeaderStyle>
                    </asp:BoundField>
                    <asp:BoundField DataField="Course_Author" HeaderText="Author" HeaderStyle-Width="20%">
                        <HeaderStyle Width="20%"></HeaderStyle>
                    </asp:BoundField>
                    <asp:CommandField ShowSelectButton="True" SelectText="View" ShowDeleteButton="True" HeaderStyle-Width="20%" ItemStyle-HorizontalAlign="Center">

                        <HeaderStyle Width="20%"></HeaderStyle>

                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:CommandField>

                </Columns>
                <PagerSettings FirstPageText="First" LastPageText="Last" Mode="NumericFirstLast" NextPageText="" />
            </asp:GridView>

        </div>
    </div>

</asp:Content>

