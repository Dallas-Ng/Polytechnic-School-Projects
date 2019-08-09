<%@ Page Title="" Language="C#" MasterPageFile="~/Static/Master/User/Signing.master" AutoEventWireup="true" CodeFile="Sign_in.aspx.cs" Inherits="Web_Account_Sign_in" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitlePlaceHolder" runat="Server">
    Sign In
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="HeadPlaceHolder" runat="Server">
    <meta name="google-signin-client_id" content="985270521060-kv52tg2o7gsfuo02siahldstlcc934ip.apps.googleusercontent.com" />
    <script src="https://apis.google.com/js/platform.js" async="async" defer="defer"></script>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="BodyPlaceHolder" runat="Server">
    <section>

        <div class="row justify-content-center mt-5" style="margin-left: 0; margin-right: 0;">

            <div class="col-lg-5 col-sm-10">

                <h2 class="form-title">Sign In</h2>

                <div class="form-group">
                    <label for="tb_Username">Username</label>
                    <asp:TextBox ID="tb_Username" runat="server" type="text" placeholder="Username" required="required" CssClass="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Please enter a Username" ControlToValidate="tb_Username" CssClass="invalid-feedback"></asp:RequiredFieldValidator>
                </div>

                <div class="form-group">
                    <label for="tb_Password">Password</label>
                    <asp:TextBox ID="tb_Password" runat="server" type="password" placeholder="Enter a password" required="required" CssClass="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Please enter a Password" ControlToValidate="tb_Password" CssClass="invalid-feedback"></asp:RequiredFieldValidator>
                </div>

                <div class="form-group mt-3">
                    <div class="d-flex justify-content-center">
                        <div class="p-2 w-100">
                            <asp:Button ID="btn_SignIn" runat="server" Text="Sign in" class="btn btn-success w-100" OnClick="btn_SignIn_Click" />
                        </div>

                        <div class="p-2">
                            <div class="g-signin2" data-width="220" data-height="40" data-longtitle="true" data-theme="dark" data-onsuccess="onSignIn"></div>
                        </div>
                    </div>
                </div>

            </div>

            <div class="col-lg-5 col-sm-10">
                <figure>
                    <img src="/Static/_Account/Img/Sign_in.jpg" alt="sing up image" />
                </figure>

                <div class="back_Btn mt-4">
                    <asp:LinkButton class="signup-image-link" ID="lbtn_SignUp" runat="server" OnClick="lbtn_SignUp_Click" CausesValidation="false">Create an account</asp:LinkButton>
                </div>

                <div class="back_Btn mt-4">
                    <asp:LinkButton class="signup-image-link" ID="lbtn_Forget" runat="server" OnClick="lbtn_Forget_Click" CausesValidation="false">Forgot your password?</asp:LinkButton>
                </div>

                <div class="back_Btn mt-4">
                    <asp:LinkButton ID="lbtn_Home" runat="server" OnClick="lbtn_Home_Click" CausesValidation="false"><i class="zmdi zmdi-arrow-left"></i>&nbsp Go back to home page</asp:LinkButton>
                </div>
            </div>

        </div>

    </section>

    <script>
        function onSignIn(googleUser) {
            var profile = googleUser.getBasicProfile();
            var email = profile.getEmail();

            var auth2 = gapi.auth2.getAuthInstance();
            auth2.disconnect();

            var string = "A/External_Login.aspx?action=Signin&email=" + email;
            window.location.href = string;
        }

    </script>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="FooterPlaceHolder" runat="Server">
</asp:Content>

