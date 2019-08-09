using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Web_Admin_Courses_Topics_Quiz_QuizView : System.Web.UI.Page
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

        string QID = Request.QueryString["Quiz_ID"];
        QuestionList = aQuestion.getQuestionByQuiz(QID);


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
        }
    }


    protected void gvQuestion_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridViewRow row = gvQuestion.SelectedRow;
        string Question_ID = row.Cells[0].Text;
        string Quiz_ID = Request.QueryString["Quiz_ID"];
        string Topic_ID = Request.QueryString["Topic_ID"];
        string Course_ID = Request.QueryString["Course_ID"];
        Response.Redirect("~/Web/Admin/Courses/Topics/Quiz/QuizView.aspx?Quiz_ID=" + Quiz_ID + "&Question_ID=" + Question_ID + "&Topic_ID=" + Topic_ID + "&Course_ID=" + Course_ID);
    }

    protected void gvQuestion_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvQuestion.PageIndex = e.NewPageIndex;
        bind();
    }


    protected void btn_back_Click(object sender, EventArgs e)
    {
        string Topic_ID = Request.QueryString["Topic_ID"];
        string Course_ID = Request.QueryString["Course_ID"];
        Response.Redirect("~/Web/Admin/Courses/Topics/TopicsView.aspx?Topic_ID=" + Topic_ID + "&Course_ID=" + Course_ID);
    }
}