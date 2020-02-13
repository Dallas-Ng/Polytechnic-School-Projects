using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NYP.DAL;

namespace NYP
{
    public partial class Default : System.Web.UI.Page
    {
        ProgrammesModel prog = new ProgrammesModel();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                bind();
            }
        }

        protected void bind()
        {
            gv_Programmes.DataSource = prog.getProgrammes();
            gv_Programmes.DataBind();
        }

        protected void gv_Programmes_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedRow = gv_Programmes.SelectedIndex;
            GridViewRow row = gv_Programmes.Rows[selectedRow];
            Response.Redirect("~/Registration.aspx?OSEP=" + row.Cells[0].Text);
        }
    }
}