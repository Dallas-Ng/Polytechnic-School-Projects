<%@ Page Title="" Language="C#" MasterPageFile="~/Static/Master/User/Settings.master" AutoEventWireup="true" CodeFile="Delete_Account.aspx.cs" Inherits="Web_Account_Settings_Delete_Account" %>

<asp:Content ID="Content2" ContentPlaceHolderID="TitlePlaceHolder" runat="Server">
    Deactivate Account
</asp:Content>

<asp:Content ID="Content5" ContentPlaceHolderID="HeadPlaceHolder" runat="Server">
    <style>
        #lbtn_Delete {
            color: black;
            border-bottom: 3px solid #6AA2F3;
        }
    </style>
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="BodyPlaceHolder" runat="Server">

    <div class="row justify-content-center pt-2">

        <div class="col-lg-5 col-sm-10">

            <div class="form-group">
                <h3>Deactivate Your Certcess Account</h3>
                <hr />
                <p>We’re sorry to see you go! Before deactivating, note that deactivated accounts will lose access to any courses enrolled by that account and cannot be restored.</p>
                <p>If you’re sure you’d like to deactivate your Certcess account, there are several ways to do this depending on your subscription.</p>
                <p>You may deactivate your account at any time.</p>
            </div>

            <div class="form-group">
                <button type="button" class="btn btn-danger" data-toggle="modal" data-target="#exampleModal">
                    I UNDERSTAND, DEACTIVATE MY ACCOUNT
           
                </button>
            </div>

            <div class="modal fade" id="exampleModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
                <div class="modal-dialog" role="document">
                    <div class="modal-content">
                        
                        <div class="modal-header">
                            <h5 class="modal-title" id="exampleModalLabel">Are you sure?</h5>
                            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                <span aria-hidden="true">&times;</span>
                            </button>
                        </div>
                        
                        <div class="modal-body">
                            You may deactivate your account at any time. However, this action is irreversible.
                        </div>

                        <div class="modal-footer">
                            <asp:Button ID="btn_Delete" runat="server" OnClick="btn_Delete_Click" Text="I UNDERSTAND, DEACTIVATE MY ACCOUNT" class="btn btn-secondary" data-toggle="modal" data-target="#exampleModal" />
                            <button type="button" class="btn btn-success" data-dismiss="modal">Close</button>
                        </div>

                    </div>
                </div>
            </div>

        </div>
    </div>
</asp:Content>

