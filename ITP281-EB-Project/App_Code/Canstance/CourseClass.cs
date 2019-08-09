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
public class CourseClass
{
    string connStr = ConfigurationManager.ConnectionStrings["EBP-Database"].ConnectionString;

    /// <summary>
    /// This is the initalisation for all the variables
    /// </summary>
    private string _Course_ID, _Course_Title, _Course_Upload_Date, _Course_Author, _Course_Desc ,_Course_Subject= "";
    private int _Course_Order = 0;
    private decimal _Course_Fee = 0;


    /// <summary>
    /// Constructors
    /// </summary>
    public CourseClass(string Course_ID, string Course_Title, string Course_Upload_Date, string Course_Author, decimal Course_Fee, string Course_Desc,string Course_Subject)
    {
        _Course_ID = Course_ID;
  
        _Course_Title = Course_Title;
        _Course_Upload_Date = Course_Upload_Date;
        _Course_Author = Course_Author;
        _Course_Fee = Course_Fee;
        //_Course_Fee = decimal.Parse(Course_Fee);
        _Course_Desc = Course_Desc;
        _Course_Subject = Course_Subject;
    }

    public CourseClass( int Course_Order, string Course_Title, string Course_Upload_Date, string Course_Author, string Course_Fee, string Course_Desc, string Course_Subject)
    {

        _Course_Order = Course_Order;
        _Course_Title = Course_Title;
        _Course_Upload_Date = Course_Upload_Date;
        _Course_Author = Course_Author;
        _Course_Fee = decimal.Parse(Course_Fee);
        _Course_Desc = Course_Desc;
        _Course_Subject = Course_Subject;
    }

    public CourseClass()
    {
    }


    /// <summary>
    /// Get and Setter Methods
    /// </summary>
    public string Course_ID
    {
        get { return _Course_ID; }
        set { _Course_ID = value; }
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

    /// <summary>
    /// Gets course data using course ID
    /// </summary>
    public CourseClass getCourse(String Course_ID)
    {
        CourseClass Course_Detail = null;
        string queryStr = "SELECT * FROM Courses WHERE Course_ID = @Course_ID";
        SqlConnection conn = new SqlConnection(connStr);
        SqlCommand cmd = new SqlCommand(queryStr, conn);
        cmd.Parameters.AddWithValue("@Course_ID", Course_ID);
        conn.Open();

        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            string Course_Order = dr["Course_Order"].ToString();
            string Course_Title = dr["Course_Title"].ToString();
            string Course_Upload_Date = dr["Course_Upload_Date"].ToString();
            string Course_Author = dr["Course_Author"].ToString();
            string Course_Fee = dr["Course_Fee"].ToString();
            string Course_Desc = dr["Course_Desc"].ToString();
            string Course_Subject = dr["Course_Subject"].ToString();

            Course_Detail = new CourseClass(Course_ID, Course_Title, Course_Upload_Date, Course_Author, decimal.Parse(Course_Fee), Course_Desc,Course_Subject);
        }
        else
        {
            Course_Detail = null;
        }
        conn.Close();
        dr.Close();
        dr.Dispose();
        return Course_Detail;
    }


