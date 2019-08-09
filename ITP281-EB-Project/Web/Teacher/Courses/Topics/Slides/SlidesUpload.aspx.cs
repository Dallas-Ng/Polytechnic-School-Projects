using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Web_Teacher_Courses_Topics_Slides_SlidesUpload : System.Web.UI.Page
{
    string connStr = ConfigurationManager.ConnectionStrings["EBP-Database"].ConnectionString;
    TopicClass aTopic = new TopicClass();
    SlidesClass aSlide = new SlidesClass();

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


        List<SlidesClass> SlidesList = new List<SlidesClass>();
        SlidesList = aSlide.getSlidesAllbyTopic(Topic_ID);
        gvSlides.DataSource = SlidesList;
        gvSlides.DataBind();

    }
    protected void btnExtractZipFiles_Click(object sender, EventArgs e)
    {

        if (fileUploadSlides.HasFile)
        {

            DateTime CurrentDate = DateTime.Now;
            SlidesClass Slides = new SlidesClass(int.Parse(tb_Slides_Pages.Text), CurrentDate.ToString(), tb_Topic_ID.Text, fileUploadSlides.FileName);
            string result = Slides.SlidesInsert();

            string saveSlides = Server.MapPath("~/Files/") + "\\" + result + "_" + fileUploadSlides.FileName;

            fileUploadSlides.SaveAs(saveSlides);

            string Topic_ID = Request.QueryString["Topic_ID"].ToString();

            Response.Redirect("~/Web/Teacher/Courses/Topics/Slides/SlidesUpload.aspx?Topic_ID=" + Topic_ID + "&Course_ID=" + Request.QueryString["Course_ID"].ToString());
        }

    }


    protected void btn_Back_Click(object sender, EventArgs e)
    {
        string Topic_ID = Request.QueryString["Topic_ID"];
        Response.Redirect("~/Web/Teacher/Courses/Topics/TopicsView.aspx?Topic_ID=" + Topic_ID + "&Course_ID=" + Request.QueryString["Course_ID"].ToString());
    }

    protected void gvSlides_SelectedIndexChanged(object sender, EventArgs e)
    {

        GridViewRow row = gvSlides.SelectedRow;
        string Slides_ID = row.Cells[0].Text;

        Response.Redirect("~/Web/Teacher/Courses/Topics/Slides/SlidesDetails.aspx?Slides_ID=" + Slides_ID + "&Course_ID=" + Request.QueryString["Course_ID"].ToString());
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

        Response.Redirect("~/Web/Teacher/Courses/Topics/Slides/SlidesUpload.aspx?Topic_ID=" +Topic_ID + "&Course_ID=" + Request.QueryString["Course_ID"].ToString());
    }

    protected void gvSlides_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvSlides.PageIndex = e.NewPageIndex;
        bind();
    }

}
