using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;
using System.Data.SqlClient;
using System.Configuration;

/// <summary>
/// Summary description for UserTransactionHistory
/// </summary>
public class UserTransactionHistory
{
    string DBConnect = ConfigurationManager.ConnectionStrings["EBP-Database"].ConnectionString;

    private string _Login_ID;
    private string _Transaction_ID;
    private string _User_ID;
    //private string _Transaction_Desc;
    private string _Transaction_Amt;
    private string _Transaction_Creation_Date;
    private string _Transaction_Email;
    private string _Transaction_Completed;
    //private string _Transaction_PK;
    //private string _Transaction_Admin_Comment;


    // Empty or Default class constructor
    public UserTransactionHistory()
    {
        this._Login_ID = null;
        this._User_ID = null;
        this._Transaction_ID = null;
        //this._Transaction_Desc = null;
        this._Transaction_Amt = null;
        this._Transaction_Creation_Date = null;
        this._Transaction_Email = null;
        //this._Transaction_PK = null;
        //this._Transaction_Admin_Comment = null;
    }



    public UserTransactionHistory(string aLogin_ID, string aUser_ID, string aTransaction_ID, string aTransaction_Creation_Date)
    {
        this._Login_ID = aLogin_ID;
        this._User_ID = aUser_ID;
        this._Transaction_ID = aTransaction_ID;
        //this._Transaction_Desc = aTransaction_Desc;
        //this._Transaction_Amt = aTransaction_Amt;
        this._Transaction_Creation_Date = aTransaction_Creation_Date;
        //this._Transaction_Email = aTransaction_Email;
        //this._Transaction_Admin_Comment = aTransaction_Admin_Comment;

    }

    public string Login_ID
    {
        get { return _Login_ID; }
        set { _Login_ID = value; }
    }

    public string User_ID
    {
        get { return _User_ID; }
        set { _User_ID = value; }
    }

    public string Transaction_ID
    {
        get { return _Transaction_ID; }
        set { _Transaction_ID = value; }
    }

    //public string Transaction_Desc
    //{
    //get { return _Transaction_Desc; }
    //set { _Transaction_Desc = value; }
    //}

    //public string Transaction_Amt
    //{
    //get { return _Transaction_Amt; }
    //set { _Transaction_Amt = value; }
    //}

    public string Transaction_Creation_Date
    {
        get { return _Transaction_Creation_Date; }
        set { _Transaction_Creation_Date = value; }
    }

    //public string Transaction_Email
    //{
    //get { return _Transaction_Email; }
    //set { _Transaction_Email = value; }
    //}

    //public string Transaction_PK
    //{
    // get { return _Transaction_PK; }
    //set { _Transaction_PK = value; }
    //}

    //public string Transaction_Admin_Comment
    //{
    //get { return _Transaction_Admin_Comment; }
    //set { _Transaction_Admin_Comment = value; }
    //}

