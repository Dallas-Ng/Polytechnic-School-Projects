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
public class SlidesClass
{
    string connStr = ConfigurationManager.ConnectionStrings["EBP-Database"].ConnectionString;

    /// <summary>
    /// This is the initalisation for all the variables
    /// </summary>
    private string _Slides_ID, _Slides_Upload_Date, _Topic_ID, _Slides_Upload = "";
    private int _Slides_Pages = 0;

    public SlidesClass()
    {

    }
    public SlidesClass(int Slides_Pages, string Slides_Upload_Date, string Topic_ID, string Slides_Upload)
    {
        _Slides_Pages = Slides_Pages;
        _Slides_Upload_Date = Slides_Upload_Date;
        _Topic_ID = Topic_ID;
        _Slides_Upload = Slides_Upload;
    }
    public SlidesClass(string Slides_ID, int Slides_Pages, string Slides_Upload_Date, string Topic_ID, string Slides_Upload)
    {
        _Slides_ID = Slides_ID;
        _Slides_Pages = Slides_Pages;
        _Slides_Upload_Date = Slides_Upload_Date;
        _Topic_ID = Topic_ID;
        _Slides_Upload = Slides_Upload;
    }

    public SlidesClass(string Slides_ID, int Slides_Pages, string Slides_Upload_Date, string Slides_Upload)
    {
        _Slides_ID = Slides_ID;
        _Slides_Pages = Slides_Pages;
        _Slides_Upload_Date = Slides_Upload_Date;

        _Topic_ID = Slides_Upload;
    }


    public string Slides_ID
    {
        get { return _Slides_ID; }
        set { _Slides_ID = value; }
    }

    public int Slides_Pages
    {
        get { return _Slides_Pages; }
        set { _Slides_Pages = value; }
    }
    public string Slides_Upload_Date
    {
        get { return _Slides_Upload_Date; }
        set { _Slides_Upload_Date = value; }
    }
    public string Topic_ID
    {
        get { return _Topic_ID; }
        set { _Topic_ID = value; }
    }
    public string Slides_Upload
    {
        get { return _Slides_Upload; }
        set { _Slides_Upload = value; }
    }

