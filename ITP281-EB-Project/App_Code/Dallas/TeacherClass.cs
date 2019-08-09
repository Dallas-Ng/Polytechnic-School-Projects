using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


/// <summary>
/// Summary description for TeacherClass
/// Teacher class uses UsersTeachers table and Users Table
/// Used for manipulation of teacher accounts
/// 
/// Methods:
/// C: InsertTeacher(),
/// R: Retrieve(),
/// U: 
/// D: Delete(), 
/// 
/// Database Variables for table UsersTeachers:
/// Basic: 
///     Teacher_ID, Name, Email, Phone, Remarks, CertificationUrl, IdentificationUrl, Login ID {FK}
/// </summary>
public class TeacherClass
{
    /// <summary>
    /// Init Variables and Setting DB connString
    /// </summary>
    private string connStr = ConfigurationManager.ConnectionStrings["EBP-Database"].ConnectionString;
    private string _Teacher_ID, _Login_ID, _Name, _Email,  _Remarks, _CertificationUrl, _IdentificationUrl = "";
    private DateTime _Creation_Date;


    /// <summary>
    /// Constructors
    /// </summary>
    public TeacherClass(string Teacher_ID, string Name, string Email, DateTime Creation_Date, string CertificationUrl, string IdentificationUrl, string Remarks, string Login_ID)
    {
        _Teacher_ID = Teacher_ID;
        _Name = Name;
        _Email = Email;
        _Creation_Date = Creation_Date;
        _CertificationUrl = CertificationUrl;
        _IdentificationUrl = IdentificationUrl;
        _Remarks = Remarks;
        _Login_ID = Login_ID;
    }


    public TeacherClass(string CertificationUrl, string IdentificationUrl, string Remarks, string Name, string Email)
    {// Used for Teacher Sign Up .aspx
        _CertificationUrl = CertificationUrl;
        _IdentificationUrl = IdentificationUrl;
        _Name = Name;
        _Email = Email;
        _Remarks = Remarks;
    }

    public TeacherClass(string Teacher_ID, string Name, string Email, string Login_ID)
    {// Used for Retrieve
        _Teacher_ID = Teacher_ID;
        _Name = Name;
        _Email = Email;
        _Login_ID = Login_ID;
    }

    public TeacherClass() { }



    /// <summary>
    /// Get and Set Methods
    /// </summary>
    public string Login_ID
    {
        get { return _Login_ID; }
        set { _Login_ID = value.ToLower(); }
    }
    public string Teacher_ID
    {
        get { return _Teacher_ID; }
        set { _Teacher_ID = value; }
    }
    public string Name
    {
        get { return _Name; }
        set { _Name = value.ToLower(); }
    }
    public string Email
    {
        get { return _Email; }
        set { _Email = value.ToLower(); }
    }
    public string Remarks
    {
        get { return _Remarks; }
        set { _Remarks = value.ToLower(); }
    }
    public string CertificationUrl
    {
        get { return _CertificationUrl; }
        set { _CertificationUrl = value; }
    }
    public string IdentificationUrl
    {
        get { return _IdentificationUrl; }
        set { _IdentificationUrl = value; }
    }
    public DateTime Creation_Date
    {
        get { return _Creation_Date; }
        set { _Creation_Date = value; }
    }



    /// <summary>
    /// Inserts a new user into the database
    /// </summary>
    /// <returns>
    /// 1 if successful, 0 if not
    /// </returns>
    public int InsertTeacher()
    {
        int output = 0;
        string queryStr = "INSERT INTO UsersTeachers(CertificationUrl, IdentificationUrl, Name, Email, Remarks)" +
                          "VALUES(@CertificationUrl, @IdentificationUrl, @Name, @Email, @Remarks)";
        // Opening SQL connection
        using (SqlConnection conn = new SqlConnection(connStr))
        {
            conn.Open();
            using (SqlCommand cmd = new SqlCommand(queryStr, conn))
            {
                cmd.Parameters.AddWithValue("@CertificationUrl", CertificationUrl);
                cmd.Parameters.AddWithValue("@IdentificationUrl", IdentificationUrl);
                cmd.Parameters.AddWithValue("@Name", Name);
                cmd.Parameters.AddWithValue("@Email", Email);
                cmd.Parameters.AddWithValue("@Remarks", Remarks);
                output += cmd.ExecuteNonQuery();
            }
        }
        return output;
    }



