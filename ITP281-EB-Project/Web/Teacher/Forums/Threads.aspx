<%@ Page Title="" Language="C#" MasterPageFile="~/Static/Master/Teacher/Dashboard.master" AutoEventWireup="true" CodeFile="Threads.aspx.cs" Inherits="Web_Forums_Threads" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitlePlaceHolder" runat="Server">
    Threads
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="HeadPlaceHolder" runat="Server">
    <style>
        #lbtn_Forums {
            color: white;
        }

        body {
            margin-top: 4.5rem;
        }
    </style>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="BodyPlaceHolder" runat="Server">

    <div class="row mx-0 my-4 justify-content-center">

        <div class="col-lg-6 col-sm-10">
            <h1 class="display-4 mb-3">Threads</h1>

            <div class="table-responsive">

                <asp:GridView ID="gv_ThreadData" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                    DataKeyNames="Thread_ID"
                    OnSelectedIndexChanged="gv_ThreadData_SelectedIndexChanged"
                    CssClass="table table-striped table-bordered table-condensed">
                    <Columns>
                        <asp:BoundField DataField="Thread_ID" />                
						<asp:BoundField DataField="Thread_Title" HeaderText="Thread Title" HeaderStyle-Width="40%" ItemStyle-Width="40%" />
                        <asp:BoundField DataField="Thread_Category" HeaderText="Category" HeaderStyle-Width="40%" ItemStyle-Width="40%" />

                        <asp:CommandField ShowSelectButton="True" SelectText="View Post" HeaderStyle-Width="15%" ItemStyle-Width="15%" ItemStyle-HorizontalAlign="Center" />
                    </Columns>
                </asp:GridView>

            </div>

            <button type="button" class="btn btn-primary" data-toggle="modal" data-target="#exampleModal">Create a thread</button>

            <div class="modal fade" id="exampleModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
                <div class="modal-dialog">

                    <div class="modal-content">

                        <div class="modal-header">
                            <h3 class="modal-title">Create Thread</h3>

                            <button type="button" class="close" data-dismiss="modal">&times;</button>
                        </div>

                        <div class="modal-body">
                            <div class="form-group">
                                <label>Thread Title</label>
                                <asp:TextBox ID="tb_ThreadTitle" runat="server" placeholder="Enter Thread Title" CssClass="form-control"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfv_ThreadTitle" runat="server" ControlToValidate="tb_ThreadTitle" ErrorMessage="Please enter Thread Title" ForeColor="Red" CssClass="invalid-feedback"></asp:RequiredFieldValidator>
                            </div>

                            <div class="form-group">
                                <label>Thread Description</label>
                                <asp:TextBox ID="tb_ThreadDesc" runat="server" placeholder="Enter Thread Description" CssClass="form-control"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfv_ThreadDesc" runat="server" ControlToValidate="tb_ThreadDesc" ErrorMessage="Please enter Thread Description" ForeColor="Red" CssClass="invalid-feedback"></asp:RequiredFieldValidator>
                            </div>

                            <div class="form-group">
                                <label>Thread Category</label>
                                <asp:DropDownList ID="ddl_ThreadCategory" runat="server" CssClass="form-control">
                                    <asp:ListItem>None</asp:ListItem>
                                    <asp:ListItem>General Discussion</asp:ListItem>
                                    <asp:ListItem>Video</asp:ListItem>
                                    <asp:ListItem>English</asp:ListItem>
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="rfv_ThreadCategory" runat="server" InitialValue="None" ControlToValidate="ddl_ThreadCategory" ErrorMessage="Please select Thread Category" ForeColor="Red" CssClass="invalid-feedback"></asp:RequiredFieldValidator>
                            </div>

                        </div>
                        <div class="modal-footer">
                            <asp:Button ID="btn_Add" runat="server" CssClass="btn btn-primary" Text="Create" OnClick="btn_Add_Click" />
                            <button type="button" class="btn btn-danger" data-dismiss="modal">Close</button>
                        </div>
                    </div>

                </div>
            </div>
        </div>

    </div>

</asp:Content>

