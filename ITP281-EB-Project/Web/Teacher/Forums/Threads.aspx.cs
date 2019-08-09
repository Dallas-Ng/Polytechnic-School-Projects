using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Web_Forums_Threads : System.Web.UI.Page
{
    ThreadClass Thread = new ThreadClass();
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            bind();
        }
    }

    protected void bind()
    {
        List<ThreadClass> ThreadList = new List<ThreadClass>();
        string FID = Request.QueryString["Forum_ID"];
        ThreadList = Thread.RetrieveUrl(FID);
        gv_ThreadData.DataSource = ThreadList;
        gv_ThreadData.DataBind();

    }

    protected void btn_Add_Click(object sender, EventArgs e)
    {
        string FID = Request.QueryString["Forum_ID"];
        ThreadClass Insert = new ThreadClass(tb_ThreadTitle.Text, tb_ThreadDesc.Text, DateTime.Now.ToString(), ddl_ThreadCategory.SelectedItem.Text, FID);
        Insert.ThreadClassInsert(Session["Current_Logged"].ToString());
        bind();
    }

    protected void gv_ThreadData_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridViewRow row = gv_ThreadData.SelectedRow;
        string Thread_ID = row.Cells[0].Text;
        Response.Redirect("~/Web/Teacher/Forums/Thread.aspx?Thread_ID=" + Thread_ID);
    }
}