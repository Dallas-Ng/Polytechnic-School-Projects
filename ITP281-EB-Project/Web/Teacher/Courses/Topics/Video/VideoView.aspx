<%@ Page Title="" Language="C#" MasterPageFile="~/Static/Master/Teacher/Dashboard.master" AutoEventWireup="true" CodeFile="VideoView.aspx.cs" Inherits="Web_Teacher_Courses_Topics_Video_VideoView" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitlePlaceHolder" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="HeadPlaceHolder" runat="Server">
    <style>
        #Video {
            width: 100vw;
            height: 100%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="BodyPlaceHolder" runat="Server">

    <div class="row justify-content-center mx-0" style="margin-top: 4rem;">
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
                <video id="Video" runat="server" controls="controls">
                    <source src="/Videos/" type="video/mp4" />
                </video>

            </div>

            <div class="form-group">
                <asp:Button ID="btn_back" runat="server" OnClick="btn_Return_Click" Text="Go Back" CssClass="btn btn-danger" />
            </div>
        </div>
    </div>
</asp:Content>

