<%@ Page Title="" Language="C#" MasterPageFile="~/Static/Master/User/Settings.master" AutoEventWireup="true" CodeFile="Payment_Settings.aspx.cs" Inherits="Web_Account_Settings_Payment" %>

<asp:Content ID="Content3" ContentPlaceHolderID="TitlePlaceHolder" runat="Server">
    Payment Settings
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadPlaceHolder" runat="Server">
    <style>
        #lbtn_Payment {
            color: black;
            border-bottom: 3px solid #6AA2F3;
        }
    </style>
    <link rel="stylesheet" href="/Static/_Account/Css/Payment_Settings.css" type="text/css" runat="server" />

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyPlaceHolder" runat="Server">

    <div class="row justify-content-center pt-2">
        <div class="col-lg-5 col-sm-10">

            <div class="form-group">
                <h3>Payment Settings</h3>
                <hr />
            </div>

            <div class="form-group">
                <label for="tb_Card_Num">Card Number</label> -  <small>numbers only</small>
                <asp:TextBox ID="tb_Card_Num" runat="server" placeholder="Credit Card Number" class="form-control" pattern="\d*" MinLength="16" MaxLength="16" type="text" ></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfv1" runat="server" ErrorMessage="Please enter a card number." Display="Dynamic" CssClass="invalid-feedback" ControlToValidate="tb_Card_Num"></asp:RequiredFieldValidator>
            </div>

            <div class="form-group">
                <label for="tb_Card_Name">Card Name</label>
                <asp:TextBox ID="tb_Card_Name" runat="server" placeholder="Cardholder's Name" class="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Please enter a card name." Display="Dynamic" CssClass="invalid-feedback" ControlToValidate="tb_Card_Name"></asp:RequiredFieldValidator>
            </div>


            <div class="form-group">
                <label for="tb_ExpMonth">Expiration Month</label>
                <select id="ddl_month" runat="server" class="custom-select">
                    <option value="01">January</option>
                    <option value="02">February</option>
                    <option value="03">March</option>
                    <option value="04">April</option>
                    <option value="05">May</option>
                    <option value="06">June</option>
                    <option value="07">July</option>
                    <option value="08">August</option>
                    <option value="09">September</option>
                    <option value="10">October</option>
                    <option value="11">November</option>
                    <option value="12">December</option>
                </select>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Please enter an expiry month." Display="Dynamic" CssClass="invalid-feedback" ControlToValidate="ddl_month" InitialValue="-"></asp:RequiredFieldValidator>
            </div>

            <div class="form-group">
                <label for="tb_ExpYear">Expiration Year</label>
                <select id="ddl_year" runat="server" class="custom-select">
                    <option value="16">2016</option>
                    <option value="17">2017</option>
                    <option value="18">2018</option>
                    <option value="19">2019</option>
                    <option value="20">2020</option>
                    <option value="21">2021</option>
                    <option value="22">2022</option>
                    <option value="23">2023</option>
                    <option value="24">2024</option>
                </select>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Please enter an expiry year." Display="Dynamic" CssClass="invalid-feedback" ControlToValidate="ddl_year" InitialValue="-"></asp:RequiredFieldValidator>
            </div>

            <div class="form-group">
                <label for="tb_CCV">CCV</label>
                <asp:TextBox ID="tb_CCV" runat="server" placeholder="CCV" class="form-control" pattern="\d*" MinLength="3" MaxLength="3" type="text"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Please enter a ccv." Display="Dynamic" CssClass="invalid-feedback" ControlToValidate="tb_CCV"></asp:RequiredFieldValidator>
            </div>

            <div class="form-group">
                <asp:Button ID="btn_Submit" runat="server" Text="Update Card Settings" class="btn btn-warning" OnClick="btn_Submit_Click" />
            </div>
        </div>
    </div>

</asp:Content>

