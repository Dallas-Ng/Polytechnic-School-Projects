<%@ Page Language="C#" MasterPageFile="~/Static/Master/Teacher/Dashboard.master" AutoEventWireup="true" CodeFile="Thread.aspx.cs" Inherits="Web_Forums_Thread" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitlePlaceHolder" runat="Server">
    Post
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="HeadPlaceHolder" runat="Server">
    <style>
        #lbtn_Forums {
            color: white;
        }

        body {
            margin-top: 4.5rem;
        }
    </style>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="BodyPlaceHolder" runat="Server">

<div class="row mx-0 mb-5 justify-content-center">

        <div class="col-lg-8 col-sm-12 my-2" style="background-color: white;">
            <div class="shadow p-3 my-2">
                <h1 class="display-3 mb-4">
                    <asp:Label ID="Title" runat="server"></asp:Label></h1>
                <p>
                    <asp:Label ID="Desc" runat="server"></asp:Label>
                </p>
            </div>

            <div class="container my-5">
                <asp:Repeater ID="Re1" runat="server" DataSourceID="SqlDataSource1">
                    <ItemTemplate>

                        <div class="media m-2 p-2" style="background-color: white;">
                            <img src="/Static/_Account/ProfilePictures/<%#Eval("User_ID")%>_<%#Eval("ProfilePictureUrl")%>" class="align-self-start mr-3" style="height: 50px; width: 50px; object-fit: cover;">
                            <div class="media-body">
                                <h5 class="mt-0"><%#Eval("User_ID")%></h5>
                                <div class="text-wrap">
                                    <p><%#Eval("Post_Msg")%></p>
                                </div>

                                <p><%#Eval("Post_CreationDate")%></p>
                            </div>

                        </div>

                    </ItemTemplate>
                </asp:Repeater>
            </div>

            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:EBP-Database %>"
                SelectCommand="select * from users order by recent_login desc;"></asp:SqlDataSource>

            <button type="button" class="btn btn-primary mb-2" data-toggle="modal" data-target="#PostModal">Post Reply</button>

            <div class="modal fade" id="PostModal" role="dialog">
                <div class="modal-dialog">

                    <div class="modal-content">

                        <div class="modal-header">
                            <h3 class="modal-title">Post Reply</h3>

                            <button type="button" class="close" data-dismiss="modal">&times;</button>
                        </div>

                        <div class="modal-body">
                            <div class="form-group">
                                <label>Enter Post Msg:</label>
                                <asp:TextBox ID="tb_PostMsg" runat="server" CssClass="form-control"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfv_PostMsg" runat="server" ControlToValidate="tb_PostMsg" ErrorMessage="Please enter Post Message" ForeColor="Red" CssClass="invalid-feedback"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="modal-footer">
                            <asp:Button ID="btn_Post" runat="server" CssClass="btn btn-primary" Text="Submit" OnClick="btn_Post_Click" />
                            <button type="button" class="btn btn-danger" data-dismiss="modal">Close</button>
                        </div>
                        <asp:ValidationSummary ID="ValidationSummary" runat="server" Font-Bold="True" ForeColor="Red" />
                    </div>

                </div>
            </div>
        </div>
    </div>

</asp:Content>
