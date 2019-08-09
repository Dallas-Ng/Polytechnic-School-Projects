using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;
using System.Data.SqlClient;
using System.Configuration;

/// <summary>
/// Summary description for TransactionHistoryClass
/// </summary>
public class TransactionHistoryClass
{
    // Connection String for SQL Database
    //string connStr = ConfigurationManager.ConnectionStrings["DatabaseContext"].ConnectionString;

    string DBConnect = ConfigurationManager.ConnectionStrings["EBP-Database"].ConnectionString;

    private int _Transaction_ID;
    private string _Login_ID;
    private string _Course_Desc;
    private string _Course_Amt;
    private string _Transaction_Creation_Date;
    private string _Course_ID;
    private string _Course_Fee;
    //private string _Transaction_PK;
    //private string _Transaction_Admin_Comment;


    // Empty or Default class constructor
    public TransactionHistoryClass()
    {
        this._Login_ID = null;
        this._Transaction_ID = 0;
        this._Course_Desc = null;
        this._Course_Amt = null;
        this._Transaction_Creation_Date = null;
        this._Course_ID = null;
        this._Course_Fee = null;
        //this._Transaction_Admin_Comment = null;
    }



    public TransactionHistoryClass(string aLogin_ID, int aTransaction_ID, string aCourse_Desc, string aCourse_ID, string aCourse_Fee, string aTransaction_Creation_Date)
    {
        this._Login_ID = aLogin_ID;
        this._Transaction_ID = aTransaction_ID;
        this._Course_Desc = aCourse_Desc;
        this._Transaction_Creation_Date = aTransaction_Creation_Date;
        this._Course_ID = aCourse_ID;
        this._Course_Fee = aCourse_Fee;
    }


    public string Login_ID
    {
        get { return _Login_ID; }
        set { _Login_ID = value; }
    }

    public int Transaction_ID
    {
        get { return _Transaction_ID; }
        set { _Transaction_ID = value; }
    }

    public string Course_Desc
    {
        get { return _Course_Desc; }
        set { _Course_Desc = value; }
    }

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

    public string Course_ID
    {
        get { return _Course_ID; }
        set { _Course_ID = value; }
    }

    public string Course_Fee
    {
        get { return _Course_Fee; }
        set { _Course_Fee = value; }
    }

    //public string Transaction_Admin_Comment
    //{
    //get { return _Transaction_Admin_Comment; }
    //set { _Transaction_Admin_Comment = value; }
    //}


    //To [INSERT] submitted form data from customer to the database NEW ROWS
    //public int insertCustomerInquiry(string user, string transactionID, string transactionDesc, string transactionAmt, string creation_date, string email)
    //{

    //int result = 0;
    //string queryStr = "INSERT INTO SupportInquiry(Inq_User, Inq_Subj, Inq_Msg, Inq_Email, Inq_Creation_Date)"
    //                        + "values (@Inq_User, @Inq_Subj, @Inq_Msg, @Inq_Email, @Inq_Creation_Date)";

    //        using (SqlConnection conn = new SqlConnection(DBConnect))
    //      {
    //        conn.Open();
    //      using (SqlCommand cmd = new SqlCommand(queryStr, conn))
    //    {
    //      cmd.Parameters.AddWithValue("@User_ID", user);
    //   cmd.Parameters.AddWithValue("@Transaction_ID", transactionID);
    // cmd.Parameters.AddWithValue("@Transaction_Desc", transactionDesc);
    //cmd.Parameters.AddWithValue("@Transaction_Amt", transactionAmt);
    //cmd.Parameters.AddWithValue("@Transaction_Creation_Date", DateTime.Parse(creation_date));
    //cmd.Parameters.AddWithValue("@Transaction_Email", email);
    //result += cmd.ExecuteNonQuery();
    //}
    //}
    //return result;
    //}

