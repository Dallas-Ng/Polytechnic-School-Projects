<%@ Page Title="" Language="C#" MasterPageFile="~/Static/Master/Admin/Dashboard.master" AutoEventWireup="true" CodeFile="QuizView.aspx.cs" Inherits="Web_Admin_Courses_Topics_Quiz_QuizView" %>

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

    <div class="row mx-0 justify-content-center">
        <div class="col-lg-6 col-sm-10 ">
            <h1 class="text-white">Quiz</h1>
            <asp:GridView ID="gvQuestion" CssClass="table table-striped table-bordered table-condensed" runat="server" ShowHeaderWhenEmpty="true" AutoGenerateColumns="False" DataKeyNames="id" OnSelectedIndexChanged="gvQuestion_SelectedIndexChanged" AllowPaging="True" OnPageIndexChanging="gvQuestion_PageIndexChanging">
                <Columns>
                    <asp:BoundField DataField="ID" HeaderText="ID" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
                    <asp:BoundField DataField="Question_Number" HeaderText="Quiz_ID" />
                    <asp:BoundField DataField="Question" HeaderText="Question" />
                    <asp:BoundField DataField="Answer" HeaderText="Answer" />
                    <asp:CommandField ShowSelectButton="True" ItemStyle-HorizontalAlign="Center" SelectText="View" />
                </Columns>
                <PagerSettings FirstPageText="First" LastPageText="Last" Mode="NumericFirstLast" PageButtonCount="4" />
            </asp:GridView>

            <asp:Button ID="btn_back" runat="server" OnClick="btn_back_Click" Text="Go Back" CssClass="btn btn-danger" />

        </div>

        <div class="col-lg-4 col-sm-10 b-white">
            <h2>Viewing Question ID
                <asp:Label ID="lbl_ID" runat="server" Text="__"></asp:Label>
            </h2>

            <div class="form-group">
                Question Number
                <asp:TextBox ID="tb_Question_Number" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
            </div>


            <div class="form-group">
                Question
                <asp:TextBox ID="tb_Question" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
            </div>


            <div class="form-group">
                Answer
                <asp:TextBox ID="tb_Answer" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
            </div>


            <div class="form-group">
                Choice #1
                <asp:TextBox ID="tb_Choice1" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
            </div>


            <div class="form-group">
                Choice #2
                <asp:TextBox ID="tb_Choice2" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
            </div>


            <div class="form-group">
                Choice #3
                <asp:TextBox ID="tb_Choice3" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
            </div>


            <div class="form-group">
                Choice #4
                <asp:TextBox ID="tb_Choice4" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
            </div>
        </div>
    </div>

</asp:Content>

