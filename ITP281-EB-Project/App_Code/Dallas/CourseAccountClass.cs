using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;
using System.Data.SqlTypes;

/// <summary>
/// Summary description for CourseAccountClass
/// </summary>
public class CourseAccountClass
{
    private string connStr = ConfigurationManager.ConnectionStrings["EBP-Database"].ConnectionString;
    private int _ID; 
    private string _Login_ID, _Course_ID;
    private bool _isCompleted;
    private DateTime _Recent_Visit, _Completed_Date;
    private string _Course_Title, _Course_Upload_Date, _Course_Author, _Course_Desc, _Course_Subject;
    private int _Course_Order = 0;
    private decimal _Course_Fee = 0;

    public CourseAccountClass(int ID, string Login_ID, string Course_ID, DateTime Recent_Visit, bool isCompleted, DateTime Completed_Date)
    {
        _ID = ID;
        _Login_ID = Login_ID;
        _Course_ID = Course_ID;
        _Recent_Visit = Recent_Visit;
        _isCompleted = isCompleted;
        _Completed_Date = Completed_Date;
    }

    public CourseAccountClass(int ID, string Login_ID, string Course_ID, DateTime Recent_Visit, bool isCompleted, DateTime Completed_Date, string Course_Title, string Course_Upload_Date, string Course_Author, decimal Course_Fee, string Course_Desc, string Course_Subject)
    {
        _ID = ID;
        _Login_ID = Login_ID;
        _Course_ID = Course_ID;
        _Recent_Visit = Recent_Visit;
        _isCompleted = isCompleted;
        _Completed_Date = Completed_Date;
    
        _Course_Title = Course_Title;
        _Course_Upload_Date = Course_Upload_Date;
        _Course_Author = Course_Author;
        _Course_Fee = Course_Fee;
        _Course_Desc = Course_Desc;
        _Course_Subject = Course_Subject;

    }

    public CourseAccountClass()
    {

    }

    public int ID
    {
        get { return _ID; }
        set { _ID = value; }
    }

    public string Course_ID
    {
        get { return _Course_ID; }
        set { _Course_ID = value; }
    }

    public string Login_ID
    {
        get { return _Login_ID; }
        set { _Login_ID = value; }
    }

    public bool isCompleted
    {
        get { return _isCompleted; }
        set { _isCompleted = value; }
    }

    public DateTime Recent_Visit
    {
        get { return _Recent_Visit; }
        set { _Recent_Visit = value; }
    }

    public DateTime Completed_Date
    {
        get { return _Completed_Date; }
        set { _Completed_Date = value; }
    }

    public int Course_Order
    {
        get { return _Course_Order; }
        set { _Course_Order = value; }
    }

    public string Course_Title
    {
        get { return _Course_Title; }
        set { _Course_Title = value; }
    }

    public string Course_Upload_Date
    {
        get { return _Course_Upload_Date; }
        set { _Course_Upload_Date = value; }
    }
    public string Course_Author
    {
        get { return _Course_Author; }
        set { _Course_Author = value; }
    }
    public decimal Course_Fee
    {
        get { return _Course_Fee; }
        set { _Course_Fee = value; }
    }
    public string Course_Desc
    {
        get { return _Course_Desc; }
        set { _Course_Desc = value; }
    }
    public string Course_Subject
    {
        get { return _Course_Subject; }
        set { _Course_Subject = value; }
    }

    public int Insert(string Login_ID, string Course_ID)
    {
        int output = 0;
        string queryStr = "INSERT INTO UsersCourse(Login_ID, Course_ID, Recent_Visit, Completed_Date) Values(@Login_ID, @Course_ID, @Recent_Visit, @Completed_Date)";

        // Opening SQL connection
        using (SqlConnection conn = new SqlConnection(connStr))
        {
            conn.Open();
            using (SqlCommand cmd = new SqlCommand(queryStr, conn))
            {
                cmd.Parameters.AddWithValue("@Login_ID", Login_ID);
                cmd.Parameters.AddWithValue("@Course_ID", Course_ID);
                cmd.Parameters.AddWithValue("@Recent_Visit", DateTime.Now);
                cmd.Parameters.AddWithValue("@Completed_Date", DateTime.Now);
                output += cmd.ExecuteNonQuery();
            }
        }
        return output;
    }

