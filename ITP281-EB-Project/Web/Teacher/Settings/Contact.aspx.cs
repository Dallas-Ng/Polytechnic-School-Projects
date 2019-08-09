using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Web_Teacher_Settings_Contact : System.Web.UI.Page
{
    InquiryClass Inq = new InquiryClass();
    AccountClass Acc = new AccountClass();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            reload();
        }
    }

    protected void reload()
    {
        tb_Message.Text = "";
        tb_Subject.Text = "";
    }

    protected void btn_Submit_Click(object sender, EventArgs e)
    {
       
        string Login_ID = Session["Current_Logged"].ToString();
        List<AccountClass> Data = Acc.retrieve(Login_ID);
        
       

        if (Inq.insertCustomerInquiry(Login_ID, tb_Subject.Text, tb_Message.Text, Data[0].Email, DateTime.Now.ToString()) > 0)
        {
            Response.Write("<script>alert('Successfully sent a support ticket to the Admins.');</script>");
        }
        else
        {
            Response.Write("<script>alert('Something went wrong, please try again.');</script>");
        }

    }
}