    // Retrieve all ROWS (getTransactions)
    public List<TransactionHistoryClass> getTransactions()
    {
        List<TransactionHistoryClass> transactionList = new List<TransactionHistoryClass>();

        string queryStr = "SELECT * FROM TransactionHistoryList WHERE Login_ID=@Login_ID Order By Transaction_Creation_Date";
        using (SqlConnection conn = new SqlConnection(DBConnect))
        {
            conn.Open();
            using (SqlCommand cmd = new SqlCommand(queryStr, conn))
            {
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    string Login_ID = dr["Login_ID"].ToString();
                    string Transaction_ID = dr["Transaction_ID"].ToString();
                    string Course_Desc = dr["Course_Desc"].ToString();
                    string Course_Fee = dr["Course_Fee"].ToString();
                    Transaction_Creation_Date = dr["Transaction_Creation_Date"].ToString();
                    string Course_ID = dr["Course_ID"].ToString();
                    //string _Transaction_Admin_Comment = dr["_Transaction_Admin_Comment"].ToString();


                    TransactionHistoryClass a = new TransactionHistoryClass(Login_ID, Convert.ToInt32(Transaction_ID), Course_ID, Course_Desc, Course_Fee, Transaction_Creation_Date);
                    transactionList.Add(a);
                }
            }

        }
        return transactionList;
    }

    public List<TransactionHistoryClass> getAdminTransactions()
    {
        List<TransactionHistoryClass> transactionList = new List<TransactionHistoryClass>();

        string queryStr = "SELECT * FROM TransactionHistoryList Order By Transaction_Creation_Date";
        using (SqlConnection conn = new SqlConnection(DBConnect))
        {
            conn.Open();
            using (SqlCommand cmd = new SqlCommand(queryStr, conn))
            {
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    string Login_ID = dr["Login_ID"].ToString();
                    string Transaction_ID = dr["Transaction_ID"].ToString();
                    string Course_Desc = dr["Course_Desc"].ToString();
                    string Course_Fee = dr["Course_Fee"].ToString();
                    Transaction_Creation_Date = dr["Transaction_Creation_Date"].ToString();
                    string Course_ID = dr["Course_ID"].ToString();
                    //string _Transaction_Admin_Comment = dr["_Transaction_Admin_Comment"].ToString();


                    TransactionHistoryClass a = new TransactionHistoryClass(Login_ID, Convert.ToInt32(Transaction_ID), Course_ID, Course_Desc, Course_Fee, Transaction_Creation_Date);
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

        string queryStr = "UPDATE TransactionHistoryList SET Transaction_ID = @Transaction_ID WHERE User_ID = @User_ID";

        //string queryStr = "UPDATE Inquiry SET Inq_ID = 'test', Inq_Subj = 'test', Inq_Msg ='teet', Inq_Email = @Inq_Email WHERE Inq_PK = @Inq_PK";


        SqlConnection conn = new SqlConnection(DBConnect);


        SqlCommand cmd = new SqlCommand(queryStr, conn);
        // cmd.Parameters.AddWithValue("@Inq_User", user);
        // cmd.Parameters.AddWithValue("@Inq_Subj", subj);
        // cmd.Parameters.AddWithValue("@Inq_Msg", msg);
        // cmd.Parameters.AddWithValue("@Inq_Email", email);
        cmd.Parameters.AddWithValue("@User_ID", User_ID);
        cmd.Parameters.AddWithValue("@Transaction_ID", Transaction_ID);



        conn.Open();
        int nofRow = 0;
        nofRow = cmd.ExecuteNonQuery();
        conn.Close();
        return nofRow;
    }




    public List<TransactionHistoryClass> getSingleTransaction(string ID)
    {
        List<TransactionHistoryClass> TransactionList = new List<TransactionHistoryClass>();

        string queryStr = "SELECT * FROM TransactionHistoryList WHERE Transaction_Creation_Date= @Transaction_Creation_Date";
        using (SqlConnection conn = new SqlConnection(DBConnect))
        {
            conn.Open();
            using (SqlCommand cmd = new SqlCommand(queryStr, conn))
            {
                cmd.Parameters.AddWithValue("@Course_ID", ID);
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    string Login_ID = dr["Login_ID"].ToString();
                    string Transaction_ID = dr["Transaction_ID"].ToString();
                    string Course_Desc = dr["Course_Desc"].ToString();
                    string Course_Fee = dr["Course_Fee"].ToString();
                    string Transaction_Creation_Date = dr["Transaction_Creation_Date"].ToString();
                    string Course_ID = dr["Course_ID"].ToString();
                    //string Inq_Admin_Comment = dr["Inq_Admin_Comment"].ToString();

                    TransactionHistoryClass a = new TransactionHistoryClass(Login_ID, Convert.ToInt32(Transaction_ID), Course_ID, Course_Desc, Course_Fee, Transaction_Creation_Date);
                    TransactionList.Add(a);
                }
            }

        }
        return TransactionList;
    }

    public int insertTransactionHistory(string Login_ID, string Course_ID, string Course_Desc, decimal Course_Fee)
    {

        int result = 0;
        string queryStr = "INSERT INTO TransactionHistoryList(Login_ID, Course_ID, Course_Desc, Course_Fee, Transaction_Creation_Date)"
                        + " values (@Login_ID, @Course_ID, @Course_Desc, @Course_Fee, @Transaction_Creation_Date)";

        using (SqlConnection conn = new SqlConnection(DBConnect))
        {
            conn.Open();
            using (SqlCommand cmd = new SqlCommand(queryStr, conn))
            {
                cmd.Parameters.AddWithValue("@Login_ID", Login_ID);
                cmd.Parameters.AddWithValue("@Course_ID", Course_ID);
                cmd.Parameters.AddWithValue("@Transaction_ID", Transaction_ID);
                cmd.Parameters.AddWithValue("@Course_Desc", Course_Desc);
                cmd.Parameters.AddWithValue("@Course_Fee", Course_Fee);
                DateTime nCreation_Date = DateTime.Now;
                cmd.Parameters.AddWithValue("@Transaction_Creation_Date", nCreation_Date);

                result += cmd.ExecuteNonQuery();
            }
        }
        return result;
    }
}

    //public List<TransactionHistoryClass> invoiceTable()
   // {
       // List<TransactionHistoryClass> transactionList = new List<TransactionHistoryClass>();

      //  string queryStr = " SELECT c.Course_ID, c.Course_Desc, tl.Transaction_Creation_Date FROM TransactionHistoryList tl " +
       //                    " INNER JOIN Courses c ON c.Course_ID = tl.Course_ID ";

      //  using (SqlConnection conn = new SqlConnection(DBConnect))
       // {
         //   conn.Open();
        //    using (SqlCommand cmd = new SqlCommand(queryStr, conn))
          //  {
            //    SqlDataReader dr = cmd.ExecuteReader();
    
           //     while (dr.Read())
              //  {
                //    string Login_ID = dr["Login_ID"].ToString();
               //     string Transaction_ID = dr["Transaction_ID"].ToString();
                //    string Course_ID = dr["Course_ID"].ToString();
                  //  string Course_Desc = dr["Course_Desc"].ToString();
                //    string Transaction_Creation_Date = dr["Transaction_Creation_Date"].ToString();
                 //   string Course_Fee = dr["Course_Fee"].ToString();
                    //string _Transaction_Admin_Comment = dr["_Transaction_Admin_Comment"].ToString(); 

                  //  TransactionHistoryClass a = new TransactionHistoryClass(Login_ID, Course_ID, Course_Desc, Course_Fee, Transaction_Creation_Date);
                 //   transactionList.Add(a);
            //    }
       //     }

   //     }
  //      return transactionList;
 //   }