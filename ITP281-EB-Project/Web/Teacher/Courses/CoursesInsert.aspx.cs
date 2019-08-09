using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Web_Teacher_Courses_CoursesInsert : System.Web.UI.Page
{
    string connStr = ConfigurationManager.ConnectionStrings["EBP-Database"].ConnectionString;
    string Course_ID = "Course ";
    AccountClass aAccount = new AccountClass();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            generateCourseID();
        }
    }

    protected void generateCourseID()
    {
        SqlConnection conn = new SqlConnection(connStr);
        conn.Open();
        SqlCommand cmd = new SqlCommand("Select Count(Course_ID)from Courses", conn);
        int i = Convert.ToInt32(cmd.ExecuteScalar());
        conn.Close();
        i++;
        tb_Course_ID.Text = Course_ID + i.ToString();
    }

    protected void Btn_View_Course_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Web/Teacher/Courses/Courses.aspx");
    }


    protected void btn_Insert_Click(object sender, EventArgs e)
    {
        int result = 0;

        DateTime CurrentDate = DateTime.Now;

        CourseClass course = new CourseClass(tb_Course_ID.Text, tb_Course_Title.Text, CurrentDate.ToString(), Session["Current_Logged"].ToString(), decimal.Parse(tb_Course_Fee.Text), tb_Course_Desc.Text, ddl_Course_Subject.Text);

        generateCourseID();
        result = course.CourseInsert();
        if (result > 0)
        {
            Response.Redirect("~/Web/Teacher/Courses/Courses.aspx");
        }
    }


    protected void btn_Submit_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Web/Teacher/Courses/Courses.aspx");
    }

    protected void ClearTextBox()
    {

        tb_Course_Title.Text = "";
        tb_Course_Fee.Text = "";
        tb_Course_Desc.Text = "";
        ddl_Course_Subject.Text = "";

    }
}