    /// <summary>
    /// Retrieves all basic information from the account in the database
    /// </summary>
    /// <param name="foo">
    /// Foo = "Teacher_ID" of the user || Direct Input "all"
    /// Foo is the filter of the function
    /// If Foo == ALL, it retrieves every user from the database
    /// Else, it retrives the information from 1 user only.
    /// </param>
    /// <returns>
    /// userList that has all the basic variables
    /// </returns>
    public List<TeacherClass> retrieve(string foo)
    {
        List<TeacherClass> teacherList = new List<TeacherClass>();

        //
        string queryStr;
        if (foo == "all")
        {
            queryStr = "SELECT * FROM UsersTeachers ORDER BY Teacher_ID";
        }
        else if (foo == "verified")
        {
            queryStr = "SELECT * FROM UsersTeachers WHERE Login_ID IS NOT NULL ORDER BY Teacher_ID ";
        }
        else if (foo == "not_verified")
        {
            queryStr = "SELECT * FROM UsersTeachers WHERE Login_ID IS NULL ORDER BY Teacher_ID ";
        }
        else
        {
            queryStr = "SELECT * FROM UsersTeachers WHERE Teacher_ID = @Teacher_ID";
        }

        using (SqlConnection conn = new SqlConnection(connStr))
        {
            conn.Open();
            using (SqlCommand cmd = new SqlCommand(queryStr, conn))
            {
                cmd.Parameters.AddWithValue("@Teacher_ID", foo);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader != null) // If there is something to read
                    {
                        while (reader.Read())
                        {
                            Teacher_ID = reader["Teacher_ID"].ToString();
                            Login_ID = reader["Login_ID"].ToString();
                            Name = reader["Name"].ToString();
                            Email = reader["Email"].ToString();
                            Creation_Date = DateTime.Parse(reader["Creation_Date"].ToString());
                            CertificationUrl = reader["CertificationUrl"].ToString();
                            IdentificationUrl = reader["IdentificationUrl"].ToString();
                            Remarks = reader["Remarks"].ToString();
                            TeacherClass eachTeacher = new TeacherClass(Teacher_ID, Name, Email, Creation_Date, CertificationUrl, IdentificationUrl, Remarks, Login_ID);
                            teacherList.Add(eachTeacher);
                        }

                    }
                }
            }
        }
        return teacherList;
    }



    /// <summary>
    /// Retrieves UpdateIdentification from database using Teacher ID
    /// </summary>
    /// <returns>
    /// 1 if successful, 0 if not
    /// </returns>
    public int UpdateIdentification(string Teacher_ID, string ImageName)
    {
        string queryStr = "UPDATE UsersTeacher SET Identification_Url = @Identification_Url WHERE Teacher_ID = @Teacher_ID";
        int output = 0;

        using (SqlConnection conn = new SqlConnection(connStr))
        {
            conn.Open();
            using (SqlCommand cmd = new SqlCommand(queryStr, conn))
            {
                cmd.Parameters.AddWithValue("@Teacher_ID", Teacher_ID);
                cmd.Parameters.AddWithValue("@Identification_Url", ImageName.ToLower());
                output = cmd.ExecuteNonQuery();
            }
        }
        return output;
    }



    /// <summary>
    /// Physically deletes primary key from the database
    /// </summary>
    /// <returns>
    /// 1 if successful, 0 if not
    /// </returns>
    public int Delete(string Teacher_ID)
    {
        int output = 0;
        string queryStr = "DELETE FROM UsersTeachers WHERE Teacher_ID = @Teacher_ID";

        using (SqlConnection conn = new SqlConnection(connStr))
        {
            conn.Open();
            using (SqlCommand cmd = new SqlCommand(queryStr, conn))
            {
                cmd.Parameters.AddWithValue("@Teacher_ID", Teacher_ID);
                output += cmd.ExecuteNonQuery();
            }
        }
        return output;
    }

    public string checkEmail(string nEmail)
    {
        string output = "none";
        string queryStr = "SELECT * FROM UsersTeachers WHERE Email = @Email";

        // Opening SQL connection
        using (SqlConnection conn = new SqlConnection(connStr))
        {
            conn.Open();
            using (SqlCommand cmd = new SqlCommand(queryStr, conn))
            {
                cmd.Parameters.AddWithValue("@Email", nEmail.ToLower());

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        output = reader["Teacher_ID"].ToString();
                    }
                }
            }
        }
        return output;
    }

    public int updateLogin(string TID, string nLogin)
    {
        int output = 0;
        string queryStr = "UPDATE UsersTeachers SET Login_ID = @Login_ID WHERE Teacher_ID = @Teacher_ID";

        using (SqlConnection conn = new SqlConnection(connStr))
        {
            conn.Open();
            using (SqlCommand cmd = new SqlCommand(queryStr, conn))
            {
                cmd.Parameters.AddWithValue("@Teacher_ID", TID);
                cmd.Parameters.AddWithValue("@Login_ID", nLogin);
                output += cmd.ExecuteNonQuery();
            }
        }
        return output;
    }



    public List<TeacherClass> retrieveByLogin(string foo)
    {
        List<TeacherClass> teacherList = new List<TeacherClass>();

        //
       
        string queryStr = "SELECT * FROM UsersTeachers WHERE Login_ID = @Login_ID";

        using (SqlConnection conn = new SqlConnection(connStr))
        {
            conn.Open();
            using (SqlCommand cmd = new SqlCommand(queryStr, conn))
            {
                cmd.Parameters.AddWithValue("@Login_ID", foo);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader != null) // If there is something to read
                    {
                        while (reader.Read())
                        {
                            Teacher_ID = reader["Teacher_ID"].ToString();
                            Login_ID = reader["Login_ID"].ToString();
                            Name = reader["Name"].ToString();
                            Email = reader["Email"].ToString();
                            Creation_Date = DateTime.Parse(reader["Creation_Date"].ToString());
                            CertificationUrl = reader["CertificationUrl"].ToString();
                            IdentificationUrl = reader["IdentificationUrl"].ToString();
                            Remarks = reader["Remarks"].ToString();
                            TeacherClass eachTeacher = new TeacherClass(Teacher_ID, Name, Email, Creation_Date, CertificationUrl, IdentificationUrl, Remarks, Login_ID);
                            teacherList.Add(eachTeacher);
                        }

                    }
                }
            }
        }
        return teacherList;
    }


    public List<TeacherClass> searchQuery(string foo)
    {
        List<TeacherClass> teacherList = new List<TeacherClass>();

        string queryStr = "SELECT Login_ID, Teacher_ID, Name, Email FROM UsersTeachers WHERE Login_ID LIKE '%'+ @Filter+'%' OR Teacher_ID LIKE '%'+ @Filter+'%'  OR Name LIKE '%'+ @Filter+'%' OR Email LIKE '%'+ @Filter+'%' ";

        using (SqlConnection conn = new SqlConnection(connStr))
        {
            conn.Open();
            using (SqlCommand cmd = new SqlCommand(queryStr, conn))
            {
                cmd.Parameters.AddWithValue("@Filter", foo);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader != null) // If there is something to read
                    {
                        while (reader.Read())
                        {
                            Teacher_ID = reader["Teacher_ID"].ToString();
                            Login_ID = reader["Login_ID"].ToString();
                            Name = reader["Name"].ToString();
                            Email = reader["Email"].ToString();
                            TeacherClass eachTeacher = new TeacherClass(Teacher_ID, Name, Email, Creation_Date, CertificationUrl, IdentificationUrl, Remarks, Login_ID);
                            teacherList.Add(eachTeacher);
                        }

                    }
                }
            }
        }
        return teacherList;
    }
}