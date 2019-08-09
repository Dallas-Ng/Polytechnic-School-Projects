using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;
using System.Data.SqlClient;
using System.Configuration;

//Name: TJANDRA PUTRA
//Admin Number : 181110B

public class InquiryClass
{
    // Connection String for SQL Database
    //string connStr = ConfigurationManager.ConnectionStrings["DatabaseContext"].ConnectionString;

    string DBConnect = ConfigurationManager.ConnectionStrings["EBP-Database"].ConnectionString;

    private string _Inq_User;
    private string _Inq_Subj;
    private string _Inq_Msg;
    private string _Inq_Creation_Date;
    private string _Inq_Email;
    private string _Inq_Completed;
    private string _Inq_PK;
    private string _Inq_Admin_Comment;
    

    // Empty or Default class constructor
    public InquiryClass()
    {
        this._Inq_User = null;
        this._Inq_Subj = null;
        this._Inq_Msg = null;
        this._Inq_Creation_Date = null;
        this._Inq_Email = null;
        this._Inq_PK = null;
        this._Inq_Admin_Comment = null;
    }



    public InquiryClass(string aInq_User, string aInq_Subj, string aInq_Msg, string aInq_Creation_Date, string a_Inq_Email, string aInq_PK, string aInq_Admin_Comment)
    {
        this._Inq_User = aInq_User;
        this._Inq_Subj = aInq_Subj;
        this._Inq_Msg = aInq_Msg;
        this._Inq_Creation_Date = aInq_Creation_Date;
        this._Inq_Email = a_Inq_Email;
        this._Inq_PK = aInq_PK;
        this._Inq_Admin_Comment = aInq_Admin_Comment;

    }


    public string Inq_User
    {
        get { return _Inq_User; }
        set { _Inq_User = value; }
    }

    public string Inq_Subj
    {
        get { return _Inq_Subj; }
        set { _Inq_Subj = value; }
    }

    public string Inq_Msg
    {
        get { return _Inq_Msg; }
        set { _Inq_Msg = value; }
    }

    public string Inq_Creation_Date
    {
        get { return _Inq_Creation_Date; }
        set { _Inq_Creation_Date = value; }
    }

    public string Inq_Completed
    {
        get { return _Inq_Completed; }
        set { _Inq_Completed = value; }
    }

    public string Inq_Email
    {
        get { return _Inq_Email; }
        set { _Inq_Email = value; }
    }

    public string Inq_PK
    {
        get { return _Inq_PK; }
        set { _Inq_PK = value; }
    }

    public string Inq_Admin_Comment
    {
        get { return _Inq_Admin_Comment; }
        set { _Inq_Admin_Comment = value; }
    }


    //To [INSERT] submitted form data from customer to the database NEW ROWS
    public int insertCustomerInquiry(string user, string category, string message, string email, string creation_date)
    {

        int result = 0;
        string queryStr = "INSERT INTO SupportInquiry(Inq_User, Inq_Subj, Inq_Msg, Inq_Email, Inq_Creation_Date)"
                        + "values (@Inq_User, @Inq_Subj, @Inq_Msg, @Inq_Email, @Inq_Creation_Date)";

        using (SqlConnection conn = new SqlConnection(DBConnect))
        {
            conn.Open();
            using (SqlCommand cmd = new SqlCommand(queryStr, conn))
            {
                cmd.Parameters.AddWithValue("@Inq_user", user);
                cmd.Parameters.AddWithValue("@Inq_Subj", category);
                cmd.Parameters.AddWithValue("@Inq_Msg", message);
                cmd.Parameters.AddWithValue("@Inq_Email", email);
                cmd.Parameters.AddWithValue("@Inq_Creation_Date", DateTime.Parse(creation_date));
                result += cmd.ExecuteNonQuery();
            }
        }
        return result;
    }

