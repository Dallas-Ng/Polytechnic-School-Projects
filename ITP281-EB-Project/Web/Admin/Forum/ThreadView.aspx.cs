using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Web_Thread_ThreadView : System.Web.UI.Page
{
    ThreadClass Thread = new ThreadClass();
    ForumClass Forum = new ForumClass();

    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            bind();
        }

    }

    protected void bind()
    {
        List<ThreadClass> ThreadList = new List<ThreadClass>();
        string FID = Request.QueryString["Forum_ID"];
        ThreadList = Thread.RetrieveUrl(FID);
        //ThreadList = Thread.getThreadAll();
        gv_ThreadData.DataSource = ThreadList;
        gv_ThreadData.DataBind();

        
        List<ForumClass> ForumList = Forum.getForumClass(FID);
        lbl_ForumTitle.Text = ForumList[0].Forum_Title.ToString();
        //lbl_ForumDesc.Text = ForumList[0].Forum_Desc.ToString();

    }


    protected void gv_ThreadData_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridViewRow row = gv_ThreadData.SelectedRow;
        string Thread_ID = row.Cells[0].Text;
        string FID = Request.QueryString["Forum_ID"];

        Response.Redirect("~/Web/Admin/Forum/ThreadDetails.aspx?Thread_ID=" + Thread_ID +"&Forum_ID=" + FID);
    }

    protected void gv_ThreadData_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int result = 0;
        ThreadClass Thread = new ThreadClass();
        string categoryID = gv_ThreadData.DataKeys[e.RowIndex].Value.ToString();
        string Forum_ID = Request.QueryString["Forum_ID"];
        result = Thread.ThreadClassDelete(categoryID);
        if (result > 0) 
        {
            Response.Write("<script>alert('Thread Remove successfully');</script>");
        }
        else
        {
            Response.Write("<script>alert('Thread Removal NOT successfully');</script>");
        }
        Response.Redirect("~/Web/Admin/Forum/ThreadView.aspx?Forum_ID=" + Forum_ID);
    }

    protected void btn_Create_Click(object sender, EventArgs e)
    {
        string Forum_ID = Request.QueryString["Forum_ID"];
        Response.Redirect("~/Web/Admin/Forum/ThreadInsert.aspx?Forum_ID=" + Forum_ID);
    }

    protected void gv_ThreadData_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gv_ThreadData.EditIndex = e.NewEditIndex;
        bind();
    }

    protected void gv_ThreadData_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gv_ThreadData.EditIndex = -1;
        bind();
    }

    protected void gv_ThreadData_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        int result = 0;
        ThreadClass Thread = new ThreadClass();
        GridViewRow row = (GridViewRow)gv_ThreadData.Rows[e.RowIndex];
        string Thread_ID = gv_ThreadData.DataKeys[e.RowIndex].Value.ToString();
        //string Thread_ID = ((TextBox)row.Cells[0].Controls[0]).Text;
        string Thread_Title = ((TextBox)row.Cells[1].Controls[0]).Text;
        //string Thread_Desc = ((TextBox)row.Cells[2].Controls[0]).Text;
        //string Thread_Category = ((TextBox)row.Cells[3].Controls[0]).Text;
       //string Thread_CreationDate = ((TextBox)row.Cells[4].Controls[0]).Text;
        result = Thread.ThreadClassUpdate(Thread_ID,Thread_Title);
        if (result > 0)
        {
            Response.Write("<script>alert('Forum Data updated successfully');</script>");
        }
        else
        {
            Response.Write("<script>alert('Forum Data NOT updated');</script>");
        }
        gv_ThreadData.EditIndex = -1;
        bind();
    }
    protected void btn_Back_Click(object sender, EventArgs e)
    {
        string Forum_ID = Request.QueryString["Forum_ID"];
        Response.Redirect("~/Web/Admin/Forum/ForumView.aspx");
    }
}