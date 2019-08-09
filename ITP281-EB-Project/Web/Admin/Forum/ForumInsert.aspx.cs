using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Web_Admin_Forum_ForumInsert : System.Web.UI.Page
{
    protected void btn_Create_Click(object sender, EventArgs e)
    {

        int result = 0;
        ForumClass newForum = new ForumClass(tb_Forum_Title.Text, ddl_ForumCategory.SelectedItem.Text, tb_Forum_Desc.Text);

        result = newForum.ForumInsert();

        if (result > 0)
        {
            Response.Redirect("~/Web/Admin/Forum/ForumView.aspx");
        }
    }

    protected void btn_Back_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Web/Admin/Forum/ForumView.aspx");
    }
}