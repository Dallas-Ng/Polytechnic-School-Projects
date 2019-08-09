<%@ Page Title="" Language="C#" MasterPageFile="~/Static/Master/User/Signing.master" AutoEventWireup="true" CodeFile="Change_Password.aspx.cs" Inherits="Web_Account_Change_Password" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitlePlaceHolder" runat="Server">
    Change Password
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="HeadPlaceHolder" runat="Server">
    <style>
        section {
            max-width: 40%;
            text-align: center;
        }

        @media screen and (max-width: 1000px), (min-height: 1200px) {
            section {
                max-width: 100%;
            }
        }
    </style>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="BodyPlaceHolder" runat="Server">

    <section>

        <div class="container py-5">

            <h2 class="form-title">Change Password</h2>

            <div class="form-group">
                <small id="passwordHelpInline" class="text-muted">Password must be at least 8 characters long</small>
            </div>

            <div class="form-group">
                <asp:TextBox ID="tb_Password" runat="server" type="password" placeholder="Enter a password" required="required" CssClass="form-control" pattern=".{8,}"></asp:TextBox>

                <div class="invalid-feedback">
                    Password has to be at least 8 characters
                </div>
            </div>

            <div class="form-group">
                <asp:TextBox ID="tb_Confirm" runat="server" type="password" placeholder="Repeat the password" required="required" CssClass="form-control" pattern=".{8,}" oninput="checkPasscode()"></asp:TextBox>
                <asp:CompareValidator ID="cv1" runat="server" ErrorMessage="Passwords do not match" ControlToValidate="tb_Password" ControlToCompare="tb_Confirm" CssClass="invalid-feedback" Display="Dynamic" Font-Size="Medium"></asp:CompareValidator>

                <div class="invalid-feedback">
                    Passwords do not match
                </div>
            </div>

            <div class="form-group">
                <asp:Button ID="btn_Submit" runat="server" Text="Change Password" class="btn btn-success w-50" OnClick="btn_Submit_Click" />
            </div>
        </div>
    </section>

</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="FooterPlaceHolder" runat="Server">
</asp:Content>

