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
public class VideoClass
{
    string connStr = ConfigurationManager.ConnectionStrings["EBP-Database"].ConnectionString;

    /// <summary>
    /// This is the initalisation for all the variables
    /// </summary>
    private string _Video_ID, _Video_Duration, _Video_Upload_Date, _Topic_ID, _Video = "";
    private int _Video_Progress = 0;

    public VideoClass(string Video_ID, int Video_Progress, string Video_Duration, string Video_Upload_Date, string Topic_ID, string Video)
    {
        _Video_ID = Video_ID;
        _Video_Progress = Video_Progress;
        _Video_Duration = Video_Duration;
        _Video_Upload_Date = Video_Upload_Date;
        _Topic_ID = Topic_ID;
        _Video = Video;
    }
    public VideoClass(string Video_ID, int Video_Progress, string Video_Upload_Date, string Topic_ID, string Video)
    {
        _Video_ID = Video_ID;
        _Video_Progress = Video_Progress;
        //_Video_Duration = Video_Duration;
        _Video_Upload_Date = Video_Upload_Date;
        _Topic_ID = Topic_ID;
        _Video = Video;
    }
    public VideoClass(int Video_Progress, string Video_Upload_Date, string Topic_ID, string Video)
    {
        //_Video_ID = Video_ID;
        _Video_Progress = Video_Progress;
        //_Video_Duration = Video_Duration;
        _Video_Upload_Date = Video_Upload_Date;
        _Topic_ID = Topic_ID;
        _Video = Video;
    }
    public VideoClass()
    {
    }

    public string Video_ID
    {
        get { return _Video_ID; }
        set { _Video_ID = value; }
    }
    public int Video_Progress
    {
        get { return _Video_Progress; }
        set { _Video_Progress = value; }
    }
    public string Video_Duration
    {
        get { return _Video_Duration; }
        set { _Video_Duration = value; }
    }
    public string Video_Upload_Date
    {
        get { return _Video_Upload_Date; }
        set { _Video_Upload_Date = value; }
    }
    public string Topic_ID
    {
        get { return _Topic_ID; }
        set { _Topic_ID = value; }
    }
    public string Video
    {
        get { return _Video; }
        set { _Video = value; }
    }