    public CourseAccountClass Retrieve(int ID)
    {
        string queryStr = "SELECT * FROM UsersCourse WHERE ID = @ID";
        CourseAccountClass output = null;

        using (SqlConnection conn = new SqlConnection(connStr))
        {
            conn.Open();
            using (SqlCommand cmd = new SqlCommand(queryStr, conn))
            {
                cmd.Parameters.AddWithValue("@ID", ID);
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    while (dr.Read())
                    {
                        int UCID = Convert.ToInt32(dr["ID"].ToString());
                        string Login_ID = dr["Login_ID"].ToString();
                        string Course_ID = dr["Course_ID"].ToString();
                        DateTime Recent_Visit = DateTime.Parse(dr["Recent_Visit"].ToString());
                        bool isCompleted = Convert.ToBoolean(dr["isCompleted"].ToString());
                        DateTime Completed_Date = DateTime.Parse(dr["Completed_Date"].ToString());

                        output = new CourseAccountClass(UCID, Login_ID, Course_ID, Recent_Visit, isCompleted, Completed_Date);
                    }
                }
            }
        }
        return output;
    }

    public List<CourseAccountClass> RetrieveAll(string nLogin_ID)
    {
        string queryStr = "SELECT * FROM UsersCourse WHERE Login_ID = @nLogin_ID";
        List<CourseAccountClass> output = new List<CourseAccountClass>();

        using (SqlConnection conn = new SqlConnection(connStr))
        {
            conn.Open();
            using (SqlCommand cmd = new SqlCommand(queryStr, conn))
            {
                cmd.Parameters.AddWithValue("@nLogin_ID", nLogin_ID);
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    int UCID = Convert.ToInt32(dr["ID"].ToString());
                    string Login_ID = dr["Login_ID"].ToString();
                    string Course_ID = dr["Course_ID"].ToString();
                    DateTime Recent_Visit = DateTime.Parse(dr["Recent_Visit"].ToString());
                    bool isCompleted = Convert.ToBoolean(dr["isCompleted"].ToString());
                    DateTime Completed_Date = DateTime.Parse(dr["Completed_Date"].ToString());

                    CourseAccountClass eachCourse = new CourseAccountClass(UCID, Login_ID, Course_ID, Recent_Visit, isCompleted, Completed_Date);
                    output.Add(eachCourse);
                }
            }
        }
        return output;
    }

    public List<CourseAccountClass> RetrieveAllByUser(string nLogin_ID)
    {
        string queryStr = "SELECT * FROM Courses c INNER JOIN UsersCourse uc on c.Course_ID = uc.Course_ID WHERE Login_ID = @nLogin_ID";
        List<CourseAccountClass> output = new List<CourseAccountClass>();

        using (SqlConnection conn = new SqlConnection(connStr))
        {
            conn.Open();
            using (SqlCommand cmd = new SqlCommand(queryStr, conn))
            {
                cmd.Parameters.AddWithValue("@nLogin_ID", nLogin_ID);
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    int UCID = Convert.ToInt32(dr["ID"].ToString());
                    string Login_ID = dr["Login_ID"].ToString();
                    string Course_ID = dr["Course_ID"].ToString();
                    DateTime Recent_Visit = DateTime.Parse(dr["Recent_Visit"].ToString());
                    bool isCompleted = Convert.ToBoolean(dr["isCompleted"].ToString());
                    DateTime Completed_Date = DateTime.Parse(dr["Completed_Date"].ToString());

                    string Course_Title = dr["Course_Title"].ToString();
                    string Course_Order = dr["Course_Order"].ToString();
                    string Course_Upload_Date = dr["Course_Upload_Date"].ToString();
                    string Course_Author = dr["Course_Author"].ToString();
                    decimal Course_Fee = Convert.ToDecimal(dr["Course_Fee"].ToString());
                    string Course_Desc = dr["Course_Desc"].ToString();
                    string Course_Subject = dr["Course_Subject"].ToString();


                    CourseAccountClass eachCourse = new CourseAccountClass(UCID, Login_ID, Course_ID, Recent_Visit, isCompleted, Completed_Date, Course_Title, Course_Upload_Date, Course_Author, Course_Fee, Course_Desc, Course_Subject);
                    output.Add(eachCourse);
                }
            }
        }
        return output;
    }

    public int Update()
    {
        int output = 0;
        string queryStr = "UPDATE UsersCourse SET Recent_Visit = @Recent_Visit, isCompleted = @isCompleted, Completed_Date = @Completed_Date WHERE ID = @ID";

        using (SqlConnection conn = new SqlConnection(connStr))
        {
            conn.Open();
            using (SqlCommand cmd = new SqlCommand(queryStr, conn))
            {
                cmd.Parameters.AddWithValue("@ID", ID);
                cmd.Parameters.AddWithValue("@Recent_Visit", Recent_Visit);
                cmd.Parameters.AddWithValue("@isCompleted", isCompleted);
                cmd.Parameters.AddWithValue("@Completed_Date", Completed_Date);
                output += cmd.ExecuteNonQuery();
            }
        }

        return output;
    }

    public int Delete(int ID)
    {
        int output = 0;

        string queryStr = "DELETE FROM UsersCourse WHERE ID = @ID";

        using (SqlConnection conn = new SqlConnection(connStr))
        {
            conn.Open();
            using (SqlCommand cmd = new SqlCommand(queryStr, conn))
            {
                cmd.Parameters.AddWithValue("@ID", ID);
                output += cmd.ExecuteNonQuery();
            }
        }
        return output;
    }
}