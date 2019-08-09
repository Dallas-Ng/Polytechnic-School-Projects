using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;
using System.Data.SqlClient;
using System.Configuration;

/// <summary>
/// Emily Ong 185208F
/// Summary description for ThreadClass
/// </summary>
public class ThreadClass
{
    string connStr = ConfigurationManager.ConnectionStrings["EBP-Database"].ConnectionString;

    private string _Thread_ID = null;
    private string _Thread_Title = "";
    private string _Thread_Desc = "";
    private string _Thread_Category = "";
    private string _Thread_CreationDate = "";
    private string _Forum_ID = "";
    private string _Forum_Title = "";
    private string _Forum_Desc = "";
    private string _Forum_Category = "";

    public ThreadClass()
    {
        
    }


    public ThreadClass(string Thread_ID, string Thread_Title, string Thread_Desc, string Thread_CreationDate, string Thread_Category,string Forum_ID)
      {
          _Thread_ID = Thread_ID;
          _Thread_Title = Thread_Title;
          _Thread_Desc = Thread_Desc;
          _Thread_Category = Thread_Category;
          _Thread_CreationDate = Thread_CreationDate;
          _Forum_ID = Forum_ID;
    }

    public ThreadClass(string Thread_Title, string Thread_Desc, string Thread_CreationDate , string Thread_Category,string Forum_ID) : this(null, Thread_Title,Thread_Desc,Thread_CreationDate,Thread_Category,Forum_ID)
    {

    }
 
  
    public ThreadClass(string Thread_ID) : this(Thread_ID, "", "", "","","")
    {

    }

    public ThreadClass(string Thread_Title,string Thread_Desc,string Thread_CreationDate)
    {

    }

    public string Thread_ID
    {
        get { return _Thread_ID; }
        set { _Thread_ID = value; }
    }

    public string Thread_Title
    {
        get { return _Thread_Title; }
        set { _Thread_Title = value; }
    }

    public string Thread_Desc
    {
        get { return _Thread_Desc; }
        set { _Thread_Desc = value; }
    }

    public string Thread_CreationDate
    {
        get { return _Thread_CreationDate; }
        set { _Thread_CreationDate = value; }
    }

    public string Thread_Category
    {
        get { return _Thread_Category; }
        set { _Thread_Category = value; }
    }

    public string Forum_ID
    {
        get { return _Forum_ID; }
        set { _Forum_ID = value; }
    }

    public ThreadClass getThreadClass(string Thread_ID)
    {
        ThreadClass NewThread = null;
        string queryStr = "SELECT * FROM ForumsThreads WHERE Thread_ID = @Thread_ID";
        SqlConnection conn = new SqlConnection(connStr);
        SqlCommand cmd = new SqlCommand(queryStr, conn);
        cmd.Parameters.AddWithValue("@Thread_ID", Thread_ID);
        conn.Open();
        SqlDataReader dr = cmd.ExecuteReader();
        //Check if there are any resultsets
        if (dr.Read())
        {
            
            string Thread_Title = dr["Thread_Title"].ToString();
            string Thread_Desc = dr["Thread_Desc"].ToString();
            string Thread_Category = dr["Thread_Category"].ToString();
            string Thread_CreationDate = dr["Thread_CreationDate"].ToString();
            string Forum_ID = dr["Forum_ID"].ToString();
            NewThread = new ThreadClass(Thread_ID, Thread_Title, Thread_Desc,Thread_Category, Thread_CreationDate,Forum_ID);
        }
        else
        {
            NewThread = null;
        }
        conn.Close();
        dr.Close();
        dr.Dispose();
        return NewThread;
    }

