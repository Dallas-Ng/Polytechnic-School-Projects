<%@ Page Title="" Language="C#" MasterPageFile="~/Static/Master/Admin/Dashboard.master" AutoEventWireup="true" CodeFile="Add.aspx.cs" Inherits="Web_Admin_Account_Add" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitlePlaceHolder" runat="Server">
    Add User
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="HeadPlaceHolder" runat="Server">
    <style>
        #lbtn_Users {
            color: white;
        }
    </style>

    <script src="https://code.jquery.com/jquery-3.3.1.min.js"></script>
    <script src="https://unpkg.com/gijgo@1.9.13/js/gijgo.min.js" type="text/javascript"></script>
    <link href="https://unpkg.com/gijgo@1.9.13/css/gijgo.min.css" rel="stylesheet" type="text/css" />
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="BodyPlaceHolder" runat="Server">

    <div class="container">
        <h1 class="text-white mb-4 p-2">User Creation </h1>

        <div class="row b-white p-3">
            <div class="col-lg-6 col-sm-10">

                <div class="form-group">
                    <asp:Label ID="lbl_Login_ID" Text="Credentials" runat="server"></asp:Label>
                    <asp:TextBox ID="tb_Login_ID" runat="server" CssClass="form-control" required="required" placeholder="Login ID"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Invalid username format, no spaces or special characters allowed" Display="Dynamic" CssClass="invalid-feedback" ControlToValidate="tb_Login_ID" Font-Size="Medium" ValidationExpression="^[a-zA-Z0-9_]*$"></asp:RegularExpressionValidator>
                </div>

                <div class="form-group">
                    <asp:TextBox ID="tb_Name" runat="server" type="text" placeholder="Name" required="required" class="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Please enter a Name" ControlToValidate="tb_Name" CssClass="invalid-feedback"></asp:RequiredFieldValidator>
                </div>

                <div class="form-group">
                    <asp:TextBox ID="tb_Email" runat="server" type="text" placeholder="Email" required="required" class="form-control"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="rev1" runat="server" ErrorMessage="Invalid email format" Display="Dynamic" CssClass="invalid-feedback" ControlToValidate="tb_Email" Font-Size="Medium" ValidationExpression="^\w+[\w-\.]*\@\w+((-\w+)|(\w*))\.[a-z]{2,3}$"></asp:RegularExpressionValidator>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Please enter a Email" ControlToValidate="tb_Email" CssClass="invalid-feedback"></asp:RequiredFieldValidator>
                </div>

                <div class="form-group">
                    <label for="tb_Password">Password</label>
                    <small id="passwordHelpInline" class="text-muted">Must be at least 8 characters long</small>

                    <asp:TextBox ID="tb_Password" runat="server" type="password" placeholder="Enter a password" required="required" class="form-control" pattern=".{8,}"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Please enter a password" ControlToValidate="tb_Password" CssClass="invalid-feedback"></asp:RequiredFieldValidator>
                </div>

                <div class="form-group">
                    <asp:TextBox ID="tb_Confirm" runat="server" type="password" placeholder="Repeat the password" required="required" class="form-control" pattern=".{8,}"></asp:TextBox>
                    <asp:CompareValidator ID="cv1" runat="server" ErrorMessage="Passwords do not match" ControlToValidate="tb_Password" ControlToCompare="tb_Confirm" CssClass="invalid-feedback" Display="Dynamic"></asp:CompareValidator>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Please enter a password" ControlToValidate="tb_Confirm" CssClass="invalid-feedback"></asp:RequiredFieldValidator>
                </div>

            </div>

            <div class="col-lg-6">
                <div class="form-group">
                    <asp:Label ID="lbl_Recent_Login" Text="Recent Login" runat="server"></asp:Label>
                    <asp:TextBox ID="tb_Recent_Login" runat="server" CssClass="form-control" Enabled="False" Placeholder="Auto Generated"></asp:TextBox>
                </div>

                <div class="form-group">
                    <asp:Label ID="lbl_Creation_Date" Text="Creation Date" runat="server"></asp:Label>
                    <asp:TextBox ID="tb_Creation_Date" runat="server" CssClass="form-control" Enabled="False" Placeholder="Auto Generated"></asp:TextBox>
                </div>



                <div class="form-group">
                    <label for="tb_DateofBirth">Date of Birth</label>
                    <input id="tb_DateofBirth" type="text" runat="server" clientidmode="Static" placeholder="Date of Birth" class="form-control" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Please enter an date of birth." Display="Dynamic" CssClass="invalid-feedback" ControlToValidate="tb_DateofBirth"></asp:RequiredFieldValidator>
                </div>

                <div class="form-group">
                    <asp:Label ID="lbl_Role" Text="Role" runat="server"></asp:Label>
                    <asp:DropDownList ID="ddl_Role" runat="server" CssClass="custom-select">
                        <asp:ListItem Selected="True" Value="-">Select an Option</asp:ListItem>
                        <asp:ListItem Value="Admin">Admin</asp:ListItem>
                        <asp:ListItem Value="Student">Student</asp:ListItem>
                        <asp:ListItem Value="Teacher">Teacher</asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="Please enter a role" CssClass="invalid-feedback" ControlToValidate="ddl_Role" InitialValue="-"></asp:RequiredFieldValidator>
                </div>

                <div class="form-group">
                    <asp:Button ID="btn_Submit" runat="server" Text="Add User" OnClick="btn_Submit_Click" CssClass="btn btn-warning" Style="float: right;" />
                </div>

            </div>

        </div>

    </div>

    <script>
        $('#tb_DateofBirth').datepicker({
            uiLibrary: 'bootstrap4',
            format: 'dd mm yyyy'
        });
    </script>

</asp:Content>

