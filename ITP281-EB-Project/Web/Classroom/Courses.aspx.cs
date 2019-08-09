using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Web_Classroom_Courses : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            reload();
        }
    }

    protected void reload()
    {
        CourseAccountClass course = new CourseAccountClass();
        string Login_ID = Session["Current_Logged"].ToString();

        List<CourseAccountClass> Courses = course.RetrieveAllByUser(Login_ID);
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

    protected void lbtn_Courses_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Web/Shop/Courses.aspx");
    }
}