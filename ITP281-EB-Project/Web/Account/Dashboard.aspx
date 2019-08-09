<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Dashboard.aspx.cs" Inherits="Web_Account_Dashboard" %>

<!DOCTYPE html>


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Home
    </title>

    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no" />
    <link rel="stylesheet" href="/Content/bootstrap.css" />
    <link rel="stylesheet" type="text/css" href="~/Static/_Main/Main.css" />
    <link rel="stylesheet" href="/Static/_Account/Css/Dashboard.css" />
    <link rel="shortcut icon" type="image" href="~/Static/_Main/Img/Icon.png" />
    <meta name="google-signin-client_id" content="985270521060-kv52tg2o7gsfuo02siahldstlcc934ip.apps.googleusercontent.com" />
    <script src="https://apis.google.com/js/platform.js" async="async" defer="defer"></script>

    <style>
        #lbtn_Home {
            color: white;
        }
    </style>
</head>

<body>
    <form runat="server">
        <div onclick="topFunction()" id="scroll"></div>

        <nav class="navbar navbar-expand-lg navbar-light fixed-top bg-transparent justify-content-end" id="DashboardNav">
            <asp:Button ID="Courses" CssClass="btn btn-success mr-2" Text="My Courses" runat="server" OnClick="lbtn_MyCourses_Click"/>
            <asp:ImageButton ID="ib_Settings" runat="server" CssClass="mr-2" Width="35" Height="35" src="https://img.icons8.com/plasticine/100/000000/settings.png" OnClick="lbtn_Settings_Click" CausesValidation="false" />
            <asp:ImageButton ID="ib_Notif" runat="server" CssClass="mr-3" Width="27" Height="27" src="https://img.icons8.com/officel/80/000000/mailbox-opened-flag-up.png" OnClick="btn_Notif_Click" CausesValidation="false" />
            <asp:Button ID="Logout_Btn" runat="server" Text="Logout" OnClientClick="signOut()" OnClick="logout" CssClass="btn btn-danger my-2 shadow-sm" CausesValidation="false" />
        </nav>

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

        <main role="main" class="container-fluid">

            <div class="container">

                <div class="d-flex justify-content-center">

                    <ul class="nav nav-pills mb-3" id="pills-tab" role="tablist" style="margin: 0 auto;">
                        <li class="nav-item">
                            <a class="nav-link ccc active" id="pills-home-tab" data-toggle="pill" href="#pills-home" role="tab" aria-controls="pills-home" aria-selected="true">Info</a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link ccc" id="pills-profile-tab" data-toggle="pill" href="#pills-profile" role="tab" aria-controls="pills-profile" aria-selected="false">My Courses</a>
                        </li>
                        <%--                        <li class="nav-item">
                            <a class="nav-link ccc" id="pills-contact-tab" data-toggle="pill" href="#pills-contact" role="tab" aria-controls="pills-contact" aria-selected="false">Notifications</a>
                        </li>--%>
                    </ul>

                </div>
            </div>

            <hr />


            <div class="container justify-content-center">

                <div class="tab-content my-4" id="pills-tabContent">
                    <div class="tab-pane fade show active" id="pills-home" role="tabpanel" aria-labelledby="pills-home-tab">

                        <div class="card-deck my-5 pb-3">
                            <div class="card">
                                <a href="../Forums/Forums.aspx" class="text-decoration-none" style="color: black;">
                                    <img src="../../Static/_Account/Img/Dashboard/Life.png" class="card-img-top" alt="..." />
                                    <div class="card-body">
                                        <h5 class="card-title">Forums</h5>
                                        <p class="card-text">
                                            We offer you forums for you and other students to interact with each other.
                                            <br />
                                            <br />
                                            Click here to find out more.
                                        </p>
                                    </div>
                                </a>
                            </div>

                            <div class="card">
                                <a href="../Shop/Courses.aspx" class="text-decoration-none" style="color: black;">
                                    <img src="../../Static/_Account/Img/Dashboard/Courses.png" class="card-img-top" alt="..." />
                                    <div class="card-body">
                                        <h5 class="card-title">Catalogue</h5>
                                        <p class="card-text">
                                            Did you know that Certcess has over 100 courses available for each subject?
                                            <br />
                                            <br />
                                            Click here to find out more.
                                        </p>
                                    </div>
                                </a>
                            </div>

                            <div class="card">
                                <a href="../Support/FAQ.aspx" class="text-decoration-none" style="color: black;">
                                    <img src="../../Static/_Account/Img/Dashboard/FAQ.png" class="card-img-top" alt="..." />
                                    <div class="card-body">
                                        <h5 class="card-title">FAQs</h5>
                                        <p class="card-text">
                                            Do you have a question for us or seek some sort of technical help?
                                            <br />
                                            <br />
                                            Check our FAQ page here.
                                        </p>
                                    </div>
                                </a>
                            </div>
                        </div>
                    </div>

                    <div class="tab-pane fade" id="pills-profile" role="tabpanel" aria-labelledby="pills-profile-tab">

                        <h4 class="mb-3">Your Courses </h4>

                        <div class="text-center container" id="CoursesBanner" runat="server">
                            <h4 class="text-center" style="font-size: 2em;">No courses enrolled</h4>
                            <br />
                            <asp:LinkButton ID="LinkButton4" runat="server" OnClick="lbtn_Courses_Click">Click here to see courses</asp:LinkButton>
                        </div>

                        <div class="d-flex flex-wrap justify-content-center">

                            <asp:Repeater ID="Re1" runat="server">
                                <ItemTemplate>

                                    <div class="d-flex flex-wrap col-sm-10 col-lg-3">
                                        <a href="../Classroom/Course.aspx?Course_ID=<%#Eval("Course_ID")%>" class="text-decoration-none">
                                            <div class="card m-1">
                                                <img class="card-img-top" src="../../Static/_Account/Img/Dashboard/FAQ.png" alt="Card image cap" style="height: 180px; background-color: silver; object-fit: cover;" />

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
                                        </a>
                                    </div>

                                </ItemTemplate>
                            </asp:Repeater>
                        </div>
                    </div>

