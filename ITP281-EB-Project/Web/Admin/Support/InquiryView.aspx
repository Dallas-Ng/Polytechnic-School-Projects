<%@ Page Title="" Language="C#" MasterPageFile="~/Static/Master/Admin/Dashboard.master" AutoEventWireup="true" CodeFile="InquiryView.aspx.cs" Inherits="Web_Admin_Support_InquiryView" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitlePlaceHolder" runat="Server">
    Inquiry
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="HeadPlaceHolder" runat="Server">
    <!--
Name: TJANDRA PUTRA
Admin Number : 181110B
-->
    <style>
        #lbtn_Inquiry {
            color: white;
        }
    </style>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="BodyPlaceHolder" runat="Server">

    <div class="container">
        <h1 class="text-white mb-4 p-2 ">Inquiry Overview</h1>

        <div class="container whiteout">

            <div class="d-flex flex-row p-2">
                <asp:TextBox ID="tb_Search" runat="server" CssClass="form-control" Width="210px" placeholder=" Search Name" Style="border-radius: 0;"></asp:TextBox>
                <asp:Button ID="btn_Search" runat="server" Text="Search" CssClass="btn btn-success mr-2" OnClick="btn_Search_Click" Width="108px" Style="border-radius: 0;" />

                <asp:DropDownList ID="ddl_Subj" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddl_Subj_SelectedIndexChanged" CssClass="btn btn-outline-light dropdown-toggle ml-auto mr-2">
                    <asp:ListItem>Accounts</asp:ListItem>
                    <asp:ListItem>Transactions</asp:ListItem>
                    <asp:ListItem>Customers</asp:ListItem>
                    <asp:ListItem>Others</asp:ListItem>
                </asp:DropDownList>

                <asp:Button ID="btn_Reset" runat="server" Text="Reset" CssClass="btn btn-danger" OnClick="btn_Reset_Click" Width="108px" Style="border-radius: 0;" />
            </div>
        </div>


        <div class="table-responsive">
            <asp:GridView ID="gv_Category" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-bordered table-condensed"
                DataKeyNames="Inq_PK"
                OnRowCancelingEdit="gv_Category_RowCancelingEdit"
                OnRowDeleting="gv_Category_RowDeleting"
                OnRowEditing="gv_Category_RowEditing"
                OnRowUpdating="gv_Category_RowUpdating"
                OnSelectedIndexChanged="gv_Category_SelectedIndexChanged"
                OnPageIndexChanging="gv_Category_PageIndexChanging"
                AllowPaging="True">

                <Columns>
                    <asp:BoundField HeaderText="No." DataField="Inq_Pk" ReadOnly="true" HeaderStyle-Width="5%" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                        <HeaderStyle HorizontalAlign="Center" Width="5%"></HeaderStyle>

                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:BoundField>
                    <asp:BoundField HeaderText="Name" DataField="Inq_User" ReadOnly="true" HeaderStyle-Width="15%">
                        <HeaderStyle Width="15%"></HeaderStyle>
                    </asp:BoundField>
                    <asp:BoundField HeaderText="Subject" DataField="Inq_Subj" ReadOnly="true" HeaderStyle-Width="15%">
                        <HeaderStyle Width="15%"></HeaderStyle>
                    </asp:BoundField>
                    <asp:BoundField HeaderText="Admin Comment" DataField="Inq_Admin_Comment" HeaderStyle-Width="30%">
                        <HeaderStyle Width="30%"></HeaderStyle>
                    </asp:BoundField>
                    <asp:BoundField HeaderText="Date" DataField="Inq_Creation_Date" ReadOnly="true" HeaderStyle-Width="20%">

                        <HeaderStyle Width="20%"></HeaderStyle>
                    </asp:BoundField>

                    <asp:CommandField ShowDeleteButton="False" ShowEditButton="True" SelectText="View" ShowSelectButton="True" ItemStyle-Width="10%" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" DeleteText="Archive">

                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                        <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                    </asp:CommandField>

                    <asp:TemplateField HeaderText="" ShowHeader="False">
                        <ItemTemplate>

                            <asp:LinkButton OnClientClick="return confirm('Are you sure to delete?');" ID="LinkButton3" runat="server" CausesValidation="False" CommandName="Delete" Text="Remove"></asp:LinkButton>

                        </ItemTemplate>
                    </asp:TemplateField>

                </Columns>
            </asp:GridView>
        </div>
    </div>

    <%--    <div class="container">
        <h2><b><span class="badge badge-secondary">INQUIRY</span> <span style="font-size: 27.5px;">OVERVIEW</b></h2>
        <hr />
        <table>
            <tr>
                <td>

                    <asp:TextBox ID="tb_Search" runat="server" CssClass="form-control d-inline md-2" Width="210px" placeholder=" Search Name"></asp:TextBox>
                    <asp:Button ID="btn_Search" runat="server" Text="Search" CssClass="btn btn-success d-inline ml-2 " OnClick="btn_Search_Click" Width="108px" />
                    <asp:Button ID="btn_Reset" runat="server" Text="Reset" CssClass="btn btn-danger d-inline ml-1 " OnClick="btn_Reset_Click" Width="108px" />


                </td>

            </tr>
        </table>

        <hr />

        <asp:GridView ID="gv_Category" runat="server" AutoGenerateColumns="False" DataKeyNames="Inq_PK"
            OnRowCancelingEdit="gv_Category_RowCancelingEdit" OnRowDeleting="gv_Category_RowDeleting"
            OnRowEditing="gv_Category_RowEditing" OnRowUpdating="gv_Category_RowUpdating" CssClass="table table-striped table-bordered table-condensed"
            Height="284px" OnSelectedIndexChanged="gv_Category_SelectedIndexChanged"
            AllowPaging="True" PageSize="8" OnPageIndexChanging="gv_Category_PageIndexChanging">


            <Columns>
                <asp:BoundField HeaderText="No." DataField="Inq_Pk" ReadOnly="true" />
                <asp:BoundField HeaderText="Name" DataField="Inq_User" ReadOnly="true" />
                <asp:BoundField HeaderText="Subject" DataField="Inq_Subj" ReadOnly="true" />
                <asp:BoundField HeaderText="Admin Comment" DataField="Inq_Admin_Comment" />
                <asp:BoundField HeaderText="Date" DataField="Inq_Creation_Date" ReadOnly="true" />

                <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" HeaderText="Edit/Delete/View" SelectText="View" ShowSelectButton="True" />
            </Columns>
        </asp:GridView>
    </div>
    </span>--%>
</asp:Content>

