using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;
using System.Data.SqlClient;
using System.Configuration;

/// <summary>
/// Name:Chin Zhi Xuan
/// Admin No:182136R
/// </summary>
public class QuestionClass
{
    string connStr = ConfigurationManager.ConnectionStrings["EBP-Database"].ConnectionString;

    private string _Question, _Answer ,_Choice1,_Choice2,_Choice3,_Choice4= " ";
    private int _ID, _Question_Number,  _Quiz_ID = 0;

    public QuestionClass()
    { 

    }

    public QuestionClass(int ID,int Question_Number,string Question,string Answer,string Choice1,string Choice2,string Choice3,string Choice4,int Quiz_ID)
    {
        _ID = ID;
        _Question_Number = Question_Number;
        _Question = Question;       
        _Answer = Answer;
        _Choice1 = Choice1;
        _Choice2 = Choice2;
        _Choice3 = Choice3;
        _Choice4 = Choice4;
        _Quiz_ID = Quiz_ID;
    }
    public QuestionClass( int Question_Number, string Question, string Answer, string Choice1, string Choice2, string Choice3, string Choice4)
    {
        _Question_Number = Question_Number;
        _Question = Question;
        _Answer = Answer;
        _Choice1 = Choice1;
        _Choice2 = Choice2;
        _Choice3 = Choice3;
        _Choice4 = Choice4;

    }

    public QuestionClass( int Question_Number, string Question, string Answer)
    {
        _Question_Number = Question_Number;
        _Question = Question;  
        _Answer = Answer;
        
    }

    public QuestionClass(int Question_Number, string Question, string Answer, int Quiz_ID)
    {
        _Question_Number = Question_Number;
        _Question = Question;
        _Answer = Answer;
        _Quiz_ID = Quiz_ID;
    }

    public QuestionClass(int Question_Number, string Question, string Answer,string Choice1,string Choice2 ,string Choice3, string Choice4,int Quiz_ID)
    {
        _Question_Number = Question_Number;
        _Question = Question;
        _Answer = Answer;
        _Choice1 = Choice1;
        _Choice2 = Choice2;
        _Choice3 = Choice3;
        _Choice4 = Choice4;
        _Quiz_ID = Quiz_ID;
    }

    public int ID
    {
        get { return _ID; }
        set { _ID = value; }
    }

    public int Question_Number
    {
        get { return _Question_Number; }
        set { _Question_Number = value; }
    }

    public string Question
    {
        get { return _Question; }
        set { _Question = value; }
    }



    public string Answer
    {
        get { return _Answer; }
        set { _Answer = value; }
    }

    public string Choice1
    {
        get { return _Choice1; }
        set { _Choice1 = value; }
    }
    public string Choice2
    {
        get { return _Choice2; }
        set { _Choice2 = value; }
    }
    public string Choice3
    {
        get { return _Choice3; }
        set { _Choice3 = value; }
    }
    public string Choice4
    {
        get { return _Choice4; }
        set { _Choice4 = value; }
    }
    public int Quiz_ID
    {
        get { return _Quiz_ID; }
        set { _Quiz_ID = value; }
    }

