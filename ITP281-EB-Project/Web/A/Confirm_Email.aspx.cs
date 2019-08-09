using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Web_A_Confirm_Email : System.Web.UI.Page
{
    AccountClass Acc = new AccountClass();

    protected void Page_Load(object sender, EventArgs e)
    {
        string token = Request.QueryString["token"].ToString();
        List<AccountClass> Data = HasherClass.retrieveToken(token);

        if (!Data.Any())
        { // No data present - token is invalid or do no exists
          ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Invalid token. Please contact an admin.');window.location ='../../Index.aspx';", true);
        }
        else
        {
            Acc.updateEmailConfirmed(Data[0].Email);
        }
    }

    protected void lbtn_Home_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Index.aspx");
    }
}