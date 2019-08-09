using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Static_Master_User_Settings : System.Web.UI.MasterPage
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

    protected void lbtn_Basic_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Web/Account/Settings.aspx");
    }

    protected void lbtn_Password_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Web/Account/Settings/Change_Password.aspx");
    }

    protected void lbtn_Payment_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Web/Account/Settings/Payment_Settings.aspx");
    }

    protected void lbtn_Delete_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Web/Account/Settings/Delete_Account.aspx");
    }

    protected void logout(object sender, EventArgs e)
    {
        Session["Current_Logged"] = "";
        Response.Redirect("~/Index.aspx");
    }

    protected void btn_Notif_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Web/Notification/Notification.aspx");
    }
}
