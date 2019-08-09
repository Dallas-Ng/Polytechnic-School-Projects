<%@ Page Title="" Language="C#" MasterPageFile="~/Static/Master/User/Template.master" AutoEventWireup="true" CodeFile="TopicsView.aspx.cs" Inherits="Web_Classroom_Topics_TopicsView" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitlePlaceHolder" runat="Server">
    Courses
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
        </div>

        <div class="col-lg-7 col-sm-10">
            <div class="container my-2">
                <h2>Slides </h2>
                <div class="table-responsive">
                    <asp:GridView ID="gvSlides" CssClass="table table-striped table-bordered table-condensed" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="gvSlides_SelectedIndexChanged" DataKeyNames="Slides_ID" AllowPaging="True" OnPageIndexChanging="gvSlides_PageIndexChanging">
                        <Columns>
                            <asp:BoundField DataField="Slides_ID" HeaderText="Slides_ID" />
                            <asp:BoundField DataField="Topic_ID" HeaderText="Topics_ID" />
                            <asp:BoundField DataField="Slides_Upload_Date" HeaderText="Slides_Upload_Date" />
                            <asp:CommandField ShowSelectButton="True" />
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
            <div class="container my-2">
                <h2>Videos </h2>
                <div class="table-responsive">
                    <asp:GridView ID="gvVideo" CssClass="table table-striped table-bordered table-condensed" runat="server" AutoGenerateColumns="False" DataKeyNames="Video_ID" OnSelectedIndexChanged="gvVideo_SelectedIndexChanged" AllowPaging="True" OnPageIndexChanging="gvVideo_PageIndexChanging">
                        <Columns>
                            <asp:BoundField DataField="Video_ID" HeaderText="Video_ID" />
                            <asp:BoundField DataField="Topic_ID" HeaderText="Topic_ID" />
                            <asp:BoundField DataField="Video_Upload_Date" HeaderText="Video_Upload_Date" />
                            <asp:CommandField ShowSelectButton="True" />
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </div>
    </div>

</asp:Content>

