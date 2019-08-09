<%@ Page Title="" Language="C#" MasterPageFile="~/Static/Master/Admin/Dashboard.master" AutoEventWireup="true" CodeFile="User.aspx.cs" Inherits="Web_Admin_Users_User" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitlePlaceHolder" runat="Server">
    View User
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="HeadPlaceHolder" runat="Server">
    <style>
        #lbtn_Users {
            color: white;
        }
    </style>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="BodyPlaceHolder" runat="Server">
    <div class="container">
        <h1 class="text-white mb-4 p-2">Viewing User </h1>

        <div class="row b-white p-3">
            <div class="col-lg-6">

                <div class="form-group">
                    <asp:Label ID="lbl_Login_ID" Text="Login ID" runat="server"></asp:Label>
                    <asp:TextBox ID="tb_Login_ID" runat="server" CssClass="form-control" Enabled="False"></asp:TextBox>
                </div>

                <div class="form-group">
                    <asp:Label ID="lbl_Email" Text="Email" runat="server"></asp:Label>
                    <asp:TextBox ID="tb_Email" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>

                    <div class="valid-feedback" id="valid" runat="server">
                        Email is validated!
                    </div>

                    <div class="invalid-feedback" id="invalid" runat="server">
                        Email has not been validated!
                    </div>

                </div>

                <div class="form-group">
                    <asp:Label ID="lbl_Recent_Login" Text="Recent Login" runat="server"></asp:Label>
                    <asp:TextBox ID="tb_Recent_Login" runat="server" CssClass="form-control" Enabled="False" Placeholder="Auto Generated"></asp:TextBox>
                </div>

                <div class="form-group">
                    <asp:Label ID="lbl_Creation_Date" Text="Creation Date" runat="server"></asp:Label>
                    <asp:TextBox ID="tb_Creation_Date" runat="server" CssClass="form-control" Enabled="False" Placeholder="Auto Generated"></asp:TextBox>
                </div>

                <div class="form-group">
                    <asp:Label ID="lbl_Profile" Text="Profile Url" runat="server"></asp:Label>
                    <asp:TextBox ID="tb_Profile" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                </div>
            </div>

            <div class="col-lg-6">

                <div class="form-group">
                    <asp:Label ID="lbl_Name" Text="Name" runat="server"></asp:Label>
                    <asp:TextBox ID="tb_Name" runat="server" CssClass="form-control"></asp:TextBox>
                </div>

                <div class="form-group">
                    <asp:Label ID="lbl_DateofBirth" Text="Date of Birth" runat="server"></asp:Label>
                    <asp:TextBox ID="tb_DateofBirth" runat="server" CssClass="form-control"></asp:TextBox>
                </div>

                <div class="form-group">
                    <asp:Label ID="lbl_Role" Text="Role" runat="server"></asp:Label>
                    <asp:DropDownList ID="ddl_Role" runat="server" CssClass="custom-select">
                        <asp:ListItem Selected="True" Hidden="True">Select an Option</asp:ListItem>
                        <asp:ListItem Value="admin">Admin</asp:ListItem>
                        <asp:ListItem Value="student">Student</asp:ListItem>
                        <asp:ListItem Value="teacher">Teacher</asp:ListItem>
                    </asp:DropDownList>
                </div>

                <div class="form-group">

                    <div class="d-flex justify-content-between">
                        <div class="p-2" style="padding-left: 0 !important;">
                            <asp:Button ID="btn_Payment" runat="server" Text="View Payment Settings" OnClick="btn_Payment_Click" CssClass="btn btn-outline-info" CausesValidation="false" />
                        </div>

                        <div class="p-2" style="padding-right: 0 !important;">
                            <asp:Button ID="btn_Courses" runat="server" Text="View Courses" OnClick="btn_Courses_Click" CssClass="btn btn-outline-success" CausesValidation="false" />
                        </div>

                    </div>

                    <div class="form-group mt-3">
                        <button type="button" class="btn btn-outline-danger" data-toggle="modal" data-target="#exampleModal" id="delete_button" runat="server">
                            Deactivate Account
                        </button>

                        <div class="modal fade" id="exampleModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
                            <div class="modal-dialog" role="document">
                                <div class="modal-content">

                                    <div class="modal-header">
                                        <h5 class="modal-title" id="exampleModalLabel">Are you sure?</h5>
                                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                            <span aria-hidden="true">&times;</span>
                                        </button>
                                    </div>

                                    <div class="modal-body">
                                        <strong style='color: rgb(211, 50, 50);'>AS A ADMIN, YOU HAVE A RESPONSIBILITY TO MAKE SURE THAT THIS ACCOUNT IS NOT BEING USED ANYMORE. 
                                            <br />
                                            ANY ACTIONS CAN BE TAKEN AGAINST YOU IF THIS IS VIOLATED.</strong>
                                    </div>

                                    <div class="modal-footer">
                                        <asp:Button ID="btn_Delete" runat="server" OnClick="btn_Delete_Click" Text="DEACTIVATE ACCOUNT" class="btn btn-secondary" data-toggle="modal" data-target="#exampleModal" />
                                        <button type="button" class="btn btn-primary" data-dismiss="modal">Close</button>
                                    </div>

                                </div>
                            </div>
                        </div>

                        <button type="button" class="btn btn-outline-danger" data-toggle="modal" data-target="#exampleModal1" id="activate_button" runat="server">
                            Reactivate Account                       
                        </button>

                        <div class="modal fade" id="exampleModal1" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
                            <div class="modal-dialog" role="document">
                                <div class="modal-content">

                                    <div class="modal-header">
                                        <h5 class="modal-title" id="exampleModalLabel1">Are you sure?</h5>
                                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                            <span aria-hidden="true">&times;</span>
                                        </button>
                                    </div>

                                    <div class="modal-body">
                                        Reactivate Account?
                                    </div>

                                    <div class="modal-footer">
                                        <asp:Button ID="Button1" runat="server" OnClick="btn_Reactivate_Click" Text="Activate Account" class="btn btn-secondary" data-toggle="modal" data-target="#exampleModal" />
                                        <button type="button" class="btn btn-primary" data-dismiss="modal">Close</button>
                                    </div>

                                </div>
                            </div>
                        </div>
                    </div>

                </div>
            </div>
        </div>

        <div class="row b-white p-3">
            <div class="col-lg-12">
                <div class="d-flex justify-content-between">
                    <div class="p-2 p-0">
                        <asp:Button ID="btn_Back" runat="server" Text="Go Back to View" OnClick="btn_Back_Click" CssClass="btn btn-primary" CausesValidation="False" />
                    </div>

                    <div class="p-2 p-0">
                        <asp:Button ID="btn_Submit" runat="server" Text="Make Changes" OnClick="btn_Submit_Click" CssClass="btn btn-warning" CausesValidation="False" />
                    </div>
                </div>
            </div>

        </div>
    </div>

</asp:Content>