    public List<UserTransactionHistory> getTransactions()
    {
        List<UserTransactionHistory> transactionList = new List<UserTransactionHistory>();

        string queryStr = "SELECT * FROM TransactionHistoryList Where Login_ID = Login_ID";
        using (SqlConnection conn = new SqlConnection(DBConnect))
        {
            conn.Open();
            using (SqlCommand cmd = new SqlCommand(queryStr, conn))
            {
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    string Login_ID = dr["Login_ID"].ToString();
                    string User_ID = dr["User_ID"].ToString();
                    string Transaction_ID = dr["Transaction_ID"].ToString();
                    //string Transaction_Desc = dr["Transaction_Desc"].ToString();
                    //string Transaction_Amt = dr["Transaction_Amt"].ToString();
                    string Transaction_Creation_Date = dr["Transaction_Creation_Date"].ToString();
                    //string Transaction_Email = dr["Transaction_Email"].ToString();
                    //string _Transaction_Admin_Comment = dr["_Transaction_Admin_Comment"].ToString();

                    UserTransactionHistory a = new UserTransactionHistory(Login_ID, User_ID, Transaction_ID, Transaction_Creation_Date);
                    transactionList.Add(a);
                }
            }
        }
        return transactionList;
    }

    public int deleteTransaction(string id)
    {

        string queryStr = "DELETE FROM TransactionHistoryList WHERE Transaction_ID=@Transaction_ID";
        SqlConnection conn = new SqlConnection(DBConnect);
        SqlCommand cmd = new SqlCommand(queryStr, conn);
        cmd.Parameters.AddWithValue("@Transaction_ID", id);
        conn.Open();
        int nofRow = 0;
        nofRow = cmd.ExecuteNonQuery();
        conn.Close();
        return nofRow;
    }

    public int TransactionUpdate(string User_ID, string Transaction_ID)
    {

        string queryStr = "UPDATE TransactionHistoryList SET Transaction_ID = @Transaction_ID WHERE Login_ID = @Login_ID";

        //string queryStr = "UPDATE Inquiry SET Inq_ID = 'test', Inq_Subj = 'test', Inq_Msg ='teet', Inq_Email = @Inq_Email WHERE Inq_PK = @Inq_PK";


        SqlConnection conn = new SqlConnection(DBConnect);


        SqlCommand cmd = new SqlCommand(queryStr, conn);
        // cmd.Parameters.AddWithValue("@Inq_User", user);
        // cmd.Parameters.AddWithValue("@Inq_Subj", subj);
        // cmd.Parameters.AddWithValue("@Inq_Msg", msg);
        // cmd.Parameters.AddWithValue("@Inq_Email", email);
        cmd.Parameters.AddWithValue("@Login_ID", Login_ID);
        cmd.Parameters.AddWithValue("@Transaction_ID", Transaction_ID);



        conn.Open();
        int nofRow = 0;
        nofRow = cmd.ExecuteNonQuery();
        conn.Close();
        return nofRow;
    }

    public List<UserTransactionHistory> getSingleTransaction(string ID)
    {
        List<UserTransactionHistory> TransactionList = new List<UserTransactionHistory>();

        string queryStr = "SELECT * FROM UserTransactionHistory WHERE Login_ID = @Login_ID";
        using (SqlConnection conn = new SqlConnection(DBConnect))
        {
            conn.Open();
            using (SqlCommand cmd = new SqlCommand(queryStr, conn))
            {
                cmd.Parameters.AddWithValue("@Login_ID", ID);
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    string Login_ID = dr["Login_ID"].ToString();
                    string User_ID = dr["User_ID"].ToString();
                    string Transaction_ID = dr["Transaction_ID"].ToString();
                    //string Tranasaction_Desc = dr["Tranasaction_Desc"].ToString();
                    //string Transaction_Amt = dr["Transaction_Amt"].ToString();
                    string Transaction_Creation_Date = dr["Transaction_Creation_Date"].ToString();
                    //string Transaction_Email = dr["Transaction_Email"].ToString();
                    //string Inq_Admin_Comment = dr["Inq_Admin_Comment"].ToString();

                    // InquiryClass a = new InquiryClass(Inq_PK,Inq_User, Inq_Subj, Inq_Msg, Inq_Creation_Date, Inq_Email, Inq_Admin_Comment);
                    UserTransactionHistory a = new UserTransactionHistory(Login_ID, User_ID, Transaction_ID, Transaction_Creation_Date);
                    TransactionList.Add(a);
                }
            }

        }
        return TransactionList;
    }

    public List<UserTransactionHistory> getTransactionByLoginId(string ID)
    {
        List<UserTransactionHistory> TransactionList = new List<UserTransactionHistory>();

        string queryStr = "SELECT * FROM TransactionHistoryClass WHERE Login_ID = @Login_ID";
        using (SqlConnection conn = new SqlConnection(DBConnect))
        {
            conn.Open();
            using (SqlCommand cmd = new SqlCommand(queryStr, conn))
            {
                cmd.Parameters.AddWithValue("@Login_ID", ID);
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    string Login_ID = dr["Login_ID"].ToString();
                    string User_ID = dr["User_ID"].ToString();
                    string Transaction_ID = dr["Transaction_ID"].ToString();
                    //string Tranasaction_Desc = dr["Tranasaction_Desc"].ToString();
                    //string Transaction_Amt = dr["Transaction_Amt"].ToString();
                    string Transaction_Creation_Date = dr["Transaction_Creation_Date"].ToString();
                    //string Transaction_Email = dr["Transaction_Email"].ToString();
                    //string Inq_Admin_Comment = dr["Inq_Admin_Comment"].ToString();

                    // InquiryClass a = new InquiryClass(Inq_PK,Inq_User, Inq_Subj, Inq_Msg, Inq_Creation_Date, Inq_Email, Inq_Admin_Comment);
                    UserTransactionHistory a = new UserTransactionHistory(Login_ID, User_ID, Transaction_ID, Transaction_Creation_Date);
                    TransactionList.Add(a);
                }
            }

        }
        return TransactionList;
    }

}