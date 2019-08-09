using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;

public partial class Web_Account_Sign_in : System.Web.UI.Page
{
    AccountClass Acc = new AccountClass();

    protected void Page_Load(object sender, EventArgs e)
    {

    }


    protected void btn_SignIn_Click(object sender, EventArgs e)
    {
        string cLoginID = tb_Username.Text.ToLower();
        string cPassword = tb_Password.Text;
        Lockout.ResetAccounts();

        // Checks if account exists, if it does, checks if password matches the database
        string filter = Acc.checkIsExist(cLoginID, cPassword);
        if (filter == "deleted")
        {
            Response.Redirect(String.Format("~/Web/A/Reactivate.aspx?user={0}", cLoginID));
        }
        else if (filter == "none")
        {
            if (!Lockout.CheckAccount(cLoginID))
            {
                Lockout.AddIncrement(cLoginID);
                Lockout.CheckAccounts();
                Response.Write(string.Format("<script>alert('Invalid username or password');</script>", filter, cLoginID));
            }
            else
            {
                List<AccountClass> Data = Acc.retrieve(tb_Username.Text);
                string Email = Data[0].Email;

                EmailClass.SendInformation(Email, "Your account has been locked for 10 minutes. If you did attempt to log in during this period, please contact an admin.");
                Response.Write("<script>alert('Your account has been locked for 10 minutes. To reach our support press contact on our the homepage.');</script>");
            }
        }
        else if (filter == "admin" || filter == "student" || filter == "teacher")
        {
            if (!Lockout.CheckAccount(cLoginID))
            {
                Lockout.ResetIncrement(tb_Username.Text);
                Session["Current_Logged"] = tb_Username.Text;

                if (filter == "admin")
                {
                    Response.Redirect("~/Web/Admin/Dashboard.aspx");
                }
                else if (filter == "teacher")
                {
                    Response.Redirect("~/Web/Teacher/Dashboard.aspx");
                }
                else
                {
                    Response.Redirect("~/Web/Account/Dashboard.aspx");
                }
            }
            else
            {
                List<AccountClass> Data = Acc.retrieve(tb_Username.Text);
                string Email = Data[0].Email;

                EmailClass.SendInformation(Email, "Your account has been locked for 10 minutes. If you did attempt to log in during this period, please contact an admin.");
                Response.Write("<script>alert('Your account has been locked for 10 minutes. To reach our support press contact on our the homepage.');</script>");
            }
        }
        else
        {
            Response.Write(string.Format("<script>alert('Something went wrong. Please try again.');</script>", filter, cLoginID));
        }
    }


    protected void lbtn_Home_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Index.aspx");
    }


    protected void lbtn_SignUp_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Web/Sign_up.aspx");
    }


    protected void lbtn_Forget_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Web/A/Forgot_Password.aspx");
    }
}