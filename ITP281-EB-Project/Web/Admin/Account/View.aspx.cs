using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

public partial class Web_Admin_Users_View : System.Web.UI.Page
{
    AccountClass Acc = new AccountClass();


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
        string filter = null;
        string sort = null;

        if (Request.QueryString["filter"] != null)
        {
            filter = Request.QueryString["filter"].ToString();
            RoleFilter.Text = filter;
            if (filter == "Deleted")
            {
                HeaderText.Text = "Deleted";
                RoleFilter.Text = "None";
            }
        }
        if (Request.QueryString["sort"] != null)
        { 
            sort = Request.QueryString["sort"].ToString();
            SortFilter.Text = sort;
        }

        if (filter != null)
        {
            filter = String.Format("'{0}'", filter.ToLower());
        }
        if (sort != null)
        {
            sort = String.Format("'{0}'", sort.ToLower());
        }

        List<AccountClass> UserList = Acc.retrieveAdmin(filter, sort);
        gvUsers.DataSource = UserList;
        gvUsers.DataBind();
    }


    /// <summary>
    /// When selected, take login_id from row
    /// Put it into query string and redirect
    /// </summary>
    protected void gvUsers_SelectedIndexChanged(object sender, EventArgs e)
    {
        reload();

        GridViewRow row = gvUsers.SelectedRow;
        string Login_ID = row.Cells[1].Text;

        Response.Redirect("~/Web/Admin/Account/User.aspx?User=" + Login_ID);
    }

    protected void btn_Add_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Web/Admin/Account/Add.aspx");
    }

    protected void gvUsers_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        reload();
        gvUsers.PageIndex = e.NewPageIndex;
        gvUsers.DataBind();
    }

    protected void btn_Search_Click(object sender, EventArgs e)
    {

        List<AccountClass> UserList = Acc.searchQuery(tb_Search.Text);
        gvUsers.DataSource = UserList;
        gvUsers.DataBind();
    }

    protected void btn_Reset_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Web/Admin/Account/View.aspx");
    }

    protected void btn_Deleted_Click(object sender, EventArgs e)
    {
        if (Request.QueryString["sort"] != null)
        {
            Response.Redirect("~/Web/Admin/Account/View.aspx?filter=Deleted&sort=" + Request.QueryString["sort"].ToString());
        }
        Response.Redirect("~/Web/Admin/Account/View.aspx?filter=Deleted");
    }

    protected void filterStudent(object sender, EventArgs e)
    {
        if (Request.QueryString["sort"] != null)
        {
            Response.Redirect("~/Web/Admin/Account/View.aspx?filter=Student&sort=" + Request.QueryString["sort"].ToString());
        }
        Response.Redirect("~/Web/Admin/Account/View.aspx?filter=Student");
    }

    protected void filterTeacher(object sender, EventArgs e)
    {
        if (Request.QueryString["sort"] != null)
        {
            Response.Redirect("~/Web/Admin/Account/View.aspx?filter=Teacher&sort=" + Request.QueryString["sort"].ToString());
        }
        Response.Redirect("~/Web/Admin/Account/View.aspx?filter=Teacher");
    }

    protected void filterAdmin(object sender, EventArgs e)
    {
        if (Request.QueryString["sort"] != null)
        {
            Response.Redirect("~/Web/Admin/Account/View.aspx?filter=admin&sort=" + Request.QueryString["sort"].ToString());
        }
        Response.Redirect("~/Web/Admin/Account/View.aspx?filter=Admin");
    }

    protected void sortLoginID(object sender, EventArgs e)
    {
        if (Request.QueryString["filter"] != null)
        {
            Response.Redirect("~/Web/Admin/Account/View.aspx?sort=Login_ID&filter=" + Request.QueryString["filter"].ToString());
        }
        Response.Redirect("~/Web/Admin/Account/View.aspx?sort=Login_ID");
    }

    protected void sortName(object sender, EventArgs e)
    {
        if (Request.QueryString["filter"] != null)
        {
            Response.Redirect("~/Web/Admin/Account/View.aspx?sort=Name&filter=" + Request.QueryString["filter"].ToString());
        }
        Response.Redirect("~/Web/Admin/Account/View.aspx?sort=Name");
    }
}


