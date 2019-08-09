using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Text.RegularExpressions;

public partial class Web_Teacher_Courses_Topics_Slides_SlidesDetails : System.Web.UI.Page
{
    SlidesClass aSlides = new SlidesClass();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            bind();
        }

    }
    public int getNumberOfPdfPages(string fileName)
    {
        using (StreamReader sr = new StreamReader(File.OpenRead(fileName)))
        {
            Regex regex = new Regex(@"/Type\s*/Page[^s]");
            MatchCollection matches = regex.Matches(sr.ReadToEnd());

            return matches.Count;
        }
    }

    protected void bind()
    {
        string Slides_ID = Request.QueryString["Slides_ID"];

        List<SlidesClass> SlidesList = new List<SlidesClass>();
        SlidesList = aSlides.getSingleSlides(Slides_ID);

        lbl_Topic_ID.Text = SlidesList[0].Topic_ID.ToString();
        lbl_Slides_ID.Text = SlidesList[0].Slides_ID.ToString();
        lbl_Slides_Pages.Text = SlidesList[0].Slides_Pages.ToString();
        lbl_Slides_Upload_Date.Text = SlidesList[0].Slides_Upload_Date.ToString();

        string Source = "~/Files/";
        Slides.Attributes["src"] = Source + SlidesList[0].Slides_ID.ToString() + "_" + SlidesList[0].Slides_Upload.ToString();

    }

    protected void btn_back_Click(object sender, EventArgs e)
    {
        string Topic_ID = Request.QueryString["Topic_ID"];
        Response.Redirect("~/Web/Teacher/Courses/Topics/TopicsView.aspx?Topic_ID=" + Topic_ID + "&Course_ID=" + Request.QueryString["Course_ID"].ToString());
    }
}