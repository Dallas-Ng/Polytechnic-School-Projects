using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Web_A_Sign_Up_Activation : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void lbtn_Terms_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Web/A/Terms.aspx");
    }

    protected void btn_Cancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Web/Sign_in.aspx");
    }

    protected void btn_Submit_Click(object sender, EventArgs e)
    {
        // Checks if validation are valid
        Page.Validate();
        if (Page.IsValid)
        {
            // Create Variables
            string cLoginID = tb_Username.Text;
            string cPassword = tb_Password.Text;
            string cEmail = tb_Email.Text;

            // Create Objects
            AccountClass Acc = new AccountClass(cLoginID, cPassword, cEmail, "Student");

            String[] reservedUsernames = new String[] { "admin", "student", "teacher", "certcess" };

            if (!reservedUsernames.Any(cLoginID.ToLower().Contains))
            { // Checks if Username is allowed
                int VerifyCode = Acc.checkSignUp(); // Gets int from method
                /// Verify code returns:
                /// 0 if valid (Email and Login_ID is not matching to any rows)
                /// 1 if Login_ID is used
                /// 2 if Email is used
                if (VerifyCode == 0)
                {
                    if (Acc.Insert() > 0) // If insert successfull
                    {
                        if (EmailClass.SendSignUp(cEmail) > 0)
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Account created successfully, redirecting you to the login page.');window.location ='Sign_in.aspx';", true);
                        }
                        else
                        {
                            Response.Write("<script>alert('Error, email service unavailable.');</script>");

                        }
                    }
                    else // If insert not sucessful
                    {
                        Response.Write("<script>alert('Not sucessful, please try again.');</script>");
                    }
                }
                else
                {
                    List<AccountClass> data = Acc.retrieve(tb_Username.Text);
                    string previousEmail = Request.QueryString["email"].ToString();

                    if (!data.Any() && tb_Email.Text == previousEmail)
                    {
                        if (Acc.Insert() > 0) // If insert successfull
                        {
                            if (EmailClass.SendSignUp(cEmail) > 0)
                            {
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Account created successfully, redirecting you to the login page.');window.location ='../Sign_in.aspx';", true);
                            }
                        }
                        else
                        {
                            Response.Write("<script>alert('Account creation went wrong. Please try again.');</script>");
                        }
                    }
                    else
                    {
                        Response.Write("<script>alert('Please enter a different username.');</script>");
                    }
                }
            }
            else
            {
                Response.Write("<script>alert('Username not allowed.');</script>");
            }
        }
    }
}