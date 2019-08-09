using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;
using System.Data.SqlClient;
using System.Configuration;

/// <summary>
/// Emily Ong 185208F
/// Summary description for PostClass
/// </summary>
public class PostClass
{
    string connStr = ConfigurationManager.ConnectionStrings["EBP-Database"].ConnectionString;

    private string _Post_ID = null;
    private string _Post_Msg = "";
    private string _Post_CreationDate = "";
    private string _Thread_ID = "";
    private string _User_ID = "";

    public PostClass()
    {
       
    }

    
    public PostClass(string Post_ID, string Post_Msg, string Post_CreationDate,string Thread_ID)
    {
        _Post_ID = Post_ID;
        _Post_Msg = Post_Msg;
        _Post_CreationDate = Post_CreationDate;
        _Thread_ID = Thread_ID;
        
    }

    public PostClass(string Post_ID, string Post_Msg, string Post_CreationDate,string Thread_ID,string User_ID)
    {
        _Post_ID = Post_ID;
        _Post_Msg = Post_Msg;
        _Post_CreationDate = Post_CreationDate;
        _Thread_ID = Thread_ID;
        _User_ID = User_ID;
    }



    public PostClass(string Post_Msg,string Post_CreationDate, string Thread_ID) : this(null,Post_Msg,Post_CreationDate,Thread_ID)
    {

    }


    public PostClass(string Post_ID) : this(Post_ID, "", "", "","")
    {

    }

    public string Post_ID
    {
        get { return _Post_ID; }
        set { _Post_ID = value; }
    }


    public string Post_Msg
    {
        get { return _Post_Msg; }
        set { _Post_Msg = value; }
    }

    public string Post_CreationDate
    {
        get { return _Post_CreationDate; }
        set { _Post_CreationDate = value; }
    }

    public string Thread_ID
    {
        get { return _Thread_ID; }
        set { _Thread_ID = value; }
    }

    public string User_ID
    {
        get { return _User_ID; }
        set { _User_ID = value; }
    }


    public PostClass getPostClass(string Post_ID)
    {
        PostClass NewPost = null;
        string Post_Msg, Post_CreationDate;
        string queryStr = "SELECT * FROM ForumsPosts WHERE Post_ID = @Post_ID";
        SqlConnection conn = new SqlConnection(connStr);
        SqlCommand cmd = new SqlCommand(queryStr, conn);
        cmd.Parameters.AddWithValue("@Post_ID", Post_ID);
        conn.Open();
        SqlDataReader dr = cmd.ExecuteReader();
        //Check if there are any resultsets
        if (dr.Read())
        {
            Post_ID = dr["Post_ID"].ToString();
            Post_Msg = dr["Post_Msg"].ToString();
            Post_CreationDate = dr["Post_CreationDate"].ToString();
            NewPost = new PostClass(Post_ID, Post_Msg, Post_CreationDate);
        }
        else
        {
            NewPost = null;
        }
        conn.Close();
        dr.Close();
        dr.Dispose();
        return NewPost;
    }

    public List<PostClass> getPostClassAll(string Thread_ID)
    {
        List<PostClass> PostList = new List<PostClass>();

        string Post_Msg, Post_CreationDate,Post_ID;
        string queryStr = "SELECT * FROM ForumsPosts WHERE Thread_ID = @Thread_ID AND isDeleted = 0 Order By Post_CreationDate";

        SqlConnection conn = new SqlConnection(connStr);
        SqlCommand cmd = new SqlCommand(queryStr, conn);
        conn.Open();
        cmd.Parameters.AddWithValue("@Thread_ID", Thread_ID);
        SqlDataReader dr = cmd.ExecuteReader();


        //Continue to read the resultsets row by row if not the end
        while (dr.Read())
        {
            Post_ID = dr["Post_ID"].ToString();
            Post_Msg = dr["Post_Msg"].ToString();
            Post_CreationDate = dr["Post_CreationDate"].ToString();
            Thread_ID = dr["Thread_ID"].ToString();
            User_ID = dr["User_ID"].ToString();
            PostClass a = new PostClass(Post_ID, Post_Msg, Post_CreationDate,Thread_ID,User_ID);
            PostList.Add(a);
        }

        conn.Close();
        dr.Close();
        dr.Dispose();
        return PostList;
    }

    

