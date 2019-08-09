<%@ Page Title="" Language="C#" MasterPageFile="~/Static/Master/User/Template.master" AutoEventWireup="true" CodeFile="Courses.aspx.cs" Inherits="Web_Shop_Courses" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitlePlaceHolder" runat="Server">
    Courses
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="HeadPlaceHolder" runat="Server">
    <style>
        #lbtn_Courses {
            color: black;
        }

        .Fixed {
            position: fixed;
            top: 5rem;
            right: 20px;
            min-height: 500px;
            background-color: white;
        }

        body {
            background-color: rgb(241, 241, 241);
            width: 100%;
        }

        @media only screen and (max-width: 800px) {
            .card-img-top {
                display: none;
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
            <h1 class="display-4">Courses
            </h1>
            <hr />

            <div class="d-flex flex-wrap justify-content-sm-center justify-content-lg-center">
                <div class="p-2 px-lg-2 px-sm-0">
                    <h4>Filter By: </h4>
                </div>

                <div class="p-2 px-lg-2 px-sm-0">
                    <div class="dropdown">
                        <button class="btn btn-primary dropdown-toggle" type="button" id="dropdownMenuButton" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false" style="width: 100px;">
                            Subject
                           
                        </button>
                        <div class="dropdown-menu" aria-labelledby="dropdownMenuButton">
                            <a class="dropdown-item" href="Courses.aspx?filter=none">None</a>
                            <a class="dropdown-item" href="Courses.aspx?filter=maths">Maths</a>
                            <a class="dropdown-item" href="Courses.aspx?filter=english">English</a>
                            <a class="dropdown-item" href="Courses.aspx?filter=science">Science</a>
                            <a class="dropdown-item" href="Courses.aspx?filter=geography">Geography</a>

                        </div>
                    </div>
                </div>

                <div class="p-2 px-lg-2 px-sm-0">
                    <div class="dropdown">
                        <button class="btn btn-primary dropdown-toggle" type="button" id="dropdownMenuButton2" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false" style="width: 100px;">
                            Price
                           
                        </button>
                        <div class="dropdown-menu" aria-labelledby="dropdownMenuButton">
                            <asp:LinkButton ID="LinkButton2" runat="server" CssClass="dropdown-item" OnClick="LinkButton2_Click">Ascending</asp:LinkButton>
                            <asp:LinkButton ID="LinkButton3" runat="server" CssClass="dropdown-item" OnClick="LinkButton3_Click">Descending</asp:LinkButton>
                        </div>
                    </div>
                </div>

                <div class="p-2 px-lg-2 px-sm-0">
                    <asp:Button ID="btn_Reset_Filter" runat="server" Text="Reset" CssClass="btn btn-info" OnClick="btn_Reset_Filter_Click" Style="width: 100px;" />
                </div>

                <div class="ml-auto p-2 px-lg-2 px-sm-0">
                    <asp:Button runat="server" ID="btn_Cart" CssClass="btn btn-success" Text="View Cart" OnClick="btn_Cart_Click" />
                </div>

            </div>

            <hr />


            <div class="d-flex flex-wrap justify-content-center p-2">

                <asp:Repeater ID="Re1" runat="server">
                    <ItemTemplate>

                        <div class="card m-1">
                            <img class="card-img-top" src="../../Static/_Account/Img/Dashboard/FAQ.png" alt="Card image cap" style="width: 250px; height: 180px; background-color: silver;" />

                            <div class="card-body text-wrap" style="width: 250px;">
                                <h5 class="card-title " >
                                    <asp:Label ID="Label6" runat="server" Text='<%#Eval("Course_Title")%>'></asp:Label>
                                </h5>

                                <p class="card-text">
                                    <asp:Label ID="Label4" runat="server" Text='<%#Eval("Course_Desc")%>'></asp:Label>
                                </p>

                                <p>
                                    $<asp:Label ID="Label1" runat="server" Text='<%#Eval("Course_Fee")%>'></asp:Label>
                                </p>

                                <asp:LinkButton ID="LinkButton1" runat="server" OnClick="Btn_Add_Click" CommandArgument='<%#Eval("Course_ID")%>' CommandName="ThisBtnClick" CssClass="Card-link">Add to cart</asp:LinkButton>

                            </div>

                            <div class="card-footer">
                                <small class="text-muted">Last Updated:
                                           
                                        <asp:Label ID="Label3" runat="server" Text='<%#Eval("Course_Upload_Date")%>'></asp:Label>
                                </small>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>
    </div>
</asp:Content>