    /// <summary>
    /// Returns all the courses with data inside the DB
    /// </summary>
    public List<CourseClass> getCourseAll()
    {
        List<CourseClass> CourseList = new List<CourseClass>();

        string queryStr = "SELECT * FROM Courses WHERE isDeleted = 0 Order By Course_ID";
        using (SqlConnection conn = new SqlConnection(connStr))
        {
            conn.Open();
            using (SqlCommand cmd = new SqlCommand(queryStr, conn))
            {
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    string Course_ID = dr["Course_ID"].ToString();
                    string Course_Title = dr["Course_Title"].ToString();
                    string Course_Order = dr["Course_Order"].ToString();
                    string Course_Upload_Date = dr["Course_Upload_Date"].ToString();
                    string Course_Author = dr["Course_Author"].ToString();
                    string Course_Fee = dr["Course_Fee"].ToString();
                    string Course_Desc = dr["Course_Desc"].ToString();
                    string Course_Subject = dr["Course_Subject"].ToString();

                    CourseClass a = new CourseClass(Course_ID,Course_Title, Course_Upload_Date, Course_Author, decimal.Parse(Course_Fee), Course_Desc,Course_Subject);
                    CourseList.Add(a);
                }
            }

        }
        return CourseList;
    }

    public List<CourseClass> getSingleCourse(string cID)
    {
        List<CourseClass> CourseList = new List<CourseClass>();

        string queryStr = "SELECT * FROM Courses WHERE Course_ID = @Course_ID";
        using (SqlConnection conn = new SqlConnection(connStr))
        {
            conn.Open();
            using (SqlCommand cmd = new SqlCommand(queryStr, conn))
            {
                cmd.Parameters.AddWithValue("@Course_ID", cID);
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    string Course_ID = dr["Course_ID"].ToString();
                    string Course_Title = dr["Course_Title"].ToString();
                    string Course_Order = dr["Course_Order"].ToString();
                    string Course_Upload_Date = dr["Course_Upload_Date"].ToString();
                    string Course_Author = dr["Course_Author"].ToString();
                    string Course_Fee = dr["Course_Fee"].ToString();
                    string Course_Desc = dr["Course_Desc"].ToString();
                    string Course_Subject = dr["Course_Subject"].ToString();

                    CourseClass a = new CourseClass(Course_ID,  Course_Title, Course_Upload_Date, Course_Author, decimal.Parse(Course_Fee), Course_Desc,Course_Subject);
                    CourseList.Add(a);
                }
            }

        }
        return CourseList;
    }


    /// <summary>
    /// Inserts a course into the database
    /// </summary>
    public int CourseInsert()
    {
        int result = 0;
        string queryStr = "INSERT INTO Courses(Course_ID, Course_Title,  Course_Upload_Date, Course_Author, Course_Fee,Course_Desc,Course_Subject)"
                        + "values (@Course_ID, @Course_Title,@Course_Upload_Date,  @Course_Author, @Course_Fee, @Course_Desc,@Course_Subject)";

        using (SqlConnection conn = new SqlConnection(connStr))
        {
            conn.Open();
            using (SqlCommand cmd = new SqlCommand(queryStr, conn))
            {
                cmd.Parameters.AddWithValue("@Course_ID", this.Course_ID);
                //cmd.Parameters.AddWithValue("@Course_Order", this.Course_Order);
                cmd.Parameters.AddWithValue("@Course_Title", this.Course_Title);
                cmd.Parameters.AddWithValue("@Course_Upload_Date", Convert.ToDateTime(this.Course_Upload_Date));
                cmd.Parameters.AddWithValue("@Course_Author", this.Course_Author);
                cmd.Parameters.AddWithValue("@Course_Fee", this.Course_Fee);
                cmd.Parameters.AddWithValue("@Course_Desc", this.Course_Desc);
                cmd.Parameters.AddWithValue("@Course_Subject", this.Course_Subject);
                result += cmd.ExecuteNonQuery();
            }
        }
        return result;
    }


    /// <summary>
    /// Course Delete
    /// </summary>
    //public int CourseDelete(string Course_ID)
    //{
    //int result = 0;
    //string queryStr = "DELETE FROM Courses WHERE Course_ID=@Course_ID";

    //using (SqlConnection conn = new SqlConnection(connStr))
    //{
    //conn.Open();
    //using (SqlCommand cmd = new SqlCommand(queryStr, conn))
    //{
    // cmd.Parameters.AddWithValue("@Course_ID", Course_ID);
    // result += cmd.ExecuteNonQuery();
    //  }
    // }
    //  return result;
    // }

    public int CourseDelete(string Course_ID)
    {
       // string queryStr = "DELETE FROM Courses WHERE Course_ID=@Course_ID";
        string queryStr = "UPDATE Courses SET isDeleted = 1 WHERE Course_ID = @Course_ID";
        SqlConnection conn = new SqlConnection(connStr);
        SqlCommand cmd = new SqlCommand(queryStr, conn);
        cmd.Parameters.AddWithValue("@Course_ID", Course_ID);
        conn.Open();
        int nofRow = 0;
        nofRow = cmd.ExecuteNonQuery();
        conn.Close();
        return nofRow;
    }


    /// <summary>
    /// 
    /// </summary>
    /// <param name="cId"></param>
    /// <param name="cTitle"></param>
    /// <param name="cFee"></param>
    /// <returns></returns>
    //    public int CourseUpdate(string Course_ID, string cTitle, decimal cFee)
    //    {
    //        int nofRow = 0;
    //       string queryStr = "UPDATE Courses SET Course_Title = @Course_Title, Course_Fee = @Course_Fee WHERE Course_ID = @Course_ID";
    //
    //       using (SqlConnection conn = new SqlConnection(connStr))
    //        {
    //           conn.Open();
    //           using (SqlCommand cmd = new SqlCommand(queryStr, conn))
    //           {
    //               cmd.Parameters.AddWithValue("@Course_ID", Course_ID);
    //               cmd.Parameters.AddWithValue("@Course_Title", cTitle);
    //               //cmd.Parameters.AddWithValue("@Course_Upload_Date", this.Course_Upload_Date);
    //              //cmd.Parameters.AddWithValue("@Course_Author", this.Course_Author);
    //              cmd.Parameters.AddWithValue("@Course_Fee", cFee);
    //              //cmd.Parameters.AddWithValue("@Course_Desc", this.Course_Desc);

    //              nofRow += cmd.ExecuteNonQuery();
    //         }
    //     }
    //     return nofRow;
    //  }
    public int CourseUpdate(string Course_ID, string cTitle,string cDesc,string cAuthor)
    {
        string queryStr = "UPDATE Courses SET" +

        " Course_Title = @Course_Title, " +
        //" Course_Fee = @Course_Fee, " +
        " Course_Desc = @Course_Desc," +
        " Course_Author = @Course_Author " +
        //" Course_Order = @Course_Order " +
        //" Course_Upload_date = @Course_Upload_Date"+
        " WHERE Course_ID = @Course_ID";

        SqlConnection conn = new SqlConnection(connStr);
        SqlCommand cmd = new SqlCommand(queryStr, conn);
        cmd.Parameters.AddWithValue("@Course_ID", Course_ID);
        cmd.Parameters.AddWithValue("@Course_Title", cTitle);
        cmd.Parameters.AddWithValue("@Course_Desc", cDesc);
        cmd.Parameters.AddWithValue("@Course_Author", cAuthor);
        //cmd.Parameters.AddWithValue("@Course_Order", cOrder);
        //cmd.Parameters.AddWithValue("@Course_Upload_Date", cDate);
        //cmd.Parameters.AddWithValue("@Course_Fee", cFee);
        conn.Open();
        int nofRow = 0;
        nofRow = cmd.ExecuteNonQuery();
        conn.Close();
        return nofRow;
    }//end Update

    public DataTable Search(String search)
    {
        string connStr = ConfigurationManager.ConnectionStrings["EBP-Database"].ConnectionString;
        SqlConnection myConn = new SqlConnection(connStr);

        myConn.Open();

        SqlCommand sqlCmd = new SqlCommand();
        string sqlQuery = "SELECT * FROM Courses WHERE Course_ID LIKE '%'+@Filter+'%' OR Course_Title LIKE '%'+@Filter+'%' OR Course_Author LIKE '%'+@Filter+'%' and IsDeleted=0 ";
        sqlCmd.CommandText = sqlQuery;
        sqlCmd.Connection = myConn;
        sqlCmd.Parameters.AddWithValue("@Filter", search);
        DataTable dt = new DataTable();
        SqlDataAdapter sda = new SqlDataAdapter(sqlCmd);
        sda.Fill(dt);
        return dt;
    }




    // CHANGES INTEGRATOR
    public List<CourseClass> getCoursesbyAuthor(string Author)
    {
        List<CourseClass> CourseList = new List<CourseClass>();
        using (SqlConnection conn = new SqlConnection(connStr))
        {
            conn.Open();
            using (SqlCommand cmd = new SqlCommand("SELECT * FROM Courses WHERE Course_Author = @Course_Author", conn))
            {
                cmd.Parameters.AddWithValue("@Course_Author", Author);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    string Course_ID = reader["Course_ID"].ToString();
                    string Course_Title = reader["Course_Title"].ToString();
                    string Course_Order = reader["Course_Order"].ToString();
                    string Course_Upload_Date = reader["Course_Upload_Date"].ToString();
                    string Course_Author = reader["Course_Author"].ToString();
                    string Course_Fee = reader["Course_Fee"].ToString();
                    string Course_Desc = reader["Course_Desc"].ToString();
                    string Course_Subject = reader["Course_Subject"].ToString();

                    CourseClass a = new CourseClass(Course_ID, Course_Title, Course_Upload_Date, Course_Author, decimal.Parse(Course_Fee), Course_Desc, Course_Subject);
                    CourseList.Add(a);
                }
            }

        }
        return CourseList;
    }

    public DataTable SearchCoursesFilterByAuthor(string foo, string author)
    {
        string connStr = ConfigurationManager.ConnectionStrings["EBP-Database"].ConnectionString;
        SqlConnection myConn = new SqlConnection(connStr);

        myConn.Open();

        SqlCommand sqlCmd = new SqlCommand();
        string sqlQuery = "SELECT * FROM Courses WHERE Course_Title LIKE '%'+@Course_Title+'%' and Course_Author = @Course_Author";
        sqlCmd.CommandText = sqlQuery;
        sqlCmd.Connection = myConn;
        sqlCmd.Parameters.AddWithValue("Course_Title", foo);
        sqlCmd.Parameters.AddWithValue("Course_Author", author);
        DataTable dt = new DataTable();
        SqlDataAdapter sda = new SqlDataAdapter(sqlCmd);
        sda.Fill(dt);
        return dt;
    }

    public List<CourseClass> getCoursesFilter(string filter)
    {
        List<CourseClass> CourseList = new List<CourseClass>();

        string queryStr = "SELECT * FROM Courses Order By Course_ID"; ;

        if (filter == "none")
        {
            queryStr = "SELECT * FROM Courses Order By Course_ID";
        }
        else if (filter == "price_asce")
        {
            queryStr = "SELECT * FROM Courses Order By Course_Fee";
        }
        else if (filter == "price_desc")
        {
            queryStr = "SELECT * FROM Courses Order By Course_Fee DESC";
        }
        else if (filter == "maths")
        {
            queryStr = "SELECT * FROM Courses WHERE Course_Subject = 'maths' Order By Course_ID";
        }
        else if (filter == "english")
        {
            queryStr = "SELECT * FROM Courses WHERE Course_Subject = 'english' Order By Course_ID";
        }
        else if (filter == "science")
        {
            queryStr = "SELECT * FROM Courses WHERE Course_Subject = 'science' Order By Course_ID";
        }
        else if (filter == "geography")
        {
            queryStr = "SELECT * FROM Courses WHERE Course_Subject = 'geography' Order By Course_ID";
        }

        using (SqlConnection conn = new SqlConnection(connStr))
        {
            conn.Open();
            using (SqlCommand cmd = new SqlCommand(queryStr, conn))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader != null) // If there is something to read
                    {
                        while (reader.Read())
                        {
                            string Course_ID = reader["Course_ID"].ToString();
                            string Course_Title = reader["Course_Title"].ToString();
                            string Course_Order = reader["Course_Order"].ToString();
                            string Course_Upload_Date = reader["Course_Upload_Date"].ToString();
                            string Course_Author = reader["Course_Author"].ToString();
                            decimal Course_Fee = Convert.ToDecimal(reader["Course_Fee"].ToString());
                            string Course_Desc = reader["Course_Desc"].ToString();

                            CourseClass a = new CourseClass(Course_ID, Course_Title, Course_Upload_Date, Course_Author, Course_Fee, Course_Desc, Course_Subject);
                            CourseList.Add(a);
                        }
                    }
                }

            }
            return CourseList;
        }
    }

    public List<CourseClass> getCoursesFilter(string filter, string login_Id)
    {
        List<CourseClass> CourseList = new List<CourseClass>();

        string queryStr = "select * from courses where courses.course_id not in (SELECT course_Id from userscourse where login_id = @Login_ID) Order By Course_ID"; ;

        if (filter == "none")
        {
            queryStr = "select * from courses where courses.course_id not in (SELECT course_Id from userscourse where login_id = @Login_ID)";
        }
        else if (filter == "price_asce")
        {
            queryStr = "select * from courses where courses.course_id not in (SELECT course_Id from userscourse where login_id = @Login_ID) Order By Course_Fee";
        }
        else if (filter == "price_desc")
        {
            queryStr = "select * from courses where courses.course_id not in (SELECT course_Id from userscourse where login_id = @Login_ID) Order By Course_Fee DESC";
        }
        else if (filter == "maths")
        {
            queryStr = "select * from courses where courses.course_id not in (SELECT course_Id from userscourse where login_id = @Login_ID) and Course_Subject = 'maths' Order By Course_ID";
        }
        else if (filter == "english")
        {
            queryStr = "select * from courses where courses.course_id not in (SELECT course_Id from userscourse where login_id = @Login_ID) AND Course_Subject = 'english' Order By Course_ID";
        }
        else if (filter == "science")
        {
            queryStr = "select * from courses where courses.course_id not in (SELECT course_Id from userscourse where login_id = @Login_ID) AND Course_Subject = 'science' Order By Course_ID";
        }
        else if (filter == "geography")
        {
            queryStr = "select * from courses where courses.course_id not in (SELECT course_Id from userscourse where login_id = @Login_ID) AND Course_Subject = 'geography' Order By Course_ID";
        }

        using (SqlConnection conn = new SqlConnection(connStr))
        {
            conn.Open();
            using (SqlCommand cmd = new SqlCommand(queryStr, conn))
            {
                cmd.Parameters.AddWithValue("@Login_ID", login_Id);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader != null) // If there is something to read
                    {
                        while (reader.Read())
                        {
                            string Course_ID = reader["Course_ID"].ToString();
                            string Course_Title = reader["Course_Title"].ToString();
                            string Course_Order = reader["Course_Order"].ToString();
                            string Course_Upload_Date = reader["Course_Upload_Date"].ToString();
                            string Course_Author = reader["Course_Author"].ToString();
                            decimal Course_Fee = Convert.ToDecimal(reader["Course_Fee"].ToString());
                            string Course_Desc = reader["Course_Desc"].ToString();

                            CourseClass a = new CourseClass(Course_ID, Course_Title, Course_Upload_Date, Course_Author, Course_Fee, Course_Desc, Course_Subject);
                            CourseList.Add(a);
                        }
                    }
                }

            }
            return CourseList;
        }
    }

}