    public QuestionClass getQuestion(String ID)
    {
        QuestionClass Question_Detail = null;
        string queryStr = "SELECT * FROM CoursesQuestions WHERE ID = @ID";
        SqlConnection conn = new SqlConnection(connStr);
        SqlCommand cmd = new SqlCommand(queryStr, conn);
        cmd.Parameters.AddWithValue("@ID", ID);
        conn.Open();

        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            string Question_Number = dr["Question_Number"].ToString();
            string Question = dr["Question"].ToString();
            string Answer = dr["Answer"].ToString();
            string Choice1 = dr["Choice1"].ToString();
            string Choice2 = dr["Choice2"].ToString();
            string Choice3 = dr["Choice3"].ToString();
            string Choice4 = dr["Choice4"].ToString();
            string Quiz_ID = dr["Quiz_ID"].ToString();

            Question_Detail = new QuestionClass(Convert.ToInt32(ID), Convert.ToInt32(Question_Number), Question, Answer, Choice1,Choice2,Choice3,Choice4,Convert.ToInt32(Quiz_ID));
        }
        else
        {
            Question_Detail = null;
        }
        conn.Close();
        dr.Close();
        dr.Dispose();
        return Question_Detail;
    }

    public List<QuestionClass> getQuestionAll()
    {
        List<QuestionClass> QuizList = new List<QuestionClass>();

        string queryStr = "SELECT * FROM CoursesQuestions ORDER BY Question_Number";
        using (SqlConnection conn = new SqlConnection(connStr))
        {
            conn.Open();
            using (SqlCommand cmd = new SqlCommand(queryStr, conn))
            {
                //cmd.Parameters.AddWithValue("@Quiz_ID",QID);
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    
                    string ID  = dr["ID"].ToString();
                    string Question_Number = dr["Question_Number"].ToString();
                    string Question = dr["Question"].ToString();
                    string Answer = dr["Answer"].ToString();
                    string Choice1 = dr["Choice1"].ToString();
                    string Choice2 = dr["Choice2"].ToString();
                    string Choice3 = dr["Choice3"].ToString();
                    string Choice4 = dr["Choice4"].ToString();
                    string Quiz_ID = dr["Quiz_ID"].ToString();

                    QuestionClass a = new QuestionClass(Convert.ToInt32(ID), Convert.ToInt32(Question_Number), Question, Answer, Choice1, Choice2, Choice3, Choice4,Convert.ToInt32(Quiz_ID));
                    QuizList.Add(a);
                }
            }

        }
        return QuizList;
    }


    public List<QuestionClass> getSingleQuestion(string qID)
    {
        List<QuestionClass> QuestionList = new List<QuestionClass>();

        string queryStr = "SELECT * FROM CoursesQuestions WHERE ID = @ID";
        using (SqlConnection conn = new SqlConnection(connStr))
        {
            conn.Open();
            using (SqlCommand cmd = new SqlCommand(queryStr, conn))
            {
                cmd.Parameters.AddWithValue("@ID", qID);
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    //string id = dr["id"].ToString();
                    string Question_Number = dr["Question_Number"].ToString();
                    string Question = dr["Question"].ToString();
                    string Answer = dr["Answer"].ToString();
                    string Choice1 = dr["Choice1"].ToString();
                    string Choice2 = dr["Choice2"].ToString();
                    string Choice3 = dr["Choice3"].ToString();
                    string Choice4 = dr["Choice4"].ToString();
                    string Quiz_ID = dr["Quiz_ID"].ToString();

                    QuestionClass a = new QuestionClass(Convert.ToInt32(ID), Convert.ToInt32(Question_Number), Question, Answer, Choice1, Choice2, Choice3,Choice4, Convert.ToInt32(Quiz_ID));
                    QuestionList.Add(a);
                }
            }

        }
        return QuestionList;


    }

    

    public int QuestionInsert()
    {
        int result = 0;
        string queryStr = "INSERT INTO CoursesQuestions(Question_Number, Question, Answer,Choice1,Choice2,Choice3,Choice4, Quiz_ID)"
                        + "values (@Question_Number, @Question, @Answer,@Choice1,@Choice2,@Choice3,@Choice4, @Quiz_ID)";

        using (SqlConnection conn = new SqlConnection(connStr))
        {
            conn.Open();
            using (SqlCommand cmd = new SqlCommand(queryStr, conn))
            {
                cmd.Parameters.AddWithValue("@Question_Number", this.Question_Number);
                cmd.Parameters.AddWithValue("@Question", this.Question);         
                cmd.Parameters.AddWithValue("@Answer", this.Answer);
                cmd.Parameters.AddWithValue("@Choice1", this.Choice1);
                cmd.Parameters.AddWithValue("@Choice2", this.Choice2);
                cmd.Parameters.AddWithValue("@Choice3", this.Choice3);
                cmd.Parameters.AddWithValue("@Choice4", this.Choice4);
                cmd.Parameters.AddWithValue("@Quiz_ID", this.Quiz_ID);

                result += cmd.ExecuteNonQuery();
            }
        }
        return result;
    }

    public int QuestionDelete(string ID)
    {
        string queryStr = "DELETE FROM CoursesQuestions WHERE ID=@ID";
        SqlConnection conn = new SqlConnection(connStr);
        SqlCommand cmd = new SqlCommand(queryStr, conn);
        cmd.Parameters.AddWithValue("@ID", ID);
        conn.Open();
        int nofRow = 0;
        nofRow = cmd.ExecuteNonQuery();
        conn.Close();
        return nofRow;
    }

    public int QuestionUpdate(int ID, string qQuestion, string aAnswer,string cChoice1,string cChoice2,string cChoice3,string cChoice4)
    {
        string queryStr = "UPDATE CoursesQuestions SET" +

        " Question = @Question, " +
        " Answer = @Answer, " +
        " Choice1 = @Choice1, " +
        " Choice2 = @Choice2, " +
        " Choice3= @Choice3, " +
        " Choice4= @Choice4 " +
        " WHERE ID = @ID";

        SqlConnection conn = new SqlConnection(connStr);
        SqlCommand cmd = new SqlCommand(queryStr, conn);
        cmd.Parameters.AddWithValue("@ID", ID);
        cmd.Parameters.AddWithValue("@Question", qQuestion);
        cmd.Parameters.AddWithValue("@Answer", aAnswer);
        cmd.Parameters.AddWithValue("@Choice1", cChoice1);
        cmd.Parameters.AddWithValue("@Choice2", cChoice2);
        cmd.Parameters.AddWithValue("@Choice3", cChoice3);
        cmd.Parameters.AddWithValue("@Choice4", cChoice4);
        conn.Open();
        int nofRow = 0;
        nofRow = cmd.ExecuteNonQuery();
        conn.Close();
        return nofRow;
    }

    //Integrator
    public List<QuestionClass> getQuestionByQuiz(string QID)
    {
        List<QuestionClass> QuizList = new List<QuestionClass>();

        string queryStr = "SELECT * FROM CoursesQuestions WHERE Quiz_ID = @Quiz_ID ORDER BY Question_Number";
        using (SqlConnection conn = new SqlConnection(connStr))
        {
            conn.Open();
            using (SqlCommand cmd = new SqlCommand(queryStr, conn))
            {
                cmd.Parameters.AddWithValue("@Quiz_ID", QID);
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {

                    string ID = dr["ID"].ToString();
                    string Question_Number = dr["Question_Number"].ToString();
                    string Question = dr["Question"].ToString();
                    string Answer = dr["Answer"].ToString();
                    string Choice1 = dr["Choice1"].ToString();
                    string Choice2 = dr["Choice2"].ToString();
                    string Choice3 = dr["Choice3"].ToString();
                    string Choice4 = dr["Choice4"].ToString();
                    string Quiz_ID = dr["Quiz_ID"].ToString();

                    QuestionClass a = new QuestionClass(Convert.ToInt32(ID), Convert.ToInt32(Question_Number), Question, Answer, Choice1, Choice2, Choice3, Choice4, Convert.ToInt32(Quiz_ID));
                    QuizList.Add(a);
                }
            }

        }
        return QuizList;
    }


    public int getLatestQuizID()
    {
        int output = 0;
        string queryStr = "SELECT ID FROM COursesQuestions ORDER BY ID DESC";
        using (SqlConnection conn = new SqlConnection(connStr))
        {
            conn.Open();
            using (SqlCommand cmd = new SqlCommand(queryStr, conn))
            {
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    if (int.Parse(dr["id"].ToString()) > output)
                    {
                        output = (int.Parse(dr["id"].ToString()));
                    }
                }
            }

        }
        return output;
    }
}