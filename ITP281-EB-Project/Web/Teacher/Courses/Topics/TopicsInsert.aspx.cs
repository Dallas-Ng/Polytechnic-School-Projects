using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Web_Teacher_Courses_Topics_TopicsInsert : System.Web.UI.Page
{
    string connStr = ConfigurationManager.ConnectionStrings["EBP-Database"].ConnectionString;
    CourseClass aCourse = new CourseClass();

    string Topic_ID = "Topic ";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            generateTopicID();
        }
    }
    protected void generateTopicID()
    {


        string Course_ID = Request.QueryString["Course_ID"];
        List<CourseClass> CourseList = new List<CourseClass>();
        CourseList = aCourse.getSingleCourse(Course_ID);
        tb_Course_ID.Text = Course_ID;
        tb_Subject.Text = CourseList[0].Course_Subject.ToString();

        SqlConnection conn = new SqlConnection(connStr);
        conn.Open();
        SqlCommand cmd = new SqlCommand("Select Count(Topic_ID)from CoursesTopics", conn);
        int i = Convert.ToInt32(cmd.ExecuteScalar());
        conn.Close();
        i++;
        tb_Topic_ID.Text = Topic_ID + i.ToString();

    }

    protected void btn_Insert_Click(object sender, EventArgs e)
    {
        int result = 0;

        DateTime CurrentDate = DateTime.Now;

        TopicClass topic = new TopicClass(tb_Topic_ID.Text, tb_Topic_Title.Text, CurrentDate.ToString(), 0, tb_Course_ID.Text);
        // tb_Course_ID =

        result = topic.TopicInsert();
        if (result > 0)
        {
            string Course_ID = Request.QueryString["Course_ID"];
            Response.Redirect("~/Web/Teacher/Courses/CoursesView.aspx?Course_ID=" + Course_ID);
        }
    }

    protected void btn_view_Click(object sender, EventArgs e)
    {
        Response.Redirect("Topics.aspx");
    }

    protected void btn_Return_Click(object sender, EventArgs e)
    {
        string Course_ID = Request.QueryString["Course_ID"];
        Response.Redirect("~/Web/Teacher/Courses/CoursesView.aspx?Course_ID=" + Course_ID);
    }
}