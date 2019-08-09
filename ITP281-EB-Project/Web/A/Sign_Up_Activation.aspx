<%@ Page Title="" Language="C#" MasterPageFile="~/Static/Master/User/Signing.master" AutoEventWireup="true" CodeFile="Sign_Up_Activation.aspx.cs" Inherits="Web_A_Sign_Up_Activation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitlePlaceHolder" runat="Server">
    Sign Up
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="HeadPlaceHolder" runat="Server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="BodyPlaceHolder" runat="Server">

    <section>
        <div class="d-flex justify-content-between FlexDiv py-5">

            <div class="container">
                <h2 class="form-title">Sign Up </h2>
                <p>Create your new account here! Note that your previous account will still be deactivate. </p>

                <div class="form-group">
                    <label for="tb_Username">Particulars</label>
                    <small class="text-muted">Your previous username is not available for your new account</small>

                    <asp:TextBox ID="tb_Username" runat="server" type="text" placeholder="Username" class="form-control" required="required" pattern=".{8,}"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Invalid username format, no spaces or special characters allowed" Display="Dynamic" CssClass="invalid-feedback" ControlToValidate="tb_Username" Font-Size="Medium" ValidationExpression="^[a-zA-Z0-9_]*$"></asp:RegularExpressionValidator>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Please enter a Username" ControlToValidate="tb_Username" CssClass="invalid-feedback"></asp:RequiredFieldValidator>
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
                    <div class="custom-control custom-checkbox mb-3">
                        <input type="checkbox" class="custom-control-input" id="customControlValidation1" required="required" />
                        <label class="custom-control-label" for="customControlValidation1">
                            I have read the                                
                               
                            <asp:LinkButton ID="lbtn_Terms" runat="server" class="term-service" OnClick="lbtn_Terms_Click" CausesValidation="false">Terms and Conditions</asp:LinkButton>
                        </label>
                    </div>
                </div>

                <div class="form-group justify-content-sm-center justify-content-lg-start">
                    <asp:Button ID="btn_Cancel" runat="server" Text="Go back to home" class="btn btn-danger" OnClick="btn_Cancel_Click" Style="width: 150px;" />

                    <asp:Button ID="btn_Submit" runat="server" Text="Sign Up" class="btn btn-success" OnClick="btn_Submit_Click" Style="width: 150px;" />
                </div>
            </div>
        </div>
    </section>

</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="FooterPlaceHolder" runat="Server">
</asp:Content>

