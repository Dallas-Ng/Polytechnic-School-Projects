using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Web_Admin_Teacher_Teacher : System.Web.UI.Page
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
        List<TeacherClass> Data = Teach.retrieve(tID);

        tb_Name.Text = Data[0].Name;
        tb_Email.Text = Data[0].Email;

        string Source = "~/Static/_Account/TeacherData";
        Certification.Attributes["src"] = Source + Data[0].Teacher_ID.ToString() + "_" + Data[0].CertificationUrl.ToString();
        Identification.Attributes["src"] = Source + Data[0].Teacher_ID.ToString() + "_" + Data[0].IdentificationUrl.ToString();
    }


    protected void btn_Courses_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Web/Courses");
    }


    protected void btn_Back_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Web/Admin/Teacher/View.aspx");
    }
}