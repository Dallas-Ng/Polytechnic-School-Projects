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
public class QuizClass
{
    string connStr = ConfigurationManager.ConnectionStrings["EBP-Database"].ConnectionString;

    private string  _Quiz_Status,_Quiz_Completed_Date,_Quiz_Upload_Date ,_Topic_ID= "";
    private int _Quiz_ID,_Quiz_Marks = 0;

 
    public QuizClass()
    {
       
    }

    public QuizClass(int Quiz_ID, string Quiz_Upload_Date, string Topic_ID)
    {
        _Quiz_ID = Quiz_ID;
        _Quiz_Upload_Date = Quiz_Upload_Date;
        _Topic_ID = Topic_ID;
    }

    public QuizClass(string Topic_ID)
    {

        _Topic_ID = Topic_ID;
    }
    public QuizClass(int Quiz_ID, int Quiz_Marks, string Quiz_Status,string Quiz_Completed_Date,string Quiz_Upload_Date ,string Topic_ID)
    {
        _Quiz_ID = Quiz_ID;

        _Quiz_Marks = Quiz_Marks;
        _Quiz_Status = Quiz_Status;
        _Quiz_Completed_Date = Quiz_Completed_Date;
        _Quiz_Upload_Date = Quiz_Upload_Date;
        _Topic_ID = Topic_ID;
    }

    public int Quiz_ID
    {
        get { return _Quiz_ID; }
        set { _Quiz_ID = value; }
    }

    public int Quiz_Marks
    {
        get { return _Quiz_Marks; }
        set { _Quiz_Marks = value; }
    }
    public string Quiz_Status
    {
        get { return _Quiz_Status; }
        set { _Quiz_Status = value; }
    }
    public string Quiz_Completed_Date
    {
        get { return _Quiz_Completed_Date; }
        set { _Quiz_Completed_Date = value; }
    }
    public string Quiz_Upload_Date
    {
        get { return _Quiz_Upload_Date; }
        set { _Quiz_Upload_Date = value; }
    }

    public string Topic_ID
    {
        get { return _Topic_ID; }
        set { _Topic_ID = value; }
    }

