using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Web_Teacher_Settings_Documents : System.Web.UI.Page
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
        string Login_ID = Session["Current_Logged"].ToString();
        List<TeacherClass> Data = Teach.retrieveByLogin(Login_ID);

        string Source = "/Static/_Account/TeacherData/";
        Certification.Attributes["src"] = Source + Data[0].Teacher_ID.ToString() + "_" + Data[0].CertificationUrl.ToString();
        Identification.Attributes["src"] = Source + Data[0].Teacher_ID.ToString() + "_" + Data[0].IdentificationUrl.ToString();
    }
}