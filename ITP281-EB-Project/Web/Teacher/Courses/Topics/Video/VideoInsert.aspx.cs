using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;


public partial class Web_Teacher_Courses_Topics_Video_VideoInsert : System.Web.UI.Page
{
    string connStr = ConfigurationManager.ConnectionStrings["EBP-Database"].ConnectionString;
    TopicClass aTopic = new TopicClass();
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
        tb_Topic_ID.Text = TopicList[0].Topic_ID.ToString();

        List<VideoClass> VideoList = new List<VideoClass>();
        VideoList = aVid.getVideoAllbyTopic(Topic_ID);
        gvVideo.DataSource = VideoList;
        gvVideo.DataBind();

    }

    protected void btn_Upload_Click(object sender, EventArgs e)
    {
        DateTime CurrentDate = DateTime.Now;
        if (FileUpload_Video.HasFile == true)
        {
            //
        }
        VideoClass vid = new VideoClass(0, CurrentDate.ToString(), tb_Topic_ID.Text, FileUpload_Video.FileName);
        string result = vid.VideoInsert();
        if (result != null)
        {
            string savevid = Server.MapPath("~/Videos") + "\\" + result + "_" + FileUpload_Video.FileName;

            FileUpload_Video.SaveAs(savevid);
            Response.Write("<script>alert('Insert successful');</script>");
            string Topic_ID = Request.QueryString["Topic_ID"];

            Response.Redirect("~/Web/Teacher/Courses/Topics/Video/VideoInsert.aspx?Topic_ID=" + Topic_ID + "&Course_ID=" + Request.QueryString["Course_ID"].ToString());
        }
        else { Response.Write("<script>alert('Insert NOT successful');</script>"); }
    }


    protected void gvVideo_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridViewRow row = gvVideo.SelectedRow;
        string Video_ID = row.Cells[0].Text;
        string Topic_ID = Request.QueryString["Topic_ID"];

        Response.Redirect("~/Web/Teacher/Courses/Topics/Video/VideoView.aspx?Video_ID=" + Video_ID + "&Topic_ID=" + Topic_ID + "&Course_ID=" + Request.QueryString["Course_ID"].ToString());
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

        Response.Redirect("~/Web/Teacher/Courses/Topics/Video/Video.aspx");
    }

    protected void gvVideo_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvVideo.PageIndex = e.NewPageIndex;
        bind();
    }

    protected void btn_VideoView_Click(object sender, EventArgs e)
    {
        string Topic_ID = Request.QueryString["Topic_ID"];
        Response.Redirect("~/Web/Teacher/Courses/Topics/TopicsView.aspx?Topic_ID=" + Topic_ID + "&Course_ID=" + Request.QueryString["Course_ID"].ToString());
    }
}