    public QuizClass getQuiz(String Quiz_ID)
    {
        QuizClass Quiz_Detail = null;
        string queryStr = "SELECT * FROM CoursesQuizes WHERE Quiz_ID = @Quiz_ID and isDeleted = 0";
        SqlConnection conn = new SqlConnection(connStr);
        SqlCommand cmd = new SqlCommand(queryStr, conn);
        cmd.Parameters.AddWithValue("@Quiz_ID", Quiz_ID);
        conn.Open();

        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            string Quiz_Marks = dr["Quiz_Marks"].ToString();
            string Quiz_Status = dr["Quiz_Status"].ToString();
            string Quiz_Completed_Date = dr["Quiz_Completed_Date"].ToString();
            string Quiz_Upload_Date = dr["Quiz_Upload_Date"].ToString();
            string Topic_ID = dr["Topic_ID"].ToString();

            Quiz_Detail = new QuizClass(Convert.ToInt32(Quiz_ID), Convert.ToInt32(Quiz_Marks), Quiz_Status, Quiz_Completed_Date, Quiz_Upload_Date,Topic_ID);
        }
        else
        {
            Quiz_Detail = null;
        }
        conn.Close();
        dr.Close();
        dr.Dispose();
        return Quiz_Detail;
    }

    public List<QuizClass> getQuizAll()
    {
        List<QuizClass> QuizList = new List<QuizClass>();

        string queryStr = "SELECT * FROM CoursesQuizes WHERE isDeleted = 0 ORDER BY Quiz_ID ";
        using (SqlConnection conn = new SqlConnection(connStr))
        {
            conn.Open();
            using (SqlCommand cmd = new SqlCommand(queryStr, conn))
            {
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    string Quiz_ID = dr["Quiz_ID"].ToString();
                    string Quiz_Marks = dr["Quiz_Marks"].ToString();
                    string Quiz_Status = dr["Quiz_Status"].ToString();
                    string Quiz_Completed_Date = dr["Quiz_Completed_Date"].ToString();
                    string Quiz_Upload_Date = dr["Quiz_Upload_Date"].ToString();
                    string Topic_ID = dr["Topic_ID"].ToString();


                    QuizClass a = new QuizClass(Convert.ToInt32(Quiz_ID), Quiz_Upload_Date, Topic_ID);
                    QuizList.Add(a);
                }
            }

        }
        return QuizList;
    }

    public List<QuizClass> getSingleQuiz(string qID)
    {
        List<QuizClass> QuizList = new List<QuizClass>();

        string queryStr = "SELECT * FROM CoursesQuizes WHERE Quiz_ID = @Quiz_ID ";
        using (SqlConnection conn = new SqlConnection(connStr))
        {
            conn.Open();
            using (SqlCommand cmd = new SqlCommand(queryStr, conn))
            {
                cmd.Parameters.AddWithValue("@Quiz_ID", qID);
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    string Quiz_ID = dr["Quiz_ID"].ToString();
                    string Quiz_Upload_Date = dr["Quiz_Upload_Date"].ToString();
                    string Topic_ID = dr["Topic_ID"].ToString();

                    QuizClass a = new QuizClass(Convert.ToInt32(Quiz_ID), Quiz_Upload_Date,Topic_ID);
                    QuizList.Add(a);
                }
            }

        }
        return QuizList;
    }

    public List<QuizClass> RetrieveUrl(string QID)
    {
        List<QuizClass> QuizList = new List<QuizClass>();

        string queryStr;
        queryStr = "SELECT * FROM CourseQuizes WHERE Quiz_ID = @Quiz_ID and isDeleted = 0";

        using (SqlConnection conn = new SqlConnection(connStr))
        {
            conn.Open();
            using (SqlCommand cmd = new SqlCommand(queryStr, conn))
            {
                cmd.Parameters.AddWithValue("@Quiz_ID", QID);

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr != null) // If there is something to read
                    {
                        while (dr.Read())
                        {
                            string Quiz_ID = dr["Quiz_ID"].ToString();
                            string Quiz_Marks = dr["Quiz_Marks"].ToString();
                            string Quiz_Status = dr["Quiz_Status"].ToString();
                            string Quiz_Completed_Date = dr["Quiz_Completed_Date"].ToString();
                            string Quiz_Upload_Date = dr["Quiz_Upload_Date"].ToString();
                            string Topic_ID = dr["Topic_ID"].ToString();


                            QuizClass a = new QuizClass(Convert.ToInt32(Quiz_ID), Convert.ToInt32(Quiz_Marks), Quiz_Status, Quiz_Completed_Date, Quiz_Upload_Date, Topic_ID);
                            QuizList.Add(a);
                        }

                    }
                }
            }
        }
        return QuizList;
    }

    public int QuizInsert()
    {
        int result = 0;
        string queryStr = "INSERT INTO CoursesQuizes(Topic_ID)"
                        + "values ( @Topic_ID)";

        using (SqlConnection conn = new SqlConnection(connStr))
        {
            conn.Open();
            using (SqlCommand cmd = new SqlCommand(queryStr, conn))
            {
                
               // cmd.Parameters.AddWithValue("@Quiz_Marks", this.Quiz_Marks);
               // cmd.Parameters.AddWithValue("@Quiz_Status", this.Quiz_Status);

                
                cmd.Parameters.AddWithValue("@Topic_ID", this.Topic_ID);
                result += cmd.ExecuteNonQuery();
            }
        }
        return result;
    }

    public int QuizInsert(string Topic_ID)
    {
        int result = 0;
        string queryStr = "INSERT INTO CoursesQuizes(Topic_ID)"
                        + "values ( @Topic_ID)";

        using (SqlConnection conn = new SqlConnection(connStr))
        {
            conn.Open();
            using (SqlCommand cmd = new SqlCommand(queryStr, conn))
            {

                // cmd.Parameters.AddWithValue("@Quiz_Marks", this.Quiz_Marks);
                // cmd.Parameters.AddWithValue("@Quiz_Status", this.Quiz_Status);


                cmd.Parameters.AddWithValue("@Topic_ID", Topic_ID);
                result += cmd.ExecuteNonQuery();
            }
        }
        return result;
    }

    public int QuizDelete(string Quiz_ID)
    {
        string queryStr = "Update CoursesQuizes set isDeleted = 1 WHERE Quiz_ID=@Quiz_ID";
        SqlConnection conn = new SqlConnection(connStr);
        SqlCommand cmd = new SqlCommand(queryStr, conn);
        cmd.Parameters.AddWithValue("@Quiz_ID", Quiz_ID);
        conn.Open();
        int nofRow = 0;
        nofRow = cmd.ExecuteNonQuery();
        conn.Close();
        return nofRow;
    }

    public int QuizUpdate(int Quiz_ID,int qMarks, string qStatus)
    {
        string queryStr = "UPDATE CoursesQuizes SET" +

        " Quiz_Marks = @Quiz_Marks, " +
        " Quiz_Status = @Quiz_Status, " +

        " WHERE Quiz_ID = @Quiz_ID";

        SqlConnection conn = new SqlConnection(connStr);
        SqlCommand cmd = new SqlCommand(queryStr, conn);

        cmd.Parameters.AddWithValue("@Quiz_ID", Quiz_ID);
        cmd.Parameters.AddWithValue("@Quiz_Marks", qMarks);

        cmd.Parameters.AddWithValue("@Quiz_Status", qStatus);
        //cmd.Parameters.AddWithValue("@Quiz_Completed_Date", qCompletedDate);
        conn.Open();
        int nofRow = 0;
        nofRow = cmd.ExecuteNonQuery();
        conn.Close();
        return nofRow;
    }


    // Integrator
    public List<QuizClass> getQuizAllbyTopic(string Topic_ID)
    {
        List<QuizClass> QuizList = new List<QuizClass>();

        string queryStr = "SELECT * FROM CoursesQuizes WHERE Topic_Id = @Topic_ID and isDeleted = 0 ORDER BY Quiz_ID ";
        using (SqlConnection conn = new SqlConnection(connStr))
        {
            conn.Open();
            using (SqlCommand cmd = new SqlCommand(queryStr, conn))
            {
                cmd.Parameters.AddWithValue("@Topic_ID", Topic_ID);

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    string Quiz_ID = dr["Quiz_ID"].ToString();
                    string Quiz_Marks = dr["Quiz_Marks"].ToString();
                    string Quiz_Status = dr["Quiz_Status"].ToString();
                    string Quiz_Completed_Date = dr["Quiz_Completed_Date"].ToString();
                    string Quiz_Upload_Date = dr["Quiz_Upload_Date"].ToString();

                    QuizClass a = new QuizClass(Convert.ToInt32(Quiz_ID), Quiz_Upload_Date, Topic_ID);
                    QuizList.Add(a);
                }
            }

        }
        return QuizList;
    }


    public int getLatestQuizID()
    {
        int output = 0;
        string queryStr = "SELECT Quiz_ID FROM CoursesQuizes ORDER BY Quiz_ID DESC";
        using (SqlConnection conn = new SqlConnection(connStr))
        {
            conn.Open();
            using (SqlCommand cmd = new SqlCommand(queryStr, conn))
            {
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    if (int.Parse(dr["Quiz_ID"].ToString()) > output)
                    {
                        output = (int.Parse(dr["Quiz_ID"].ToString()));
                    }
                }
            }

        }
        return output;
    }
}