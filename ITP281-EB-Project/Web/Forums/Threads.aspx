<%@  Language="C#" MasterPageFile="~/Static/Master/User/Template.master" AutoEventWireup="true" CodeFile="Threads.aspx.cs" Inherits="Web_Forums_Threads" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitlePlaceHolder" runat="Server">
    Threads
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="HeadPlaceHolder" runat="Server">
    <style>
        #lbtn_Forums {
            color: black;
        }

        body {
            background-color: #ececec;
        }
    </style>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="HeaderPlaceHolder" runat="Server">
    Threads
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="BodyPlaceHolder" runat="Server">

    <div class="row mx-0 mb-5 justify-content-center">

        <div class="col-lg-8 col-sm-12 my-2" style="background-color: white;">
            <div class="shadow p-3 my-2">
                <h1 class="display-3 mb-4">
                    <asp:Label ID="Title" runat="server"></asp:Label></h1>
                <p>
                    <asp:Label ID="Desc" runat="server"></asp:Label>
                </p>
            </div>

            <div class="table-responsive">

                <asp:GridView ID="gv_ThreadData" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                    DataKeyNames="Thread_ID"
                    OnSelectedIndexChanged="gv_ThreadData_SelectedIndexChanged"
                    CssClass="table table-striped table-bordered table-condensed">
                    <Columns>
                        <asp:BoundField DataField="Thread_ID" />                
                        <asp:BoundField DataField="Thread_Title" HeaderText="Topics" HeaderStyle-Width="40%" ItemStyle-Width="40%">
                            <HeaderStyle Width="40%"></HeaderStyle>

                            <ItemStyle Width="40%"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="Thread_Category" HeaderText="Category" HeaderStyle-Width="40%" ItemStyle-Width="40%">

                            <HeaderStyle Width="40%"></HeaderStyle>

                            <ItemStyle Width="40%"></ItemStyle>
                        </asp:BoundField>

                        <asp:CommandField ShowSelectButton="True" SelectText="View" HeaderStyle-Width="15%" ItemStyle-Width="15%" ItemStyle-HorizontalAlign="Center">
                            <HeaderStyle Width="15%"></HeaderStyle>

                            <ItemStyle HorizontalAlign="Center" Width="15%"></ItemStyle>
                        </asp:CommandField>
                    </Columns>
                </asp:GridView>

            </div>

            <button type="button" class="btn btn-primary mb-2" data-toggle="modal" data-target="#exampleModal">Create a Topic</button>

            <div class="modal fade" id="exampleModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
                <div class="modal-dialog modal-lg">

                    <div class="modal-content">

                        <div class="modal-header">
                            <h3 class="modal-title">Create Topic</h3>

                            <button type="button" class="close" data-dismiss="modal">&times;</button>
                        </div>

                        <div class="modal-body">
                            <div class="form-group">
                                <label>Title</label>
                                <asp:TextBox ID="tb_ThreadTitle" runat="server" placeholder="Enter Title" CssClass="form-control"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfv_ThreadTitle" runat="server" ControlToValidate="tb_ThreadTitle" ErrorMessage="Please enter Title" ForeColor="Red" CssClass="invalid-feedback"></asp:RequiredFieldValidator>
                            </div>

                            <div class="form-group">
                                <label>Description</label>
                                <asp:TextBox ID="tb_ThreadDesc" runat="server" placeholder="Enter Description" CssClass="form-control"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfv_ThreadDesc" runat="server" ControlToValidate="tb_ThreadDesc" ErrorMessage="Please enter Description" ForeColor="Red" CssClass="invalid-feedback"></asp:RequiredFieldValidator>
                            </div>

                            <div class="form-group">
                                <label>Category</label>
                                <asp:DropDownList ID="ddl_ThreadCategory" runat="server" CssClass="form-control">
                                    <asp:ListItem>English</asp:ListItem>
                                    <asp:ListItem>Mathematics</asp:ListItem>
                                    <asp:ListItem>Science</asp:ListItem>
                                    <asp:ListItem>General Discussion</asp:ListItem>
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="rfv_ThreadCategory" runat="server" InitialValue="None" ControlToValidate="ddl_ThreadCategory" ErrorMessage="Please select Category" ForeColor="Red" CssClass="invalid-feedback"></asp:RequiredFieldValidator>
                            </div>

                        </div>
                        <div class="modal-footer">
                            <asp:Button ID="btn_Add" runat="server" CssClass="btn btn-primary" Text="Create" OnClick="btn_Add_Click" />
                            <button type="button" class="btn btn-danger" data-dismiss="modal">Close</button>
                        </div>
                        <asp:ValidationSummary ID="ValidationSummary" runat="server" Font-Bold="True" ForeColor="Red" />
                    </div>

                </div>
            </div>

        </div>

    </div>

</asp:Content>

