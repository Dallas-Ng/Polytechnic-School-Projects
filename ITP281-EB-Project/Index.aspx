<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Index.aspx.cs" Inherits="Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />

    <title>Home</title>

    <link href="https://fonts.googleapis.com/css?family=Muli:300,400,700,900" rel="stylesheet" />
    <link rel="stylesheet" type="text/css" href="/Static/_Index/Css/bootstrap.min.css" />
    <link rel="stylesheet" type="text/css" href="/Static/_Index/Css/jquery-ui.css" />
    <link rel="stylesheet" type="text/css" href="/Static/_Index/Css/owl.carousel.min.css" />
    <link rel="stylesheet" type="text/css" href="/Static/_Index/Css/owl.theme.default.min.css" />
    <link rel="stylesheet" type="text/css" href="/Static/_Index/Css/aos.css" />
    <link rel="stylesheet" type="text/css" href="/Static/_Index/Css/style.css" />
    <link rel="stylesheet" type="text/css" href="/Static/_Index/Css/flaticon.css" />

    <link rel="shortcut icon" type="image" href="~/Static/_Main/Img/Icon.png" />

    <link rel="stylesheet" type="text/css" href="../../Static/_Main/Main.css" />
</head>

<body>
    <form runat="server" id="form1">


        <div onclick="topFunction()" id="scroll"></div>

        <div class="site-wrap">

            <div class="site-mobile-menu site-navbar-target">
                <div class="site-mobile-menu-header">
                    <div class="site-mobile-menu-close mt-3">
                        <span class="icon-close2 js-menu-toggle"></span>
                    </div>
                </div>
                <div class="site-mobile-menu-body"></div>
            </div>


            <header class="site-navbar py-4 js-sticky-header site-navbar-target" role="banner">

                <div class="container-fluid">
                    <div class="d-flex align-items-center">
                        <div class="site-logo mr-auto w-25"><a href="#">Certcess</a></div>

                        <div class="mx-auto text-center">
                            <nav class="site-navigation position-relative text-right" role="navigation">
                                <ul class="site-menu main-menu js-clone-nav mx-auto d-none d-lg-block  m-0 p-0">
                                    <li><a href="#home-section" class="nav-link">Home</a></li>
                                    <li><a href="#courses-section" class="nav-link">Courses</a></li>
                                    <li><a href="#programs-section" class="nav-link">Programs</a></li>
                                    <li><a href="/Web/Main/Inquiry.aspx" onclick="location.href='/Web/Main/Inquiry.aspx';" class="nav-link">Contact</a></li>
                                </ul>
                            </nav>
                        </div>

                        <div class="ml-auto w-25">
                            <nav class="site-navigation position-relative text-right" role="navigation">
                                <ul class="site-menu main-menu site-menu-dark js-clone-nav mr-auto d-none d-lg-block m-0 p-0">
                                    <li class="cta"><a href="/Web/Sign_in.aspx" class="nav-link" onclick="location.href='/Web/Sign_in.aspx';"><span>Sign in</span></a></li>
                                </ul>
                            </nav>
                            <a href="#" class="d-inline-block d-lg-none site-menu-toggle js-menu-toggle text-black float-right"><span class="flaticon-menu h3"></span></a>
                        </div>
                    </div>
                </div>

            </header>

            <div class="intro-section" id="home-section">

                <div class="slide-1" style="background-image: url('Static/_Index/Img/hero_1.jpg');" data-stellar-background-ratio="0.5">
                    <div class="container">
                        <div class="row align-items-center">
                            <div class="col-12">
                                <div class="row align-items-center">
                                    <div class="col-lg-6 mb-4">
                                        <h1 data-aos="fade-up" data-aos-delay="100">Certcess Education.</h1>
                                        <p class="mb-4" data-aos="fade-up" data-aos-delay="200">We strive to create education accessible by anyone, anytime, and anywhere. Join us in our journey!</p>

                                    </div>

                                </div>
                            </div>

                        </div>
                    </div>
                </div>
            </div>


            <div class="site-section courses-title" id="courses-section">
                <div class="container">
                    <div class="row mb-3 justify-content-center">
                        <div class="col-lg-7 text-center" data-aos="fade-up" data-aos-delay="">
                            <h2 class="section-title">Courses</h2>
                        </div>
                    </div>
                </div>
            </div>
            <div class="site-section courses-entry-wrap" data-aos="fade-up" data-aos-delay="100">
                <div class="container">

                    <div class="row">

                        <div class="owl-carousel col-12 nonloop-block-14">

                            <asp:Repeater ID="Re1" runat="server">
                                <ItemTemplate>

                                    <div class="course bg-white h-100 align-self-stretch">
                                        <figure class="m-0">
                                                <img src="/Static/_Account/Img/Dashboard/FAQ.png" alt="Image" class="img-fluid" />
                                        </figure>

                                        <div class="course-inner-text py-4 px-4">
                                            <span class="course-price">$<%#Eval("Course_Fee")%></span>

                                            <h3>
                                                <asp:Label ID="lbl_Title_Card_1" runat="server" Text='<%#Eval("Course_Title")%>'></asp:Label>
                                            </h3>

                                            <p>
                                                <asp:Label ID="lbl_Desc_Card_1" runat="server" Text='<%#Eval("Course_Desc")%>'></asp:Label>
                                            </p>
                                        </div>
                                    </div>

                                </ItemTemplate>
                            </asp:Repeater>

                        </div>



                    </div>
                    <div class="row justify-content-center">
                        <div class="col-7 text-center">
                            <button class="customPrevBtn btn btn-primary m-1" type="button">Prev</button>
                            <button class="customNextBtn btn btn-primary m-1" type="button">Next</button>
                        </div>
                    </div>
                </div>
            </div>


            <div class="site-section" id="programs-section">
                <div class="container">
                    <div class="row mb-5 justify-content-center">
                        <div class="col-lg-7 text-center" data-aos="fade-up" data-aos-delay="">
                            <h2 class="section-title">Our Programs</h2>
                            <p>Our programs are curated and created for you. This means that we go through each course and see if it is a good fit for everyone.</p>
                        </div>
                    </div>
                    <div class="row mb-5 align-items-center">
                        <div class="col-lg-7 mb-5" data-aos="fade-up" data-aos-delay="100">
                            <img src="/Static/_Index/Img/undraw_youtube_tutorial.svg" alt="Image" class="img-fluid" />
                        </div>
                        <div class="col-lg-4 ml-auto" data-aos="fade-up" data-aos-delay="200">
                            <h2 class="text-black mb-4">We Are Excellent In Education</h2>
                            <p class="mb-4">Awarded with the Stella education awards in 2018</p>

                            <div class="d-flex align-items-center custom-icon-wrap mb-3">
                                <span class="custom-icon-inner mr-3"><span class="icon flaticon-mortarboard"></span></span>
                                <div>
                                    <h3 class="m-0">22,931 Yearly Graduates</h3>
                                </div>
                            </div>

                            <div class="d-flex align-items-center custom-icon-wrap">
                                <span class="custom-icon-inner mr-3"><span class="icon flaticon-worldwide"></span></span>
                                <div>
                                    <h3 class="m-0">150 Universities Worldwide</h3>
                                </div>
                            </div>

                        </div>
                    </div>

                    <div class="row mb-5 align-items-center">
                        <div class="col-lg-7 mb-5 order-1 order-lg-2" data-aos="fade-up" data-aos-delay="100">
                            <img src="/Static/_Index/Img/undraw_teaching.svg" alt="Image" class="img-fluid" />
                        </div>
                        <div class="col-lg-4 mr-auto order-2 order-lg-1" data-aos="fade-up" data-aos-delay="200">
                            <h2 class="text-black mb-4">Strive for Excellent</h2>
                            <p class="mb-4">Our goal in Certcess is to deliver education at a reasonable price and to allow you to learn efficiently.</p>

                            <div class="d-flex align-items-center custom-icon-wrap mb-3">
                                <span class="custom-icon-inner mr-3"><span class="icon flaticon-mortarboard"></span></span>
                                <div>
                                    <h3 class="m-0">22,931 Yearly Graduates</h3>
                                </div>
                            </div>

                            <div class="d-flex align-items-center custom-icon-wrap">
                                <span class="custom-icon-inner mr-3"><span class="icon flaticon-worldwide"></span></span>
                                <div>
                                    <h3 class="m-0">150 Universities Worldwide</h3>
                                </div>
                            </div>

                        </div>
                    </div>

                    <div class="row mb-5 align-items-center">
                        <div class="col-lg-7 mb-5" data-aos="fade-up" data-aos-delay="100">
                            <img src="/Static/_Index/Img/undraw_teacher.svg" alt="Image" class="img-fluid" />
                        </div>
                        <div class="col-lg-4 ml-auto" data-aos="fade-up" data-aos-delay="200">
                            <h2 class="text-black mb-4">Education is life</h2>
                            <p class="mb-4">At Certcess, your education is our main focus.</p>

                            <div class="d-flex align-items-center custom-icon-wrap mb-3">
                                <span class="custom-icon-inner mr-3"><span class="icon flaticon-mortarboard"></span></span>
                                <div>
                                    <h3 class="m-0">22,931 Yearly Graduates</h3>
                                </div>
                            </div>

                            <div class="d-flex align-items-center custom-icon-wrap">
                                <span class="custom-icon-inner mr-3"><span class="icon flaticon-worldwide"></span></span>
                                <div>
                                    <h3 class="m-0">150 Universities Worldwide</h3>
                                </div>
                            </div>

                        </div>
                    </div>

                </div>
            </div>

            <div class="site-section" id="teachers-section">
                <div class="container">

                    <div class="row mb-5 justify-content-center">
                        <div class="col-lg-7 mb-5 text-center" data-aos="fade-up" data-aos-delay="">
                            <h2 class="section-title">Our Teachers</h2>
                            <p class="mb-5">Teachers are able to apply anytime. Our teachers are the best at what they do.</p>
                        </div>
                    </div>

                    <div class="row">

                        <div class="col-md-6 col-lg-4 mb-4" data-aos="fade-up" data-aos-delay="100">
                            <div class="teacher text-center">
                                <img src="/Static/_Index/Img/person_1.jpg" alt="Image" class="img-fluid w-50 rounded-circle mx-auto mb-4" />
                                <div class="py-2">
                                    <h3 class="text-black">Benjamin Stone</h3>
                                    <p class="position">Science Teacher</p>
                                    <p>Online education is growing exponentionally, and i believe that Certcess will be leading the charge.</p>
                                </div>
                            </div>
                        </div>

                        <div class="col-md-6 col-lg-4 mb-4" data-aos="fade-up" data-aos-delay="200">
                            <div class="teacher text-center">
                                <img src="/Static/_Index/Img/person_2.jpg" alt="Image" class="img-fluid w-50 rounded-circle mx-auto mb-4" />
                                <div class="py-2">
                                    <h3 class="text-black">Katleen Stone</h3>
                                    <p class="position">Maths Teacher</p>
                                    <p>Certcess education handles all my problems as well as include me in decision making for content creation.</p>
                                </div>
                            </div>
                        </div>

                        <div class="col-md-6 col-lg-4 mb-4" data-aos="fade-up" data-aos-delay="300">
                            <div class="teacher text-center">
                                <img src="/Static/_Index/Img/person_3.jpg" alt="Image" class="img-fluid w-50 rounded-circle mx-auto mb-4" />
                                <div class="py-2">
                                    <h3 class="text-black">Sadie White</h3>
                                    <p class="position">English Teacher</p>
                                    <p>Never thought I would have the chance to easily affect new students in a positive way.</p>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <script src="/Static/_Index/Js/jquery-3.3.1.min.js"></script>
        <script src="/Static/_Index/Js/jquery-migrate-3.0.1.min.js"></script>
        <script src="/Static/_Index/Js/jquery-ui.js"></script>
        <script src="/Static/_Index/Js/popper.min.js"></script>
        <script src="/Static/_Index/Js/bootstrap.min.js"></script>
        <script src="/Static/_Index/Js/owl.carousel.min.js"></script>
        <script src="/Static/_Index/Js/jquery.stellar.min.js"></script>
        <script src="/Static/_Index/Js/jquery.countdown.min.js"></script>
        <script src="/Static/_Index/Js/bootstrap-datepicker.min.js"></script>
        <script src="/Static/_Index/Js/jquery.easing.1.3.js"></script>
        <script src="/Static/_Index/Js/aos.js"></script>
        <script src="/Static/_Index/Js/jquery.fancybox.min.js"></script>
        <script src="/Static/_Index/Js/jquery.sticky.js"></script>


        <script src="/Static/_Index/Js/main.js"></script>

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
    </form>
</body>

</html>
