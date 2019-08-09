using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Static_Master_User_Template : System.Web.UI.MasterPage
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
                if (Data[0].Role == "teacher")
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('You do not have permission to view this page.');window.location ='/Web/Teacher/Dashboard.aspx';", true);
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
        Response.Redirect("~/Web/Account/Dashboard.aspx");
    }

    protected void lbtn_Forums_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Web/Forums/Forums.aspx");
    }

    protected void lbtn_Courses_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Web/Shop/Courses.aspx");
    }

    protected void lbtn_MyCourses_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Web/Classroom/Courses.aspx");
    }

    protected void lbtn_Settings_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Web/Account/Settings.aspx");
    }

    protected void btn_Logout_Click(object sender, EventArgs e)
    {
        Session.Clear();
        Response.Redirect("~/Index.aspx");
    }

    protected void btn_Notif_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Web/Notification/Notification.aspx");
    }



    protected void lbtn_Inquiry_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Web/Support/Inquiry.aspx");
    }

    protected void lbtn_FAQ_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Web/Support/FAQ.aspx");
    }

    protected void lbtn_Terms_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Web/Main/Terms.aspx");
    }
}