    public List<ThreadClass> RetrieveUrl(string FID)
    {
        List<ThreadClass> ThreadList = new List<ThreadClass>();

        string queryStr;
        queryStr = "SELECT * FROM ForumsThreads WHERE Forum_ID = @Forum_ID AND IsDeleted = 0";

        using (SqlConnection conn = new SqlConnection(connStr))
        {
            conn.Open();
            using (SqlCommand cmd = new SqlCommand(queryStr, conn))
            {
                cmd.Parameters.AddWithValue("@Forum_ID", FID);

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr != null) // If there is something to read
                    {
                        while (dr.Read())
                        {
                            Thread_ID = dr["Thread_ID"].ToString();
                            Thread_Title = dr["Thread_Title"].ToString();
                            Thread_Category = dr["Thread_Category"].ToString();
                            Thread_Desc = dr["Thread_Desc"].ToString();
                            Thread_CreationDate = dr["Thread_CreationDate"].ToString();
                            Forum_ID = dr["Forum_ID"].ToString();
                            ThreadClass a = new ThreadClass(Thread_ID, Thread_Title, Thread_Desc, Thread_CreationDate, Thread_Category, Forum_ID);
                            ThreadList.Add(a);
                        }

                    }
                }
            }
        }
        return ThreadList;
    }

    public List<ThreadClass> getSingleThread(string Thread_ID)
    {
        List<ThreadClass> ThreadList = new List<ThreadClass>();

        string queryStr = "SELECT * FROM ForumsThreads WHERE Thread_ID = @Thread_ID";
        using (SqlConnection conn = new SqlConnection(connStr))
        {
            conn.Open();
            using (SqlCommand cmd = new SqlCommand(queryStr, conn))
            {
                cmd.Parameters.AddWithValue("@Thread_ID", Thread_ID);
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    string Thread_Title = dr["Thread_Title"].ToString();
                    string Thread_Desc = dr["Thread_Desc"].ToString();
                    string Thread_Category = dr["Thread_Category"].ToString();
                    string Thread_CreationDate = dr["Thread_CreationDate"].ToString();
                    string Forum_ID = dr["Forum_ID"].ToString();
                    
                    ThreadClass a = new ThreadClass(Thread_Title, Thread_Desc, Thread_CreationDate, Thread_Category, Forum_ID);
                    ThreadList.Add(a);
                }
            }

        }
        return ThreadList;
    }

    public List<ThreadClass> getThreadAll(string Thread_ID)
    {
        List<ThreadClass> ThreadList = new List<ThreadClass>();

        string queryStr = "SELECT * FROM ForumsThreads WHERE Thread_ID = @Thread_ID AND isDeleted = 0";

        using (SqlConnection conn = new SqlConnection(connStr))
        {
            conn.Open();
            using (SqlCommand cmd = new SqlCommand(queryStr, conn))
            {
                cmd.Parameters.AddWithValue("@Thread_ID", Thread_ID);
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    //Thread_ID = dr["Thread_ID"].ToString();
                    String Thread_Title = dr["Thread_Title"].ToString();
                    String Thread_Desc = dr["Thread_Desc"].ToString();
                    String Thread_CreationDate = dr["Thread_CreationDate"].ToString();
                    String Thread_Category = dr["Thread_Category"].ToString();
                    string Forum_ID = dr["Forum_ID"].ToString();
                    ThreadClass a = new ThreadClass(Thread_ID, Thread_Title, Thread_Desc, Thread_CreationDate, Thread_Category, Forum_ID);
                    ThreadList.Add(a);
                }
            }

        }
        return ThreadList;
    }


    public int ThreadClassInsert()
    {
        int result = 0;
        string queryStr = "INSERT INTO ForumsThreads(Thread_Title,Thread_Desc,Thread_Category,Thread_CreationDate,Forum_ID)" +
            "values(@Thread_Title,@Thread_Desc,@Thread_Category,@Thread_CreationDate,@Forum_ID)";

        using (SqlConnection conn = new SqlConnection(connStr))
        {
            conn.Open();
            using (SqlCommand cmd = new SqlCommand(queryStr, conn))
            {
                //cmd.Parameters.AddWithValue("@Thread_ID", this.Thread_ID);
                cmd.Parameters.AddWithValue("@Thread_Title", this.Thread_Title);
                cmd.Parameters.AddWithValue("@Thread_Desc", this.Thread_Desc);
                cmd.Parameters.AddWithValue("@Thread_Category", this.Thread_Category);
                cmd.Parameters.AddWithValue("@Thread_CreationDate",this.Thread_CreationDate);
                cmd.Parameters.AddWithValue("@Forum_ID",this.Forum_ID);

                result += cmd.ExecuteNonQuery(); // Returns no. of rows affected. Must be > 0

            }
        }

        return result;
    }

    public int ThreadClassInsert(string Login_ID)
    {
        int result = 0;
        string queryStr = "INSERT INTO ForumsThreads(User_ID, Thread_Title,Thread_Desc,Thread_Category,Thread_CreationDate,Forum_ID)" +
            "values(@User_ID, @Thread_Title,@Thread_Desc,@Thread_Category,@Thread_CreationDate,@Forum_ID)";

        using (SqlConnection conn = new SqlConnection(connStr))
        {
            conn.Open();
            using (SqlCommand cmd = new SqlCommand(queryStr, conn))
            {
                //cmd.Parameters.AddWithValue("@Thread_ID", this.Thread_ID);
                cmd.Parameters.AddWithValue("@User_ID", Login_ID);
                cmd.Parameters.AddWithValue("@Thread_Title", this.Thread_Title);
                cmd.Parameters.AddWithValue("@Thread_Desc", this.Thread_Desc);
                cmd.Parameters.AddWithValue("@Thread_Category", this.Thread_Category);
                cmd.Parameters.AddWithValue("@Thread_CreationDate", this.Thread_CreationDate);
                cmd.Parameters.AddWithValue("@Forum_ID", this.Forum_ID);

                result += cmd.ExecuteNonQuery(); // Returns no. of rows affected. Must be > 0

            }
        }

        return result;
    }

    public int ThreadClassDelete(string Thread_ID)
    {
        string queryStr = "UPDATE ForumsThreads SET isDeleted = 1 WHERE Thread_ID = @Thread_ID";
        SqlConnection con = new SqlConnection(connStr);
        SqlCommand cmd = new SqlCommand(queryStr, con);
        cmd.Parameters.AddWithValue("@Thread_ID",Thread_ID);
        //cmd.Parameters.AddWithValue("@Forum_ID", Forum_ID);
        con.Open();
        int nofRow = 0;
        nofRow = cmd.ExecuteNonQuery();
        con.Close();
        return nofRow;
    }

    public int ThreadClassUpdate(string Thread_ID, string Thread_Title)
    {
        string queryStr = "UPDATE ForumsThreads SET  Thread_Title = @Thread_Title WHERE Thread_ID = @Thread_ID";
        SqlConnection conn = new SqlConnection(connStr);
        SqlCommand cmd = new SqlCommand(queryStr, conn);
        cmd.Parameters.AddWithValue("@Thread_ID", Thread_ID);
        cmd.Parameters.AddWithValue("@Thread_Title", Thread_Title);
        conn.Open();
        int nofRow = 0;
        nofRow = cmd.ExecuteNonQuery();
        conn.Close();
        return nofRow;
    }

}