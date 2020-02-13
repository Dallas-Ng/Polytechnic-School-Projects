using NYP.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NYP
{
    public partial class Registration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

            }
        }

        protected void btn_Back_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Default.aspx");
        }

        protected void btn_Register_Click(object sender, EventArgs e)
        {
            string OSEP_ID = Request.QueryString["OSEP"];

            StudentsModel stud = new StudentsModel();
            ProgrammesModel prog = new ProgrammesModel();

            prog.IncrementSeats(Convert.ToInt32(OSEP_ID));

            int result = stud.InsertStudent(tb_Name.Text, tb_Admin.Text, tb_Course.Text, tb_Contact.Text, tb_PEM.Text, tb_EmergencyPerson.Text, tb_EmergencyContact.Text, OSEP_ID);
            if (result > 0)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Successfully registered.');window.location ='/Default.aspx';", true);
            }
            else
            {
                Response.Write("<script>alert('Failed to register, please try again later.');</script>");
            }
        }
    }
}