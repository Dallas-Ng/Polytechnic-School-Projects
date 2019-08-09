using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Web_Error : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }

    protected void btn_Back_Click(object sender, EventArgs e)
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
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Redirecting.');window.location ='/Web/Account/Dashboard.aspx';", true);
                }
                if (Data[0].Role == "teacher")
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Redirecting.');window.location ='/Web/Teacher/Dashboard.aspx';", true);
                }
                else if (Data[0].Role == "admin")
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Redirecting.');window.location ='/Web/Admin/Dashboard.aspx';", true);
                }
            }
        }
    }
}