<%@ Page Title="" Language="C#" MasterPageFile="~/Static/Master/Admin/Dashboard.master" AutoEventWireup="true" CodeFile="ThreadDetails.aspx.cs" Inherits="Web_Admin_Forum_ThreadDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitlePlaceHolder" runat="Server">
    View Posts
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="HeadPlaceHolder" runat="Server">
    <style>
        #lbtn_Forums {
            color: white;
        }
    </style>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="BodyPlaceHolder" runat="Server">

    <div class="container">
        <h1 class="text-white mb-4 p-2">Viewing Posts
        </h1>

        <div class=" p-2 my-2" style="background-color: #ececec">

            <div class="shadow p-4 b-white">
                <div class="my-2">
                    <h4>Thread Title:
               
                        <asp:Label ID="lblThreadTitle" runat="server" Text='<%#Eval("Thread_Title") %>' Enabled="false"></asp:Label></h4>
                </div>

                <div class="my-2">
                    Thread Description:
               
                    <asp:Label ID="lblThreadDesc" runat="server" Text='<%#Eval("Thread_Desc") %>' Enabled="false"></asp:Label>
                </div>
            </div>

            <div class="form-control my-2">
                Thread Creation Date:
               
                <asp:Label ID="lblThreadCreationDate" runat="server" Text='<%#Eval("Thread_CreationDate") %>' Enabled="false" Style="max-width: 250px;"></asp:Label>
            </div>

        </div>


        <div class="b-white">
            <asp:GridView ID="gv_PostData" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-bordered table-condensed" GridLines="None" DataKeyNames="Post_ID" OnRowDeleting="gv_PostData_RowDeleting" AllowPaging="True" OnPageIndexChanging="gv_PostData_PageIndexChanging">
                <Columns>
                    <asp:BoundField DataField="Post_Msg" HeaderText="Post Message" ItemStyle-Width="60%" ItemStyle-CssClass="text-wrap"/>
                    <asp:BoundField DataField="User_ID" HeaderText="User" ItemStyle-Width="20%"/>
                    <asp:CommandField ShowDeleteButton="True" ItemStyle-Width="10%"/>
                </Columns>
            </asp:GridView>
        </div>


        <div class="row mx-0 justify-content-between">

            <asp:Button ID="btn_Back" runat="server" Text="Back" CssClass="btn btn-danger" OnClick="btn_Back_Click" Width="100px" CausesValidation="false" />

            <!--  <button type="button" class="btn btn-primary" data-toggle="modal" data-target="#PostModal">Post Reply</button>

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
                    </div>

                </div>
            </div>
            </div> -->
        </div>

        <%--<div class="container">
        <h4>Thread / Post </h4>
        <hr />

        <h4><b>Thread Title:
            <asp:Label ID="lblThreadTitle" runat="server" Text='<%#Eval("Thread_Title") %>'></asp:Label></b></h4>
        <br />
        Thread Description:
        <asp:Label ID="lblThreadDesc" runat="server" Text='<%#Eval("Thread_Desc") %>'></asp:Label>
        <br />
        Thread Creation Date: 
        <asp:Label ID="lblThreadCreationDate" runat="server" Text='<%#Eval("Thread_CreationDate") %>'></asp:Label>
        <hr />
        <!--  <asp:Repeater ID="Rp_ThreadData" runat="server" EnableViewState="False" OnItemCommand="rp_ThreadData_ItemCommand">
          <ItemTemplate>  
                    <table>  
                         <tr> 
                            <td></td>
                            <td> Post Title:
                                <asp:Label ID="lblPostTitle" runat="server" Text='<%#Eval("Post_Title") %>'></asp:Label>
                            </td> 
                        </tr>
                        <tr> 
                            <td></td>
                            <td> Post Msg:
                                <asp:Label ID="lblPostMsg" runat="server" Text='<%#Eval("Post_Msg") %>'></asp:Label>
                            </td> 
                        </tr>
                        <tr>    
                            <td></td>
                            <td> post Reply:
                                <asp:Label ID="lblPostReply" runat="server" Text='<%#Eval("Post_Reply") %>'></asp:Label>
                            </td> 
                        </tr>                    
                    </table>
                   <asp:LinkButton ID="btnDeletePost" CommandName="Delete" CommandArgument='<%#Eval("Post_ID") %>' runat="server">Delete</asp:LinkButton>
                <hr /> 
            </ItemTemplate>
     </asp:Repeater> -->

        <asp:GridView ID="gv_PostData" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered" Width="862px" DataKeyNames="Post_ID" Style="margin-left: 0px" OnRowDeleting="gv_PostData_RowDeleting">
            <Columns>
                <asp:BoundField DataField="Post_Title" HeaderText="Post Title" />
                <asp:BoundField DataField="Post_Msg" HeaderText="Post Message" />
                <asp:BoundField DataField="Post_Reply" HeaderText="Post Reply" />
                <asp:CommandField ShowDeleteButton="True" />
            </Columns>
        </asp:GridView>
        <br />
        <hr />
        <br />
        <br />
        <button type="button" class="btn btn-Default" data-toggle="modal" data-target="#PostModal">Post Reply</button>

        <!-- Modal -->
        <div class="modal fade" id="PostModal" role="dialog">
            <div class="modal-dialog">

                <!-- Modal content-->
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal">&times;</button>
                        <h6 class="modal-title">Post Reply</h6>
                    </div>
                    <div class="modal-body">
                        <table class="table table-bordered" style="width=auto">
                            <tr>
                                <td class="auto-style3">Enter Title:</td>
                                <td class="auto-style4">
                                    <asp:TextBox ID="tb_PostTitle" runat="server" Width="225px"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfv_PostTitle" runat="server" ControlToValidate="tb_PostTitle" ErrorMessage="Please enter Post Title" ForeColor="Red"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style3">Enter Post Msg:</td>
                                <td class="auto-style4">
                                    <asp:TextBox ID="tb_PostMsg" runat="server" Width="223px"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfv_PostMsg" runat="server" ControlToValidate="tb_PostMsg" ErrorMessage="Please enter Post Message" ForeColor="Red"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style3">Enter Post Reply:</td>
                                <td class="auto-style4">
                                    <asp:TextBox ID="tb_PostReply" runat="server" Width="223px" TextMode="MultiLine"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfv_PostReply" runat="server" ControlToValidate="tb_PostReply" ErrorMessage="Please enter Post Reply" ForeColor="Red"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div class="modal-footer">
                        <asp:Button ID="btn_Post" runat="server" CssClass="btn btn-default" Text="Submit" Width="157px" OnClick="btn_Post_Click" />
                        <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                    </div>
                </div>

            </div>
        </div>
        <br />
        <br />
        <asp:Button ID="btn_Back" runat="server" Text="Back" CssClass="btn btn-Default" OnClick="btn_Back_Click" Height="40px" Width="144px" CausesValidation="false" />

    </div>


    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.3/jquery.min.js">

    </script>
    <script src="bootstrap/js/bootstrap.min.js"></script>--%>
    </div>
</asp:Content>

