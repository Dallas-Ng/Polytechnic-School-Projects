<%@ Page Title="" Language="C#" MasterPageFile="~/Static/Master/User/Template.master" AutoEventWireup="true" CodeFile="Courses.aspx.cs" Inherits="Web_Classroom_Courses" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitlePlaceHolder" runat="Server">
    My Courses
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="HeadPlaceHolder" runat="Server">
    <style>
        #lbtn_MyCourses {
            color: black;
        }
        .card {
            width: 250px;
        }
        @media only screen and (max-width: 900px) {
            .card img {
                display: none;
            }
            .card {
                width: 300px;
            }
            h1 {
                text-align: center;
            }
        }
    </style>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="HeaderPlaceHolder" runat="Server">
    Courses
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="BodyPlaceHolder" runat="Server">

    <div class="row justify-content-center p-4" style="margin-left: 0px; margin-right: 0px;">
        <div class="col-lg-10 col-sm-10">
            <h1 class="display-4">My Courses
            </h1>

            <div class="text-center container" id="CoursesBanner" runat="server">
                <h4 class="text-center" style="font-size: 2em;">No courses enrolled</h4>
                <br />
                <asp:LinkButton ID="LinkButton4" runat="server" OnClick="lbtn_Courses_Click">Click here to see courses</asp:LinkButton>
            </div>

            <div class="d-flex flex-wrap justify-content-center p-2">

                <asp:Repeater ID="Re1" runat="server">
                    <ItemTemplate>
                        <a href="../Classroom/Course.aspx?Course_ID=<%#Eval("Course_ID")%>" class="text-decoration-none">
                            <div class="card m-1">
                                <img class="card-img-top" src="../../Static/_Account/Img/Dashboard/FAQ.png" alt="Card image cap" style="background-color: silver;" />

                                <div class="card-body text-wrap">
                                    <h5 class="card-title">
                                        <asp:Label ID="Label6" runat="server" Text='<%#Eval("Course_Title")%>'></asp:Label>
                                    </h5>

                                    <p class="card-text">
                                        <asp:Label ID="Label4" runat="server" Text='<%#Eval("Course_Desc")%>'></asp:Label>
                                    </p>

                                    <p>
                                        $<asp:Label ID="Label1" runat="server" Text='<%#Eval("Course_Fee")%>'></asp:Label>
                                    </p>
                                </div>

                                <div class="card-footer">
                                    <small class="text-muted">Last Updated:
                                           
                                        <asp:Label ID="Label3" runat="server" Text='<%#Eval("Course_Upload_Date")%>'></asp:Label>
                                    </small>
                                </div>
                            </div>
                        </a>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>
    </div>

</asp:Content>

