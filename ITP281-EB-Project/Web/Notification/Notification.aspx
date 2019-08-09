<%@ Page Title="" Language="C#" MasterPageFile="~/Static/Master/User/Template.master" AutoEventWireup="true" CodeFile="Notification.aspx.cs" Inherits="Web_Notification_1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitlePlaceHolder" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="HeadPlaceHolder" runat="Server">
    <style>
        #clock {
            width: 100%;
            font-size: 3vw;
        }

        .table {
            box-shadow: 3px 3px 3px 3px #ccc;
            font-family: 'Open Sans', sans-serif;
        }

            .table th {
            }

        h2 {
            font-family: 'Open Sans', sans-serif;
        }

        h3 {
            font-family: 'Open Sans', sans-serif;
        }

        p {
            font-family: 'Open Sans', sans-serif;
        }

        .table td:hover {
            background-color: #FFF842;
            color: #403E10;
            box-shadow: #7F7C21 -1px 1px, #7F7C21 -2px 2px, #7F7C21 -3px 3px, #7F7C21 -4px 4px, #7F7C21 -5px 5px, #7F7C21 -6px 6px;
            transform: translate3d(6px, -6px, 0);
            transition-delay: 0s;
            transition-duration: 0.4s;
            transition-property: all;
            transition-timing-function: line;
        }
    </style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="HeaderPlaceHolder" runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="BodyPlaceHolder" runat="Server">

    <div class="row justify-content-center pt-2 my-3">
        <div class="col-lg-5 col-sm-10">

            <div class="form-group">
                <h2>Notifications</h2>
                <hr />

                <%--            <div class="col-lg-5 col-sm-10 rounded text-center text-white" style="box-shadow: 3px 3px 3px 3px #ccc;background-color: #001f3f">
                <small>
                    <body onload="startTime()">

                        <div id="clock"></div>
                </small>
            </div>--%>

                <p><b>Latest Notification in Real Time</b></p>

                <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>

                <asp:UpdatePanel ID="UpdatePanel1" style="font-weight: 700; text-transform: uppercase; color: #FB667A; box-shadow: 3px 3px 3px 3px #ccc;" cssClass="rounded" runat="server">
                    <ContentTemplate>
                        <asp:Panel ID="Panel1" runat="server" Visible="False">
                            <asp:Label ID="lbl_Notification" runat="server"></asp:Label>
                        </asp:Panel>

                        <asp:Timer ID="Timer1" runat="server" Interval="1" OnTick="Timer1_Tick"></asp:Timer>
                    </ContentTemplate>
                </asp:UpdatePanel>

                <hr />

                <p><b>Notification History</b></p>

                <asp:GridView ID="gv_Notification" runat="server" AutoGenerateColumns="False" DataKeyNames="Notification_PK" CssClass="table table-striped table-bordered table-condensed " AllowPaging="True" OnPageIndexChanging="gv_Notification_PageIndexChanging" PageSize="3">
                    <Columns>
                        <asp:BoundField DataField="Notification_CreationDate" HeaderText="Date" />
                        <asp:BoundField DataField="Notification_Msg" HeaderText="Announcement" />
                    </Columns>
                </asp:GridView>
            </div>
        </div>

        <div id="p-2 ContentPicture" style="margin-top: 65px;">

            <div class="shadow py-3 px-5 text-center">
                <div class="form-group">
                    <h3 style="font-weight: 300;">Time</h3>
                    <hr />
                    <body onload="startTime()">

                        <div id="clock"></div>

                        <hr />
                        <div class="container-fluid">
                            <p>
                                WELCOME!



                            </p>
                        </div>
                    </>
                </div>

            </div>
        </div>




    </div>






    <script>
        function startTime() {
            var today = new Date();
            var h = today.getHours();
            var m = today.getMinutes();
            var s = today.getSeconds();
            m = checkTime(m);
            s = checkTime(s);
            document.getElementById('clock').innerHTML =
            h + ":" + m + ":" + s;
            var t = setTimeout(startTime, 500);
        }
        function checkTime(i) {
            if (i < 10) { i = "0" + i };  // add zero in front of numbers < 10
            return i;
        }
    </script>

</asp:Content>

