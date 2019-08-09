<%@ Page Title="" Language="C#" MasterPageFile="~/Static/Master/User/Template.master" AutoEventWireup="true" CodeFile="Course.aspx.cs" Inherits="Web_Classroom_Course" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitlePlaceHolder" runat="Server">
    Course
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="HeadPlaceHolder" runat="Server">
    <style>
        #lbtn_MyCourses {
            color: black;
        }
    </style>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="HeaderPlaceHolder" runat="Server">
    Courses
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="BodyPlaceHolder" runat="Server">

    <div class="row justify-content-center mx-0 my-2">

        <div class="col-lg-3 col-sm-10">
            <h1>Viewing the course</h1>

            <div class="form-group">
                Course Title:
                <asp:Label ID="lbl_Course_Title" runat="server"></asp:Label>
            </div>
            <div class="form-group">
                Course ID:
                <asp:Label ID="lbl_Course_ID" runat="server"></asp:Label>
            </div>

            <div class="form-group">
                Course Subject:
                <asp:Label ID="lbl_Course_Subject" runat="server"></asp:Label>
            </div>

            <div class="form-group">
                Course Description:
                <asp:Label ID="lbl_Course_Desc" runat="server"></asp:Label>
            </div>

            <div class="form-group">
                Upload Date:
                <asp:Label ID="lbl_Course_Upload_Date" runat="server" Text="lbl_Course_Upload_Date"></asp:Label>
            </div>

            <div class="form-group">
                <asp:Button ID="btn_return" runat="server" OnClick="btn_return_Click" Text="Return to Course" CssClass="btn btn-danger" />
            </div>
        </div>


        <div class="col-lg-7 col-sm-10">
            <div class="container">
                <h2>Topics </h2>
                <asp:TextBox ID="tb_Search" runat="server" CssClass="form-control d-inline md-2 " Width="210px" placeholder=" Search Topic Title" Style="border-radius: 0;"></asp:TextBox>
                <asp:Button ID="btn_Search" runat="server" Text="Search" CssClass="btn btn-success d-inline" OnClick="btn_Search_Click" Width="108px" Style="border-radius: 0;" />
                <asp:Button ID="btn_Reset" runat="server" Text="Reset" CssClass="btn btn-danger d-inline" OnClick="btn_Reset_Click" Width="108px" Style="border-radius: 0; margin-top: 0.5px; margin-left: 0.5px" />

                <div class="table-responsive my-2">
                    <asp:GridView ID="gvTopic" CssClass="table table-striped table-bordered table-condensed" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="gvTopic_SelectedIndexChanged" DataKeyNames="Topic_ID" AllowPaging="True" OnPageIndexChanging="gvTopic_PageIndexChanging">
                        <Columns>
                            <asp:BoundField DataField="Topic_ID" HeaderText="Topic_ID" />
                            <asp:BoundField DataField="Topic_Title" HeaderText="Topic_Title" />
                            <asp:BoundField DataField="Topic_Upload_Date" HeaderText="Topic_Created_Date" />
                            <asp:CommandField ShowSelectButton="True" SelectText="View Topic Content" ItemStyle-HorizontalAlign="Center" />
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </div>

    </div>

</asp:Content>

