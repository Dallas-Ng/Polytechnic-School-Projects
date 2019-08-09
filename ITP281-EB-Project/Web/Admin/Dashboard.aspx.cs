using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Web_Admin_Dashboard : System.Web.UI.Page
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
        NotificationClass noti = new NotificationClass();
        List<NotificationClass> data = noti.getNotifications();
        Re1.DataSource = data.Take(4);
        Re1.DataBind();
    }

    protected void gvUsers_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        reload();
        gvUsers.PageIndex = e.NewPageIndex;
        gvUsers.DataBind();
    }
}