    public int PostClassInsert()
    {
        int result = 0;
        string queryStr = "INSERT INTO ForumsPosts(Post_Msg,Post_CreationDate,Thread_ID)" +
            "values(@Post_Msg, @Post_CreationDate,@Thread_ID)";

        using (SqlConnection conn = new SqlConnection(connStr))
        {
            conn.Open();
            using (SqlCommand cmd = new SqlCommand(queryStr, conn))
            {
                //cmd.Parameters.AddWithValue("@Post_ID", this.Post_ID);
                cmd.Parameters.AddWithValue("@Post_Msg", this.Post_Msg);
                cmd.Parameters.AddWithValue("@Post_CreationDate", this.Post_CreationDate);
                cmd.Parameters.AddWithValue("@Thread_ID", this.Thread_ID);

                result += cmd.ExecuteNonQuery(); // Returns no. of rows affected. Must be > 0

            }
        }

        return result;
    }

    public int PostClassInsert1(string Login_ID)
    {
        int result = 0;
        string queryStr = "INSERT INTO ForumsPosts(User_ID,Post_Msg,Post_CreationDate,Thread_ID)" +
            "values(@User_ID, @Post_Msg, @Post_CreationDate,@Thread_ID)";

        using (SqlConnection conn = new SqlConnection(connStr))
        {
            conn.Open();
            using (SqlCommand cmd = new SqlCommand(queryStr, conn))
            {
                //cmd.Parameters.AddWithValue("@Post_ID", this.Post_ID);
                cmd.Parameters.AddWithValue("@User_ID", Login_ID);
                cmd.Parameters.AddWithValue("@Post_Msg", this.Post_Msg);
                cmd.Parameters.AddWithValue("@Post_CreationDate", this.Post_CreationDate);
                cmd.Parameters.AddWithValue("@Thread_ID", this.Thread_ID);

                result += cmd.ExecuteNonQuery(); // Returns no. of rows affected. Must be > 0

            }
        }

        return result;
    }

    public List<PostClass> getSinglePost(string Post_ID)
    {
        List<PostClass> PostList = new List<PostClass>();

        string queryStr = "SELECT * FROM ForumsPosts WHERE Post_ID = @Post_ID";
        using (SqlConnection conn = new SqlConnection(connStr))
        {
            conn.Open();
            using (SqlCommand cmd = new SqlCommand(queryStr, conn))
            {
                cmd.Parameters.AddWithValue("@Post_ID", Post_ID);
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    string Post_Msg = dr["Post_Msg"].ToString();
                    string Post_CreationDate = dr["Post_CreationDate"].ToString();

                    PostClass a = new PostClass(Post_ID, Post_Msg, Post_CreationDate);
                    PostList.Add(a);
                }
            }

        }
        return PostList;
    }

    public int PostClassDelete(string Post_ID)
    {
        string queryStr = "UPDATE ForumsPosts SET isDeleted = 1 WHERE Post_ID = @Post_ID";

        SqlConnection con = new SqlConnection(connStr);
        SqlCommand cmd = new SqlCommand(queryStr, con);
        cmd.Parameters.AddWithValue("@Post_ID",Post_ID);
       // cmd.Parameters.AddWithValue("@Forum_ID", Forum_ID);
        con.Open();
        int nofRow = 0;
        nofRow = cmd.ExecuteNonQuery();
        con.Close();
        return nofRow;
    }

    /*public int PostClassUpdate(string Post_ID, string Post_Msg)
    {
        string queryStr = "UPDATE ForumsPosts SET" + " Post_Title = @Post_Title, " + " Post_Msg = @Post_Msg " + "Post_Reply = @Post_Reply" +  "WHERE Post_ID = @Post_ID";
        SqlConnection conn = new SqlConnection(connStr);
        SqlCommand cmd = new SqlCommand(queryStr, conn);
        cmd.Parameters.AddWithValue("@Post_ID", Post_ID);
        cmd.Parameters.AddWithValue("@Post_Msg", Post_Msg);
        conn.Open();
        int nofRow = 0;
        nofRow = cmd.ExecuteNonQuery();
        conn.Close();
        return nofRow;
    } */
}