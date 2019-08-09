<%@ Page Title="" Language="C#" MasterPageFile="~/Static/Master/Teacher/Dashboard.master" AutoEventWireup="true" CodeFile="QuizView.aspx.cs" Inherits="Web_Teacher_Courses_Topics_Quiz_QuizView" %>

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
    <div class="table-responsive">
        <asp:GridView ID="gvQuiz" runat="server" AutoGenerateColumns="False" DataKeyNames="Quiz_ID" OnRowDeleting="gvQuiz_RowDeleting" OnRowCancelingEdit="gvQuiz_RowCancelingEdit" OnRowEditing="gvQuiz_RowEditing" OnRowUpdating="gvQuiz_RowUpdating" OnSelectedIndexChanged="gvQuiz_SelectedIndexChanged" AllowPaging="True" OnPageIndexChanging="gvQuiz_PageIndexChanging">
            <Columns>
                <asp:BoundField DataField="Quiz_ID" HeaderText="Quiz ID" />
                <asp:BoundField DataField="Topic_ID" HeaderText="Topic ID" ReadOnly="True" />
                <asp:CommandField ShowDeleteButton="True" ShowSelectButton="True" SelectText="View Details/Insert Question" />
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>

