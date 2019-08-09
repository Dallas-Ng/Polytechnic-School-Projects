using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Web_Classroom_Topics_TopicsView : System.Web.UI.Page
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
    }

    protected void gvVideo_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridViewRow row = gvVideo.SelectedRow;
        string Video_ID = row.Cells[0].Text;
        string Topic_ID = Request.QueryString["Topic_ID"];
        Response.Redirect("~/Web/Classroom/Topics/VideoView.aspx?Video_ID=" + Video_ID + "&Topic_ID=" + Topic_ID);
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
        Response.Redirect("~/Web/Classroom/Topics/SlidesDetails.aspx?Slides_ID=" + Slides_ID + "&Topic_ID=" + Topic_ID);
    }

    protected void gvSlides_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvSlides.PageIndex = e.NewPageIndex;
        bind();
    }
}