<%@ Page Title="" Language="C#" MasterPageFile="~/Static/Master/Teacher/Settings.master" AutoEventWireup="true" CodeFile="Documents.aspx.cs" Inherits="Web_Teacher_Settings_Documents" %>

<asp:Content ID="Content5" ContentPlaceHolderID="Content5" runat="Server">
    <style>
        #BodyPlaceHolder_lbtn_Documents {
            color: black;
            border-bottom: 3px solid #6AA2F3;
        }
    </style>
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="Content4" runat="Server">

    <div class="d-flex justify-content-center">
        <div class="col-sm-10 col-lg-6">
            <div class="form-group">
                <h3>View Documents</h3>
                <hr />
                <small>If there is a need to update documents, please contact an admin.</small>
                <br />
            </div>

            <asp:Label ID="lbl_Certification" Text="Certification" runat="server"></asp:Label>
            <div class="form-group">
                <button type="button" class="btn btn-primary" data-toggle="modal" data-target="#exampleModal1">
                    View certification
                </button>

                <!-- Modal -->
                <div class="modal fade" id="exampleModal1" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
                    <div class="modal-dialog" role="document">
                        <div class="modal-content">
                            <asp:Image ID="Certification" runat="server" />
                        </div>
                    </div>
                </div>
            </div>

            <asp:Label ID="lbl_Identification" Text="Identification" runat="server"></asp:Label>

            <div class="form-group">
                <button type="button" class="btn btn-primary" data-toggle="modal" data-target="#exampleModal2">
                    View Identification
                </button>

                <!-- Modal -->
                <div class="modal fade" id="exampleModal2" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
                    <div class="modal-dialog" role="document">
                        <div class="modal-content">
                            <asp:Image ID="Identification" runat="server" />

                        </div>
                    </div>
                </div>
            </div>

        </div>

    </div>
    </div>

</asp:Content>