    public SlidesClass getSlides(String Slides_ID)
    {
        SlidesClass Slides_Detail = null;
        string queryStr = "SELECT * FROM CoursesSlides WHERE Slides_ID = @Slides_ID";
        SqlConnection conn = new SqlConnection(connStr);
        SqlCommand cmd = new SqlCommand(queryStr, conn);
        cmd.Parameters.AddWithValue("@Slides_ID", Slides_ID);
        conn.Open();

        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            string Slides_Pages = dr["Slides_Pages"].ToString();
            string Slides_Upload_Date = dr["Slides_Upload_Date"].ToString();
            string Topic_ID = dr["Topic_ID"].ToString();
            string Slides_Upload = dr["Slides_Upload"].ToString();


            Slides_Detail = new SlidesClass(Slides_ID, Convert.ToInt32(Slides_Pages), Slides_Upload_Date, Topic_ID);
        }
        else
        {
            Slides_Detail = null;
        }
        conn.Close();
        dr.Close();
        dr.Dispose();
        return Slides_Detail;
    }

    public List<SlidesClass> getSingleSlides(String sID)
    {
        List<SlidesClass> SlidesList = new List<SlidesClass>();

        string queryStr = "SELECT * FROM CoursesSlides WHERE Slides_ID = @Slides_ID";
        using (SqlConnection conn = new SqlConnection(connStr))
        {
            conn.Open();
            using (SqlCommand cmd = new SqlCommand(queryStr, conn))
            {
                cmd.Parameters.AddWithValue("@Slides_ID", sID);

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    string Slides_ID = dr["Slides_ID"].ToString();
                    string Slides_Pages = dr["Slides_Pages"].ToString();
                    string Slides_Upload_Date = dr["SLides_Upload_Date"].ToString();
                    string Topic_ID = dr["Topic_ID"].ToString();
                    string Slides_Upload = dr["Slides_Upload"].ToString();

                    SlidesClass a = new SlidesClass(Slides_ID, Convert.ToInt32(Slides_Pages), Slides_Upload_Date, Topic_ID, Slides_Upload);
                    SlidesList.Add(a);
                }
            }

        }
        return SlidesList;
    }

    public List<SlidesClass> getSlidesAll()
    {
        List<SlidesClass> SlidesList = new List<SlidesClass>();

        string queryStr = "SELECT * FROM CoursesSlides Order By Slides_ID";
        using (SqlConnection conn = new SqlConnection(connStr))
        {
            conn.Open();
            using (SqlCommand cmd = new SqlCommand(queryStr, conn))
            {
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    string Slides_ID = dr["Slides_ID"].ToString();
                    string Slides_Pages = dr["Slides_Pages"].ToString();

                    string Slides_Upload_Date = dr["Slides_Upload_Date"].ToString();
                    string Topic_ID = dr["Topic_ID"].ToString();
                    string Slides_Upload = dr["Slides_Upload"].ToString();

                    SlidesClass a = new SlidesClass(Slides_ID, Convert.ToInt32(Slides_Pages), Slides_Upload_Date, Topic_ID, Slides_Upload);
                    SlidesList.Add(a);
                }
            }

        }
        return SlidesList;
    }

    public string SlidesInsert()
    {
        string result = null;
        int result1 = 0;
        string queryStr = "INSERT INTO CoursesSlides(Slides_Pages, Slides_Upload_Date, Topic_ID,Slides_Upload)"
                        + "values (@Slides_Pages, @Slides_Upload_Date, @Topic_ID,@Slides_Upload)";
        string queryStr2 = "SELECT * FROM CoursesSlides WHERE Slides_Upload_Date = @Slides_Upload_Date AND Slides_Upload = @Slides_Upload";

        using (SqlConnection conn = new SqlConnection(connStr))
        {
            conn.Open();
            using (SqlCommand cmd = new SqlCommand(queryStr, conn))
            {
                //cmd.Parameters.AddWithValue("@Slides_ID", this.Slides_ID);
                cmd.Parameters.AddWithValue("@Slides_Pages", this.Slides_Pages);

                cmd.Parameters.AddWithValue("@Slides_Upload_Date", Convert.ToDateTime(this.Slides_Upload_Date));

                cmd.Parameters.AddWithValue("@Topic_ID", this.Topic_ID);
                cmd.Parameters.AddWithValue("@Slides_Upload", this.Slides_Upload);
                result += cmd.ExecuteNonQuery();
            }
            using (SqlCommand cmd = new SqlCommand(queryStr2, conn))
            {
                cmd.Parameters.AddWithValue("@Slides_Upload_Date", Convert.ToDateTime(this.Slides_Upload_Date));
                cmd.Parameters.AddWithValue("@Slides_Upload", this.Slides_Upload);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        result = reader["Slides_ID"].ToString();
                    }
                }
            }
        }
        return result;
    }

    public int SlidesDelete(string Slides_ID)
    {
        string queryStr = "DELETE FROM CoursesSlides WHERE Slides_ID=@Slides_ID";
        SqlConnection conn = new SqlConnection(connStr);
        SqlCommand cmd = new SqlCommand(queryStr, conn);
        cmd.Parameters.AddWithValue("@Slides_ID", Slides_ID);
        conn.Open();
        int nofRow = 0;
        nofRow = cmd.ExecuteNonQuery();
        conn.Close();
        return nofRow;
    }

    public int SlidesUpdate(string Slides_ID, int sPages, string sDate)
    {
        string queryStr = "UPDATE CoursesSlides SET" +

        " Slides_pages = @Slides_pages " +
        " WHERE Slides_ID = @Slides_ID";

        SqlConnection conn = new SqlConnection(connStr);
        SqlCommand cmd = new SqlCommand(queryStr, conn);
        cmd.Parameters.AddWithValue("@Slides_ID", Slides_ID);
        cmd.Parameters.AddWithValue("@Slides_Pages", sPages);
        cmd.Parameters.AddWithValue("@Slides_Upload_Date", sDate);
        cmd.Parameters.AddWithValue("@Slides_Upload", sDate);
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
        string sqlQuery = "SELECT * FROM CoursesSlides WHERE Topic_ID LIKE '%'+@Topic_ID+'%' ";
        sqlCmd.CommandText = sqlQuery;
        sqlCmd.Connection = myConn;
        sqlCmd.Parameters.AddWithValue("Topic_ID", search);
        DataTable dt = new DataTable();
        SqlDataAdapter sda = new SqlDataAdapter(sqlCmd);
        sda.Fill(dt);
        return dt;
    }

    // Integrator Codes
    public List<SlidesClass> getSlidesAllbyTopic(string Topic_ID)
    {
        List<SlidesClass> SlidesList = new List<SlidesClass>();

        string queryStr = "SELECT * FROM CoursesSlides WHERE Topic_ID = @Topic_ID Order By Slides_ID";
        using (SqlConnection conn = new SqlConnection(connStr))
        {
            conn.Open();
            using (SqlCommand cmd = new SqlCommand(queryStr, conn))
            {
                cmd.Parameters.AddWithValue("@Topic_ID", Topic_ID);
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    string Slides_ID = dr["Slides_ID"].ToString();
                    string Slides_Pages = dr["Slides_Pages"].ToString();

                    string Slides_Upload_Date = dr["Slides_Upload_Date"].ToString();
                    string Slides_Upload = dr["Slides_Upload"].ToString();

                    SlidesClass a = new SlidesClass(Slides_ID, Convert.ToInt32(Slides_Pages), Slides_Upload_Date, Topic_ID, Slides_Upload);
                    SlidesList.Add(a);
                }
            }

        }
        return SlidesList;
    }

}