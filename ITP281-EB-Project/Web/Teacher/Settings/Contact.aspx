<%@ Page Title="" Language="C#" MasterPageFile="~/Static/Master/Teacher/Settings.master" AutoEventWireup="true" CodeFile="Contact.aspx.cs" Inherits="Web_Teacher_Settings_Contact" %>

<asp:Content ID="Content5" ContentPlaceHolderID="Content5" runat="Server">
    <style>
        #BodyPlaceHolder_lbtn_Contact {
            color: black;
            border-bottom: 3px solid #6AA2F3;
        }
    </style>
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="Content4" runat="Server">

    <div class="container">

        <div class="form-group">
            <h3>Have a problem or need to contact us? </h3>
            <hr />
            <small>Replies usually take 3-5 business days</small>
            <br />
        </div>

        <div class="form-group">
            <label for="tb_Subject">Subject</label>
            <asp:TextBox ID="tb_Subject" runat="server" type="text" placeholder="Your subject" CssClass="form-control" required="required"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Please enter a subject" ForeColor="Red" ControlToValidate="tb_Subject"></asp:RequiredFieldValidator>
        </div>


        <div class="form-group">
            <label for="tb_Message">Message for us</label>
            <asp:TextBox ID="tb_Message" runat="server" type="text" CssClass="form-control" TextMode="multiline" required="required"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Please enter a message" ForeColor="Red" ControlToValidate="tb_Message"></asp:RequiredFieldValidator>
        </div>

        <div class="form-group">
            <asp:Button ID="btn_Submit" runat="server" Text="Submit" CssClass="btn btn-success" OnClick="btn_Submit_Click" CausesValidation="true" />
        </div>
    </div>

</asp:Content>
