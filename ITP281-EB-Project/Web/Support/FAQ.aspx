<%@ Page Title="" Language="C#" MasterPageFile="~/Static/Master/User/Template.master" AutoEventWireup="true" CodeFile="FAQ.aspx.cs" Inherits="Web_Support_FAQ" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitlePlaceHolder" runat="Server">
    FAQ
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="HeadPlaceHolder" runat="Server">
    <style>
        #lbtn_Support {
            color: black;
        }

        #banner {
            padding: 3rem;
        }

        h1 {
            font-size: 3rem;
        }

        h5 {
            font-size: 1.3rem;
        }

        @media only screen and (max-width: 900px) {
            #banner {
                padding: 3rem;
            }

            h1 {
                font-size: 2rem;
            }

            h5 {
                font-size: 1rem;
            }
        }
    </style>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="HeaderPlaceHolder" runat="Server">
    FAQs
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="BodyPlaceHolder" runat="Server">

    <div id="banner" class="container-fluid text-white" style="background-color: #001f3f; color: white;">

        <div class="container-fluid">
            <div style="text-align: center">
                <h1><b>We'd love to hear from you</b></h1>
                <h5>Whether you have a question about features, trials, pricing, need a demo, or anything else,<br />
                    our team is ready to answer all your questions</h5>
            </div>

            <div class="d-flex justify-content-center">

                <div class="d-flex flex-column">
                </div>

                <div class="d-flex flex-column">
                </div>

                <div class="d-flex flex-column pt-2 pb-0">

                    <div class="p-2">
                        <asp:Button ID="btn_Ask" runat="server" Text="Get in touch" class="btn btn-outline-primary text-white" Height="55px" Style="height: 55px; margin-left: 10px; width: 200px;" OnClick="btn_Ask_Click" />

                    </div>
                </div>
            </div>

        </div>

    </div>



    <!-- FAQ BUTTONS START HERE -->

    <div class="container my-4">

        <div class="row flex-row flex-wrap mx-0 justify-content-center">

            <div class="col-lg-5 col-sm-10 mb-2">
                <h2 class="text-secondary col-12 ">Accounts</h2>

                <button type="button" class="btn btn-light shadow-sm bg-white rounded border text-truncate w-100 mb-2" data-toggle="modal" data-target="#exampleModalCenter1">
                    I forgot my password, what do I do?
                </button>

                <!-- Modal -->
                <div class="modal fade" id="exampleModalCenter1" tabindex="-1" role="dialog" aria-labelledby="exampleModalCenterTitle" aria-hidden="true">
                    <div class="modal-dialog modal-dialog-centered" role="document">
                        <div class="modal-content">
                            <div class="modal-header">
                                <h5 class="modal-title">I forgot my password, what do I do?</h5>
                                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                    <span aria-hidden="true">&times;</span>
                                </button>
                            </div>
                            <div class="modal-body">
                                Click on Sign In in the top-right corner.
                                        Click on the Forgot Password link in the pop-up.
                                        Enter your email address in the field and click the Send me password reset instructions button.
                                        An email will be sent to your address with reset instructions.
                                        Follow the instructions in the email to create a new password.
                            </div>
                            <div class="modal-footer">
                                <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>

                            </div>
                        </div>
                    </div>
                </div>

                <button type="button" class="btn btn-light shadow-sm bg-white rounded border text-truncate w-100 mb-2" data-toggle="modal" data-target="#exampleModalCenter2">
                    My account has been deactivated, what do I do?
                </button>

                <!-- Modal -->
                <div class="modal fade" id="exampleModalCenter2" tabindex="-1" role="dialog" aria-labelledby="exampleModalCenterTitle" aria-hidden="true">
                    <div class="modal-dialog modal-dialog-centered" role="document">
                        <div class="modal-content">
                            <div class="modal-header">
                                <h5 class="modal-title">My account has been deactivated, what do I do?</h5>
                                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                    <span aria-hidden="true">&times;</span>
                                </button>
                            </div>
                            <div class="modal-body">
                                Enter your email address and password, and click Log In. If you see a message that says "Account disabled", your account is being blocked by Certcess, which means you can send in an appeal.
                            </div>
                            <div class="modal-footer">
                                <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                            </div>
                        </div>
                    </div>
                </div>
            </div>


            <div class="col-lg-5 col-sm-10 mb-2">
                <h2 class="text-secondary col-12">Customers</h2>

                <button type="button" class="btn btn-light shadow-sm bg-white rounded border text-truncate w-100 mb-2" data-toggle="modal" data-target="#exampleModalCenter3">
                    How can I get access to other contents?
                </button>

                <!-- Modal -->
                <div class="modal fade" id="exampleModalCenter3" tabindex="-1" role="dialog" aria-labelledby="exampleModalCenterTitle" aria-hidden="true">
                    <div class="modal-dialog modal-dialog-centered" role="document">
                        <div class="modal-content">
                            <div class="modal-header">
                                <h5 class="modal-title">How can I get access to other contents?</h5>
                                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                    <span aria-hidden="true">&times;</span>
                                </button>
                            </div>
                            <div class="modal-body">
                                If you are unable to reach the original course’s instructor, another way to gain access is to request that that instructor’s department course scheduling coordinator officially enroll you as an instructor, assistant lecturer, or teaching assistant for the course in USC’s Student Information Systems (SIS).  The department course scheduling coordinator is usually found in the department’s main office.  Scheduling coordinators are able to enroll additional instructors, assistant lecturers, or teaching assistants into a Blackboard course for up to four years after the course has concluded.
                            </div>
                            <div class="modal-footer">
                                <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>

                            </div>
                        </div>
                    </div>
                </div>

                <button type="button" class="btn btn-light shadow-sm bg-white rounded border text-truncate w-100 mb-2" data-toggle="modal" data-target="#exampleModalCenter3">
                    How do I upload content?
                </button>

                <!-- Modal -->
                <div class="modal fade" id="exampleModalCenter8" tabindex="-1" role="dialog" aria-labelledby="exampleModalCenterTitle" aria-hidden="true">
                    <div class="modal-dialog modal-dialog-centered" role="document">
                        <div class="modal-content">
                            <div class="modal-header">
                                <h5 class="modal-title">q8</h5>
                                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                    <span aria-hidden="true">&times;</span>
                                </button>
                            </div>
                            <div class="modal-body">
                                Question 3
                            </div>
                            <div class="modal-footer">
                                <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>

                            </div>
                        </div>
                    </div>
                </div>
            </div>


            <div class="col-lg-5 col-sm-10 mb-2">
                <h2 class="text-secondary col-12">Transactions</h2>

                <button type="button" class="btn btn-light shadow-sm bg-white rounded border text-truncate w-100 mb-2" data-toggle="modal" data-target="#exampleModalCenter4">
                    How do I get a refund? What is the duration?
                </button>

                <!-- Modal -->
                <div class="modal fade" id="exampleModalCenter4" tabindex="-1" role="dialog" aria-labelledby="exampleModalCenterTitle" aria-hidden="true">
                    <div class="modal-dialog modal-dialog-centered" role="document">
                        <div class="modal-content">
                            <div class="modal-header">
                                <h5 class="modal-title">How do I get a refund? What is the duration?
                                </h5>
                                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                    <span aria-hidden="true">&times;</span>
                                </button>
                            </div>
                            <div class="modal-body">
                                Navigate to Certcess Help and log in with your account. After you have logged in, click on A Purchase. Find the purchase you would like to refund and click on it. Select the problem you are having with the product. Next, click I'd like to request a refund.
                            </div>
                            <div class="modal-footer">
                                <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>

                            </div>
                        </div>
                    </div>
                </div>

                <button type="button" class="btn btn-light shadow-sm bg-white rounded border text-truncate w-100 mb-2" data-toggle="modal" data-target="#exampleModalCenter5">
                    What card details are needed to be paid?
                </button>

                <!-- Modal -->
                <div class="modal fade" id="exampleModalCenter5" tabindex="-1" role="dialog" aria-labelledby="exampleModalCenterTitle" aria-hidden="true">
                    <div class="modal-dialog modal-dialog-centered" role="document">
                        <div class="modal-content">
                            <div class="modal-header">
                                <h5 class="modal-title">What card details are needed to be paid?</h5>
                                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                    <span aria-hidden="true">&times;</span>
                                </button>
                            </div>
                            <div class="modal-body">
                                Name of the person or business you're paying. Six-digit sort code of the account you're paying. Eight-digit account number of the account you're paying. A payment reference (often your name or customer number) to let them know the money came from you.
                            </div>
                            <div class="modal-footer">
                                <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>

                            </div>
                        </div>
                    </div>
                </div>
            </div>


            <div class="col-lg-5 col-sm-10 mb-2">
                <h2 class="text-secondary col-12">Others</h2>


                <button type="button" class="btn btn-light shadow-sm bg-white rounded border text-truncate w-100 mb-2" data-toggle="modal" data-target="#exampleModalCenter6">
                    I reset my password but did'nt get an email
                </button>

                <!-- Modal -->
                <div class="modal fade" id="exampleModalCenter6" tabindex="-1" role="dialog" aria-labelledby="exampleModalCenterTitle" aria-hidden="true">
                    <div class="modal-dialog modal-dialog-centered" role="document">
                        <div class="modal-content">
                            <div class="modal-header">
                                <h5 class="modal-title">I reset my password but did'nt get an email</h5>
                                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                    <span aria-hidden="true">&times;</span>
                                </button>
                            </div>
                            <div class="modal-body">
                                Make sure you reset using the correct account email address. A password can only be sent to an email address that's already in the system. If you are certain that you used the correct email, make sure to check your email's spam and junk folders
                            </div>
                            <div class="modal-footer">
                                <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>

                            </div>
                        </div>
                    </div>
                </div>

                <button type="button" class="btn btn-light shadow-sm bg-white rounded border text-truncate w-100 mb-2" data-toggle="modal" data-target="#exampleModalCenter6">
                    How do I reset my password?
                </button>

                <!-- Modal -->
                <div class="modal fade" id="exampleModalCenter13" tabindex="-1" role="dialog" aria-labelledby="exampleModalCenterTitle" aria-hidden="true">
                    <div class="modal-dialog modal-dialog-centered" role="document">
                        <div class="modal-content">
                            <div class="modal-header">
                                <h5 class="modal-title">How do I reset my password?</h5>
                                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                    <span aria-hidden="true">&times;</span>
                                </button>
                            </div>
                            <div class="modal-body">
                                Go to POWr.io
                                    Click on Sign In in the top-right corner.
                                    Click on the Forgot Password link in the pop-up.
                                    Enter your email address in the field and click the Send me password reset instructions button.
                                    An email will be sent to your address with reset instructions.
                                    Follow the instructions in the email to create a new password.
                            </div>
                            <div class="modal-footer">
                                <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>

                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>

