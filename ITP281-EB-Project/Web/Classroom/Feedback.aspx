<%@ Page Title="" Language="C#" MasterPageFile="~/Static/Master/User/Template.master" AutoEventWireup="true" CodeFile="Feedback.aspx.cs" Inherits="Web_Classroom_Feedback" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitlePlaceHolder" runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="HeadPlaceHolder" runat="Server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="BodyPlaceHolder" runat="Server">
    <div class="container">

        <h2>Feedback</h2>
        <p>Course ID</p>
        <p>
            <asp:TextBox ID="tb_Feedback_ID" runat="server"></asp:TextBox>
        </p>

        <p>Rating for the course:</p>
        <p>&nbsp;<asp:TextBox ID="tb_Rating" runat="server"></asp:TextBox></p>
        <p>Feedback:</p>
        <p>
            <asp:TextBox ID="tb_Feedback" runat="server"></asp:TextBox>
        </p>
        <p>
            <asp:Button ID="btn_Submit" runat="server" OnClick="btn_Submit_Click" Text="Submit" />
        </p>


    </div>
</asp:Content>

