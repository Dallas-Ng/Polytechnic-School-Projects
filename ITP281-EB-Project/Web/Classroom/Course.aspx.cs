using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Web_Classroom_Course : System.Web.UI.Page
{
    CourseClass aCourse = new CourseClass();
    TopicClass aTopic = new TopicClass();

    //public int myCounter;
    // string connStr = ConfigurationManager.ConnectionStrings["DatabaseContext"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            bind();
        }
    }

    protected void bind()
    {
        string Course_ID = Request.QueryString["Course_ID"];

        List<CourseClass> CourseList = new List<CourseClass>();
        CourseList = aCourse.getSingleCourse(Course_ID);

        lbl_Course_Title.Text = CourseList[0].Course_Title.ToString();
        lbl_Course_ID.Text = CourseList[0].Course_ID.ToString();
        lbl_Course_Desc.Text = CourseList[0].Course_Desc.ToString();
        lbl_Course_Upload_Date.Text = CourseList[0].Course_Upload_Date.ToString();
        lbl_Course_Subject.Text = CourseList[0].Course_Subject.ToString();

        List<TopicClass> TopicList = new List<TopicClass>();
        TopicList = aTopic.getTopicAll();
        gvTopic.DataSource = TopicList;
        gvTopic.DataBind();
    }



    protected void btn_return_Click(object sender, EventArgs e)
    {
        string Course_ID = Request.QueryString["Course_ID"];
        Response.Redirect("~/Web/Classroom/Courses.aspx");
    }


    protected void gvTopic_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridViewRow row = gvTopic.SelectedRow;
        string TopicID = row.Cells[0].Text;
        string Course_ID = Request.QueryString["Course_ID"];
        Response.Redirect("~/Web/Classroom/Topics/TopicsView.aspx?Topic_ID=" + TopicID + "&Course_ID=" + Course_ID);
    }



    protected void gvTopic_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvTopic.PageIndex = e.NewPageIndex;
        bind();
    }

    protected void btn_Search_Click(object sender, EventArgs e)
    {
        DataTable dt = new DataTable();
        var TopicClassOj = new TopicClass();
        string Course_ID = Request.QueryString["Course_ID"];

        dt = TopicClassOj.Search(tb_Search.Text, Course_ID);
        gvTopic.DataSource = dt;
        gvTopic.DataBind();
    }

    protected void btn_Reset_Click(object sender, EventArgs e)
    {
        string Course_ID = Request.QueryString["Course_ID"];
        Response.Redirect("~/Web/Classroom/Course.aspx?Course_ID=" + Course_ID);
    }
}