<%@ Page Title="" Language="C#" MasterPageFile="~/Static/Master/User/Template.master" AutoEventWireup="true" CodeFile="VideoView.aspx.cs" Inherits="Web_Classroom_Topics_VideoView" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitlePlaceHolder" runat="Server">
    Courses
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="HeadPlaceHolder" runat="Server">
    <style>
        #lbtn_MyCourses {
            color: black;
        }

        #Video {
            width: 100vw;
            height: 100%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="HeaderPlaceHolder" runat="Server">
    Courses
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="BodyPlaceHolder" runat="Server">

    <div class="row justify-content-center mx-0">
        <div class="col-lg-7 col-sm-10">
            <h1>Video Details</h1>
            <div class="form-group">
                Video ID: 
                    <asp:Label ID="lbl_Video_ID" runat="server" Text="lbl_Video_ID"></asp:Label>
            </div>

            <div class="form-group">
                Video Upload Date : 
                    <asp:Label ID="lbl_Video_Upload_Date" runat="server" Text="lbl_Video_Upload_Date"></asp:Label>

            </div>


            <div class="form-group">
                <video controls="controls">
                    <source id="Video" src="/Video/3_1.mp4" type="video/mp4" runat="server" />
                    <source id="Video2" src="movie.ogg" type="video/ogg" runat="server" />
                </video>

            </div>

            <div class="form-group">
                <asp:Button ID="btn_back" runat="server" OnClick="btn_Return_Click" Text="Go Back" CssClass="btn btn-danger" />
            </div>
        </div>
    </div>

</asp:Content>

