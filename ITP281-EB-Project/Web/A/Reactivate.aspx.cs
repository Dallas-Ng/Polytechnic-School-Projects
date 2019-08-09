using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Web_A_Reactivate : System.Web.UI.Page
{
    AccountClass acc = new AccountClass();

    protected void Page_Load(object sender, EventArgs e)
    {
        string Login_ID = Request.QueryString["user"];
        List<AccountClass> data = acc.retrieve(Login_ID);
        TimeSpan span = DateTime.Now.Subtract(data[0].Recent_Login);
        lbl_Days.Text = span.Days.ToString();

    }

    protected void btn_Activate_Click(object sender, EventArgs e)
    {

        string Login_ID = Request.QueryString["user"];
        if (AccountClass.ActivateAccount(Login_ID) > 0)
        {
            List<AccountClass> data = acc.retrieve(Login_ID);
            string email = data[0].Email;

            EmailClass.SendInformation(email, "You reactivate your account, if you did not do this, please contact an admin");

            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Account activated. Please log in again.');window.location ='/Web/Sign_in.aspx';", true);

        }
        else
        {
            Response.Write("<script>alert('Activation failed, please try again later.');</script>");
        }

    }

    protected void btn_SignUp_Click(object sender, EventArgs e)
    {
        string Login_ID = Request.QueryString["user"];
        List<AccountClass> data = acc.retrieve(Login_ID);
        string email = data[0].Email;
        Response.Redirect(String.Format("~/Web/A/Sign_Up_Activation.aspx?email={0}", email));
    }
}