using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Web_Classroom_Feedback : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btn_Submit_Click(object sender, EventArgs e)
    {
        int result = 0;
        int Rating = int.Parse(tb_Rating.Text);
        string Login_ID = Session["Current_Logged"].ToString();

        FeedbackClass feedback = new FeedbackClass(tb_Feedback_ID.Text, tb_Feedback.Text, Rating, Login_ID, "001");

        //int result = course.CourseInsert();
        result = feedback.FeedbackInsert();
        if (result > 0)
        {
            Response.Redirect("~/Web/Dashboard.aspx");
        }
    }
}