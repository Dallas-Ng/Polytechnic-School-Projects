<%@ Page Title="" Language="C#" MasterPageFile="~/Static/Master/Admin/Dashboard.master" AutoEventWireup="true" CodeFile="SlidesDetails.aspx.cs" Inherits="Web_Admin_Courses_Topics_Slides_SlidesDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitlePlaceHolder" runat="Server">
    Courses
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="HeadPlaceHolder" runat="Server">
    <style>
        .responsive-object embed {
            position: absolute;
            top: 0;
            left: 0;
            width: 100%;
            height: 100%;
        }

        .responsive-object {
            position: relative;
            padding-bottom: 67.5%;
            height: 0;
            margin: 10px 0;
            overflow: hidden;
        }

        #lbtn_Courses {
            color: white;
        }
    </style>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="BodyPlaceHolder" runat="Server">

    <div class="row justify-content-center mx-0">
        <div class="col-lg-3 col-sm-10 b-white">
            <h1>Slide Details</h1>
            <div class="form-group">
                Topic ID: 
                <asp:Label ID="lbl_Topic_ID" runat="server" Text="lbl_Topic_ID"></asp:Label>
            </div>

            <div class="form-group">
                Slides ID: 
                <asp:Label ID="lbl_Slides_ID" runat="server" Text="lbl_Slides_ID"></asp:Label>

            </div>


            <div class="form-group">
                Slide pages: 
                <asp:Label ID="lbl_Slides_Pages" runat="server" Text="lbl_Slides_Pages"></asp:Label>

            </div>

            <div class="form-group">
                Slides Upload Date: 
                <asp:Label ID="lbl_Slides_Upload_Date" runat="server" Text="lbl_Slides_Upload_Date"></asp:Label>

            </div>


            <div class="form-group">
                <asp:Button ID="btn_back" runat="server" OnClick="btn_back_Click" Text="Go Back" CssClass="btn btn-danger" />
            </div>
        </div>

        <div class="col-lg-7 col-sm-10">
            <div class="responsive-object">
                <embed src="~/Files/" runat="server" id="Slides" />
            </div>
        </div>
    </div>

</asp:Content>

