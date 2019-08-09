using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Web_Admin_Users_View : System.Web.UI.Page
{
    TeacherClass Teach = new TeacherClass();


    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            reload();
        }
    }

    /// <summary>
    /// Reloads data pulled out
    /// </summary>
    protected void reload()
    {
        string listToPull = Request.QueryString["list"];

        if (listToPull == "verified")
        {
            lbl_Title.Text = "Verified Teachers";
        }
        else if (listToPull == "not_verified")
        {
            lbl_Title.Text = "Teacher Applications";
        }
        else
        {
            lbl_Title.Text = "Viewing All";
            listToPull = "all";
        }

        // For all teachers
        List<TeacherClass> TeacherList = Teach.retrieve(listToPull);
        gvTeachers.DataSource = TeacherList;
        gvTeachers.DataBind();
    }


    /// <summary>
    /// When selected, take login_id from row
    /// Put it into query string and redirect
    /// </summary>
    protected void gvTeachers_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridViewRow row = gvTeachers.SelectedRow;
        string Teacher_ID = row.Cells[0].Text;

        Response.Redirect("~/Web/Admin/Teacher/Application.aspx?tid=" + Teacher_ID);
    }


    protected void gvTeachers_RowCommand(object sender, GridViewCommandEventArgs e)
    {

    }

    protected void btn_Search_Click(object sender, EventArgs e)
    {

        List<TeacherClass> UserList = Teach.searchQuery(tb_Search.Text);
        gvTeachers.DataSource = UserList;
        gvTeachers.DataBind();
    }

    protected void btn_Reset_Click(object sender, EventArgs e)
    {
        reload();
        tb_Search.Text = "";
    }
}