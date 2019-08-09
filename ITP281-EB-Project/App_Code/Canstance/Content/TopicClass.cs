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
public class TopicClass
{
    string connStr = ConfigurationManager.ConnectionStrings["EBP-Database"].ConnectionString;

    /// <summary>
    /// This is the initalisation for all the variables
    /// </summary>
    private string _Topic_ID, _Topic_Title, _Topic_Upload_Date, _Course_ID = "";
    private int _Topic_Progress_Bar = 0;

    public TopicClass()
    {

    }
    public TopicClass(string Topic_ID, string Topic_Title, string Topic_Upload_Date, int Topic_Progress_bar, string Course_ID)
    {
        _Topic_ID = Topic_ID;

        _Topic_Title = Topic_Title;
        _Topic_Upload_Date = Topic_Upload_Date;
        _Topic_Progress_Bar = Topic_Progress_bar;
        _Course_ID = Course_ID;
    }

    public TopicClass(string Topic_Title, string Topic_Upload_Date, int Topic_Progress_bar, string Course_ID)
    {


        _Topic_Title = Topic_Title;
        _Topic_Upload_Date = Topic_Upload_Date;
        _Topic_Progress_Bar = Topic_Progress_bar;
        _Course_ID = Course_ID;
    }
    public string Topic_ID
    {
        get { return _Topic_ID; }
        set { _Topic_ID = value; }
    }
    public string Topic_Title
    {
        get { return _Topic_Title; }
        set { _Topic_Title = value; }
    }
    public string Topic_Upload_Date
    {
        get { return _Topic_Upload_Date; }
        set { _Topic_Upload_Date = value; }
    }
    public int Topic_Progress_Bar
    {
        get { return _Topic_Progress_Bar; }
        set { _Topic_Progress_Bar = value; }
    }

    public string Course_ID
    {
        get { return _Course_ID; }
        set { _Course_ID = value; }
    }

