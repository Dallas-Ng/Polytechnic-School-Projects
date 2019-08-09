<%@ Page Title="" Language="C#" MasterPageFile="~/Static/Master/Admin/Dashboard.master" AutoEventWireup="true" CodeFile="Notification_Admin.aspx.cs" Inherits="Web_Admin_Support_Notification_Admin_NEW" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitlePlaceHolder" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="HeadPlaceHolder" runat="Server">
    <style>
        /* Style the "Add" button */
        .addBtn {
            padding: 10px;
            background: #d9d9d9;
            color: #555;
            text-align: center;
            font-size: 16px;
            cursor: pointer;
            transition: 0.3s;
            border-radius: 0;
        }

            .addBtn:hover {
                background-color: #bbb;
            }

        hr {
            border-top: 1px solid white;
        }


        #lbtn_Notifications {
            color: white;
        }

        /* Add a "checked" mark when clicked on */
    </style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="BodyPlaceHolder" runat="Server">

    <div class="container">
        <h1 class="text-white mb-4 p-2 ">Make an Announcement</h1>
    </div>

    <div class="container">
        <div class="row flex-wrap justify-content-center">

            <div class="col-lg-6 col-sm-10 ">
                <div class="card text-white whiteout mb-3" style="min-height: 500px;">
                    <div class="card-header whiteout text-white">
                        Announcements  
                    </div>

                    <div class="card-body">
                        <div class="d-flex flex-row">
                            <a class="btn btn-light mr-1 disabled" style="width: 121px; margin-left: 60px;" data-toggle="collapse" href="#collapseExample1" role="button" aria-expanded="false" aria-controls="collapseExample"><b>Promotions</b></a>

                            <a class="btn btn-light mr-1 disabled" style="width: 124px; margin-left: 5px;" data-toggle="collapse" href="#collapseExample1" role="button" aria-expanded="false" aria-controls="collapseExample"><b>Maintenance</b></a>

                            <a class="btn btn-light mr-1 disabled" style="width: 121px; margin-left: 5px;" data-toggle="collapse" href="#collapseExample1" role="button" aria-expanded="false" aria-controls="collapseExample"><b>Rewards</b></a>
                        </div>

                        <hr />

                        <asp:TextBox ID="tb_Notification" runat="server" Height="260px" TextMode="MultiLine" CssClass="form-control" ToolTip="Enter Message" cols="25" placeholder="Write a message. . ." required="required"></asp:TextBox>
                        <br />
                        <asp:Button ID="btn_Send" runat="server" OnClick="btn_Send_Click" Text="Send" CssClass="btn btn-success" Width="150px" />&nbsp
                        <asp:RequiredFieldValidator ID="rqv_Notification" runat="server" ErrorMessage="Please enter a message" ControlToValidate="tb_Notification" ForeColor="White" Display="Dynamic"></asp:RequiredFieldValidator><br />

                    </div>
                </div>
            </div>

            <div class="col-lg-6 col-sm-10">
                <div class="card whiteout" style="min-height: 500px;">
                    <div class="card-header whiteout text-white text-wrap">History (Latest)</div>
                    <div class="card-body">
                        <asp:GridView ID="gv_Notification" runat="server" AutoGenerateColumns="False" DataKeyNames="Notification_PK" CssClass="table table-striped table-bordered table-condensed " AllowPaging="True" OnPageIndexChanging="gv_Notification_PageIndexChanging" PageSize="3" OnRowDeleting="gv_Notification_RowDeleting">
                            <Columns>
                                <asp:BoundField DataField="Notification_CreationDate" HeaderText="Date" ItemStyle-Width="20%"/>
                                <asp:BoundField DataField="Notification_Msg" HeaderText="Announcement" ItemStyle-Width="60%"/>
                                <asp:CommandField ShowDeleteButton="True" ItemStyle-Width="10%"/>
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

