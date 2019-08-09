using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Static_Master_Admin_Dashboard : System.Web.UI.MasterPage
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
                else if (Data[0].Role == "teacher")
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('You do not have permission to view this page.');window.location ='/Web/Teacher/Dashboard.aspx';", true);
                }
            }
        }
    }

    protected void lbtn_Home_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Web/Admin/Dashboard.aspx");
    }

    protected void lbtn_Users_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Web/Admin/Account/View.aspx");
    }

    protected void lbtn_Lockout_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Web/Admin/Account/Lockout_System.aspx");
    }

    protected void lbtn_Teachers_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Web/Admin/Teacher/View.aspx?list=verified");
    }

    protected void lbtn_Courses_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Web/Admin/Courses/Courses.aspx");
    }

    protected void lbtn_Forums_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Web/Admin/Forum/ForumView.aspx");
    }

    protected void lbtn_Inquiry_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Web/Admin/Support/InquiryView.aspx");
    }

    protected void lbtn_Notifications_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Web/Admin/Notification/Notification_Admin.aspx");
    }

    protected void lbtn_Transactions_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Web/Admin/Transactions/TransactionHistoryExtract.aspx");
    }

    protected void btn_Logout_Click(object sender, EventArgs e)
    {
        Session.Clear();
        Response.Redirect("~/Index.aspx");
    }
}
