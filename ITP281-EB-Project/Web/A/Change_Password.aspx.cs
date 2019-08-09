using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Web_Account_Change_Password : System.Web.UI.Page
{
    AccountClass Acc = new AccountClass();

    protected void Page_Load(object sender, EventArgs e)
    {
        string Token = Request.QueryString["token"];
        List<AccountClass> DataList = HasherClass.retrieveToken(Token);

        // Get the total minutes passed - Validation is set at 30 minutes
        DateTime current_date = DateTime.Now;
        DateTime data_date = DateTime.Parse(DataList[0].Creation_Date.ToString());
        TimeSpan span = current_date.Subtract(data_date);

        if (Token == "" || Token == null || span.TotalMinutes < 3600) // If token is available
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Invalid token or token has expired. Please request for a new password. ');window.location ='../../Index.aspx';", true);
        }

    }


    protected void btn_Submit_Click(object sender, EventArgs e)
    {
        string Token = Request.QueryString["token"];
        List<AccountClass> DataList = HasherClass.retrieveToken(Token);

        if (DataList.Count > 0)
        {   // if Data exist and time is equal or above 30 minutes
            string Login_ID = Acc.checkEmail(DataList[0].Email.ToString());

            int result = Acc.resetPassword(tb_Confirm.Text, Login_ID);
            if (result > 0)
            {   // If password changes successfully
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Password Changed Successfully');window.location ='../../Index.aspx';", true);
            }
            else
            {   // If reset password () does not work
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Sorry, something went wrong. Please request for a new password. ');window.location ='../../Index.aspx';", true);
            }
        }
        else
        {   // If total minutes is above 30 minutes or token data is null
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Token expired. Please request for a new password. ');window.location ='../../Index.aspx';", true);
        }

    }
}