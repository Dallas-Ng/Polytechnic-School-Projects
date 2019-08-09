using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Web_Teacher_Courses_Courses : System.Web.UI.Page
{
    CourseClass aCourse = new CourseClass();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            bind();
        }
    }

    protected void bind()
    {
        List<CourseClass> CourseList = new List<CourseClass>();
        CourseList = aCourse.getCoursesbyAuthor(Session["Current_Logged"].ToString());
        gvCourse.DataSource = CourseList;
        gvCourse.DataBind();
    }

    protected void gvCourse_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridViewRow row = gvCourse.SelectedRow;
        string CourseID = row.Cells[0].Text;

        Response.Redirect("~/Web/Teacher/Courses/CoursesView.aspx?Course_ID=" + CourseID);
    }

    protected void gvCourse_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int result = 0;
        CourseClass course = new CourseClass();


        string categoryID = gvCourse.DataKeys[e.RowIndex].Value.ToString();


        result = course.CourseDelete(categoryID);

        if (result > 0)
        {
            Response.Write("<script>alert('Course Remove successfully');</script>");
        }
        else
        {
            Response.Write("<script>alert('Course Removal NOT successfully');</script>");
        }

        Response.Redirect("~/Web/Teacher/Courses/Courses.aspx");


    }

    protected void gvCourse_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gvCourse.EditIndex = e.NewEditIndex;
        bind();
    }

    protected void gvCourse_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gvCourse.EditIndex = -1;
        bind();
    }

    protected void gvCourse_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        CourseClass course = new CourseClass();
        GridViewRow row = (GridViewRow)gvCourse.Rows[e.RowIndex];

        string cTitle = ((TextBox)row.Cells[1].Controls[0]).Text;

    }


    protected void gvCourse_RowCommand(object sender, GridViewCommandEventArgs e)
    {

    }

    protected void btn_AddCourse_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Web/Teacher/Courses/CoursesInsert.aspx");
    }


    protected void gvCourse_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvCourse.PageIndex = e.NewPageIndex;
        bind();
    }
    protected void btn_Search_Click(object sender, EventArgs e)
    {
        DataTable dt = new DataTable();
        var CourseClassOj = new CourseClass();
        dt = CourseClassOj.SearchCoursesFilterByAuthor(tb_Search.Text, Session["Current_Logged"].ToString());
        gvCourse.DataSource = dt;
        gvCourse.DataBind();
    }

    protected void btn_Reset_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Web/Teacher/Courses/Courses.aspx");
    }
}