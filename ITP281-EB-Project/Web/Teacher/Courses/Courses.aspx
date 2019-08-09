<%@ Page Title="" Language="C#" MasterPageFile="~/Static/Master/Teacher/Dashboard.master" AutoEventWireup="true" CodeFile="Courses.aspx.cs" Inherits="Web_Teacher_Courses_Courses" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitlePlaceHolder" runat="Server">
    Courses
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="HeadPlaceHolder" runat="Server">
    <style>
        #lbtn_Courses{
            color: white;
        }
    </style>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="BodyPlaceHolder" runat="Server">

    <div class="container" style="margin-top: 4rem;">
        <h1>Courses </h1>
        <hr />

        <div class="d-flex flex-wrap flex-row">
            <asp:TextBox ID="tb_Search" CssClass="form-control" runat="server" Width="210px" placeholder=" Search Topic Title" Style="border-radius: 0;"></asp:TextBox>
            <asp:Button ID="btn_Search" CssClass="btn btn-success" runat="server" Text="Search" OnClick="btn_Search_Click" Width="108px" Style="border-radius: 0;" />
            <asp:Button ID="btn_Reset" CssClass="btn btn-danger ml-auto" runat="server" Text="Reset" OnClick="btn_Reset_Click" Width="108px" Style="border-radius: 0;" />
        </div>

        <div class="table-responsive mt-3">
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
                    <asp:BoundField DataField="Course_ID" HeaderText="Course ID" HeaderStyle-Width="10%" ReadOnly="True">
                        <HeaderStyle Width="10%"></HeaderStyle>
                    </asp:BoundField>
                    <asp:BoundField DataField="Course_Title" HeaderText="Course Title" HeaderStyle-Width="40%">
                        <HeaderStyle Width="40%"></HeaderStyle>
                    </asp:BoundField>
                    <asp:BoundField DataField="Course_Desc" HeaderText="Course Description" HeaderStyle-Width="40%">
                        <HeaderStyle Width="40%"></HeaderStyle>
                    </asp:BoundField>
                    <asp:CommandField ShowSelectButton="True" SelectText="View" ShowDeleteButton="True" HeaderStyle-Width="10%" ItemStyle-HorizontalAlign="Center">
                        <HeaderStyle Width="10%"></HeaderStyle>
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:CommandField>
                </Columns>
                <PagerSettings FirstPageText="First" LastPageText="Last" Mode="NumericFirstLast" NextPageText="" />
            </asp:GridView>

            <asp:Button ID="btn_AddCourse" runat="server" OnClick="btn_AddCourse_Click" Text="Add New Course" CssClass="btn btn-info mt-3" />
        </div>
    </div>

</asp:Content>

