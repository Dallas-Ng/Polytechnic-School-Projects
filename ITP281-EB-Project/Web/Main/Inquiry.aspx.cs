using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Web_Main_Inquiry : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btn_SendMessage_Click(object sender, EventArgs e)
    {

        string Inq_User = tb_Name.Text;
        string Inq_Msg = tb_Message.Text;
        string Inq_Email = tb_Email.Text;
        string Inq_Subj = ddl_Category.SelectedItem.Text;

        InquiryClass OBJ = new InquiryClass();  //creating new object and calling the function

        OBJ.insertCustomerInquiry(Inq_User, Inq_Subj, tb_Message.Text, tb_Email.Text, DateTime.Now.ToString());

        Response.Redirect("~/Index.aspx");
    }
}