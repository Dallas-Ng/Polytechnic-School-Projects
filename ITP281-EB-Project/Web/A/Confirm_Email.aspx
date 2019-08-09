<%@ Page Title="" Language="C#" MasterPageFile="~/Static/Master/User/Signing.master" AutoEventWireup="true" CodeFile="Confirm_Email.aspx.cs" Inherits="Web_A_Confirm_Email" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitlePlaceHolder" runat="Server">
    Confirmed Email
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="HeadPlaceHolder" runat="Server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="BodyPlaceHolder" runat="Server">
    <section>

        <div class="container py-5">
            <h1 class="display-3">Email Confirmed</h1>
            <p>Thanks for confirming your email with us!</p>

            <div class="form-group">
                <div class="back-btn mt-5">
                    <asp:LinkButton ID="lbtn_Home" runat="server" OnClick="lbtn_Home_Click"><i class="zmdi zmdi-arrow-left"></i>&nbsp Go back to home page</asp:LinkButton>
                </div>
            </div>
        </div>


    </section>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="FooterPlaceHolder" runat="Server">
</asp:Content>

