using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class Web_Account_ExternalLogin : System.Web.UI.Page
{
    AccountClass Acc = new AccountClass();

    protected void Page_Load(object sender, EventArgs e)
    {
        string token_Id = Request.QueryString["token"];
        string action = Request.QueryString["action"];
        string email = Request.QueryString["email"];

        if (action == "Signin"){
            string result = Acc.checkEmail(email);
            if (result != "none")
            {
                Session["Current_Logged"] = result;
                Response.Redirect("~/Web/Account/Dashboard.aspx");
            }

            else
            {
                Response.Redirect(String.Format("~/Web/A/Sign_up_Google.aspx?&email={0}", email));
            }
        }
        else if (action.ToLower() == "signup")
        {

            string result = Acc.checkEmail(email);
            if (result != "none")
            {
                Session["Current_Logged"] = result;
                Response.Redirect("~/Web/Account/Dashboard.aspx");
            }

            Response.Redirect(String.Format("~/Web/A/Sign_up_Google.aspx?email={0}", email));
        }
        else if (action == "ConfirmEmail")
        {
            Response.Redirect(String.Format("~/Web/A/Confirm_Email.aspx?&token={0}", token_Id));
        }

    }
}