using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Web_Forums_Forums : System.Web.UI.Page
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
        Response.Redirect("~/Web/Forums/Threads.aspx?Forum_ID=" + Forum_ID);
    }
}