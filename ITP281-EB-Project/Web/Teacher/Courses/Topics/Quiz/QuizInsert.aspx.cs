using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Web_Teacher_Courses_Topics_Quiz_QuizInsert : System.Web.UI.Page
{
    QuestionClass aQuestion = new QuestionClass();
    QuizClass aQuiz = new QuizClass();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            bind();
        }
    }
    protected void bind()
    {
        //string ID = Request.QueryString["ID"]; 
        List<QuestionClass> QuestionList = new List<QuestionClass>();

        if (Request.QueryString["Quiz_ID"] != null && Request.QueryString["Quiz_ID"] != " " && Request.QueryString["Quiz_ID"] != "")
        {
            string QID = Request.QueryString["Quiz_ID"];
            QuestionList = aQuestion.getQuestionByQuiz(QID);
        }

        gvQuestion.DataSource = QuestionList;
        gvQuestion.DataBind();

        if (Request.QueryString["Question_ID"] != null && Request.QueryString["Question_ID"] != " " && Request.QueryString["Question_ID"] != "")
        {
            QuestionClass Question = aQuestion.getQuestion(Request.QueryString["Question_ID"].ToString());
            lbl_ID.Text = Question.ID.ToString();
            tb_Answer.Text = Question.Answer;
            tb_Choice1.Text = Question.Choice1;
            tb_Choice2.Text = Question.Choice2;
            tb_Choice3.Text = Question.Choice3;
            tb_Choice4.Text = Question.Choice4;
            tb_Question.Text = Question.Question;
            tb_Question_Number.Text = Question.Question_Number.ToString();

            btn_Insert.Attributes["style"] += "display:none;";
        }
        else
        {
            btn_Update.Attributes["style"] += "display:none;";
        }
    }

    protected void btn_return_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Web/Teacher/Courses/Topics/TopicsView.aspx?Topic_ID=" + Request.QueryString["Topic_ID"].ToString() + "&Course_ID=" + Request.QueryString["Course_ID"].ToString());
    }

    protected void gvQuestion_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int result = 0;
        QuestionClass question = new QuestionClass();
        string categoryID = gvQuestion.DataKeys[e.RowIndex].Value.ToString();
        result = question.QuestionDelete(categoryID);

        if (result > 0)
        {
            Response.Write("<script>alert('Question Remove successfully');</script>");
        }
        else
        {
            Response.Write("<script>alert('Question Removal NOT successfully');</script>");
        }

        Response.Redirect("~/Web/Teacher/Courses/Topics/Quiz/QuizInsert.aspx?Topic_ID=" + Request.QueryString["Topic_ID"].ToString() + "&Quiz_ID=" + Request.QueryString["Quiz_ID"].ToString() + "&Course_ID=" + Request.QueryString["Course_ID"].ToString());
    }

    protected void gvQuestion_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridViewRow row = gvQuestion.SelectedRow;
        string Question_ID = row.Cells[0].Text;
        Response.Redirect("~/Web/Teacher/Courses/Topics/Quiz/QuizInsert.aspx?Topic_ID=" + Request.QueryString["Topic_ID"].ToString() + "&Quiz_ID=" + Request.QueryString["Quiz_ID"].ToString() + "&Question_ID=" + Question_ID + "&Course_ID=" + Request.QueryString["Course_ID"].ToString());
    }

    protected void gvQuestion_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvQuestion.PageIndex = e.NewPageIndex;
        bind();
    }

    protected void btn_Back_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Web/Teacher/Courses/Topics/TopicsView.aspx?Topic_ID=" + Request.QueryString["Topic_ID"].ToString());
    }

    protected void btn_Update_click(object sender, EventArgs e)
    {
        int Quiz_ID = int.Parse(Request.QueryString["Quiz_ID"].ToString()); // Get Quiz ID From query
        QuestionClass question = new QuestionClass();
        if (question.QuestionUpdate(Quiz_ID, tb_Question.Text, tb_Answer.Text, tb_Choice1.Text, tb_Choice2.Text, tb_Choice3.Text, tb_Choice4.Text) > 0)
        {
            Response.Redirect("~/Web/Teacher/Courses/Topics/Quiz/QuizInsert.aspx?Topic_ID=" + Request.QueryString["Topic_ID"].ToString() + "&Quiz_ID=" + Quiz_ID + "&Course_ID=" + Request.QueryString["Course_ID"].ToString());
        }
    }

    protected void btn_Insert_Click(object sender, EventArgs e)
    {
        int Quiz_ID; // Init
        if (Request.QueryString["Quiz_ID"] != null && Request.QueryString["Quiz_ID"] != " " && Request.QueryString["Quiz_ID"] != "")
        {
            Quiz_ID = int.Parse(Request.QueryString["Quiz_ID"].ToString()); // Get Quiz ID From query
        }
        else
        {
            aQuiz.QuizInsert(Request.QueryString["Topic_ID"].ToString()); // Insert new Quiz
            Quiz_ID = aQuiz.getLatestQuizID(); // Get latest quiz IDs
        }

        QuestionClass question = new QuestionClass(int.Parse(tb_Question_Number.Text), tb_Question.Text, tb_Answer.Text, tb_Choice1.Text, tb_Choice2.Text, tb_Choice3.Text, tb_Choice4.Text, Quiz_ID);
        if (question.QuestionInsert() > 0)
        {
            Response.Redirect("~/Web/Teacher/Courses/Topics/Quiz/QuizInsert.aspx?Topic_ID=" + Request.QueryString["Topic_ID"].ToString() + "&Quiz_ID=" + Quiz_ID + "&Course_ID=" + Request.QueryString["Course_ID"].ToString());
        }
    }

    protected void btn_InsertClear_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Web/Teacher/Courses/Topics/Quiz/QuizInsert.aspx?Topic_ID=" + Request.QueryString["Topic_ID"].ToString() + "&Quiz_ID=" + Request.QueryString["Quiz_ID"].ToString() + "&Course_ID=" + Request.QueryString["Course_ID"].ToString());
    }


}
