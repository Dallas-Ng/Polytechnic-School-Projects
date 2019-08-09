using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Web_Teacher_Settings_Change_Password : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            tb_Confirm.Text = "";
            tb_Password.Text = "";
            tb_Past_Password.Text = "";
        }
    }


    /// <summary>
    /// Change old pasword with new password
    /// </summary>
    protected void btn_Submit_Click(object sender, EventArgs e)
    {
        Page.Validate();

        if (Page.IsValid)
        {
            string Current_Logged = (string)Session["Current_Logged"].ToString();
            AccountClass User = new AccountClass();
            int result = User.PasswordUpdate(Current_Logged, tb_Past_Password.Text, tb_Confirm.Text);

            if (result > 0)
            {
                Response.Write("<script>alert('Password updated successfully');</script>");
            }
            else
            {
                Response.Write("<script>alert('Password not successfully updated');</script>");
            }
        }
    }
}