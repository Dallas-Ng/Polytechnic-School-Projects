using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class Web_Notification_1 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            bind();
        }
    }

    protected void bind()
    {
        var NotificationClass = new NotificationClass();

        var NotiList = NotificationClass.getNotifications();
        gv_Notification.DataSource = NotiList;
        gv_Notification.DataBind();

    }

    protected void gv_Notification_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gv_Notification.PageIndex = e.NewPageIndex;
        bind();

    }

   


    protected void Timer1_Tick(object sender, EventArgs e)
    {
        Panel1.Visible = true;

        //string DBConnect = ConfigurationManager.ConnectionStrings["DatabaseContext"].ConnectionString;
        //string queryStr = "SELECT * FROM Notifications order by Notification_PK DESC";
        //SqlConnection conn = new SqlConnection(DBConnect);
        //SqlCommand cmd = new SqlCommand();
        //cmd.CommandText = queryStr;
        //cmd.Connection = conn;
        //SqlDataAdapter da = new SqlDataAdapter();
        //da.SelectCommand = cmd;
        DataSet ds = new DataSet();

        var notificationObj = new NotificationClass();
        ds = notificationObj.notification();
        //da.Fill(ds);


        if (ds.Tables[0].Rows.Count > 0)
        {
            lbl_Notification.Text = ds.Tables[0].Rows[0]["Notification_Msg"].ToString();
        }

    }
}