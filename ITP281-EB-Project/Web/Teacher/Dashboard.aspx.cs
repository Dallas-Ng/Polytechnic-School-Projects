using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Web_Teacher_Dashboard : System.Web.UI.Page
{
    AccountClass Acc = new AccountClass();
    CourseClass aCourse = new CourseClass();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            reload();
        }
    }


    protected void reload()
    {
        lbl_Username.Text = Session["Current_Logged"].ToString();
        List<AccountClass> data = Acc.retrieve(Session["Current_Logged"].ToString());
        lbl_RecentLogin.Text = data[0].Recent_Login.ToString();

        List<CourseClass> CourseList = new List<CourseClass>();
        CourseList = aCourse.getCoursesbyAuthor(Session["Current_Logged"].ToString());
         
        if (CourseList == null || !CourseList.Any())
        {
            CoursesBanner.Attributes["class"] += " d-block";
        }
        else
        {
            CoursesBanner.Attributes["class"] += " d-none";
        }

        Re1.DataSource = CourseList;
        Re1.DataBind();

    }

    protected void lbtn_Courses_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Web/Teacher/Courses/Courses.aspx");
    }
}