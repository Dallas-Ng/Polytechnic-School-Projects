using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Web_Admin_Account_Lockout_System : System.Web.UI.Page
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
        string filter = null;
        string sort = null;

        if (Request.QueryString["filter"] != null)
        {
            filter = Request.QueryString["filter"].ToString();
            RoleFilter.Text = filter;
            if (filter == "Deleted")
            {
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

        AccountClass Acc = new AccountClass();
        List<AccountClass> data = Acc.retrieveLockoutInformation(filter, sort);
        gvLockout.DataSource = data;
        gvLockout.DataBind();
    }

    protected void gvLockout_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        reload();
        gvLockout.PageIndex = e.NewPageIndex;
        gvLockout.DataBind();
    }

    protected void gvLockout_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void btn_Search_Click(object sender, EventArgs e)
    {
        AccountClass Acc = new AccountClass();
        List<AccountClass> data = Acc.searchQueryLockoutInformation(tb_Search.Text);
        gvLockout.DataSource = data;
        gvLockout.DataBind();
    }

    protected void btn_Reset_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Web/Admin/Account/Lockout_System.aspx");
    }

    protected void btn_Deleted_Click(object sender, EventArgs e)
    {
        if (Request.QueryString["sort"] != null)
        {
            Response.Redirect("~/Web/Admin/Account/Lockout_System.aspx?filter=Deleted&sort=" + Request.QueryString["sort"].ToString());
        }
        Response.Redirect("~/Web/Admin/Account/Lockout_System.aspx?filter=Deleted");
    }

    protected void filterStudent(object sender, EventArgs e)
    {
        if (Request.QueryString["sort"] != null)
        {
            Response.Redirect("~/Web/Admin/Account/Lockout_System.aspx?filter=Student&sort=" + Request.QueryString["sort"].ToString());
        }
        Response.Redirect("~/Web/Admin/Account/Lockout_System.aspx?filter=Student");
    }

    protected void filterTeacher(object sender, EventArgs e)
    {
        if (Request.QueryString["sort"] != null)
        {
            Response.Redirect("~/Web/Admin/Account/Lockout_System.aspx?filter=Teacher&sort=" + Request.QueryString["sort"].ToString());
        }
        Response.Redirect("~/Web/Admin/Account/Lockout_System.aspx?filter=Teacher");
    }

    protected void filterAdmin(object sender, EventArgs e)
    {
        if (Request.QueryString["sort"] != null)
        {
            Response.Redirect("~/Web/Admin/Account/Lockout_System.aspx?filter=admin&sort=" + Request.QueryString["sort"].ToString());
        }
        Response.Redirect("~/Web/Admin/Account/Lockout_System.aspx?filter=Admin");
    }

    protected void sortLoginID(object sender, EventArgs e)
    {
        if (Request.QueryString["filter"] != null)
        {
            Response.Redirect("~/Web/Admin/Account/Lockout_System.aspx?sort=Login_ID&filter=" + Request.QueryString["filter"].ToString());
        }
        Response.Redirect("~/Web/Admin/Account/Lockout_System.aspx?sort=Login_ID");
    }

    protected void sortName(object sender, EventArgs e)
    {
        if (Request.QueryString["filter"] != null)
        {
            Response.Redirect("~/Web/Admin/Account/Lockout_System.aspx?sort=Name&filter=" + Request.QueryString["filter"].ToString());
        }
        Response.Redirect("~/Web/Admin/Account/Lockout_System.aspx?sort=Name");
    }
}