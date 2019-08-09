using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Web_Admin_Account_Courses : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            Reload();
        }
    }

    protected void Reload()
    {
        string Login_ID = Request.QueryString["user"];
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
    /// Redirects back to View Page
    /// </summary>
    protected void btn_Back_Click(object sender, EventArgs e)
    {
        string Login_ID = Request.QueryString["User"];
        Response.Redirect(String.Format("~/Web/Admin/Account/User.aspx?User={0}", Login_ID));
    }


    /// <summary>
    /// Redirects back to View Page
    /// </summary>
    protected void btn_Home_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Web/Admin/Account/View.aspx");
    }
}