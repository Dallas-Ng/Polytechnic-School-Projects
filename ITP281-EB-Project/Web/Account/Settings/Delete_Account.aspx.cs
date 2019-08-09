using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Web_Account_Settings_Delete_Account : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }


    /// <summary>
    /// Deletes Account
    /// </summary>
    protected void btn_Delete_Click(object sender, EventArgs e)
    {
        int result = 0;
        AccountClass User = new AccountClass();
        result = User.Delete(Session["Current_Logged"].ToString(), "logical");
        
        if (result > 0)
        {
            Session.Clear();
            Response.Redirect("~/Index.aspx");
        }
        else
        {
            Response.Write("<script>alert('Error, please try again.');</script>");
        }
    }
}