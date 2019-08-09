<%@ Page Title="" Language="C#" MasterPageFile="~/Static/Master/User/Signing.master" AutoEventWireup="true" CodeFile="Sign_up_Teacher.aspx.cs" Inherits="Web_Account_Sign_up_Teacher" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitlePlaceHolder" runat="Server">
    Sign Up
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="HeadPlaceHolder" runat="Server">
    <script src="https://www.google.com/recaptcha/api.js" async="async" defer="defer"></script>
    <style>
        body, html {
            overflow: auto;
        }

        section {
            width: 50%;
        }

        @media screen and (max-width: 1200px), (min-height: 1440px) {
            section {
                width: 100%;
            }
        }
    </style>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="BodyPlaceHolder" runat="Server">
    <section>

        <div class="container py-5">

            <h2 class="form-title">Teacher Registration</h2>

            <div class="form-group">
                <label for="tb_Name">Particulars</label>
                <asp:TextBox ID="tb_Name" runat="server" type="text" placeholder="Full Name" class="form-control" required="required"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfv1" runat="server" ErrorMessage="Please enter a name." Display="Dynamic" CssClass="invalid-feedback" ControlToValidate="tb_Name"></asp:RequiredFieldValidator>
            </div>

            <div class="form-group">
                <asp:TextBox ID="tb_Email" runat="server" type="email" placeholder="Email" class="form-control" required="required"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Please enter an email." Display="Dynamic" CssClass="invalid-feedback" ControlToValidate="tb_Email"></asp:RequiredFieldValidator>
            </div>

            <div class="form-group">
                <asp:Label ID="lbl_Cert" Text="Highest Achieved Certification" runat="server"></asp:Label>
                <asp:DropDownList ID="ddl_Cert" runat="server" CssClass="custom-select" required="required">
                    <asp:ListItem Value="" Selected="True">Please Select</asp:ListItem>
                    <asp:ListItem Value="O">GCE O' Level</asp:ListItem>
                    <asp:ListItem Value="D">Diploma</asp:ListItem>
                    <asp:ListItem Value="B">Bachelor</asp:ListItem>
                    <asp:ListItem Value="M">Masters and Above</asp:ListItem>
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Please select" Display="Dynamic" InitialValue="" ControlToValidate="ddl_Cert" CssClass="invalid-feedback"></asp:RequiredFieldValidator>
            </div>

            <div style="margin-top: 15px;">
                <label>Please upload your certification</label>
                <asp:FileUpload type="file" ID="FUploadIdentity" runat="server" Style="display: none;" ClientIDMode="Static" onchange="updatemyname();" />
                <div class="input-group">
                    <input id="fileone" type="text" class="form-control" placeholder="No file Selected" disabled="disabled" />
                    <span class="input-group-btn">
                        <a href="javascript:void(0);" class="btn btn-warning" onclick="uploadme();">Select File</a>
                    </span>
                </div>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Please upload a file" ControlToValidate="FUploadIdentity" Display="Dynamic" CssClass="invalid-feedback"></asp:RequiredFieldValidator>
            </div>

            <div style="margin-top: 15px;">
                <label>Please upload your identification</label>
                <asp:FileUpload type="file" ID="FUploadCert" runat="server" Style="display: none;" ClientIDMode="Static" onchange="updatemyname2();" />
                <div class="input-group">
                    <input id="filetwo" type="text" class="form-control" placeholder="No file Selected" disabled="disabled" />
                    <span class="input-group-btn">
                        <a href="javascript:void(0);" class="btn btn-warning" onclick="uploadme2();">Select File</a>
                    </span>
                </div>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Please upload a file" ControlToValidate="FUploadCert" Display="Dynamic" CssClass="invalid-feedback"></asp:RequiredFieldValidator>
            </div>

            <div class="form-group" style="margin-top: 15px;">
                <div class="g-recaptcha" data-sitekey="6Le4UK0UAAAAANdY8p4g_8w9XbrQWfohJKM8P74C"></div>
            </div>

            <div style="text-align: center;">
                <div class="form-group mt-5">
                    <div class="custom-control custom-checkbox mb-3">
                        <input type="checkbox" class="custom-control-input" id="customControlValidation1" required="required" />
                        <label class="custom-control-label" for="customControlValidation1">
                            I have read the                                
                            <asp:LinkButton ID="lbtn_Terms" runat="server" class="term-service" OnClick="lbtn_Terms_Click" CausesValidation="false">Terms and Conditions</asp:LinkButton>
                        </label>
                    </div>
                </div>

                <div class="form-group">
                    <asp:Button ID="btn_Submit" runat="server" Text="Apply" class="btn btn-success w-50" OnClick="btn_Submit_Click" />
                </div>


                <div class="back_Btn mt-3">
                    <asp:LinkButton ID="lbtn_SignIn" runat="server" OnClick="lbtn_SignIn_Click" CausesValidation="false"><i class="zmdi zmdi-arrow-left"></i>&nbsp Go Back</asp:LinkButton>
                </div>
            </div>
        </div>

    </section>

    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.3/jquery.min.js"></script>

    <script type="text/javascript">

        function uploadme() {
            $('#FUploadIdentity').click();

        }

        function splitpath(paths) {
            var st = paths.split("\\");
            return st[st.length - 1];
        } function updatemyname() {


            var varfile = document.getElementById("FUploadIdentity");
            document.getElementById("fileone").value = splitpath(varfile.value);

        }    </script>

    <script type="text/javascript">

        function uploadme2() {
            $('#FUploadCert').click();

        }

        function splitpath2(paths2) {
            var st2 = paths2.split("\\");
            return st2[st2.length - 1];
        } function updatemyname2() {


            var varfile2 = document.getElementById("FUploadCert");
            document.getElementById("filetwo").value = splitpath2(varfile2.value);

        }    </script>

</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="FooterPlaceHolder" runat="Server">
</asp:Content>

