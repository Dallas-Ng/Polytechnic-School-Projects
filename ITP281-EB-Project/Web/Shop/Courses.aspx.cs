using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Web_Shop_Courses : System.Web.UI.Page
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
        CourseClass course = new CourseClass();
        List<CourseClass> Courses = course.getCoursesFilter("none", Session["Current_logged"].ToString());

        if (Request.QueryString["filter"] != null || Request.QueryString["filter"] != "" || Request.QueryString["filter"] != " ")
        {
            string filter = Request.QueryString["filter"];
            Courses = course.getCoursesFilter(filter, Session["Current_logged"].ToString());
        }

        Re1.DataSource = Courses;
        Re1.DataBind();
    }


    protected void Btn_Add_Click(object sender, EventArgs e)
    {
        LinkButton btn = (LinkButton)sender;
        CourseClass course = new CourseClass();
        CourseClass aCourse = course.getCourse(btn.CommandArgument.ToString());
        ShoppingCart.Instance.AddItem(btn.CommandArgument.ToString(), aCourse);
        Response.Write("<script>alert('Added to cart!')</script>");
    }

    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Web/Shop/Courses.aspx?filter=price_asce");
    }

    protected void LinkButton3_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Web/Shop/Courses.aspx?filter=price_desc");
    }

    protected void btn_Reset_Filter_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Web/Shop/Courses.aspx?filter=none");
    }

    protected void btn_Cart_Click(object sender, EventArgs e)
    {
        CourseClass course = new CourseClass();
        string Course_ID = Request.QueryString["Course_ID"];
        Response.Redirect("~/Web/Shop/ViewCart.aspx?Course_ID=" + Course_ID);
    }
}