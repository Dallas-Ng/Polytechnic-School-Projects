<%@ Page Title="" Language="C#" MasterPageFile="~/Static/Master/Admin/Dashboard.master" AutoEventWireup="true" CodeFile="Payment_Settings.aspx.cs" Inherits="Web_Admin_Account_Payment_Settings" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitlePlaceHolder" runat="Server">
    Payment Info
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="HeadPlaceHolder" runat="Server">
    <style>
        #lbtn_Users {
            color: white;
        }
    </style>
    <link rel="stylesheet" href="/Static/_Account/Css/Payment_Settings.css" type="text/css" runat="server" />
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="BodyPlaceHolder" runat="Server">

    <div class="container">
        <h1 class="text-white mb-4 p-2">Payment Settings</h1>

        <div class="container-fluid b-white py-3">
            <div class="form-group">
                <asp:Label ID="lbl_Card_Num" Text="Card Number" runat="server"></asp:Label>
                <asp:TextBox ID="tb_Card_Num" runat="server" CssClass="form-control" Enabled="False"></asp:TextBox>
            </div>

            <div class="form-group">
                <asp:Label ID="lbl_Card_Name" Text="Card Name" runat="server"></asp:Label>
                <asp:TextBox ID="tb_Card_Name" runat="server" CssClass="form-control" Enabled="False"></asp:TextBox>
            </div>

            <div class="form-group">
                <asp:Label ID="lbl_Card_Exp_Date" Text="Card Expiry Date" runat="server"></asp:Label>
                <asp:TextBox ID="tb_Card_Exp_date" runat="server" CssClass="form-control" Enabled="False"></asp:TextBox>
            </div>

            <div class="form-group">
                <asp:Label ID="lbl_CCV" Text="Card CCV" runat="server"></asp:Label>
                <asp:TextBox ID="tb_CCV" runat="server" CssClass="form-control" Enabled="False"></asp:TextBox>
            </div>

            <div class="d-flex justify-content-between">
                <div class="p-2">
                    <div class="form-group">
                        <asp:Button ID="btn_Back" runat="server" Text="Go Back to User" OnClick="btn_Back_Click" CssClass="btn btn-info" CausesValidation="False"/>
                    </div>
                </div>
                <div class="p-2">
                    <div class="form-group">
                        <asp:Button ID="btn_Home" runat="server" Text="Go Back to View" OnClick="btn_Home_Click" CssClass="btn btn-warning" CausesValidation="False"/>

                    </div>
                </div>
            </div>




        </div>

    </div>
</asp:Content>

