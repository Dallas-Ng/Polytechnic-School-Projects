﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Static/Master/Admin/Dashboard.master" AutoEventWireup="true" CodeFile="CoursesView.aspx.cs" Inherits="Web_Admin_Courses_CoursesView" %>

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


    <div class="row justify-content-center mx-0">

        <div class="col-lg-5 col-sm-10 b-white">
            <h1>Editing the course</h1>


            <div class="form-group">
                <label>Course Title</label>
                <asp:TextBox ID="tb_Course_Title" runat="server" CssClass="form-control"></asp:TextBox>
            </div>

            <div class="form-group">
                Course ID    
            <asp:Label ID="lbl_Course_ID" runat="server" Text="lbl_Course_ID" CssClass="form-control"></asp:Label>
            </div>

            <div class="form-group">
                Course Subject
                <asp:DropDownList ID="ddl_Course_Subject" runat="server" CssClass="form-control">
                    <asp:ListItem>Math</asp:ListItem>
                    <asp:ListItem>English</asp:ListItem>
                    <asp:ListItem>Science</asp:ListItem>
                    <asp:ListItem>Geography</asp:ListItem>
                </asp:DropDownList>
            </div>

            <div class="form-group">
                Course Description
                <asp:TextBox ID="tb_Course_Desc" runat="server" Width="100%" Height="200px" TextMode="MultiLine" CssClass="form-control"></asp:TextBox>

            </div>

            <div class="form-group">
                Upload Date
                <asp:Label ID="lbl_Course_Upload_Date" runat="server" Text="lbl_Course_Upload_Date" CssClass="form-control"></asp:Label>
            </div>

            <div class="form-group">
                Course Fee
                <asp:Label ID="lbl_Course_Fee" runat="server" Text="lbl_Course_Fee" CssClass="form-control"></asp:Label>
            </div>

            <div class="form-group">
                <div class="d-flex flex-wrap flex-row">
                    <asp:Button ID="btn_return" runat="server" OnClick="btn_return_Click" Text="Return to Course" CssClass="btn btn-danger" />

                    <asp:Button ID="btn_Update_Course" runat="server" OnClick="btn_Update_Course_Click" Text="Update Course Details" CssClass="btn btn-warning ml-auto" />
                </div>
            </div>

            <asp:GridView ID="gvFeedback" runat="server" AutoGenerateColumns="False" DataKeyNames="Feedback_ID" OnRowDeleting="gvFeedback_RowDeleting" OnRowCancelingEdit="gvFeedback_RowCancelingEdit" OnRowEditing="gvFeedback_RowEditing" OnRowUpdating="gvFeedback_RowUpdating">
                <Columns>
                    <asp:BoundField DataField="Feedback_ID" HeaderText="Feedback_ID" />
                    <asp:BoundField DataField="Rating" HeaderText="Rating" />
                    <asp:BoundField DataField="Feedback" HeaderText="Feedback" />
                    <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
                </Columns>
            </asp:GridView>
        </div>


        <div class="col-lg-5 col-sm-10">
            <div class="container">
                <div class="whiteout text-white p-2">
                    <h2>Topics </h2>
                    <div class="d-flex flex-wrap flex-row">
                        <asp:TextBox ID="tb_Search" runat="server" CssClass="form-control" Width="210px" placeholder=" Search Topic Title" Style="border-radius: 0;"></asp:TextBox>
                        <asp:Button ID="btn_Search" runat="server" Text="Search" CssClass="btn btn-success" OnClick="btn_Search_Click" Width="108px" Style="border-radius: 0;" />
                        <asp:Button ID="btn_Reset" runat="server" Text="Reset" CssClass="btn btn-danger ml-auto" OnClick="btn_Reset_Click" Width="108px" Style="border-radius: 0;" />
                    </div>
                </div>

                <div class="table-responsive my-2">
                    <asp:GridView ID="gvTopic" CssClass="table table-striped table-bordered table-condensed" runat="server" AutoGenerateColumns="False" OnRowCancelingEdit="gvTopic_RowCancelingEdit" OnRowDeleting="gvTopic_RowDeleting" OnRowEditing="gvTopic_RowEditing" OnRowUpdating="gvTopic_RowUpdating" OnSelectedIndexChanged="gvTopic_SelectedIndexChanged" DataKeyNames="Topic_ID" AllowPaging="True" OnPageIndexChanging="gvTopic_PageIndexChanging">
                        <Columns>
                            <asp:BoundField DataField="Topic_ID" HeaderText="Topic_ID" />
                            <asp:BoundField DataField="Topic_Title" HeaderText="Topic_Title" />
                            <asp:BoundField DataField="Topic_Upload_Date" HeaderText="Topic_Created_Date" />
                            <asp:CommandField ShowSelectButton="True" SelectText="View Topic Content" ItemStyle-HorizontalAlign="Center"/>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </div>

    </div>
</asp:Content>

