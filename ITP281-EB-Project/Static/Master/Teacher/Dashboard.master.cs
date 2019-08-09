using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Static_Master_Teacher_Dashboard : System.Web.UI.MasterPage
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

    protected void lbtn_Home_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Web/Teacher/Dashboard.aspx");
    }

    protected void lbtn_Courses_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Web/Teacher/Courses/Courses.aspx");
    }

    protected void lbtn_Payment_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Web/Teacher/Payment.aspx");
    }

    protected void lbtn_Forums_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Web/Teacher/Forums/Forums.aspx");
    }

    protected void lbtn_Settings_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Web/Teacher/Settings.aspx");
    }

    protected void logout(object sender, EventArgs e)
    {
        Session["Current_Logged"] = "";
        Response.Redirect("~/Index.aspx");
    }
}
