<%@ Page Language="C#" MasterPageFile="~/Static/Master/Admin/Dashboard.master" AutoEventWireup="true" CodeFile="Application.aspx.cs" Inherits="Web_Admin_Teacher_Application" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitlePlaceHolder" runat="Server">
    Application
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="HeadPlaceHolder" runat="Server">
    <style>
        #teachers_btn {
            color: white;
        }
    </style>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="BodyPlaceHolder" runat="Server">
    <div class="container">
        <h1 class="text-white mb-4 p-2">Viewing <asp:Label ID="Title" runat="server" Text="Application"></asp:Label></h1>

        <div class="row b-white p-3">
            <div class="col-lg-6">
                <div class="form-group">
                    <asp:Label ID="lbl_Name" Text="Applicant's  Name" runat="server"></asp:Label>
                    <asp:TextBox ID="tb_Name" runat="server" CssClass="form-control" Enabled="False"></asp:TextBox>
                </div>

                <div class="form-group">
                    <asp:Label ID="lbl_Email" Text="Applicant's Email" runat="server"></asp:Label>
                    <asp:TextBox ID="tb_Email" runat="server" CssClass="form-control" Enabled="False"></asp:TextBox>
                </div>

                <div class="form-group">
                    <asp:Label ID="lbl_Login_ID" Text="Login ID" runat="server"></asp:Label>
                    <asp:TextBox ID="tb_Login_ID_Text" runat="server" CssClass="form-control" Enabled="False"></asp:TextBox>
                </div>

                <div class="form-group">
                    <asp:Label ID="lbl_Creation_Date" Text="Date Applied" runat="server"></asp:Label>
                    <asp:TextBox ID="tb_Creation_Date" runat="server" CssClass="form-control" Enabled="False"></asp:TextBox>
                </div>
            </div>



            <div class="col-lg-6">

                <asp:Label ID="lbl_Certification" Text="Certification" runat="server"></asp:Label>


                <div class="form-group">
                    <button type="button" class="btn btn-primary" data-toggle="modal" data-target="#exampleModal1">
                        View certification
                    </button>

                    <!-- Modal -->
                    <div class="modal fade" id="exampleModal1" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
                        <div class="modal-dialog" role="document">
                            <div class="modal-content">
                                <asp:Image ID="Certification" runat="server" />
                            </div>
                        </div>
                    </div>
                </div>

                <asp:Label ID="lbl_Identification" Text="Identification" runat="server"></asp:Label>

                <div class="form-group">


                    <button type="button" class="btn btn-primary" data-toggle="modal" data-target="#exampleModal2">
                        View Identification
                    </button>

                    <!-- Modal -->
                    <div class="modal fade" id="exampleModal2" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
                        <div class="modal-dialog" role="document">
                            <div class="modal-content">
                                <asp:Image ID="Identification" runat="server" />

                            </div>
                        </div>
                    </div>
                </div>

            </div>
        </div>

        <div class="row  b-white p-3">
            <div class="col-lg-12">
                <div class="d-flex justify-content-between">

                    <div class="p-2 p-0">
                        <asp:Button ID="btn_Back" runat="server" Text="Go Back to View" OnClick="btn_Back_Click" CssClass="btn btn-success" CausesValidation="False"/>
                    </div>

                    <div class="p-2 p-0">

                        <!-- Button trigger modal -->
                        <button type="button" class="btn btn-danger" data-toggle="modal" data-target="#exampleModal" runat="server" id="modal">
                            Approve Teacher
                        </button>

                        <!-- Modal -->
                        <div class="modal fade" id="exampleModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
                            <div class="modal-dialog" role="document">
                                <div class="modal-content">
                                    <div class="modal-header">
                                        <h5 class="modal-title" id="exampleModalLabel">Create Login ID for Teacher</h5>
                                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                            <span aria-hidden="true">&times;</span>
                                        </button>
                                    </div>
                                    <div class="modal-body">
                                        <p class="text-danger text-center font-weight-bold">ONCE LOGIN ID IS CREATED, THE ACTION IS IRREVERSIBLE </p>

                                        <div class="form-group">
                                            <asp:TextBox ID="tb_Login_ID" runat="server" CssClass="form-control" pattern=".{8,}" placeholder="Teacher's Login ID"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="rfv1" runat="server" ErrorMessage="Login ID Required" ControlToValidate="tb_Login_ID" CssClass="invalid-feedback" Display="Dynamic" Font-Size="Medium"></asp:RequiredFieldValidator>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Invalid username format, no spaces or special characters allowed" Display="Dynamic" CssClass="invalid-feedback" ControlToValidate="tb_Login_ID" Font-Size="Medium" ValidationExpression="^[a-zA-Z0-9_]*$"></asp:RegularExpressionValidator>
                                            <small>Username has to be at least 8 characters</small>
                                        </div>

                                    </div>
                                    <div class="modal-footer">
                                        <button type="button" class="btn btn-success" data-dismiss="modal">Close</button>
                                        <asp:Button ID="btn_Submit" runat="server" Text="Approve Teacher" OnClick="btn_Submit_Click" CssClass="btn btn-danger" CausesValidation="True" />
                                    </div>
                                </div>
                            </div>
                        </div>

                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

