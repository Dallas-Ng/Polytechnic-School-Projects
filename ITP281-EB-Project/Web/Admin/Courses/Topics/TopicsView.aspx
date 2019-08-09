<%@ Page Title="" Language="C#" MasterPageFile="~/Static/Master/Admin/Dashboard.master" AutoEventWireup="true" CodeFile="TopicsView.aspx.cs" Inherits="Web_Admin_Courses_Topics_TopicView" %>

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

    <div class="row justify-content-center mx-0 my-2">
        <div class="col-lg-3 col-sm-10 whiteout text-white">
            <h1>Viewing Topic                
                <asp:Label ID="lbl_Topic_ID" runat="server" Text="lbl_Topic_ID"></asp:Label>
            </h1>

            <div class="form-group">
                Topic title: 
                <asp:Label ID="lbl_Topic_Title" runat="server" Text="lbl_Topic_Title"></asp:Label>

            </div>

            <div class="form-group">
                Topic upload date: 
                <asp:Label ID="lbl_Topic_Upload_Date" runat="server" Text="lbl_Topic_Upload_Date"></asp:Label>
            </div>

            <div class="form-group">
                <asp:Button ID="btn_return" runat="server" Text="Go back" OnClick="btn_return_Click" CssClass="btn btn-danger" />
            </div>
        </div>

        <div class="col-lg-7 col-sm-10 b-white">
            <div class="container my-2">
                <h2>Slides </h2>
                <asp:GridView ID="gvSlides" CssClass="table table-striped table-bordered table-condensed" runat="server" ShowHeaderWhenEmpty="true" AutoGenerateColumns="False" OnSelectedIndexChanged="gvSlides_SelectedIndexChanged" OnRowDeleting="gvSlides_RowDeleting" DataKeyNames="Slides_ID" AllowPaging="True" OnPageIndexChanging="gvSlides_PageIndexChanging">
                    <Columns>
                        <asp:BoundField DataField="Slides_ID" HeaderText="Slides_ID" />
                        <asp:BoundField DataField="Slides_Upload_Date" HeaderText="Slides_Upload_Date" />
                        <asp:CommandField  ShowSelectButton="True" SelectText="View" ItemStyle-Width="10%" ItemStyle-HorizontalAlign="Center" />
                    </Columns>
                </asp:GridView>
            </div>
            <div class="container my-2">
                <h2>Videos </h2>
                <asp:GridView ID="gvVideo" CssClass="table table-striped table-bordered table-condensed" runat="server" ShowHeaderWhenEmpty="true" AutoGenerateColumns="False" DataKeyNames="Video_ID" OnSelectedIndexChanged="gvVideo_SelectedIndexChanged" OnRowDeleting="gvVideo_RowDeleting" AllowPaging="True" OnPageIndexChanging="gvVideo_PageIndexChanging">
                    <Columns>
                        <asp:BoundField DataField="Video_ID" HeaderText="Video_ID" />
                        <asp:BoundField DataField="Video_Upload_Date" HeaderText="Video_Upload_Date" />
                        <asp:CommandField ShowSelectButton="True" SelectText="View" ItemStyle-Width="10%" ItemStyle-HorizontalAlign="Center"/>
                    </Columns>
                </asp:GridView>
            </div>

            <div class="container my-2">
                <h2>Quizes </h2>
                <asp:GridView ID="gvQuiz" CssClass="table table-striped table-bordered table-condensed" runat="server" ShowHeaderWhenEmpty="true" AutoGenerateColumns="False" DataKeyNames="Quiz_ID" OnRowDeleting="gvQuiz_RowDeleting" OnRowCancelingEdit="gvQuiz_RowCancelingEdit" OnRowEditing="gvQuiz_RowEditing" OnRowUpdating="gvQuiz_RowUpdating" OnSelectedIndexChanged="gvQuiz_SelectedIndexChanged" AllowPaging="True" OnPageIndexChanging="gvQuiz_PageIndexChanging">
                    <Columns>
                        <asp:BoundField DataField="Quiz_ID" HeaderText="Quiz ID" />
                        <asp:CommandField ShowSelectButton="True" SelectText="View" ItemStyle-Width="10%" ItemStyle-HorizontalAlign="Center"/>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>

</asp:Content>

