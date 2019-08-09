using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Static_Master_Teacher_Settings : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Current_Logged"] == null || Session["Current_Logged"].ToString() == "")
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Login session expired. Please sign in again.');window.location ='/Index.aspx';", true);
        }
        else
        {
            string User = Session["Current_Logged"].ToString();
            AccountClass Checker = new AccountClass();
            List<AccountClass> Data = Checker.retrieve(User);
            if (Data.Any())
            {
                if (Data[0].Role == "student")
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('You do not have permission to view this page.');window.location ='/Web/Account/Dashboard.aspx';", true);
                }
                else if (Data[0].Role == "admin")
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('You do not have permission to view this page.');window.location ='/Web/Admin/Dashboard.aspx';", true);
                }
            }
        }
    }

    protected void lbtn_Basic_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Web/Teacher/Settings.aspx");
    }

    protected void lbtn_Password_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Web/Teacher/Settings/Change_Password.aspx");
    }

    protected void lbtn_Payment_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Web/Teacher/Settings/Payment.aspx");
    }

    protected void lbtn_Document_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Web/Teacher/Settings/Documents.aspx");
    }

    protected void lbtn_Contact_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Web/Teacher/Settings/Contact.aspx");
    }
}
