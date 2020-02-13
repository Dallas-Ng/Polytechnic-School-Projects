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
    public partial class Default : System.Web.UI.Page
    {
        ProgrammesModel programmes = new ProgrammesModel();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                bind();
            }
        }

        protected void bind()
        {
            gv_Programmes.DataSource = programmes.getAllProgrammes();
            gv_Programmes.DataBind();
        }

        protected void gv_Programmes_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedRow = gv_Programmes.SelectedIndex;
            GridViewRow row = gv_Programmes.Rows[selectedRow];
            Response.Redirect("~/View-Students.aspx?OSEP=" + row.Cells[0].Text);
        }

        protected void btn_Add_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Add-Programme.aspx");
        }

        protected void gv_Programmes_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            bind();
            gv_Programmes.PageIndex = e.NewPageIndex;
            gv_Programmes.DataBind();
        }
    }
}
