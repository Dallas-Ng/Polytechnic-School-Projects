<%@ Page Title="" Language="C#" MasterPageFile="~/Static/Master/Teacher/Dashboard.master" AutoEventWireup="true" CodeFile="Dashboard.aspx.cs" Inherits="Web_Teacher_Dashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitlePlaceHolder" runat="Server">
    Dashboard
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="HeadPlaceHolder" runat="Server">
    <style>
        #lbtn_Home {
            color: white;
        }

        #DashboardBanner {
            background-image: url("/Static/_Account/Img/Dashboard/Background_1.png");
        }
    </style>
    <link rel="stylesheet" type="text/css" href="~/Static/_Main/Main.css" />
    <link rel="stylesheet" href="/Static/_Account/Css/Dashboard_Teacher.css" />
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="BodyPlaceHolder" runat="Server">
    <div id="topDiv"></div>
    <div class="container-fluid mb-3 text-white" id="DashboardBanner">
        <div class="container">

            <div class="d-flex justify-content-center justify-content-lg-start flex-row">
                <div class="p-2 mr-2">
                    <asp:Image ID="ProfilePicture" runat="server" src="/Static/_Account/ProfilePictures/Default.png" CssClass="m-0" />
                </div>

                <div class="p-2">
                    <div class="d-flex justify-content-start" style="flex-direction: column; padding: 0 !important;">
                        <strong class="p-2">
                            <asp:Label ID="lbl_Username" runat="server"></asp:Label>

                        </strong>
                        <small id="Recent" class="p-2" style="padding-top: 0 !important;">Recent Login:
                           <asp:Label ID="lbl_RecentLogin" runat="server"></asp:Label>
                        </small>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <div class="container">
        <h2>Your Courses </h2>
        <hr />

        <div class="text-center container" id="CoursesBanner" runat="server">
            <h4 class="text-center" style="font-size: 2em;">No courses enrolled</h4>
            <br />
            <asp:LinkButton ID="LinkButton4" runat="server" OnClick="lbtn_Courses_Click">Click here to see courses</asp:LinkButton>
        </div>

        <div class="d-flex justify-content-center flex-row flex-wrap mx-0">

            <asp:Repeater ID="Re1" runat="server">
                <ItemTemplate>

                    <div class="p-2">
                        <a href="/Web/Teacher/Courses/CoursesView.aspx?Course_ID=<%#Eval("Course_ID")%>" class="text-decoration-none">
                            <div class="card m-1">
                                <div class="d-flex flex-row">
                                    <img class="card-img-top" src="/Static/_Account/Img/Dashboard/FAQ.png" alt="Card image cap" style="height: 120px; width: 220px; background-color: silver; object-fit: cover;" />

                                    <div class="card-body shadow-lg" style="width: 250px;">
                                        <h5 class="card-title">
                                            <asp:Label ID="Label6" runat="server" Text='<%#Eval("Course_ID")%>'></asp:Label>
                                        </h5>
                                        <p class="card-text">
                                            <asp:Label ID="Label1" runat="server" Text='<%#Eval("Course_Subject")%>'></asp:Label>
                                        </p>
                                    </div>
                                </div>
                            </div>
                        </a>
                    </div>

                </ItemTemplate>
            </asp:Repeater>

        </div>
    </div>
</asp:Content>

