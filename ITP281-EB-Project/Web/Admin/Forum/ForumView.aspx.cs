using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Web_Thread_ForumView : System.Web.UI.Page
{
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
        List<ForumClass> ForumList = new List<ForumClass>();
        ForumList = Forum.getForumAll();
        gv_ForumData.DataSource = ForumList;
        gv_ForumData.DataBind();
    }


    protected void gv_ForumData_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridViewRow row = gv_ForumData.SelectedRow;
        string Forum_ID = row.Cells[0].Text;
        Response.Redirect("~/Web/Admin/Forum/ThreadView.aspx?Forum_ID=" + Forum_ID);
    }

    protected void gv_ForumData_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int result = 0;
        ForumClass Forum = new ForumClass();
        string categoryID = gv_ForumData.DataKeys[e.RowIndex].Value.ToString();
        result = Forum.ForumClassDelete(categoryID);
        if (result > 0)
        {
            Response.Write("<script>alert('Forum Remove successfully');</script>");
        }
        else
        {
            Response.Write("<script>alert('Forum Removal NOT successfully');</script>");
        }
        Response.Redirect("~/Web/Admin/Forum/ForumView.aspx");
    }

    protected void gv_ForumData_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gv_ForumData.EditIndex = e.NewEditIndex;
        bind();
    }

    protected void gv_ForumData_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gv_ForumData.EditIndex = -1;
        bind();
    }

    protected void gv_ForumData_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        int result = 0;
        ForumClass Forum = new ForumClass();
        GridViewRow row = (GridViewRow)gv_ForumData.Rows[e.RowIndex];
        string Forum_ID = gv_ForumData.DataKeys[e.RowIndex].Value.ToString();
        string Forum_Title = ((TextBox)row.Cells[1].Controls[0]).Text;
        string Forum_Category = ((TextBox)row.Cells[2].Controls[0]).Text;
        //string Forum_Desc = ((TextBox)row.Cells[3].Controls[0]).Text;
        result = Forum.ForumClassUpdate(Forum_ID, Forum_Title, Forum_Category);
        if (result > 0)
        {
            Response.Write("<script>alert('Forum Data updated successfully');</script>");
        }
        else
        {
            Response.Write("<script>alert('Forum Data NOT updated');</script>");
        }
        gv_ForumData.EditIndex = -1;
        bind();
    }

    protected void btn_CreateForum_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Web/Admin/Forum/ForumInsert.aspx");
    }


}