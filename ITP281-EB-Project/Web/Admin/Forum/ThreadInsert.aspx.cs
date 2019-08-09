using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Web_Thread_ThreadInsert : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
        string Thread_ID = Request.QueryString["Thread_ID"];
    }

    
    protected void btn_Create_Click(object sender, EventArgs e)
    {
        string Thread_CreationDate = DateTime.Now.ToString();
       
        int result = 0;
        string FID = Request.QueryString["Forum_ID"];
        //string TID = Request.QueryString["Thread_ID"];
        ThreadClass newThread = new ThreadClass(tb_ThreadTitle.Text, tb_ThreadDesc.Text, Thread_CreationDate, ddl_ThreadCategory.SelectedItem.Text, FID);

        result = newThread.ThreadClassInsert();
        
        if (result > 0)
        {
            //string TID = Request.QueryString["Thread_ID"];
            Response.Write("<script>alert('Successful');</script>");
            Response.Redirect("~/Web/Admin/Forum/ThreadView.aspx?Forum_ID=" + FID);
        }
        else
        {
            Response.Write("<script>alert('Not Successful');</script>");

        }
    }

    protected void btn_Back_Click(object sender, EventArgs e)
    {
        string FID = Request.QueryString["Forum_ID"];
        Response.Redirect("~/Web/Admin/Forum/ThreadView.aspx?Forum_ID=" + FID);
    }
}