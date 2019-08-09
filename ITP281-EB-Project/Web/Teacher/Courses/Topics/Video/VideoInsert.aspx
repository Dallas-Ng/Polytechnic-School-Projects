<%@ Page Title="" Language="C#" MasterPageFile="~/Static/Master/Teacher/Dashboard.master" AutoEventWireup="true" CodeFile="VideoInsert.aspx.cs" Inherits="Web_Teacher_Courses_Topics_Video_VideoInsert" %>

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
        <div class="col-lg-3 col-sm-10 ">
            <h1>Upload your Videos</h1>

            <div class="form-group">
                Topic ID: 
                <asp:TextBox ID="tb_Topic_ID" runat="server" ReadOnly="True" CssClass="form-control"></asp:TextBox>

            </div>

            <div class="form-group">
                Upload your file<br />

                <asp:FileUpload ID="FileUpload_Video" runat="server" />
                <asp:RequiredFieldValidator ID="rfv_Upload_Video" runat="server" ControlToValidate="FileUpload_Video" ErrorMessage="Please Select your file" ForeColor="Red"></asp:RequiredFieldValidator>

            </div>

            <div class="form-group">
                <asp:Button ID="btn_Upload" runat="server" OnClick="btn_Upload_Click" Text="Upload" CssClass="btn btn-success"/>
                <asp:Button ID="btn_VideoView" runat="server" OnClick="btn_VideoView_Click" Text="Back to topic" CausesValidation="False" CssClass="btn btn-danger"/>
            </div>

        </div>

        <div class="col-lg-7 col-sm-10">
            <div class="container my-2">
                <h2>Videos </h2>
                <div class="table-responsive">
                    <asp:GridView ID="gvVideo" CssClass="table table-striped table-bordered table-condensed" runat="server" ShowHeaderWhenEmpty="true" AutoGenerateColumns="False" DataKeyNames="Video_ID" OnSelectedIndexChanged="gvVideo_SelectedIndexChanged" OnRowDeleting="gvVideo_RowDeleting" AllowPaging="True" OnPageIndexChanging="gvVideo_PageIndexChanging">
                        <Columns>
                            <asp:BoundField DataField="Video_ID" HeaderText="Video_ID" />
                            <asp:BoundField DataField="Topic_ID" HeaderText="Topic_ID" />
                            <asp:BoundField DataField="Video_Upload_Date" HeaderText="Video_Upload_Date" />
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

