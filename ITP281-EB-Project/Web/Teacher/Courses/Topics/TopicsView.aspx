<%@ Page Title="" Language="C#" MasterPageFile="~/Static/Master/Teacher/Dashboard.master" AutoEventWireup="true" CodeFile="TopicsView.aspx.cs" Inherits="Web_Teacher_Courses_Topics_TopicsView" %>

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

    <div class="row justify-content-center mx-0" style="margin-top: 5rem;">

        <div class="col-lg-3 col-sm-10">
            <h1>Viewing               
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
                <div class="d-flex flex-row flex-wrap">
                    <asp:Button ID="btn_Insert_Slides" runat="server" Text="Insert Slides" OnClick="btn_Insert_Slides_Click" CssClass="btn btn-warning mr-2" />
                    <asp:Button ID="btn_Insert_Video" runat="server" Text="Insert Video" OnClick="btn_Insert_Video_Click" CssClass="btn btn-info mr-2" />
                    <asp:Button ID="btn_Create_Quiz" runat="server" Text="Create Quiz" OnClick="btn_Create_Quiz_Click" CssClass="btn btn-success mr-2" />
                </div>
            </div>

            <div class="form-group">
                <asp:Button ID="btn_Back" CssClass="btn btn-danger" runat="server" OnClick="btn_return_Click" Text="Go Back"/>
            </div>
        </div>

        <div class="col-lg-7 col-sm-10">
            <div class="container my-2">
                <h2>Slides </h2>
                                <div class="table-responsive">

                <asp:GridView ID="gvSlides" CssClass="table table-striped table-bordered table-condensed" runat="server" ShowHeaderWhenEmpty="true" AutoGenerateColumns="False" OnSelectedIndexChanged="gvSlides_SelectedIndexChanged" OnRowDeleting="gvSlides_RowDeleting" DataKeyNames="Slides_ID" AllowPaging="True" OnPageIndexChanging="gvSlides_PageIndexChanging">
                    <Columns>
                        <asp:BoundField DataField="Slides_ID" HeaderText="Slides_ID" ItemStyle-Width="10%" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
                        <asp:BoundField DataField="Topic_ID" HeaderText="Topics_ID" />
                        <asp:BoundField DataField="Slides_Upload_Date" HeaderText="Slides_Upload_Date" />
                        <asp:CommandField ShowDeleteButton="True" ShowSelectButton="True" SelectText="View" ItemStyle-Width="15%" ItemStyle-HorizontalAlign="Center"/>
                    </Columns>
                </asp:GridView>
            </div>
            <div class="container my-2">
                <h2>Videos </h2>
                <div class="table-responsive">
                    <asp:GridView ID="gvVideo" CssClass="table table-striped table-bordered table-condensed" runat="server" ShowHeaderWhenEmpty="true" AutoGenerateColumns="False" DataKeyNames="Video_ID" OnSelectedIndexChanged="gvVideo_SelectedIndexChanged" OnRowDeleting="gvVideo_RowDeleting" AllowPaging="True" OnPageIndexChanging="gvVideo_PageIndexChanging">
                        <Columns>
                            <asp:BoundField DataField="Video_ID" HeaderText="Video_ID" ItemStyle-Width="10%" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center"/>
                            <asp:BoundField DataField="Topic_ID" HeaderText="Topic_ID" />
                            <asp:BoundField DataField="Video_Upload_Date" HeaderText="Video_Upload_Date" />
                            <asp:CommandField ShowSelectButton="True" ShowDeleteButton="True" SelectText="View" ItemStyle-Width="15%" ItemStyle-HorizontalAlign="Center"/>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>

            <div class="container my-2">
                <h2>Quizes </h2>
                <div class="table-responsive">
                    <asp:GridView ID="gvQuiz" CssClass="table table-striped table-bordered table-condensed" runat="server" ShowHeaderWhenEmpty="true" AutoGenerateColumns="False" DataKeyNames="Quiz_ID" OnRowDeleting="gvQuiz_RowDeleting" OnRowCancelingEdit="gvQuiz_RowCancelingEdit" OnRowEditing="gvQuiz_RowEditing" OnRowUpdating="gvQuiz_RowUpdating" OnSelectedIndexChanged="gvQuiz_SelectedIndexChanged" AllowPaging="True" OnPageIndexChanging="gvQuiz_PageIndexChanging">
                        <Columns>
                            <asp:BoundField DataField="Quiz_ID" HeaderText="Quiz ID" ItemStyle-Width="10%" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center"/>
                            <asp:BoundField DataField="Topic_ID" HeaderText="Topic ID" ReadOnly="True" />
                            <asp:CommandField ShowDeleteButton="True" ShowSelectButton="True" SelectText="View" ItemStyle-Width="15%" ItemStyle-HorizontalAlign="Center" />
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

