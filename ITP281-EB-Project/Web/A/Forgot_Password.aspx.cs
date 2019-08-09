using System;
using System.Net.Mail;

public partial class Web_Account_Forget_Password : System.Web.UI.Page
{
    AccountClass Acc = new AccountClass();

    protected void Page_Load(object sender, EventArgs e)
    {

    }


    /// <summary>
    /// Redirect to home page
    /// </summary>
    protected void lbtn_Home_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Index.aspx");
    }


    protected void btn_Submit_Click(object sender, EventArgs e)
    {
        string cEmail = tb_Email.Text;

        if (Acc.checkEmail(cEmail) != null)
        {
            HasherClass.resetPassword(cEmail);
        }
        Response.Write("<script>window.alert('Please check your email for a link to reset your password.');window.location='../../Index.aspx';</script>");
    }
}