<%@ Page Title="" Language="C#" MasterPageFile="~/Static/Master/Admin/Dashboard.master" AutoEventWireup="true" CodeFile="Courses.aspx.cs" Inherits="Web_Admin_Account_Courses" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitlePlaceHolder" runat="Server">
    View Courses
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="HeadPlaceHolder" runat="Server">
    <style>
        #lbtn_Users {
            color: white;
        }
    </style>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="BodyPlaceHolder" runat="Server">

    <div class="container">
        <h1 class="text-white mb-4 p-2">Viewing Courses</h1>

        <div class="row b-white p-3">
            <div class="col-lg-6">

                <div class="text-center container" id="CoursesBanner" runat="server">
                    <h4 class="text-center" style="font-size: 2em;">No courses enrolled</h4>
                    <br />
                </div>

                <asp:Repeater ID="Re1" runat="server">
                    <ItemTemplate>

                        <div class="d-flex flex-wrap col-sm-10 col-lg-7">

                            <div class="card m-1">
                                <img class="card-img-top" src="/Static/_Account/Img/Dashboard/FAQ.png" alt="Card image cap" style="height: 180px; background-color: silver; object-fit: cover;" />

                                <div class="card-body">
                                    <h5 class="card-title">
                                        <asp:Label ID="Label6" runat="server" Text='<%#Eval("Course_ID")%>'></asp:Label>
                                    </h5>
                                    <p class="card-text">
                                        <asp:Label ID="Label4" runat="server" Text=''></asp:Label>
                                    </p>

                                </div>

                                <div class="card-footer">
                                    <small class="text-muted">Last Visited:
                                        <asp:Label ID="Label1" runat="server" Text='<%#Eval("Recent_Visit")%>'></asp:Label>
                                    </small>
                                </div>
                            </div>

                        </div>

                    </ItemTemplate>
                </asp:Repeater>

            </div>
        </div>

        <div class="row b-white p-3">
            <div class="col-lg-12">
                <div class="d-flex justify-content-between">
                    <div class="p-2 p-0">
                        <asp:Button ID="btn_Back" runat="server" Text="Go Back to User" OnClick="btn_Back_Click" CssClass="btn btn-primary" CausesValidation="False" />
                    </div>

                    <div class="p-2 p-0">
                        <asp:Button ID="btn_View" runat="server" Text="Go Back to View" OnClick="btn_Home_Click" CssClass="btn btn-warning" CausesValidation="False" />
                    </div>
                </div>
            </div>

        </div>

    </div>

</asp:Content>

