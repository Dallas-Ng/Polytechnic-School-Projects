<%@ Page Title="" Language="C#" MasterPageFile="~/Static/Master/Teacher/Dashboard.master" AutoEventWireup="true" CodeFile="TopicsInsert.aspx.cs" Inherits="Web_Teacher_Courses_Topics_TopicsInsert" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitlePlaceHolder" runat="Server">
    Courses
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="HeadPlaceHolder" runat="Server">
    <style>
        #lbtn_Courses {
            color: white;
        }
    </style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="BodyPlaceHolder" runat="Server">

    <div class="container" style="margin-top: 5rem;">
    </div>

    <div class="row justify-content-center mx-0">
        <div class="col-sm-10 col-lg-5 shadow-lg my-2">
            <h1>Add a new Topic </h1>

            <div class="form-group">
                Course ID
                <asp:TextBox ID="tb_Course_ID" runat="server" ReadOnly="True" CssClass="form-control"></asp:TextBox>

            </div>

            <div class="form-group">
                Course Subject
                <asp:TextBox ID="tb_Subject" runat="server" ReadOnly="True" CssClass="form-control"></asp:TextBox>

            </div>

            <div class="form-group">
                Course Topic ID
                <asp:TextBox ID="tb_Topic_ID" runat="server" ReadOnly="True" CssClass="form-control"></asp:TextBox>

            </div>

            <div class="form-group">
                Topic Title
                <asp:TextBox ID="tb_Topic_Title" runat="server" placeholder="Enter Topic Title" CssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfv_Topic_Title" runat="server" ControlToValidate="tb_Topic_Title" ErrorMessage="Please enter your Topic Title" ForeColor="Red"></asp:RequiredFieldValidator>

            </div>

            <div class="form-group">
                <div class="d-flex flex-row justify-content-between">
                    <asp:Button ID="btn_Return" runat="server" CausesValidation="False" OnClick="btn_Return_Click" Text="Return to Courses" CssClass="btn btn-danger" />
                    <asp:Button ID="btn_Insert" runat="server" Text="Add New Topic" OnClick="btn_Insert_Click" CssClass="btn btn-success" />
                </div>
            </div>

            <div class="form-group">
            </div>
        </div>

    </div>
</asp:Content>

