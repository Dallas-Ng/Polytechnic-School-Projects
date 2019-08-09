<%@ Page Title="" Language="C#" MasterPageFile="~/Static/Master/User/Signing.master" AutoEventWireup="true" CodeFile="Sign_up.aspx.cs" Inherits="Web_Account_Sign_up" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitlePlaceHolder" runat="Server">
    Sign Up
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="HeadPlaceHolder" runat="Server">
    <meta name="google-signin-client_id" content="985270521060-kv52tg2o7gsfuo02siahldstlcc934ip.apps.googleusercontent.com" />
    <script src="https://www.google.com/recaptcha/api.js" async="async" defer="defer"></script>
    <script src="https://apis.google.com/js/platform.js" async="async" defer="defer"></script>
    <style>
        #g-recaptcha-response {
            display: block !important;
            position: absolute;
            margin: -78px 0 0 0 !important;
            width: 302px !important;
            height: 76px !important;
            z-index: -999999;
            opacity: 0;
        }
    </style>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="BodyPlaceHolder" runat="Server">
    <section>

        <div class="row justify-content-center mt-5" style="margin-left: 0; margin-right: 0;">

            <div class="col-lg-5 col-sm-10">

                <h2 class="form-title">Sign Up</h2>

                <div class="form-group">
                    <label for="tb_Username">Particulars</label>
                    <small id="username" class="text-muted">Must be at least 8 characters long</small>
                    <asp:TextBox ID="tb_Username" runat="server" type="text" placeholder="Username" class="form-control" required="required" pattern=".{8,}"></asp:TextBox>
                    <div class="invalid-feedback">
                        Make sure your username is at least 8 characters.
                    </div>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Invalid username format, no spaces or special characters allowed" CssClass="invalid-feedback" ControlToValidate="tb_Username" Font-Size="Medium" ValidationExpression="^[a-zA-Z0-9_]*$" Display="Dynamic"></asp:RegularExpressionValidator>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Please enter a Username" ControlToValidate="tb_Username" CssClass="invalid-feedback" Display="Dynamic"></asp:RequiredFieldValidator>

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

                <div class="form-group">
                    <div class="g-recaptcha" data-sitekey="6Le4UK0UAAAAANdY8p4g_8w9XbrQWfohJKM8P74C"></div>
                </div>

                <div class="form-group">
                    <div class="custom-control custom-checkbox mb-3">
                        <input type="checkbox" class="custom-control-input" id="customControlValidation1" required="required" />
                        <label class="custom-control-label" for="customControlValidation1">
                            I have read the                                
                                <asp:LinkButton ID="lbtn_Terms" runat="server" class="term-service" OnClick="lbtn_Terms_Click" CausesValidation="false">Terms and Conditions</asp:LinkButton>
                        </label>
                    </div>
                </div>

                <div class="form-group mt-3">
                    <div class="d-flex justify-content-center">
                        <div class="p-2 w-100">
                            <asp:Button ID="btn_Submit" runat="server" Text="Sign Up" class="btn btn-success w-100" OnClick="btn_Submit_Click" CausesValidation="true" />
                        </div>

                        <div class="p-2">
                            <div class="g-signin2" data-width="220" data-height="40" data-longtitle="true" data-theme="dark" data-onsuccess="onSignIn"></div>
                        </div>
                    </div>
                </div>

            </div>

            <div class="col-lg-5 col-sm-10">

                <figure>
                    <img src="/Static/_Account/Img/Sign_up.jpg" alt="sing up image" />
                </figure>

                <div class="back_Btn mt-4">
                    <asp:LinkButton ID="lbtn_SignIn" runat="server" OnClick="lbtn_SignIn_Click" CausesValidation="false">I am already a member</asp:LinkButton>
                </div>

                <div class="back_Btn mt-4">
                    <asp:LinkButton ID="lbl_Teacher" runat="server" OnClick="lbtn_Teacher_Click" CausesValidation="false">Signing up to be a teacher?</asp:LinkButton>
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

            var id_token = googleUser.getAuthResponse().id_token;
            var string = "A/External_Login.aspx?action=Signup&email=" + email;
            window.location.href = string;
        }

        window.onload = function () {
            var $recaptcha = document.querySelector('#g-recaptcha-response');

            if ($recaptcha) {
                $recaptcha.setAttribute("required", "required");
            }
        };
    </script>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="FooterPlaceHolder" runat="Server">
</asp:Content>

