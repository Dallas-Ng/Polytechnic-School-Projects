using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Web_Admin_Account_Add : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btn_Submit_Click(object sender, EventArgs e)
    {
        DateTime Creation_Date = DateTime.Now;
        DateTime DoB;
        if (tb_DateofBirth.Value != "")
        {
            DoB = DateTime.Parse(tb_DateofBirth.Value);
        }
        else
        {
            DoB = DateTime.MinValue;

        }
        AccountClass Acc = new AccountClass(tb_Login_ID.Text, tb_Confirm.Text, DateTime.MinValue, Creation_Date, tb_Name.Text, tb_Email.Text, DoB, ddl_Role.SelectedItem.Text);

        int result = Acc.InsertAll();
        if (result > 0)
        {
            Response.Write("<script>alert('Changes made successfully')</script>");
            Response.Redirect(String.Format("~/Web/Admin/User?User={0}", tb_Login_ID.Text));
        }
        else
        {
            Response.Write("<script>alert('Changes NOT made successfully')</script>");
        }
    }


    /// <summary>
    /// Redirects back to View Page
    /// </summary>
    protected void btn_Back_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Web/Admin/Account/View.aspx");
    }
}