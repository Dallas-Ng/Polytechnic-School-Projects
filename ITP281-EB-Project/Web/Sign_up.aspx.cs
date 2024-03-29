﻿using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Net.Mail;
using System.Web;
using System.Linq;

public partial class Web_Account_Sign_up : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

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
                        System.IO.File.Copy(HttpContext.Current.Server.MapPath("~/Static/_Account/ProfilePictures/Default.png"), HttpContext.Current.Server.MapPath(String.Format("~/Static/_Account/ProfilePictures/{0}_Default.png", cLoginID)));

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
                else if (VerifyCode == 1) // If username is used
                {
                    Response.Write("<script>alert('Username current is used, please enter a different username');</script>");
                }
                else if (VerifyCode == 2) // If email is used
                {
                    Response.Write("<script>alert('Email currently used, please enter a different email.');</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('Username not allowed.');</script>");
            }
        }
    }


    protected void lbtn_Home_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Index.aspx");
    }


    protected void lbtn_SignIn_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Web/Sign_in.aspx");
    }


    protected void lbtn_Terms_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Web/A/Terms.aspx");
    }


    protected void lbtn_Teacher_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Web/A/Sign_up_Teacher.aspx");
    }
}