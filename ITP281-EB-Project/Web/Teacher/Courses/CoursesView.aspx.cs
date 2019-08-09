using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Web_Teacher_Courses_CoursesView : System.Web.UI.Page
{
    CourseClass aCourse = new CourseClass();
    FeedbackClass aFeedback = new FeedbackClass();
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

        tb_Course_Title.Text = CourseList[0].Course_Title.ToString();
        lbl_Course_ID.Text = CourseList[0].Course_ID.ToString();
        tb_Course_Desc.Text = CourseList[0].Course_Desc.ToString();
        lbl_Course_Upload_Date.Text = CourseList[0].Course_Upload_Date.ToString();
        lbl_Course_Fee.Text = CourseList[0].Course_Fee.ToString();
        ddl_Course_Subject.Text = CourseList[0].Course_Subject.ToString();

        List<FeedbackClass> FeedbackList = new List<FeedbackClass>();
        FeedbackList = aFeedback.getFeedback(Course_ID);

        gvFeedback.DataSource = FeedbackList;
        gvFeedback.DataBind();

        List<TopicClass> TopicList = new List<TopicClass>();
        TopicList = aTopic.getTopicAllbyCourse(Course_ID);
        gvTopic.DataSource = TopicList;
        gvTopic.DataBind();
    }



    protected void gvFeedback_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int result = 0;
        FeedbackClass fb = new FeedbackClass();


        string categoryID = gvFeedback.DataKeys[e.RowIndex].Value.ToString();


        result = fb.FeedbackDelete(categoryID);

        if (result > 0)
        {
            Response.Write("<script>alert('Feedback Remove successfully');</script>");
        }
        else
        {
            Response.Write("<script>alert('Feedback Removal NOT successfully');</script>");
        }

        Response.Redirect("~/Web/Teacher/Courses/CoursesView.aspx");
    }

    protected void gvFeedback_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gvFeedback.EditIndex = e.NewEditIndex;
        bind();
    }

    protected void gvFeedback_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gvFeedback.EditIndex = -1;
        bind();
    }

    protected void gvFeedback_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        int result = 0;
        FeedbackClass fb = new FeedbackClass();
        GridViewRow row = (GridViewRow)gvFeedback.Rows[e.RowIndex];

        string fid = ((TextBox)row.Cells[0].Controls[0]).Text;
        string frating = ((TextBox)row.Cells[1].Controls[0]).Text;
        string ffeedback = ((TextBox)row.Cells[2].Controls[0]).Text;
        result = fb.FeedbackUpdate(fid, int.Parse(frating), ffeedback);
        if (result > 0)
        {
            Response.Write("<script>alert('Feedback updated successfully');</script>");
        }
        else
        {
            Response.Write("<script>alert('Feedback NOT updated');</script>");
        }
        gvFeedback.EditIndex = -1;
        bind();
    }

    protected void btn_Topic_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Web/Teacher/Courses/Topics/Topics.aspx");
    }

    protected void btn_Update_Course_Click(object sender, EventArgs e)
    {
        int result = 0;
        string Course_ID = Request.QueryString["Course_ID"];
        CourseClass aCourse = new CourseClass();
        result = aCourse.CourseUpdate(Course_ID, tb_Course_Title.Text, tb_Course_Desc.Text, Session["Current_Logged"].ToString());
        if (result > 0)
        {
            Response.Write("<script>alert('Course updated successfully');</script>");
        }
        else
        {
            Response.Write("<script>alert('Course not successfully updated');</script>");
        }


        bind();
    }

    protected void btn_Insert_Topics_Click(object sender, EventArgs e)
    {
        string Course_ID = Request.QueryString["Course_ID"];
        Response.Redirect("~/Web/Teacher/Courses/Topics/TopicsInsert.aspx?Course_ID=" + Course_ID);
    }

    protected void btn_return_Click(object sender, EventArgs e)
    {
        string Course_ID = Request.QueryString["Course_ID"];
        Response.Redirect("~/Web/Teacher/Courses/Courses.aspx?Course_ID=" + Course_ID);
    }


    protected void gvTopic_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gvTopic.EditIndex = -1;
        bind();
    }

    protected void gvTopic_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridViewRow row = gvTopic.SelectedRow;
        string TopicID = row.Cells[0].Text;
        string Course_ID = Request.QueryString["Course_ID"];
        Response.Redirect("~/Web/Teacher/Courses/Topics/TopicsView.aspx?Topic_ID=" + TopicID + "&Course_ID=" + Course_ID);
    }

    protected void gvTopic_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int result = 0;
        TopicClass topic = new TopicClass();
        string categoryID = gvTopic.DataKeys[e.RowIndex].Value.ToString();
        result = topic.TopicDelete(categoryID);

        if (result > 0)
        {
            Response.Write("<script>alert('Topic Remove successfully');</script>");
        }
        else
        {
            Response.Write("<script>alert('Topic Removal NOT successfully');</script>");
        }

        string Course_ID = Request.QueryString["Course_ID"];
        Response.Redirect("~/Web/Teacher/Courses/Courses.aspx?Course_ID=" + Course_ID);
    }



    protected void gvTopic_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gvTopic.EditIndex = e.NewEditIndex;
        bind();
    }

    protected void gvTopic_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        int result = 0;
        TopicClass topic = new TopicClass();
        GridViewRow row = (GridViewRow)gvTopic.Rows[e.RowIndex];

        string ID = gvTopic.DataKeys[e.RowIndex].Value.ToString();
        string tTitle = ((TextBox)row.Cells[1].Controls[0]).Text;
        result = topic.TopicUpdate(ID, tTitle);
        if (result > 0)
        {
            Response.Write("<script>alert('Topic updated successfully');</script>");
        }
        else
        {
            Response.Write("<script>alert('Topic NOT updated');</script>");
        }
        gvTopic.EditIndex = -1;
        bind();
    }

    protected void btn_View_Slides_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Web/Teacher/CoursesTopics/Slides/Slides.aspx");
    }

    protected void btn_View_Videos_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Web/Teacher/Courses/Topics/Video/Video.aspx");
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
        Response.Redirect("~/Web/Teacher/Courses/CoursesView.aspx?Course_ID=" + Course_ID);
    }
}