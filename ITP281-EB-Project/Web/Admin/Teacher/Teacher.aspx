<%@ Page Title="" Language="C#" MasterPageFile="~/Static/Master/Admin/Dashboard.master" AutoEventWireup="true" CodeFile="Teacher.aspx.cs" Inherits="Web_Admin_Teacher_Teacher" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitlePlaceHolder" runat="Server">
    Teacher
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
        <h1 class="text-white mb-4 p-2">Viewing Teacher</h1>

        <div class="row b-white p-3">
            <div class="col-lg-6">
                <div class="form-group">
                    <asp:Label ID="lbl_Name" Text="Teacher's Name" runat="server"></asp:Label>
                    <asp:TextBox ID="tb_Name" runat="server" CssClass="form-control" Enabled="False"></asp:TextBox>
                </div>

                <div class="form-group">
                    <asp:Label ID="lbl_Email" Text="Email" runat="server"></asp:Label>
                    <asp:TextBox ID="tb_Email" runat="server" CssClass="form-control" Enabled="False"></asp:TextBox>
                </div>

                <div class="form-group">
                    <asp:Label ID="lbl_Phone" Text="Login ID" runat="server"></asp:Label>
                    <asp:TextBox ID="tb_Phone" runat="server" CssClass="form-control" Enabled="False"></asp:TextBox>
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

                <div class="form-group">
                    <asp:Label ID="lbl_Courses" Text="View courses by Teacher" runat="server"></asp:Label><br />
                    <asp:Button ID="btn_Courses" runat="server" CssClass="btn btn-info" Text="Courses" OnClick="btn_Courses_Click" Style="max-width: 10vw;" />
                </div>
            </div>
        </div>

        <div class="row b-white p-3">
            <div class="col">
                <asp:Button ID="btn_Back" runat="server" Text="Go Back to View" OnClick="btn_Back_Click" CssClass="btn btn-warning" CausesValidation="False" />
            </div>
        </div>
    </div>
</asp:Content>

