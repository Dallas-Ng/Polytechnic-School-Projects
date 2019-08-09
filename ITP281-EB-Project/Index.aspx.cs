using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Index : System.Web.UI.Page
{
    // Dallas
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            reload();
        }
    }

    protected void reload()
    {
        CourseClass course = new CourseClass();
        List<CourseClass> Courses = course.getCourseAll();
        Re1.DataSource = Courses;
        Re1.DataBind();
    }
}