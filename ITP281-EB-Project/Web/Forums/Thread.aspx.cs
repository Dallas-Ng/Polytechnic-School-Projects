using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Web_Forums_Thread : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            reload();
        }
    }

    protected void reload()
    {
        ThreadClass Thread = new ThreadClass();
        List<ThreadClass> ThreadList = new List<ThreadClass>();
        string TID = Request.QueryString["Thread_ID"];
        ThreadList = Thread.getSingleThread(TID);

        Title.Text = ThreadList[0].Thread_Title;
        Desc.Text = ThreadList[0].Thread_Desc;

        SqlDataSource1.SelectCommand = "SELECT Thread_Title, Post_Msg, Post_CreationDate, Fp.User_ID, U.ProfilePictureUrl FROM ForumsThreads Ft INNER JOIN ForumsPosts Fp on Ft.Thread_ID = Fp.Thread_ID INNER JOIN Users U on Fp.User_ID = U.Login_ID WHERE Fp.Thread_ID = " + TID + " AND Fp.IsDeleted = 0";
    }

    protected void btn_Post_Click(object sender, EventArgs e)
    {
        string creation_date = DateTime.Now.ToString();
        string TID = Request.QueryString["Thread_ID"];
        PostClass newPost = new PostClass(tb_PostMsg.Text, creation_date,TID);

        int result = newPost.PostClassInsert1(Session["Current_Logged"].ToString());

        if (result > 0)
        {
            Response.Write("<script>alert('Post submitted successfully');</script>");
        }
        else
        {
            Response.Write("<script>alert('Post not submitted successfully');</script>");
        }
        Response.Redirect("~/Web/Forums/Thread.aspx?Thread_ID=" + TID);
    }

}