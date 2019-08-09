<%@ Page Title="" Language="C#" MasterPageFile="~/Static/Master/User/Template.master" AutoEventWireup="true" CodeFile="Inquiry.aspx.cs" Inherits="Web_Support_Inquiry" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitlePlaceHolder" runat="Server">
    Inquiry
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="HeadPlaceHolder" runat="Server">
    <style>
        #lbtn_Support {
            color: black;
        }


        #Heading {
            font-size: 3.5rem;
            font-weight: 300;
            line-height: 1.2;
            padding: 4rem;
        }

        @media only screen and (max-width: 900px) {
            #Heading {
                font-size: 2rem;
                padding: 1.4rem;
            }
        }
    </style>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="HeaderPlaceHolder" runat="Server">
    Support
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="BodyPlaceHolder" runat="Server">

    <div class="container text-center mb-2">
        <div class="row rounded text-white" style="background-color: #001f3f">
            <p id="Heading"><b>Feel Free to Contact Us </b></p>
        </div>
    </div>

    <div class="container rounded shadow">
        <div class="row mx-0 justify-content-center">
            <div class="col-lg-4 col-sm-10 mb-3 ">
                <div class="form-group">
                    <label for="name">
                        <b>Name</b></label>
                    <asp:TextBox ID="tb_Name" runat="server" MaxLength="64" CssClass="form-control" ToolTip="Enter Full Name" Style="margin-right: 150px;" required="required"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label for="email">
                        <b>Email Address</b></label>
                    <div class="input-group">
                        <asp:TextBox ID="tb_Email" runat="server" CssClass="form-control" ToolTip="Enter Email" type="email" placeholder="name@gmail.com" required="required"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group">
                    <label for="subject">
                        <b>Issue Type</b>
                        <asp:RequiredFieldValidator ID="rfv_ddl_Subject" runat="server" ErrorMessage="Please Select Issue Type" ControlToValidate="ddl_Category" ForeColor="Red" InitialValue="-1"></asp:RequiredFieldValidator></label>
                    <asp:DropDownList ID="ddl_Category" runat="server" CssClass="btn btn-outline-primary dropdown-toggle form-control ">
                        <asp:ListItem Value="-1">-- Select --</asp:ListItem>
                        <asp:ListItem Value="Accounts">Accounts</asp:ListItem>
                        <asp:ListItem Value="Transactions">Transactions</asp:ListItem>
                        <asp:ListItem Value="Customers">Customers</asp:ListItem>
                        <asp:ListItem Value="Others">Others</asp:ListItem>
                    </asp:DropDownList>
                </div>

                <div class="form-group">
                    <asp:Button ID="btn_SendMessage" runat="server" OnClick="btn_SendMessage_Click" Text="Send Message" CssClass="btn btn-success" Width="150px" />
                </div>
            </div>
            <div class="col-lg-4 col-sm-10">
                <div class="form-group">
                    <label for="name">
                        <b>Message</b></label>
                    <asp:TextBox ID="tb_Message" runat="server" MaxLength="128" TextMode="MultiLine" CssClass="form-control" ToolTip="Enter Message" cols="25" required="required" Width="100%" Height="200px" ></asp:TextBox>

                </div>
            </div>


            <div class="col-lg-4 col-sm-10 mb-3">
                <address>
                    <strong>Certcess</strong><br />
                    795 Folsom Ave, Suite 600<br />
                    San Francisco, CA 94107<br />
                    Phone:
                    (123) 456-7890
           
                </address>
                <address>
                    <strong>Email</strong><br />
                    <p>CertcessEducation@gmail.com</p>
                </address>

            </div>
        </div>
    </div>

</asp:Content>