<%--                    <div class="tab-pane fade" id="pills-contact" role="tabpanel" aria-labelledby="pills-contact-tab">

                        <div class="container-fluid">

                            <h4 class="mb-3">Notifications</h4>

                        </div>

                    </div>--%>
                </div>
            </div>

        </main>

        <div class="container">

            <footer class="border-top">

                <div class="container" style="min-height: 100px;">
                    <div class="d-flex flex-row justify-content-center">
                        <div class="col-lg-2 p-2">
                            <asp:LinkButton ID="LinkButton1" runat="server" OnClick="lbtn_FAQ_Click" class="text-muted" CausesValidation="false">FAQ</asp:LinkButton>
                        </div>

                        <div class="col-lg-2 p-2">
                            <asp:LinkButton ID="LinkButton2" runat="server" OnClick="lbtn_Inquiry_Click" class="text-muted" CausesValidation="false">Inquiry</asp:LinkButton>
                        </div>

                        <div class="col-lg-2 p-2">
                            <asp:LinkButton ID="LinkButton3" runat="server" OnClick="lbtn_Terms_Click" class="text-muted" CausesValidation="false">Terms</asp:LinkButton>
                        </div>

                        <div class="col-lg-2 p-2">
                            <asp:LinkButton ID="LinkButton5" runat="server" OnClick="lbtn_Forums_Click" class="text-muted" CausesValidation="false">Forums</asp:LinkButton>
                        </div>

                        <div class="col-lg-2 p-2">
                            <asp:LinkButton ID="LinkButton6" runat="server" OnClick="lbtn_Settings_Click" class="text-muted" CausesValidation="false">Settings</asp:LinkButton>
                        </div>
                    </div>
                </div>
            </footer>
        </div>
    </form>

    <script src="/Scripts/jquery-3.0.0.slim.min.js"></script>
    <script src="/Scripts/umd/popper.min.js"></script>
    <script src="/Scripts/bootstrap.min.js"></script>

    <script>
        function signOut() {
            var auth2 = gapi.auth2.getAuthInstance();
            auth2.signOut().then(function () {
                console.log('User signed out.');
            });
        }
    </script>

    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <script>
        $(document).ready(function () {
            $(window).scroll(function () {
                if ($(this).scrollTop() > 100) {
                    $('#scroll').fadeIn();
                } else {
                    $('#scroll').fadeOut();
                }
            });
            $('#scroll').click(function () {
                $("html, body").animate({ scrollTop: 0 }, 600);
                return false;
            });
        });
    </script>
</body>

</html>
