<%@ Page Title="" Language="C#" MasterPageFile="~/Static/Master/Teacher/Settings.master" AutoEventWireup="true" CodeFile="Settings.aspx.cs" Inherits="Web_Teacher_Settings" %>

<asp:Content ID="Content5" ContentPlaceHolderID="Content5" runat="Server">
    <style>
        #BodyPlaceHolder_lbtn_Basic {
            color: black;
            border-bottom: 3px solid #6AA2F3;
        }

        .fileUpload {
            position: relative;
            overflow: hidden;
            margin: 10px;
        }

            .fileUpload input.upload {
                position: absolute;
                top: 0;
                right: 0;
                margin: 0;
                padding: 0;
                font-size: 20px;
                cursor: pointer;
                opacity: 0;
                filter: alpha(opacity=0);
            }
    </style>

    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.3/jquery.min.js"></script>

    <script src="https://code.jquery.com/jquery-3.3.1.min.js"></script>
    <script src="https://unpkg.com/gijgo@1.9.13/js/gijgo.min.js" type="text/javascript"></script>
    <link href="https://unpkg.com/gijgo@1.9.13/css/gijgo.min.css" rel="stylesheet" type="text/css" />    
</asp:Content>


<asp:Content ID="Content1" ContentPlaceHolderID="Content4" runat="Server">

    <div class="d-flex flex-row flex-wrap justify-content-center pt-2">

        <div class="col-lg-6 col-sm-10" id="Content">
            <div class="form-group">
                <h3>Edit Your Profile Here </h3>
                <hr />
            </div>

            <div class="form-group">
                <label for="tb_Email">Email address</label>
                <asp:TextBox ID="tb_Email" runat="server" type="email" placeholder="Email" class="form-control" disabled="disabled"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfv1" runat="server" ErrorMessage="Please enter an email." Display="Dynamic" CssClass="invalid-feedback" ControlToValidate="tb_Email"></asp:RequiredFieldValidator>
            </div>

            <div class="form-group">
                <label for="tb_Name">Name</label>
                <asp:TextBox ID="tb_Name" runat="server" type="text" placeholder="Name" class="form-control" pattern=".{3,}"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Please enter an name." Display="Dynamic" CssClass="invalid-feedback" ControlToValidate="tb_Name"></asp:RequiredFieldValidator>
            </div>

            <div class="form-group">
                <label for="tb_DateofBirth">Date of Birth</label>
                <input id="tb_DateofBirth" type="text" runat="server" clientidmode="Static" placeholder="Date of Birth" class="form-control" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Please enter an date of birth." Display="Dynamic" CssClass="invalid-feedback" ControlToValidate="tb_DateofBirth"></asp:RequiredFieldValidator>
            </div>
        </div>

        <div id="p-2 ContentPicture">

            <div class="shadow-sm py-3 px-5 text-center">
                <div class="form-group">
                    <h3>Profile Picture</h3>
                    <small>This is how people will recognise you!</small>
                </div>

                <div class="form-group">
                    <asp:Image ID="ProfilePicture" runat="server" src="/Static/_Account/ProfilePictures/Default.png" CssClass="ProfileImage" />
                </div>

                <div class="form-group">

                    <div style="margin-top: 15px;">
                        <!-- file control css styles-->
                        <asp:FileUpload type="file" ID="FileUpload" runat="server" Style="display: none;" ClientIDMode="Static" onchange="updatemyname();" />
                        <div class="input-group">
                            <input id="fileone" type="text" class="form-control" placeholder="No file Selected" disabled="disabled"/>
                            <span class="input-group-btn">
                                <a href="javascript:void(0);" class="btn btn-info" onclick="uploadme();">Select File</a>
                            </span>
                        </div>
                    </div>

                    <br />
                    <small>This is how students identify you!</small>
                </div>

            </div>

            <div class="form-group float-lg-right mt-3 text-center">
                <asp:Button ID="btn_Submit" runat="server" Text="Change Settings" class="btn btn-warning" OnClick="btn_Submit_Click" />
            </div>
        </div>

    </div>
    <script>
        $('#tb_DateofBirth').datepicker({
            uiLibrary: 'bootstrap4',
            format: 'dd mm yyyy'
        });
    </script>

    <script type="text/javascript">

        function uploadme() {
            $('#FileUpload').click();

        }

        function splitpath(paths) {
            var st = paths.split("\\");
            return st[st.length - 1];
        } function updatemyname() {


            var varfile = document.getElementById("FileUpload");
            document.getElementById("fileone").value = splitpath(varfile.value);

        }    </script>


</asp:Content>

