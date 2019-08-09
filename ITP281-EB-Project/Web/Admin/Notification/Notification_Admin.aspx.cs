using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

using Twilio;
using Twilio.Rest.Api.V2010.Account;


//Name: TJANDRA PUTRA
//Admin Number : 181110B

public partial class Web_Admin_Support_Notification_Admin_NEW : System.Web.UI.Page
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

        tb_Notification.Text = "";

    }



    protected void btn_Send_Click(object sender, EventArgs e)
    {
        // string DBConnect = ConfigurationManager.ConnectionStrings["DatabaseContext"].ConnectionString;
        // string queryStr = "INSERT INTO Notifications(Notification_Msg) VALUES('" + tb_Notification.Text + "')";
        // SqlConnection conn = new SqlConnection(DBConnect);
        // conn.Open();
        // SqlCommand cmd = new SqlCommand();
        // cmd.CommandText = queryStr;
        // cmd.Connection = conn;
        // cmd.ExecuteNonQuery();
        //// lbl_Notification.Text = "Notification Sent!";
        // tb_Notification.Text = "";


        //SMS sending Twillio

        const string accountSid = "AC9" + "3804d3fbbb" + "be60a24" + "ef1c023fb" + "b929b";
        const string authToken = "05adf596" + "e9ee51" + "969e4b6" + "6495f41a964"; //pasword key

        TwilioClient.Init(accountSid, authToken);

        //Twilio APIs now requires TLS v1.2 and string cipher suites. 
        System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls
                                                | System.Net.SecurityProtocolType.Tls11
                                                | System.Net.SecurityProtocolType.Tls12
                                                | System.Net.SecurityProtocolType.Ssl3;


        var message = MessageResource.Create(
            body: tb_Notification.Text,
            from: new Twilio.Types.PhoneNumber("+12055576459"),
            to: new Twilio.Types.PhoneNumber("+6591438726")
        );



        string Notification_Msg = tb_Notification.Text;


        NotificationClass OBJ = new NotificationClass();  //creating new object and calling the function

        OBJ.insertNotification(tb_Notification.Text, DateTime.Now.ToString());

        bind();

    }

    protected void gv_Notification_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gv_Notification.PageIndex = e.NewPageIndex;
        bind();

    }

    protected void gv_Notification_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int result = 0;
        NotificationClass obj = new NotificationClass(); //creating instance of the class
        string ID = gv_Notification.DataKeys[e.RowIndex].Value.ToString();//if successfully inserted or deleted will return 1 
        obj.deleteNotification(ID);

        if (result > 0)
        {
            Response.Write("<script>alert(' Remove successfully');</script>");
        }
        else
        {
            Response.Write("<script>alert(' Removal NOT successfully');</script>");
        }
        Response.Redirect("~/Web/Admin/Notification/Notification_Admin.aspx");
    }
}