using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;
using System.Data.SqlClient;
using System.Configuration;

/// <summary>
/// Emily Ong 185208F
/// Summary description for Forum
/// </summary>
public class ForumClass
{
    string connStr = ConfigurationManager.ConnectionStrings["EBP-Database"].ConnectionString;

    private string _Forum_ID = null;
    private string _Forum_Title = "";
    private string _Forum_Category = "";
    private string _Forum_Desc = "";

    public ForumClass()
    {
    }

    public ForumClass(string Forum_ID, string Forum_Title, string Forum_Category, string Forum_Desc)
    {
        _Forum_ID = Forum_ID;
        _Forum_Title = Forum_Title;
        _Forum_Category = Forum_Category;
        _Forum_Desc = Forum_Desc;
    }

    public ForumClass(string Forum_Title, string Forum_Category, string Forum_Desc) : this(null, Forum_Title, Forum_Category, Forum_Desc)
    {

    }

    public ForumClass(string Forum_ID) : this(Forum_ID, "", "", "")
    {

    }

    public string Forum_ID
    {
        get { return _Forum_ID; }
        set { _Forum_ID = value; }
    }

    public string Forum_Title
    {
        get { return _Forum_Title; }
        set { _Forum_Title = value; }
    }

    public string Forum_Category
    {
        get { return _Forum_Category; }
        set { _Forum_Category = value; }
    }

    public string Forum_Desc
    {
        get { return _Forum_Desc; }
        set { _Forum_Desc = value; }
    }

    public ForumClass getForum(string Forum_ID)
    {
        ForumClass NewForum = null;
        string Forum_Title, Forum_Category, Forum_Desc;
        string queryStr = "SELECT * FROM Forums WHERE Forum_ID = @Forum_ID";
        SqlConnection conn = new SqlConnection(connStr);
        SqlCommand cmd = new SqlCommand(queryStr, conn);
        cmd.Parameters.AddWithValue("@Forum_ID", Forum_ID);
        conn.Open();
        SqlDataReader dr = cmd.ExecuteReader();
        //Check if there are any resultsets
        if (dr.Read())
        {
            Forum_ID = dr["Forum_ID"].ToString();
            Forum_Title = dr["Forum_Title"].ToString();
            Forum_Category = dr["Forum_Category"].ToString();
            Forum_Desc = dr["Forum_Desc"].ToString();
            NewForum = new ForumClass(Forum_ID,Forum_Title,Forum_Category,Forum_Desc);
        }
        else
        {
            NewForum = null;
        }
        conn.Close();
        dr.Close();
        dr.Dispose();
        return NewForum;
    }

    public List<ForumClass> getForumAll()
    {
        List<ForumClass> ForumList = new List<ForumClass>();

        string Forum_Title, Forum_Category, Forum_Desc, Forum_ID;
        string queryStr = "SELECT * FROM Forums WHERE isDeleted = 0 Order By Forum_ID + 0 ASC";

        SqlConnection conn = new SqlConnection(connStr);
        SqlCommand cmd = new SqlCommand(queryStr, conn);
        conn.Open();
        SqlDataReader dr = cmd.ExecuteReader();


        //Continue to read the resultsets row by row if not the end
        while (dr.Read())
        {
            Forum_ID = dr["Forum_ID"].ToString();
            Forum_Title = dr["Forum_Title"].ToString();
            Forum_Category = dr["Forum_Category"].ToString();
            Forum_Desc = dr["Forum_Desc"].ToString();
            ForumClass a = new ForumClass(Forum_ID,Forum_Title,Forum_Category,Forum_Desc);
            ForumList.Add(a);
        }

        conn.Close();
        dr.Close();
        dr.Dispose();
        return ForumList;
    }

    public List<ForumClass> getForumClass(string FID)
    {
        List<ForumClass> ForumList = new List<ForumClass>();

        string queryStr = "SELECT * FROM Forums WHERE Forum_ID = @Forum_ID";
        using (SqlConnection conn = new SqlConnection(connStr))
        {
            conn.Open();
            using (SqlCommand cmd = new SqlCommand(queryStr, conn))
            {
                cmd.Parameters.AddWithValue("@Forum_ID", FID);
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    string Forum_ID = dr["Forum_ID"].ToString();
                    string Forum_Title = dr["Forum_Title"].ToString();
                    string Forum_Category = dr["Forum_Category"].ToString();
                    string Forum_Desc = dr["Forum_Desc"].ToString();
                    ForumClass a = new ForumClass(Forum_ID, Forum_Title, Forum_Category, Forum_Desc);
                    ForumList.Add(a);
                }
            }
        }
        return ForumList;
    }

    public int ForumInsert()
    {
        int result = 0;
        string queryStr = "INSERT INTO Forums(Forum_Title,Forum_Category,Forum_Desc)" + "values(@Forum_Title, @Forum_Category, @Forum_Desc)";

        using (SqlConnection conn = new SqlConnection(connStr))
        {
            conn.Open();
            using (SqlCommand cmd = new SqlCommand(queryStr, conn))
            {
                
                cmd.Parameters.AddWithValue("@Forum_Title", this.Forum_Title);
                cmd.Parameters.AddWithValue("@Forum_Category", this.Forum_Category);
                cmd.Parameters.AddWithValue("@Forum_Desc", this.Forum_Desc);

                result += cmd.ExecuteNonQuery(); // Returns no. of rows affected. Must be > 0

            }
        }

        return result;
    }

  

    public int ForumClassDelete(string Forum_ID)
    {
        string queryStr = "UPDATE Forums SET isDeleted = 1 WHERE Forum_ID = @Forum_ID";


        SqlConnection con = new SqlConnection(connStr);
        SqlCommand cmd = new SqlCommand(queryStr, con);
        cmd.Parameters.AddWithValue("@Forum_ID", Forum_ID);
        con.Open();
        int nofRow = 0;
        nofRow = cmd.ExecuteNonQuery();
        con.Close();
        return nofRow;
    }

    public int ForumClassUpdate(string Forum_ID ,string Forum_Title, string Forum_Category)
    {
        string queryStr = "UPDATE Forums SET Forum_Title =  @Forum_Title, Forum_Category = @Forum_Category WHERE Forum_ID = @Forum_ID";

        SqlConnection conn = new SqlConnection(connStr);
        SqlCommand cmd = new SqlCommand(queryStr, conn);
        cmd.Parameters.AddWithValue("@Forum_ID", Forum_ID);
        cmd.Parameters.AddWithValue("@Forum_Title", Forum_Title);
        cmd.Parameters.AddWithValue("@Forum_Category", Forum_Category);
        cmd.Parameters.AddWithValue("@Forum_Desc", Forum_Desc);

        conn.Open();
        int nofRow = 0;
        nofRow = cmd.ExecuteNonQuery();

        conn.Close();

        return nofRow;
    }

}