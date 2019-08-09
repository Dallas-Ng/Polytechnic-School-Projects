using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Web_Teacher_Courses_Topics_Quiz_QuizView : System.Web.UI.Page
{
    QuizClass aQuizes = new QuizClass();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            bind();
        }
    }

    protected void bind()
    {
        List<QuizClass> QuizList = new List<QuizClass>();
        //string QID = Request.QueryString["Quiz_ID"];
        QuizList = aQuizes.getQuizAll();
        gvQuiz.DataSource = QuizList;
        gvQuiz.DataBind();
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

        Response.Redirect("~/Web/Admin/Course/Topics/Quiz/Quiz.aspx");
    }

    protected void gvQuiz_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridViewRow row = gvQuiz.SelectedRow;
        string Quiz_ID = row.Cells[0].Text;
        //string QID = Request.QueryString["ID"];
        Response.Redirect("~/Web/Admin/Course/Topics/Quiz/QuizView.aspx?Quiz_ID=" + Quiz_ID + "&Course_ID=" + Request.QueryString["Course_ID"].ToString());

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