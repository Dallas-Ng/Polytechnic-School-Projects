<%@ Page Title="" Language="C#" MasterPageFile="~/Static/Master/Teacher/Dashboard.master" AutoEventWireup="true" CodeFile="CoursesInsert.aspx.cs" Inherits="Web_Teacher_Courses_CoursesInsert" %>

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
            <h1>Add a new Course </h1>

            <div class="form-group">
                <asp:Label ID="tb_Course_ID" runat="server" />
            </div>

            <hr />

            <div class="form-group">
                <label>Course Title</label>
                <asp:TextBox ID="tb_Course_Title" placeholder="Enter Course Title" runat="server" CssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfv_Course_Title" runat="server" ControlToValidate="tb_Course_Title" ErrorMessage="Please enter your Course Title" ForeColor="Red"></asp:RequiredFieldValidator>

            </div>

            <div class="form-group">
                Pick a subject
                <br />
                <asp:DropDownList ID="ddl_Course_Subject" runat="server" CssClass="form-control">
                    <asp:ListItem Value="0">Please select</asp:ListItem>
                    <asp:ListItem>Math</asp:ListItem>
                    <asp:ListItem>English</asp:ListItem>
                    <asp:ListItem>Science</asp:ListItem>
                    <asp:ListItem>Geography</asp:ListItem>
                </asp:DropDownList>

                <asp:RequiredFieldValidator ID="rfv_Course_Subject" runat="server" ControlToValidate="ddl_Course_Subject" ErrorMessage="Please Choose Your Subject of Course" ForeColor="Red" InitialValue="0"></asp:RequiredFieldValidator>
            </div>

            <div class="form-group">
                <label>Please enter a small description of what you are offering</label>
                <asp:TextBox ID="tb_Course_Desc" runat="server" Height="125px" TextMode="MultiLine" placeholder="Enter Course Descripton" CssClass="form-control"></asp:TextBox>

            </div>

            <div class="form-group">
                <label>What is your preferred course fee ($SGD)</label>
                <asp:TextBox ID="tb_Course_Fee" runat="server" TextMode="Number" min="10" placeholder="Choose Your Prefered Course fee" Width="278px" CssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfv_Course_Fee" runat="server" ControlToValidate="tb_Course_Fee" ErrorMessage="Please Enter your desired Course fee $" ForeColor="Red"></asp:RequiredFieldValidator>

            </div>

            <div class="form-group">
                <div class="d-flex flex-row">
                    <asp:Button ID="Btn_View_Course" runat="server" OnClick="Btn_View_Course_Click" Text="Go Back" CssClass="btn btn-danger " CausesValidation="False" Style="width: 150px;" />

                    <asp:Button ID="btn_Insert" runat="server" OnClick="btn_Insert_Click" Text="Insert" CssClass="btn btn-success ml-auto" Style="width: 150px;" />
                </div>
            </div>
        </div>
    </div>


</asp:Content>