    public TopicClass getTopic(String Topic_ID)
    {
        TopicClass Topic_Detail = null;
        string queryStr = "SELECT * FROM CoursesTopics WHERE Topic_ID = @Topic_ID";
        SqlConnection conn = new SqlConnection(connStr);
        SqlCommand cmd = new SqlCommand(queryStr, conn);
        cmd.Parameters.AddWithValue("@Topic_ID", Topic_ID);
        conn.Open();

        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            string Topic_Title = dr["Topic_Title"].ToString();
            string Topic_Upload_Date = dr["Topic_Upload_Date"].ToString();
            string Topic_Progress_Bar = dr["Topic_Progress_Bar"].ToString();
            string Course_ID = dr["Course_ID"].ToString();

            Topic_Detail = new TopicClass(Topic_ID, Topic_Title, Topic_Upload_Date, Convert.ToInt32(Topic_Progress_Bar), Course_ID);
        }
        else
        {
            Topic_Detail = null;
        }
        conn.Close();
        dr.Close();
        dr.Dispose();
        return Topic_Detail;
    }

    public List<TopicClass> getTopicAll()
    {
        List<TopicClass> TopicList = new List<TopicClass>();

        string queryStr = "SELECT * FROM CoursesTopics WHERE isDeleted = 0 Order By Topic_ID";
        using (SqlConnection conn = new SqlConnection(connStr))
        {
            conn.Open();
            using (SqlCommand cmd = new SqlCommand(queryStr, conn))
            {
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    string Topic_ID = dr["Topic_ID"].ToString();
                    string Topic_Title = dr["Topic_Title"].ToString();
                    string Topic_Upload_Date = dr["Topic_Upload_Date"].ToString();
                    string Topic_Progress_Bar = dr["Topic_Progress_Bar"].ToString();
                    string Course_ID = dr["Course_ID"].ToString();


                    TopicClass a = new TopicClass(Topic_ID, Topic_Title, Topic_Upload_Date, Convert.ToInt32(Topic_Progress_Bar), Course_ID);
                    TopicList.Add(a);
                }
            }

        }
        return TopicList;
    }
    public List<TopicClass> getSingleTopic(string tID)
    {
        List<TopicClass> TopicList = new List<TopicClass>();

        string queryStr = "SELECT * FROM CoursesTopics WHERE Topic_ID = @Topic_ID";
        using (SqlConnection conn = new SqlConnection(connStr))
        {
            conn.Open();
            using (SqlCommand cmd = new SqlCommand(queryStr, conn))
            {
                cmd.Parameters.AddWithValue("@Topic_ID", tID);
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    string Topic_ID = dr["Topic_ID"].ToString();
                    string Topic_Title = dr["Topic_Title"].ToString();
                    string Topic_Upload_Date = dr["Topic_Upload_Date"].ToString();
                    string Topic_Progress_Bar = dr["Topic_Progress_Bar"].ToString();
                    string Course_ID = dr["Course_ID"].ToString();

                    TopicClass a = new TopicClass(Topic_ID, Topic_Title, Topic_Upload_Date, Convert.ToInt32(Topic_Progress_Bar), Course_ID);
                    TopicList.Add(a);
                }
            }

        }
        return TopicList;
    }

    public int TopicInsert()
    {
        int result = 0;
        string queryStr = "INSERT INTO CoursesTopics(Topic_ID, Topic_Title,Topic_Upload_Date, Topic_Progress_Bar, Course_ID)"
                        + "values (@Topic_ID, @Topic_Title, @Topic_Upload_Date,@Topic_Progress_Bar,  @Course_ID)";

        using (SqlConnection conn = new SqlConnection(connStr))
        {
            conn.Open();
            using (SqlCommand cmd = new SqlCommand(queryStr, conn))
            {
                cmd.Parameters.AddWithValue("@Topic_ID", this.Topic_ID);
                cmd.Parameters.AddWithValue("@Topic_Title", this.Topic_Title);

                cmd.Parameters.AddWithValue("@Topic_Upload_Date", Convert.ToDateTime(this.Topic_Upload_Date));
                cmd.Parameters.AddWithValue("@Topic_Progress_Bar", this.Topic_Progress_Bar);
                cmd.Parameters.AddWithValue("@Course_ID", this.Course_ID);
                result += cmd.ExecuteNonQuery();
            }
        }
        return result;
    }

    public int TopicDelete(string Topic_ID)
    {
        //string queryStr = "DELETE FROM CoursesTopics WHERE Topic_ID=@Topic_ID";
        string queryStr = "UPDATE CoursesTopics SET isDeleted = 1 WHERE Topic_ID = @Topic_ID";

        SqlConnection conn = new SqlConnection(connStr);
        SqlCommand cmd = new SqlCommand(queryStr, conn);
        cmd.Parameters.AddWithValue("@Topic_ID", Topic_ID);
        conn.Open();
        int nofRow = 0;
        nofRow = cmd.ExecuteNonQuery();
        conn.Close();
        return nofRow;
    }
    public int TopicUpdate(string Topic_ID, string tTitle)
    {
        string queryStr = "UPDATE CoursesTopics SET Topic_Title = @Topic_Title WHERE Topic_ID = @Topic_ID";

        SqlConnection conn = new SqlConnection(connStr);
        SqlCommand cmd = new SqlCommand(queryStr, conn);
        cmd.Parameters.AddWithValue("@Topic_ID", Topic_ID);
        cmd.Parameters.AddWithValue("@Topic_Title", tTitle);
        conn.Open();
        int nofRow = 0;
        nofRow = cmd.ExecuteNonQuery();
        conn.Close();
        return nofRow;
    }

    public DataTable Search(String search, string Course_ID)
    {
        string connStr = ConfigurationManager.ConnectionStrings["EBP-Database"].ConnectionString;
        SqlConnection myConn = new SqlConnection(connStr);

        myConn.Open();

        SqlCommand sqlCmd = new SqlCommand();
        string sqlQuery = "SELECT * FROM CoursesTopics WHERE Topic_Title LIKE '%'+@Topic_Title+'%' AND Course_ID=@Course_ID  and IsDeleted=0";
        sqlCmd.CommandText = sqlQuery;
        sqlCmd.Connection = myConn;
        sqlCmd.Parameters.AddWithValue("@Topic_Title", search);
        sqlCmd.Parameters.AddWithValue("@Course_ID", Course_ID);
        DataTable dt = new DataTable();
        SqlDataAdapter sda = new SqlDataAdapter(sqlCmd);
        sda.Fill(dt);
        return dt;
    }


    public List<TopicClass> getTopicAllbyCourse(string Course_ID)
    {
        List<TopicClass> TopicList = new List<TopicClass>();

        string queryStr = "SELECT * FROM CoursesTopics WHERE Course_ID=@Course_ID and isDeleted = 0 Order By Topic_ID";
        using (SqlConnection conn = new SqlConnection(connStr))
        {
            conn.Open();
            using (SqlCommand cmd = new SqlCommand(queryStr, conn))
            {
                cmd.Parameters.AddWithValue("@Course_ID", Course_ID);
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    string Topic_ID = dr["Topic_ID"].ToString();
                    string Topic_Title = dr["Topic_Title"].ToString();
                    string Topic_Upload_Date = dr["Topic_Upload_Date"].ToString();
                    string Topic_Progress_Bar = dr["Topic_Progress_Bar"].ToString();

                    TopicClass a = new TopicClass(Topic_ID, Topic_Title, Topic_Upload_Date, Convert.ToInt32(Topic_Progress_Bar), Course_ID);
                    TopicList.Add(a);
                }
            }

        }
        return TopicList;
    }
}