using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


using System.Data;
using System.Data.SqlClient;
using System.Configuration;
//Name: TJANDRA PUTRA
//Admin Number : 181110B
public class NotificationClass
{
    string DBConnect = ConfigurationManager.ConnectionStrings["EBP-Database"].ConnectionString;

    private string _Notification_PK;
    private string _Notification_Msg;
    private string _Notification_CreationDate;


    public NotificationClass()
    {
        this._Notification_PK = null;
        this._Notification_Msg = null;
        this._Notification_CreationDate = null;
    }



    public NotificationClass(string aNotification_PK, string aNotificaton_Msg, string aNotification_CreationDate)
    {
        this._Notification_PK = aNotification_PK;
        this._Notification_Msg = aNotificaton_Msg;
        this._Notification_CreationDate = aNotification_CreationDate;
    }

   public string Notification_PK
    {
        get { return _Notification_PK; }
        set { _Notification_PK = value; }
    }

    public string Notification_Msg
    {
        get { return _Notification_Msg; }
        set { _Notification_Msg = value; }
    }
    public string Notification_CreationDate
    {
        get { return _Notification_CreationDate; }
        set { _Notification_CreationDate = value; }
    }





    //To [INSERT] submitted form data from customer to the database NEW ROWS
    public int insertNotification( string notification, string creation_date)
    {

        int result = 0;
        string queryStr = "INSERT INTO Notifications(Notification_Msg, Notification_CreationDate)"
                        + "values (@Notification_Msg, @Notification_CreationDate)";

        using (SqlConnection conn = new SqlConnection(DBConnect))
        {
            conn.Open();
            using (SqlCommand cmd = new SqlCommand(queryStr, conn))
            {
                


                cmd.Parameters.AddWithValue("@Notification_Msg", notification);
              
                cmd.Parameters.AddWithValue("@Notification_CreationDate", DateTime.Parse(creation_date));
                result += cmd.ExecuteNonQuery();
            }
        }
        return result;
    }



    public List<NotificationClass> getNotifications()
    {
        List<NotificationClass> NotiList= new List<NotificationClass>();

        string queryStr = "SELECT * FROM Notifications order by Notification_PK DESC";
        using (SqlConnection conn = new SqlConnection(DBConnect))
        {
            conn.Open();
            using (SqlCommand cmd = new SqlCommand(queryStr, conn))
            {
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    string Notification_PK = dr["Notification_PK"].ToString();
                    string Notification_Msg = dr["Notification_Msg"].ToString();
                    string Notification_CreationDate = dr["Notification_CreationDate"].ToString();




                    NotificationClass a = new NotificationClass(Notification_PK,Notification_Msg,Notification_CreationDate);
                    NotiList.Add(a);
                }
            }

        }


        return NotiList;
    }



    public DataSet notification()
    {
        string DBConnect = ConfigurationManager.ConnectionStrings["EBP-Database"].ConnectionString;
        string queryStr = "SELECT * FROM Notifications order by Notification_PK DESC";
        SqlConnection conn = new SqlConnection(DBConnect);
        SqlCommand cmd = new SqlCommand();
        cmd.CommandText = queryStr;
        cmd.Connection = conn;
        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = cmd;
        DataSet ds = new DataSet();
        da.Fill(ds);

        return ds;
    }



    public int deleteNotification(string id)
    {

        string queryStr = "DELETE FROM Notifications WHERE Notification_PK=@Notification_PK";
        SqlConnection conn = new SqlConnection(DBConnect);
        SqlCommand cmd = new SqlCommand(queryStr, conn);
        cmd.Parameters.AddWithValue("@Notification_PK", id);
        conn.Open();
        int nofRow = 0;
        nofRow = cmd.ExecuteNonQuery();
        conn.Close();
        return nofRow;
    }













}
