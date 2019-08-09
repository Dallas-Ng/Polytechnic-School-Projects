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
public class FeedbackClass
{
    string connStr = ConfigurationManager.ConnectionStrings["EBP-Database"].ConnectionString;

    /// <summary>
    /// This is the initalisation for all the variables
    /// </summary>
    private string _Feedback_ID, _Feedback, _Login_Id, _Course_Id = "";
    private int _Rating = 0;
    private string rating;

    /// <summary>
    /// Constructors
    /// </summary>
    public FeedbackClass(string Feedback_ID, string Feedback, int Rating,  string Course_ID, string Login_ID)
    {
        _Feedback_ID = Feedback_ID;
        _Rating = Rating;
        _Feedback = Feedback;
        
        _Course_Id = Course_ID;
        _Login_Id = Login_ID;
    }

    public FeedbackClass(int Rating, string Feedback, string Course_ID, string Login_ID)
    {
        _Feedback = Feedback;
        _Rating = Rating;
        _Course_Id = Course_ID;
        _Login_Id = Login_ID;
    }

    public FeedbackClass()
    {

    }
    public FeedbackClass(string Feedback_ID,string Feedback, int Rating, string Login_ID)
    {
        _Feedback_ID = Feedback_ID;
        _Feedback = Feedback;
        _Rating = Rating;
     
        _Login_Id = Login_ID;
    }

    /// <summary>
    /// Get and Setter Methods
    /// </summary>
    public string Feedback_ID
    {
        get { return _Feedback_ID; }
        set { _Feedback_ID = value; }
    }

    public string Feedback
    {
        get { return _Feedback; }
        set { _Feedback = value; }
    }

    public int Rating
    {
        get { return _Rating; }
        set { _Rating = value; }
    }

    public string Course_ID
    {
        get { return _Course_Id; }
        set { _Course_Id = value; }
    }

    public string Login_ID
    {
        get { return _Login_Id; }
        set { _Login_Id = value; }
    }

    /// <summary>
    /// Gets feedback data using feedback ID
    /// </summary>
    public List<FeedbackClass> getFeedback(String c_ID)
    {
        List<FeedbackClass> FeedbackList = new List<FeedbackClass>();

        string queryStr = "SELECT * FROM CoursesFeedback WHERE Course_ID = @Course_ID";
        using (SqlConnection conn = new SqlConnection(connStr))
        {
            conn.Open();
            using (SqlCommand cmd = new SqlCommand(queryStr, conn))
            {
                cmd.Parameters.AddWithValue("@Course_ID", c_ID);

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    string Feedback_ID = dr["Feedback_ID"].ToString();
                    string Rating = dr["Rating"].ToString();
                    string Feedback = dr["Feedback"].ToString();
                    string Course_ID = dr["Course_ID"].ToString();
                    string Login_ID = dr["Login_ID"].ToString();

                    FeedbackClass a = new FeedbackClass(Feedback_ID,  Feedback, Convert.ToInt32(Rating), Course_ID, Login_ID);
                    FeedbackList.Add(a);
                }
            }

        }
        return FeedbackList;
    }

    public List<FeedbackClass> getFeedbackAll()
    {
        List<FeedbackClass> FeedbackList = new List<FeedbackClass>();

        string queryStr = "SELECT * FROM CoursesFeedback Order By Feedback_ID";
        using (SqlConnection conn = new SqlConnection(connStr))
        {
            conn.Open();
            using (SqlCommand cmd = new SqlCommand(queryStr, conn))
            {
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    string Feedback_ID = dr["Feedback_ID"].ToString();
                    string Rating = dr["Rating"].ToString();
                    string Feedback = dr["Feedback"].ToString();
                    string Course_ID = dr["Course_ID"].ToString();
                    string Login_ID = dr["Login_ID"].ToString();

                    FeedbackClass a = new FeedbackClass(Feedback_ID,  Feedback, Convert.ToInt32(Rating), Course_ID,Login_ID);
                    FeedbackList.Add(a);
                }
            }

        }
        return FeedbackList;
    }
    public int FeedbackInsert()
    {
        int result = 0;
        string queryStr = "INSERT INTO CoursesFeedback(Rating, Feedback, Login_ID, Course_ID)"
                        + "values (@Rating, @Feedback, @Login_ID, @Course_ID)";

        using (SqlConnection conn = new SqlConnection(connStr))
        {
            conn.Open();
            using (SqlCommand cmd = new SqlCommand(queryStr, conn))
            {
                //cmd.Parameters.AddWithValue("@Feedback_ID", this.Feedback_ID);
                cmd.Parameters.AddWithValue("@Rating", this.Rating);
                cmd.Parameters.AddWithValue("@Feedback", this.Feedback);
                cmd.Parameters.AddWithValue("@Login_ID", this.Login_ID);
                cmd.Parameters.AddWithValue("@Course_ID", this.Course_ID);
                result += cmd.ExecuteNonQuery();
            }
        }
        return result;
    }

    public int FeedbackDelete(string Feedback_ID)
    {
        string queryStr = "DELETE FROM CoursesFeedback WHERE Feedback_ID = @Feedback_ID";
        SqlConnection conn = new SqlConnection(connStr);
        SqlCommand cmd = new SqlCommand(queryStr, conn);
        cmd.Parameters.AddWithValue("@Feedback_ID", Feedback_ID);
        conn.Open();
        int nofRow = 0;
        nofRow = cmd.ExecuteNonQuery();
        conn.Close();
        return nofRow;
    }

    public int FeedbackUpdate(string Feedback_ID, int fRating, string fFeedback)
    {
        string queryStr = "UPDATE CoursesFeedback SET" +

        " Rating = @Rating, " +
        " Feedback = @Feedback  " + 
        " WHERE Feedback_ID = @Feedback_ID";

        SqlConnection conn = new SqlConnection(connStr);
        SqlCommand cmd = new SqlCommand(queryStr, conn);
        cmd.Parameters.AddWithValue("@Feedback_ID", Feedback_ID);
        cmd.Parameters.AddWithValue("@Rating",fRating);
        cmd.Parameters.AddWithValue("@Feedback", fFeedback);
        conn.Open();
        int nofRow = 0;
        nofRow = cmd.ExecuteNonQuery();
        conn.Close();
        return nofRow;
    }
}

