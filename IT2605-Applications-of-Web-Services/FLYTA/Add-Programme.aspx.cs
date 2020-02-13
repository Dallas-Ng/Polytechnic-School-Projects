using FLYTA.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FLYTA
{
    public partial class Add_Programme : System.Web.UI.Page
    {
        ProgrammesModel prog = new ProgrammesModel();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_Create_Click(object sender, EventArgs e)
        {
            int result = prog.InsertProgramme(tb_Title.Text, tb_Description.Text, tb_Duration.Text, ddl_Type.SelectedValue.ToString(), Convert.ToInt16(tb_Quota.Text), 0, Convert.ToInt16(tb_Fees.Text));

            if (result > 0)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Successfully created programme.');window.location ='/Default.aspx';", true);
            }
            else
            {
                Response.Write("<script>alert('Failed to create programme, please try again later.');</script>");
            }
        }

        protected void btn_Back_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Default.aspx");
        }
    }
}