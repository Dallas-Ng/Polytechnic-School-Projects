using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Web_Teacher_Courses_Topics_Video_VideoView : System.Web.UI.Page
{
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
        string Video_ID = Request.QueryString["Video_ID"];

        List<VideoClass> VideoList = new List<VideoClass>();
        VideoList = aVid.getSingleVideo(Video_ID);

        lbl_Video_ID.Text = VideoList[0].Video_ID.ToString();
        lbl_Video_Upload_Date.Text = VideoList[0].Video_Upload_Date.ToString();

        string Source = "~/Videos/";
        Video.Attributes["src"] = Source + VideoList[0].Video_ID.ToString() + "_" + VideoList[0].Video.ToString();
    }

    protected void btn_Return_Click(object sender, EventArgs e)
    {
        string Topic_ID = Request.QueryString["Topic_ID"].ToString();
        Response.Redirect("~/Web/Teacher/Courses/Topics/Video/VideoInsert.aspx?Topic_ID=" + Topic_ID + "&Course_ID=" + Request.QueryString["Course_ID"].ToString());
    }
}