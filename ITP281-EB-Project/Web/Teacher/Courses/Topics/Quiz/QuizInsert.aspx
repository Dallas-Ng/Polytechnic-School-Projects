<%@ Page Title="" Language="C#" MasterPageFile="~/Static/Master/Teacher/Dashboard.master" AutoEventWireup="true" CodeFile="QuizInsert.aspx.cs" Inherits="Web_Teacher_Courses_Topics_Quiz_QuizInsert" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitlePlaceHolder" runat="Server">
    Courses
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="HeadPlaceHolder" runat="Server">
    <style>
        #lbtn_Courses{
            color: white;
        }
    </style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="BodyPlaceHolder" runat="Server">

    <div class="row mx-0 justify-content-center" style="margin-top: 5rem;">
        <div class="col-lg-6 col-sm-10 ">
            <div class="d-flex flex-wrap flex-row justify-content-between">
                <h1>Quiz</h1>
                <asp:Button runat="server" ID="btn_InsertClear" Text="Add new question" CssClass="btn btn-success" Height="40px" OnClick="btn_InsertClear_Click" />
            </div>
            <div class="table-responsive">
                <asp:GridView ID="gvQuestion" CssClass="table table-striped table-bordered table-condensed" runat="server" ShowHeaderWhenEmpty="true" AutoGenerateColumns="False" DataKeyNames="id" OnRowDeleting="gvQuestion_RowDeleting" OnSelectedIndexChanged="gvQuestion_SelectedIndexChanged" AllowPaging="True" OnPageIndexChanging="gvQuestion_PageIndexChanging">
                    <Columns>
                        <asp:BoundField DataField="ID" HeaderText="ID" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
                        <asp:BoundField DataField="Question_Number" HeaderText="Quiz_ID" />
                        <asp:BoundField DataField="Question" HeaderText="Question" />
                        <asp:BoundField DataField="Answer" HeaderText="Answer" />
                        <asp:CommandField ShowDeleteButton="True" ShowSelectButton="true" SelectText="View" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="10%" />
                    </Columns>
                    <PagerSettings FirstPageText="First" LastPageText="Last" Mode="NumericFirstLast" PageButtonCount="4" />
                </asp:GridView>
            </div>

            <asp:Button ID="btn_Back" CssClass="btn btn-danger" runat="server" OnClick="btn_return_Click" Text="Go Back" CausesValidation="false"/>

        </div>

        <div class="col-lg-4 col-sm-10">
            <h2>Question
                <asp:Label ID="lbl_ID" runat="server" Text=""></asp:Label></h2>

            <div class="form-group">
                Question Number
                <asp:TextBox ID="tb_Question_Number" runat="server" CssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfv_Question_Number" runat="server" ControlToValidate="tb_Question_Number" ErrorMessage="Please enter a Question Number" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
            </div>


            <div class="form-group">
                Question
                <asp:TextBox ID="tb_Question" runat="server" CssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfv_Question" runat="server" ControlToValidate="tb_Question" ErrorMessage="Please Enter your Question" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
            </div>


            <div class="form-group">
                Answer
                <asp:TextBox ID="tb_Answer" runat="server" CssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfv_Answer" runat="server" ControlToValidate="tb_Answer" ErrorMessage="Please enter your Answer" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
            </div>


            <div class="form-group">
                Choice #1
                <asp:TextBox ID="tb_Choice1" runat="server" CssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfv_Choice_1" runat="server" ControlToValidate="tb_Choice1" ErrorMessage="Please enter your Choice " ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
            </div>


            <div class="form-group">
                Choice #2
                <asp:TextBox ID="tb_Choice2" runat="server" CssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfv_Choice_2" runat="server" ControlToValidate="tb_Choice2" ErrorMessage="Please enter your Choice " ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
            </div>


            <div class="form-group">
                Choice #3
                <asp:TextBox ID="tb_Choice3" runat="server" CssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfv_Choice_3" runat="server" ControlToValidate="tb_Choice3" ErrorMessage="Please Enter your Choice" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
            </div>


            <div class="form-group">
                Choice #4
                <asp:TextBox ID="tb_Choice4" runat="server" CssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfv_Choice_4" runat="server" ControlToValidate="tb_Choice4" ErrorMessage="Please Enter your Choice" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
            </div>


            <div class="form-group">
                <asp:Button ID="btn_Insert" runat="server" OnClick="btn_Insert_Click" Text="Create Question" CssClass="btn btn-success" />
                <asp:Button ID="btn_Update" runat="server" OnClick="btn_Update_click" Text="Update Current Question" CssClass="btn btn-warning" />

            </div>
        </div>
    </div>
</asp:Content>

