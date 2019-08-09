<%@ Page Title="" Language="C#" MasterPageFile="~/Static/Master/User/Signing.master" AutoEventWireup="true" CodeFile="Reactivate.aspx.cs" Inherits="Web_A_Reactivate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitlePlaceHolder" runat="Server">
    Activate Account
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="HeadPlaceHolder" runat="Server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="BodyPlaceHolder" runat="Server">
    <section class="text-center">

        <div class="container py-5">
            <h1 class="display-4">Account Activation</h1>
            <p>It seems like your account was deleted <asp:Label ID="lbl_Days" runat="server"></asp:Label> days ago.</p>


            <div class="form-group p-3 mt-3">
                <p>Would you like to reactivate it or make a new account?</p>

                <div class="d-flex justify-content-center">
                    <div class="p-2">
                        <asp:Button ID="Button1" runat="server" Text="Activate my account" CssClass="btn btn-success" OnClick="btn_Activate_Click"/>
                    </div>

                    <div class="p-2">
                        <asp:Button ID="Button2" runat="server" Text="Create a new account" CssClass="btn btn-danger" OnClick="btn_SignUp_Click"/>
                    </div>
                </div>
            </div>
        </div>


    </section>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="FooterPlaceHolder" runat="Server">
</asp:Content>

