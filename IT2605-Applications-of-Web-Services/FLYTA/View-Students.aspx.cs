using FLYTA.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FLYTA
{
    public partial class View_Students : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                bindProgramme();
                bindStudents();
            }
        }

        protected void bindProgramme()
        {
            string OSEP_ID = Request.QueryString["OSEP"];

            ProgrammesModel prog = new ProgrammesModel();
            gv_Programmes.DataSource = prog.getProgramme(OSEP_ID);
            gv_Programmes.DataBind();

        }

        protected void bindStudents()
        {
            string OSEP_ID = Request.QueryString["OSEP"];

            StudentsModel stud = new StudentsModel();
            DataSet ds = stud.getStudents(Convert.ToInt16(OSEP_ID));
            gv_Students.DataSource = ds;
            gv_Students.DataBind();
        }

        protected void btn_Back_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Default.aspx");
        }
    }
}