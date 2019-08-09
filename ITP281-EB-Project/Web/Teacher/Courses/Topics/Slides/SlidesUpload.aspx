<%@ Page Title="" Language="C#" MasterPageFile="~/Static/Master/Teacher/Dashboard.master" AutoEventWireup="true" CodeFile="SlidesUpload.aspx.cs" Inherits="Web_Teacher_Courses_Topics_Slides_SlidesUpload" %>

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
            <h1>Upload your slides</h1>

            <div class="form-group">
                Topic ID: 
                <asp:TextBox ID="tb_Topic_ID" runat="server" ReadOnly="True" CssClass="form-control"></asp:TextBox>

            </div>

            <div class="form-group">
                Slide Pages
                <asp:TextBox ID="tb_Slides_Pages" runat="server" placeholder="Enter Your Total Slides" CssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfv_Slides_Pages" runat="server" ControlToValidate="tb_Slides_Pages" ErrorMessage="Please Enter the Number of Pages" ForeColor="Red"></asp:RequiredFieldValidator>
            </div>

            <div class="form-group">
                Upload your file<br />
                <asp:FileUpload ID="fileUploadSlides" runat="server" />
                <asp:RequiredFieldValidator ID="rfv_Slides_Upload" runat="server" ControlToValidate="fileUploadSlides" ErrorMessage="Please Choose your Pdf Slides to be Uploaded" ForeColor="Red"></asp:RequiredFieldValidator>

            </div>

            <div class="form-group">
                <asp:Button ID="btnExtractZipFiles" runat="server"
                    OnClick="btnExtractZipFiles_Click" Text="Upload Slides" CssClass="btn btn-success"/>

                <asp:Button ID="btn_Back" runat="server" CssClass="btn btn-danger" OnClick="btn_Back_Click" CausesValidation="false" Text="Back to topic"/>
            </div>
        </div>


        <div class="col-lg-7 col-sm-10">
            <div class="container my-2">
                <h2>Slides </h2>
                <div class="table-responsive">
                    <asp:GridView ID="gvSlides" CssClass="table table-striped table-bordered table-condensed" runat="server" ShowHeaderWhenEmpty="true" AutoGenerateColumns="False" OnSelectedIndexChanged="gvSlides_SelectedIndexChanged" OnRowDeleting="gvSlides_RowDeleting" DataKeyNames="Slides_ID" AllowPaging="True" OnPageIndexChanging="gvSlides_PageIndexChanging">
                        <Columns>
                            <asp:BoundField DataField="Slides_ID" HeaderText="Slides_ID" />
                            <asp:BoundField DataField="Topic_ID" HeaderText="Topics_ID" />
                            <asp:BoundField DataField="Slides_Upload_Date" HeaderText="Slides_Upload_Date" />
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </div>
    </div>

</asp:Content>