    // Retrieve all ROWS (getinquiriesall)
    public List<InquiryClass> getInquiries()
    {
        List<InquiryClass> InqList = new List<InquiryClass>();

        string queryStr = "SELECT * FROM SupportInquiry Order By Inq_PK";
        using (SqlConnection conn = new SqlConnection(DBConnect))
        {
            conn.Open();
            using (SqlCommand cmd = new SqlCommand(queryStr, conn))
            {
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    string Inq_PK = dr["Inq_PK"].ToString();
                    string Inq_User = dr["Inq_User"].ToString();
                    string Inq_Subj = dr["Inq_Subj"].ToString();
                    string Inq_Creation_Date = dr["Inq_Creation_Date"].ToString();
                    string Inq_Msg = dr["Inq_Msg"].ToString();
                    string Inq_Email = dr["Inq_Email"].ToString();
                    string Inq_Admin_Comment = dr["Inq_Admin_Comment"].ToString();


                    InquiryClass a = new InquiryClass(Inq_User, Inq_Subj, Inq_Msg, Inq_Creation_Date, Inq_Email, Inq_PK, Inq_Admin_Comment);
                    InqList.Add(a);
                }
            }

        }
        return InqList;
    }


    public int deleteCustomerInquiry(string id)
    {

        string queryStr = "DELETE FROM SupportInquiry WHERE Inq_PK=@Inq_PK";
        SqlConnection conn = new SqlConnection(DBConnect);
        SqlCommand cmd = new SqlCommand(queryStr, conn);
        cmd.Parameters.AddWithValue("@Inq_PK", id);
        conn.Open();
        int nofRow = 0;
        nofRow = cmd.ExecuteNonQuery();
        conn.Close();
        return nofRow;
    }





    public int inquiryUpdate(string pk, string admin_comment)
    {

        string queryStr = "UPDATE SupportInquiry SET  Inq_Admin_Comment = @Inq_Admin_Comment WHERE Inq_PK = @Inq_PK";

        //string queryStr = "UPDATE Inquiry SET Inq_ID = 'test', Inq_Subj = 'test', Inq_Msg ='teet', Inq_Email = @Inq_Email WHERE Inq_PK = @Inq_PK";


        SqlConnection conn = new SqlConnection(DBConnect);


        SqlCommand cmd = new SqlCommand(queryStr, conn);
        // cmd.Parameters.AddWithValue("@Inq_User", user);
        // cmd.Parameters.AddWithValue("@Inq_Subj", subj);
        // cmd.Parameters.AddWithValue("@Inq_Msg", msg);
        // cmd.Parameters.AddWithValue("@Inq_Email", email);
        cmd.Parameters.AddWithValue("@Inq_PK", pk);
        cmd.Parameters.AddWithValue("@Inq_Admin_Comment", admin_comment);



        conn.Open();
        int nofRow = 0;
        nofRow = cmd.ExecuteNonQuery();
        conn.Close();
        return nofRow;
    }




    public List<InquiryClass> getSingleInquiry(string ID)
    {
        List<InquiryClass> InqList = new List<InquiryClass>();

        string queryStr = "SELECT * FROM SupportInquiry WHERE Inq_PK = @Inq_PK";
        using (SqlConnection conn = new SqlConnection(DBConnect))
        {
            conn.Open();
            using (SqlCommand cmd = new SqlCommand(queryStr, conn))
            {
                cmd.Parameters.AddWithValue("@Inq_PK", ID);
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    string Inq_PK = dr["Inq_PK"].ToString();
                    string Inq_User = dr["Inq_User"].ToString();
                    string Inq_Subj = dr["Inq_Subj"].ToString();
                    string Inq_Creation_Date = dr["Inq_Creation_Date"].ToString();
                    string Inq_Msg = dr["Inq_Msg"].ToString();
                    string Inq_Email = dr["Inq_Email"].ToString();
                    string Inq_Admin_Comment = dr["Inq_Admin_Comment"].ToString();

                    // InquiryClass a = new InquiryClass(Inq_PK,Inq_User, Inq_Subj, Inq_Msg, Inq_Creation_Date, Inq_Email, Inq_Admin_Comment);
                    InquiryClass a = new InquiryClass(Inq_User,Inq_Subj,Inq_Msg,Inq_Creation_Date,Inq_Email,Inq_PK,_Inq_Admin_Comment);
                    InqList.Add(a);
                }
            }

        }
        return InqList;
    }

    //Search Function
    public DataTable Search(String searchVal)
    {
        string DBConnect = ConfigurationManager.ConnectionStrings["EBP-Database"].ConnectionString;

        SqlConnection myConn = new SqlConnection(DBConnect);

        myConn.Open();

        SqlCommand sqlCmd = new SqlCommand();

        string sqlQuery = "SELECT * FROM SupportInquiry WHERE Inq_User LIKE '%'+@Inq_User+'%' OR Inq_Creation_Date LIKE '%'+@Inq_User+'%' ";
        sqlCmd.CommandText = sqlQuery;
        sqlCmd.Connection = myConn;
        sqlCmd.Parameters.AddWithValue("Inq_User", searchVal);
        DataTable dt = new DataTable();
        SqlDataAdapter sda = new SqlDataAdapter(sqlCmd);
        sda.Fill(dt);



        return dt;
    }

   
    public DataTable filterInquiry(string inquiryType)
    {
        string DBConnect = ConfigurationManager.ConnectionStrings["EBP-Database"].ConnectionString;
        SqlConnection myConn = new SqlConnection(DBConnect);
        string queryStr;
        if (inquiryType == "All") 
        {
            queryStr = "SELECT * FROM SupportInquiry";

        }
        else
        {
            queryStr = "SELECT * FROM SupportInquiry WHERE Inq_Subj ='" + inquiryType + "'";
        }

        SqlCommand sqlCmd = new SqlCommand(queryStr, myConn);
        myConn.Open();


        SqlDataAdapter sda = new SqlDataAdapter(sqlCmd);

        DataTable dt = new DataTable();
        sda.Fill(dt);

        return dt;
    }





}