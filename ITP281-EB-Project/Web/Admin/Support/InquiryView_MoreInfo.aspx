<%@ Page Title="" Language="C#" MasterPageFile="~/Static/Master/Admin/Dashboard.master" AutoEventWireup="true" CodeFile="InquiryView_MoreInfo.aspx.cs" Inherits="Web_Admin_Support_InquiryView_MoreInfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitlePlaceHolder" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="HeadPlaceHolder" runat="Server">
    <style>
        #lbtn_Inquiry {
            color: white;
        }

        hr{
            border-color:white;
        }
    </style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="BodyPlaceHolder" runat="Server">
    <div class="container">
        <h1 class="text-white mb-4 p-2">Inquiry View</h1>

        <div class="d-flex justify-content-between whiteout text-white py-1 px-3 FlexDiv">
            <div class="p-2 w-100 px-3">
                <h3>Customer Details</h3>
                <hr />

                <div class="form-group">
                    <asp:Label ID="lbl_PK" Text="Inquiry ID" runat="server"></asp:Label>
                    <asp:TextBox ID="tb_PK" runat="server" CssClass="form-control" Enabled="False"></asp:TextBox>

                </div>

                <div class="form-group">
                    <asp:Label ID="lbl_Email" Text="Customer's Email" runat="server"></asp:Label>
                    <asp:TextBox ID="tb_Email" runat="server" CssClass="form-control" Enabled="False"></asp:TextBox>
                </div>

                <div class="form-group">
                    <asp:Label ID="lbl_Msg" Text="Customer's Message" runat="server"></asp:Label>
                    <asp:TextBox ID="tb_Msg" runat="server" CssClass="form-control" Enabled="False" Height="200px" TextMode="MultiLine"></asp:TextBox>
                </div>
            </div>

            <div class="p-2 w-100 px-3">
                <h3>Email Creation</h3>

                <hr />

                <div class="form-group">
                    <asp:Label ID="lbl_From" Text="Company Email" runat="server"></asp:Label>
                    <asp:TextBox ID="tb_From" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                </div>
                <asp:RequiredFieldValidator ID="rfv_From" runat="server" ControlToValidate="tb_From" ErrorMessage="Enter Your Email" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>

                <div class="form-group">
                    <asp:Label ID="Lbl_Subject" Text="Subject Title" runat="server"></asp:Label>
                    <asp:TextBox ID="tb_Subject" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <asp:RequiredFieldValidator ID="rfv_Subj" runat="server" ControlToValidate="tb_Subject" ErrorMessage="Enter Subject" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>


                <div class="form-group">
                    <asp:Label ID="lbl_Body" Text="Admin's Message" runat="server"></asp:Label>
                    <asp:TextBox ID="tb_Body" runat="server" TextMode="MultiLine" CssClass="form-control" Height="200px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfv_Msg" runat="server" ControlToValidate="tb_Body" ErrorMessage="Enter Message" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>

                </div>
            </div>
        </div>

        <div class="d-flex justify-content-between">
            <div class="p-2" style="padding-left: 0 !important;">
                <asp:Button ID="btn_Back" runat="server" OnClick="btn_Back_Click" Text="Back" CssClass="btn btn-danger" Width="150px" CausesValidation="False" />
            </div>

            <div class="p-2" style="padding-right: 0 !important;">
                <asp:Button ID="btn_Send" runat="server" OnClick="btn_Send_Click1" OnClientClick="alert('Message sent!')" Text="Send" CssClass="btn btn-success" Width="150px" />
            </div>
        </div>

    </div>
</asp:Content>

