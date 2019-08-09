using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;


public partial class Web_Admin_Teacher_Application : System.Web.UI.Page
{
    TeacherClass Teach = new TeacherClass();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            reload();
        }
    }


    protected void reload()
    {
        string tID = Request.QueryString["tid"].ToString();
        if (tID == null || tID == "")
        {
            tID = "all";
        }
        List<TeacherClass> Data = Teach.retrieve(tID);

        tb_Name.Text = Data[0].Name;
        tb_Email.Text = Data[0].Email;
        tb_Login_ID_Text.Text = Data[0].Login_ID;
        if (Data[0].Login_ID != null && Data[0].Login_ID != " " && Data[0].Login_ID != "")
        {
            Title.Text = "Teacher";
            modal.Attributes["class"] += " d-none";
        }

        DateTime data_date = DateTime.Parse(Data[0].Creation_Date.ToString());
        TimeSpan span = DateTime.Now.Subtract(data_date);

        string days = String.Format("  (Created {0} days, {1} hours ago)", span.Days, span.Hours);
        tb_Creation_Date.Text = Data[0].Creation_Date.ToString() + days;

        string Source = "/Static/_Account/TeacherData/";
        Certification.Attributes["src"] = Source + Data[0].Teacher_ID.ToString() + "_" + Data[0].CertificationUrl.ToString();
        Identification.Attributes["src"] = Source + Data[0].Teacher_ID.ToString() + "_" + Data[0].IdentificationUrl.ToString();

    }

    protected void btn_Back_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Web/Admin/Teacher/View.aspx");
    }

    protected void btn_Submit_Click(object sender, EventArgs e)
    {
        string tID = Request.QueryString["tid"].ToString();

        Page.Validate();
        if (Page.IsValid)
        { // Page is valid
            string generatedPassword = HasherClass.GenerateToken();

            AccountClass Acc = new AccountClass(tb_Login_ID.Text, generatedPassword, tb_Email.Text, "Teacher");

            List<AccountClass> Data = Acc.retrieve(tb_Login_ID.Text);
            List<TeacherClass> TData = Teach.retrieve(tID);

            if (!String.IsNullOrEmpty(TData[0].Teacher_ID)) // If teacher data is empty
            {
                if (Acc.checkEmail(tb_Email.Text) == "none" && !Data.Any())// Checks and validates if the user has been created before.
                {
                    if (Acc.Insert() > 0) // If insert is sucessful
                    {
                        if (Teach.updateLogin(tID, tb_Login_ID.Text) > 0)
                        {
                            if (EmailClass.sendApplication(tb_Email.Text, tb_Login_ID.Text, generatedPassword) > 0)
                            {
                                System.IO.File.Copy(HttpContext.Current.Server.MapPath("~/Static/_Account/ProfilePictures/Default.png"), HttpContext.Current.Server.MapPath(String.Format("~/Static/_Account/ProfilePictures/{0}_Default.png", tb_Login_ID.Text)));
                                Response.Write("<script>alert('Successfully created account.');</script>");
                                reload();
                            }
                            else
                            {
                                Response.Write("<script>alert('Error, email service unavailable.');</script>");
                            }
                        }
                        else
                        {
                            Response.Write("<script>alert('Not successful, unable to update login id of teacher.');</script>");
                        }
                    }
                    else
                    {
                        Response.Write("<script>alert('Not sucessful, please try again.');</script>");
                    }
                }
                else
                {
                    Response.Write("<script>alert('Login ID or Email already exists.');</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('Account already exists. Unable to create teacher's account.');</script>");
            }

        }
    }
}