    public VideoClass getVideo(String Video_ID)
    {
        VideoClass Video_Detail = null;
        string queryStr = "SELECT * FROM CoursesVideos WHERE Video_ID = @Video_ID";
        SqlConnection conn = new SqlConnection(connStr);
        SqlCommand cmd = new SqlCommand(queryStr, conn);
        cmd.Parameters.AddWithValue("@Video_ID", Video_ID);
        conn.Open();

        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            string Video_Progress = dr["Video_Progress"].ToString();
            string Video_Duration = dr["Video_Duration"].ToString();
            string Video_Upload_Date = dr["Video_Upload_Date"].ToString();
            string Topic_ID = dr["Topic_ID"].ToString();
            string Video = dr["Video"].ToString();

            Video_Detail = new VideoClass(Video_ID, Convert.ToInt32(Video_Progress), Video_Duration, Video_Upload_Date, Topic_ID, Video);
        }
        else
        {
            Video_Detail = null;
        }
        conn.Close();
        dr.Close();
        dr.Dispose();
        return Video_Detail;
    }

    public List<VideoClass> getVideoAll()
    {
        List<VideoClass> VideoList = new List<VideoClass>();

        string queryStr = "SELECT * FROM CoursesVideos Order By Video_ID";
        using (SqlConnection conn = new SqlConnection(connStr))
        {
            conn.Open();
            using (SqlCommand cmd = new SqlCommand(queryStr, conn))
            {
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    string Video_ID = dr["Video_ID"].ToString();
                    string Video_Progress = dr["Video_Progress"].ToString();
                    string Video_Duration = dr["Video_Duration"].ToString();
                    string Video_Upload_Date = dr["Video_Upload_Date"].ToString();
                    string Topic_ID = dr["Topic_ID"].ToString();
                    string Video = dr["Video"].ToString();

                    VideoClass a = new VideoClass(Video_ID, Convert.ToInt32(Video_Progress), Video_Duration, Video_Upload_Date, Topic_ID, Video);
                    VideoList.Add(a);
                }
            }

        }
        return VideoList;
    }

    public List<VideoClass> getSingleVideo(string vID)
    {
        List<VideoClass> VideoList = new List<VideoClass>();

        string queryStr = "SELECT * FROM CoursesVideos WHERE Video_ID = @Video_ID";
        using (SqlConnection conn = new SqlConnection(connStr))
        {
            conn.Open();
            using (SqlCommand cmd = new SqlCommand(queryStr, conn))
            {
                cmd.Parameters.AddWithValue("@Video_ID", vID);
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read()) 
                {
                    string Video_ID = dr["Video_ID"].ToString();
                    string Video_Progress = dr["Video_Progress"].ToString();
                    string Video_Duration = dr["Video_Duration"].ToString();
                    string Video_Upload_Date = dr["Video_Upload_Date"].ToString();
                    string Topic_ID = dr["Topic_ID"].ToString();
                    string Video = dr["Video"].ToString();


                    VideoClass a = new VideoClass(Video_ID, Convert.ToInt32(Video_Progress), Video_Duration, Video_Upload_Date, Topic_ID, Video);
                    VideoList.Add(a);
                }
            }

        }
        return VideoList;
    }


    public string VideoInsert()
    {
        string result = null;
        string queryStr = "INSERT INTO CoursesVideos(Video_Progress, Video_Upload_Date, Topic_ID,Video)"
                        + "values (@Video_Progress, @Video_Upload_Date, @Topic_ID,@Video)";
        string queryStr2 = "SELECT * FROM CoursesVideos WHERE Video_Upload_Date = @Video_Upload_Date AND Video = @Video";

        using (SqlConnection conn = new SqlConnection(connStr))
        {
            conn.Open();
            using (SqlCommand cmd = new SqlCommand(queryStr, conn))
            {
                cmd.Parameters.AddWithValue("@Video_Progress", this.Video_Progress);
                //cmd.Parameters.AddWithValue("@Video_Duration", this._Video_Duration);
                cmd.Parameters.AddWithValue("@Video_Upload_Date", Convert.ToDateTime(this.Video_Upload_Date));
                cmd.Parameters.AddWithValue("@Topic_ID", this.Topic_ID);
                cmd.Parameters.AddWithValue("@Video", this.Video);
                result += cmd.ExecuteNonQuery();
            }
            using (SqlCommand cmd = new SqlCommand(queryStr2, conn))
            {
                cmd.Parameters.AddWithValue("@Video_Upload_Date", Convert.ToDateTime(this.Video_Upload_Date));
                cmd.Parameters.AddWithValue("@Video", this.Video);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        result = reader["Video_ID"].ToString();
                    }
                }
            }
        }
        return result;
    }

    public int VideoDelete(string Video_ID)
    {
        string queryStr = "DELETE FROM CoursesVideos WHERE Video_ID=@Video_ID";
        SqlConnection conn = new SqlConnection(connStr);
        SqlCommand cmd = new SqlCommand(queryStr, conn);
        cmd.Parameters.AddWithValue("@Video_ID", Video_ID);
        conn.Open();
        int nofRow = 0;
        nofRow = cmd.ExecuteNonQuery();
        conn.Close();
        return nofRow;
    }

    public int VideoUpdate(string Video_ID, int vProgress, string vDuration, string vDate, string vVideo)
    {
        string queryStr = "UPDATE CoursesVideos SET" +

        " Video_Progress = @Video_Progress, " +
        " Video_Duration = @Video_Duration,  " +
        " Video_Upload_Date = @Video_Upload_Date,  " +
        " Video = @Video  " +
        " WHERE Video_ID = @Video_ID";

        SqlConnection conn = new SqlConnection(connStr);
        SqlCommand cmd = new SqlCommand(queryStr, conn);
        cmd.Parameters.AddWithValue("@Video_ID", Video_ID);
        cmd.Parameters.AddWithValue("@Video_Progress", vProgress);
        cmd.Parameters.AddWithValue("@Video_Duration", vDuration);
        cmd.Parameters.AddWithValue("@Video_Upload_Date", vDate);
        cmd.Parameters.AddWithValue("@Video", vVideo);
        conn.Open();
        int nofRow = 0;
        nofRow = cmd.ExecuteNonQuery();
        conn.Close();
        return nofRow;
    }

    public DataTable Search(String search)
    {
        string connStr = ConfigurationManager.ConnectionStrings["EBP-Database"].ConnectionString;
        SqlConnection myConn = new SqlConnection(connStr);

        myConn.Open();

        SqlCommand sqlCmd = new SqlCommand();
        string sqlQuery = "SELECT * FROM CoursesVideos WHERE Topic_ID LIKE '%'+@Topic_ID+'%' ";
        sqlCmd.CommandText = sqlQuery;
        sqlCmd.Connection = myConn;
        sqlCmd.Parameters.AddWithValue("Topic_ID", search);
        DataTable dt = new DataTable();
        SqlDataAdapter sda = new SqlDataAdapter(sqlCmd);
        sda.Fill(dt);
        return dt;
    }



    // Integrator Codes
    public List<VideoClass> getVideoAllbyTopic(string Topic_ID)
    {
        List<VideoClass> VideoList = new List<VideoClass>();

        string queryStr = "SELECT * FROM CoursesVideos WHERE Topic_ID = @Topic_ID Order By Video_ID ";
        using (SqlConnection conn = new SqlConnection(connStr))
        {
            conn.Open();
            using (SqlCommand cmd = new SqlCommand(queryStr, conn))
            {
                cmd.Parameters.AddWithValue("@Topic_ID", Topic_ID);
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    string Video_ID = dr["Video_ID"].ToString();
                    string Video_Progress = dr["Video_Progress"].ToString();
                    string Video_Duration = dr["Video_Duration"].ToString();
                    string Video_Upload_Date = dr["Video_Upload_Date"].ToString();
                    string Video = dr["Video"].ToString();

                    VideoClass a = new VideoClass(Video_ID, Convert.ToInt32(Video_Progress), Video_Duration, Video_Upload_Date, Topic_ID, Video);
                    VideoList.Add(a);
                }
            }

        }
        return VideoList;
    }
}