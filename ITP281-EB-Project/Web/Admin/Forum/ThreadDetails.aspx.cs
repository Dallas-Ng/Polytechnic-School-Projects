using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using System.Data.SqlClient;
using System.Configuration;


public partial class Web_Admin_Forum_ThreadDetails : System.Web.UI.Page
{
    ThreadClass Thread = new ThreadClass();
    PostClass Post = new PostClass();
    
    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (!IsPostBack)
        {
            //RepeaterData();
            bind();
        }
    }

    protected void bind()
    {
        string Thread_ID = Request.QueryString["Thread_ID"];

        List<ThreadClass> ThreadList = Thread.getThreadAll(Thread_ID);
        lblThreadTitle.Text = ThreadList[0].Thread_Title.ToString();
        lblThreadDesc.Text = ThreadList[0].Thread_Desc.ToString();
        lblThreadCreationDate.Text = ThreadList[0].Thread_CreationDate.ToString();

        tb_PostMsg.Text = "";

        List<PostClass> PostList = new List<PostClass>();
        PostList = Post.getPostClassAll(Thread_ID);
        gv_PostData.DataSource = PostList;
        gv_PostData.DataBind();

    }

    protected void gv_PostData_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int result = 0;
        PostClass Post = new PostClass();
        string categoryID = gv_PostData.DataKeys[e.RowIndex].Value.ToString();
        string Thread_ID = Request.QueryString["Thread_ID"];
        //string Post_ID = Request.QueryString["Post_ID"];
        result = Post.PostClassDelete(categoryID);
        if (result > 0)
        {
            Response.Write("<script>alert('Post Remove successfully');</script>");
        }
        else
        {
            Response.Write("<script>alert('Post Removal NOT successfully');</script>");
        }
        Response.Redirect("~/Web/Admin/Forum/ThreadDetails.aspx?Thread_ID=" + Thread_ID);
    }

    /*public void RepeaterData()
    {
        string Thread_ID = Request.QueryString["Thread_ID"];
        //string Post_ID = Request.QueryString["Post_ID"];
        List<ThreadClass> ThreadData = Thread.getSingleThread(Thread_ID);
        List<PostClass> Posts = Post.getPostClassAll(Thread_ID);

        Posts.Reverse();
       
        Rp_ThreadData.DataSource = Posts;
        Rp_ThreadData.DataBind();

        List<ThreadClass> ThreadList = Thread.getThreadAll(Thread_ID);
        lblThreadTitle.Text = ThreadList[0].Thread_Title.ToString();
        lblThreadDesc.Text = ThreadList[0].Thread_Desc.ToString();
        lblThreadCreationDate.Text = ThreadList[0].Thread_CreationDate.ToString();

        tb_PostMsg.Text = "";
        tb_PostTitle.Text = "";
        tb_PostReply.Text = "";
    } */


    protected void btn_Post_Click(object sender, EventArgs e)
    {
        string creation_date = DateTime.Now.ToString();
        int result = 1;
        string TID = Request.QueryString["Thread_ID"];
        PostClass newPost = new PostClass(tb_PostMsg.Text, creation_date,TID);
        if (result > 0)
        {
            Response.Write("<script>alert('Post submitted successfully');</script>");
        }
        else
        {
            Response.Write("<script>alert('Post not submitted successfully');</script>");
        }

        result = newPost.PostClassInsert();
        bind();
        //RepeaterData();
    }

    protected void rp_ThreadData_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "Delete") //breakpoint on this line
        {
            LinkButton DeletePost = (LinkButton)e.CommandSource;
            // int Post_ID = Convert.ToInt32(e.CommandArgument);
          
            string Post_ID = e.CommandArgument.ToString();
            Post.PostClassDelete(Post_ID);
            //RepeaterData();
        }
    }

    protected void btn_DeletePost_Click(object sender, EventArgs e)
    {
        int result = 0;
        PostClass Post = new PostClass();
        string TID = Request.QueryString["Thread_ID"];
        string Post_ID = Request.QueryString["Post_ID"];
        result = Post.PostClassDelete(Post_ID);
        if (result > 0)
        {
            Response.Write("<script>alert('Post Remove successfully');</script>");
        }
        else
        {
            Response.Write("<script>alert('Post Removal NOT successfully');</script>");
        }
        Response.Redirect("~/Web/Admin/Forum/ThreadDetails.aspx?Thread_ID=" + TID);
    }


    protected void btn_Back_Click(object sender, EventArgs e)
    {
        //string TID = Request.QueryString["Thread_ID"];
        //string Forum_ID = Request.QueryString["Forum_ID"];
        //Response.Redirect("~/Web/Admin/Forum/Threadview.aspx?Forum_ID=" + Forum_ID);
        Response.Redirect("~/Web/Admin/Forum/Forumview.aspx");
    }


    protected void gv_PostData_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        bind();
        gv_PostData.PageIndex = e.NewPageIndex;
        gv_PostData.DataBind();
    }
}
