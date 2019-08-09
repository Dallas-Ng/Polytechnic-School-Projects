using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Web_Admin_Courses_Topics_TopicView : System.Web.UI.Page
{

    TopicClass aTopic = new TopicClass();
    SlidesClass aSlide = new SlidesClass();
    QuizClass aQuizes = new QuizClass();

    VideoClass aVid = new VideoClass();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            bind();
        }
    }
    protected void bind()
    {
        string Topic_ID = Request.QueryString["Topic_ID"];

        List<TopicClass> TopicList = new List<TopicClass>();
        TopicList = aTopic.getSingleTopic(Topic_ID);

        lbl_Topic_ID.Text = TopicList[0].Topic_ID.ToString();
        lbl_Topic_Title.Text = TopicList[0].Topic_Title.ToString();
        lbl_Topic_Upload_Date.Text = TopicList[0].Topic_Upload_Date.ToString();
        //lbl_Topic_Progress_Bar.Text = TopicList[0].Topic_Progress_Bar.ToString();

        List<SlidesClass> SlidesList = new List<SlidesClass>();
        SlidesList = aSlide.getSlidesAllbyTopic(Topic_ID);
        gvSlides.DataSource = SlidesList;
        gvSlides.DataBind();

        List<VideoClass> VideoList = new List<VideoClass>();
        VideoList = aVid.getVideoAllbyTopic(Topic_ID);
        gvVideo.DataSource = VideoList;
        gvVideo.DataBind();

        List<QuizClass> QuizList = new List<QuizClass>();
        QuizList = aQuizes.getQuizAllbyTopic(Topic_ID);
        gvQuiz.DataSource = QuizList;
        gvQuiz.DataBind();


    }

    protected void btn_Quiz_Click(object sender, EventArgs e)
    {
        //Response.Redirect("~/Web/Admin/Course/Topics/Quiz/QuizView.aspx?Topic_ID=" + TopicID);
    }

    protected void btn_return_Click(object sender, EventArgs e)
    {
        string Course_ID = Request.QueryString["Course_ID"];
        Response.Redirect("~/Web/Admin/Courses/CoursesView.aspx?Course_ID=" + Course_ID);
    }

    protected void btn_Insert_Slides_Click(object sender, EventArgs e)
    {
        string Topic_ID = Request.QueryString["Topic_ID"];
        Response.Redirect("~/Web/Admin/Courses/Topics/Slides/SlidesUpload.aspx?Topic_ID=" + Topic_ID);
    }

    protected void btn_Insert_Video_Click(object sender, EventArgs e)
    {
        string Topic_ID = Request.QueryString["Topic_ID"];
        Response.Redirect("~/Web/Admin/Courses/Topics/video/VideoInsert.aspx?Topic_ID=" + Topic_ID);
    }

    protected void btn_Create_Quiz_Click(object sender, EventArgs e)
    {
        string Topic_ID = Request.QueryString["Topic_ID"];
        Response.Redirect("~/Web/Admin/Courses/Topics/Quiz/QuizInsert.aspx?Topic_ID=" + Topic_ID);
    }

    protected void gvVideo_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridViewRow row = gvVideo.SelectedRow;
        string Video_ID = row.Cells[0].Text;

        string Topic_ID = Request.QueryString["Topic_ID"];
        string Course_ID = Request.QueryString["Course_ID"];
        Response.Redirect("~/Web/Admin/Courses/Topics/Video/VideoView.aspx?Video_ID=" + Video_ID + "&Topic_ID=" + Topic_ID + "&Course_ID=" + Course_ID);
    }

    protected void gvVideo_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int result = 0;
        VideoClass video = new VideoClass();
        string categoryID = gvVideo.DataKeys[e.RowIndex].Value.ToString();
        result = video.VideoDelete(categoryID);

        if (result > 0)
        {
            Response.Write("<script>alert('Video Remove successfully');</script>");
        }
        else
        {
            Response.Write("<script>alert('Video Removal NOT successfully');</script>");
        }

        string Topic_ID = Request.QueryString["Topic_ID"];
        Response.Redirect("~/Web/Admin/Courses/Topics/TopicsView.aspx?Topic_ID=" + Topic_ID);
    }

    protected void gvVideo_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvVideo.PageIndex = e.NewPageIndex;
        bind();
    }

    protected void gvSlides_SelectedIndexChanged(object sender, EventArgs e)
    {

        GridViewRow row = gvSlides.SelectedRow;
        string Slides_ID = row.Cells[0].Text;
        string Topic_ID = Request.QueryString["Topic_ID"];
        string Course_ID = Request.QueryString["Course_ID"];
        Response.Redirect("~/Web/Admin/Courses/Topics/Slides/SlidesDetails.aspx?Slides_ID=" + Slides_ID + "&Topic_ID=" + Topic_ID + "&Course_ID=" + Course_ID);
    }

    protected void gvSlides_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int result = 0;
        SlidesClass slides = new SlidesClass();


        string categoryID = gvSlides.DataKeys[e.RowIndex].Value.ToString();


        result = slides.SlidesDelete(categoryID);

        if (result > 0)
        {
            Response.Write("<script>alert('Slides Remove successfully');</script>");
        }
        else
        {
            Response.Write("<script>alert('Slides Removal NOT successfully');</script>");
        }

        string Topic_ID = Request.QueryString["Topic_ID"];
        Response.Redirect("~/Web/Admin/Courses/Topics/TopicsView.aspx?Topic_ID=" + Topic_ID);
    }

    protected void gvSlides_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvSlides.PageIndex = e.NewPageIndex;
        bind();
    }

    protected void gvQuiz_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int result = 0;
        QuizClass aQuizes = new QuizClass();


        string categoryID = gvQuiz.DataKeys[e.RowIndex].Value.ToString();


        result = aQuizes.QuizDelete(categoryID);

        if (result > 0)
        {
            Response.Write("<script>alert('Quizes Remove successfully');</script>");
        }
        else
        {
            Response.Write("<script>alert('Quizes Removal NOT successfully');</script>");
        }

        string Topic_ID = Request.QueryString["Topic_ID"];
        string Course_ID = Request.QueryString["Course_ID"];
        Response.Redirect("~/Web/Admin/Courses/Topics/TopicsView.aspx?Topic_ID=" + Topic_ID + "&Course_ID=" + Course_ID);
    }

    protected void gvQuiz_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridViewRow row = gvQuiz.SelectedRow;
        string Quiz_ID = row.Cells[0].Text;
        //string QID = Request.QueryString["ID"];
        string Topic_ID = Request.QueryString["Topic_ID"];
        string Course_ID = Request.QueryString["Course_ID"];

        Response.Redirect("~/Web/Admin/Courses/Topics/Quiz/QuizView.aspx?Quiz_ID=" + Quiz_ID + "&Topic_ID=" + Topic_ID + "&Course_ID=" + Course_ID);

    }


    protected void gvQuiz_RowEditing(object sender, GridViewEditEventArgs e)
    {

        gvQuiz.EditIndex = e.NewEditIndex;
        bind();
    }


    protected void gvQuiz_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        int result = 0;
        QuizClass quiz = new QuizClass();
        GridViewRow row = (GridViewRow)gvQuiz.Rows[e.RowIndex];

        string Quiz_ID = ((TextBox)row.Cells[0].Controls[0]).Text;
        string qMarks = ((TextBox)row.Cells[2].Controls[0]).Text;
        string qStatus = ((TextBox)row.Cells[3].Controls[0]).Text;
        //string qCompletedDate = ((TextBox)row.Cells[4].Controls[0]).Text;
        result = quiz.QuizUpdate(int.Parse(Quiz_ID), int.Parse(qMarks), qStatus);
        if (result > 0)
        {
            Response.Write("<script>alert('Quiz updated successfully');</script>");
        }
        else
        {
            Response.Write("<script>alert('Quiz NOT updated');</script>");
        }
        gvQuiz.EditIndex = -1;
        bind();
    }

    protected void gvQuiz_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gvQuiz.EditIndex = -1;
        bind();
    }

    protected void gvQuiz_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvQuiz.PageIndex = e.NewPageIndex;
        bind();
    }
}