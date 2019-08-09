<%@ Page Title="" Language="C#" MasterPageFile="~/Static/Master/User/Signing.master" AutoEventWireup="true" CodeFile="Forgot_Password.aspx.cs" Inherits="Web_Account_Forget_Password" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitlePlaceHolder" runat="Server">
    Forgot Password
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
                <h2 class="form-title">Forgot Password</h2>

                <div class="form-group">
                    <label for="tb_Email">Enter your Email</label>
                    <asp:TextBox ID="tb_Email" runat="server" type="email" placeholder="Email" required="required" CssClass="form-control"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="rev1" runat="server" ErrorMessage="Invalid email format" Display="Dynamic" CssClass="invalid-feedback" ControlToValidate="tb_Email" Font-Size="Medium" ValidationExpression="^\w+[\w-\.]*\@\w+((-\w+)|(\w*))\.[a-z]{2,3}$"></asp:RegularExpressionValidator>

                    <div class="invalid-feedback">
                        Please enter a valid Email
                    </div>
                </div>

                <div class="form-group">
                    <p>
                        We'll look for your account and send you a password reset email.
                    </p>
                </div>

                <div class="form-group">
                    <asp:Button ID="btn_Submit" runat="server" Text="Send Us" class="btn btn-success w-50" OnClick="btn_Submit_Click" />
                </div>

                <div class="back-btn mt-5">
                    <asp:LinkButton ID="lbtn_Home" runat="server" OnClick="lbtn_Home_Click" CausesValidation="false"><i class="zmdi zmdi-arrow-left"></i>&nbsp Go back to home page</asp:LinkButton>
                </div>
            </div>
    </section>

</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="FooterPlaceHolder" runat="Server">
</asp:Content>

