<%@ Page Title="" Language="C#" MasterPageFile="~/Static/Master/User/Settings.master" AutoEventWireup="true" CodeFile="Change_Password.aspx.cs" Inherits="Web_Account_Settings_Change_Password" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitlePlaceHolder" runat="Server">
    Change Password
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="HeadPlaceHolder" runat="Server">
    <style>
        #lbtn_Password {
            color: black;
            border-bottom: 3px solid #6AA2F3;
        }
    </style>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="BodyPlaceHolder" runat="Server">

    <div class="row justify-content-center pt-2">
        <div class="col-lg-5 col-sm-10">

            <div class="form-group">
                <h3>Change Your Password </h3>
                <hr />
                <small>Password has to be at least 8 characters</small>
                <br />
            </div>

            <div class="form-group">
                <label for="tb_New_Password">New Password</label>
                <asp:TextBox ID="tb_Password" runat="server" type="password" placeholder="New password" class="form-control" pattern=".{8,}"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Please enter a password" CssClass="invalid-feedback" Font-Size="Medium" ControlToValidate="tb_Password" Display="Dynamic"></asp:RequiredFieldValidator>

                <div class="invalid-feedback">
                    Password has to be at least 8 characters
           
                </div>
            </div>

            <div class="form-group">
                <label for="tb_Confirm">Confirm your New Password</label>
                <asp:TextBox ID="tb_Confirm" runat="server" type="password" placeholder="Confirmation of New Password" class="form-control" pattern=".{8,}"></asp:TextBox>
                <asp:CompareValidator ID="cv1" runat="server" ErrorMessage="Passwords do not match" ControlToValidate="tb_Password" ControlToCompare="tb_Confirm" CssClass="invalid-feedback" Display="Dynamic" Font-Size="Medium"></asp:CompareValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Please enter a password" CssClass="invalid-feedback" Font-Size="Medium" ControlToValidate="tb_Confirm" Display="Dynamic"></asp:RequiredFieldValidator>
                <div class="invalid-feedback">
                    Passwords do not match
           
                </div>
            </div>

            <div class="form-group">
                <label for="tb_Password">We need your current password to confirm your change</label>
                <asp:TextBox ID="tb_Past_Password" runat="server" type="password" placeholder="Current Password" class="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfv1" runat="server" ErrorMessage="Please enter a password" CssClass="invalid-feedback" Font-Size="Medium" ControlToValidate="tb_Past_Password" Display="Dynamic"></asp:RequiredFieldValidator>
                <div class="invalid-feedback">
                    Password has to be at least 8 characters
           
                </div>
            </div>

            <div class="form-group">
                <asp:Button ID="btn_Submit" runat="server" Text="Change Password" class="btn btn-warning" OnClick="btn_Submit_Click" />
            </div>
        </div>
    </div>

</asp:Content>

