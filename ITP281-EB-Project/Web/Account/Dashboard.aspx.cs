using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Web_Account_Dashboard : System.Web.UI.Page
{
    AccountClass Acc = new AccountClass();

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

        if (!Page.IsPostBack)
        {
            Reload();
        }


    }

    protected void Reload()
    {
        string Login_ID = Session["Current_Logged"].ToString();
        List<AccountClass> Data = Acc.retrieve(Login_ID);

        lbl_Username.Text = Data[0].Login_ID.ToString();
        lbl_RecentLogin.Text = Data[0].Recent_Login.ToString();

        // Pulls profile picture from user database
        string ImageName = Acc.ImageRetrieve(Login_ID);
        if (ImageName == "Default.png")
        { // If image is default, use this path
            ProfilePicture.Attributes["Src"] = String.Format("../../../Static/_Account/ProfilePictures/{0}", ImageName);
        }
        else
        {
            //FileUpload.Attributes= ImageName;
            ProfilePicture.Attributes["Src"] = String.Format("../../../Static/_Account/ProfilePictures/{0}_{1}", Login_ID, ImageName);
        }

        CourseAccountClass course = new CourseAccountClass();
        List<CourseAccountClass> Courses = course.RetrieveAll(Login_ID);
        if (Courses == null || !Courses.Any())
        {
            CoursesBanner.Attributes["class"] += " d-block";
        }
        else
        {
            CoursesBanner.Attributes["class"] += " d-none";
        }

        Re1.DataSource = Courses;
        Re1.DataBind();
    }

    /// <summary>
    /// Navbar links
    /// </summary>

    protected void lbtn_Home_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Web/Account/Dashboard.aspx");
    }

    protected void lbtn_Courses_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Web/Shop/Courses.aspx");
    }
    

            protected void lbtn_MyCourses_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Web/Classroom/Courses.aspx");
    }

    protected void lbtn_Forums_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Web/Forums/Forums.aspx");
    }

    protected void lbtn_Settings_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Web/Account/Settings.aspx");
    }

    protected void btn_Notif_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Web/Notification/Notification.aspx");
    }

    /// <summary>
    /// Other Links
    /// </summary>
    protected void lbtn_Inquiry_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Web/Support/Inquiry.aspx");
    }

    protected void lbtn_FAQ_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Web/Support/FAQ.aspx");
    }

    protected void lbtn_Feedback_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Web/Classroom/Feedback.aspx");
    }

    protected void lbtn_Terms_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Web/Main/Terms.aspx");
    }

    protected void logout(object sender, EventArgs e)
    {
        Session["Current_Logged"] = "";
        Response.Redirect("~/Index.aspx");
    }
}