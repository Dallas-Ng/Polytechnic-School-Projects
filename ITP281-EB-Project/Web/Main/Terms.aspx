<%@ Page Title="" Language="C#" MasterPageFile="~/Static/Master/User/Template.master" AutoEventWireup="true" CodeFile="Terms.aspx.cs" Inherits="Web_Main_Terms" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitlePlaceHolder" runat="Server">
    Terms and Conditions
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="HeadPlaceHolder" runat="Server">
    <style>

        .container {
            width: 50vw;
            padding: 3% 0;
        }

        h4 {
            margin-bottom: 2vh;
        }

        p {
            margin-bottom: 3vh;
        }

        @media screen and (max-width: 1200px), (min-height: 1080px) {
            .container {
                width: 80vw;
            }
        }

        #lbtn_Support {
            color: black;
        }
    </style>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="HeaderPlaceHolder" runat="Server">
    Terms
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="BodyPlaceHolder" runat="Server">

    <div class="jumbotron text-center">
        <h1 class="display-4">Terms and Conditions</h1>
        <small>Last modified: July 6, 2019 </small>
    </div>

    <div class="container">
        <h4>Welcome to Certcess!</h4>

        <p>Thanks for using our services. The services are provided by Certcess Company.</p>

        <p>By using our services, you are agreeing to these terms. Please read them carefully.</p>

        <p>
            Our Services are very diverse, so sometimes additional terms or product requirements (including age requirements) may apply. 
            Additional terms will be available with the relevant Services, and those additional terms become part of your agreement with us if you use those Services.
        </p>
    </div>

    <div class="container">
        <h4>Using our Services</h4>

        <p>You must follow any policies made available to you within the services</p>

        <p>
            Don’t misuse our Services. For example, don’t interfere with our Services or try to access them using a method other than the interface and the instructions that we provide.
            You may use our Services only as permitted by law, including applicable export and re-export control laws and regulations. 
            We may suspend or stop providing our Services to you if you do not comply with our terms or policies or if we are investigating suspected misconduct. 
        </p>

        <p>
            Using our Services does not give you ownership of any intellectual property rights in our Services or the content you access. 
            You may not use content from our Services unless you obtain permission from its owner or are otherwise permitted by law. 
            These terms do not grant you the right to use any branding or logos used in our Services. 
            Don’t remove, obscure, or alter any legal notices displayed in or along with our Services.
        </p>

        <p>
            Our Services display some content that is not Certcess’s. This content is the sole responsibility of the entity that makes it available. 
            We may review content to determine whether it is illegal or violates our policies, and we may remove or refuse to display content that we reasonably believe violates our policies or the law. 
            But that does not necessarily mean that we review content, so please don’t assume that we do.
        </p>

        <p>
            In connection with your use of the Services, we may send you service announcements, administrative messages, and other information. 
            You may opt out of some of those communications.
        </p>

        <p>
            Some of our Services are available on mobile devices. 
            Do not use such Services in a way that distracts you and prevents you from obeying traffic or safety laws.
        </p>
    </div>

    <div class="container">
        <h4>Privacy and Copyright Protection</h4>

        <p>
            Certcess’s privacy policies explain how we treat your personal data and protect your privacy when you use our Services. 
            By using our Services, you agree that Google can use such data in accordance with our privacy policies.
        </p>

        <p>
            We respond to notices of alleged copyright infringement and terminate accounts of repeat infringers according to the process set out in the SG Digital Millennium Copyright Act.
        </p>

        <p>
            We provide information to help copyright holders manage their intellectual property online. 
            If you think somebody is violating your copyrights and want to notify us, you can find information about submitting notices and Certcess’s policy about responding to notices in our Help Center.
        </p>
    </div>

    <div class="container text-center" style="border-bottom: none">
        <p>For information about how to contact Certcess, please visit our <a href="#" class="text-decoration-none">support page</a>.</p>
    </div>

</asp:Content>

