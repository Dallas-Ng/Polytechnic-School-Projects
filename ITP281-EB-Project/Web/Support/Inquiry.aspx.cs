using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Web_Support_Inquiry : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        bind();
    }

    protected void bind()
    { // Dallas
        AccountClass Acc = new AccountClass();
        List<AccountClass> data = Acc.retrieve(Session["Current_Logged"].ToString());
        tb_Email.Text = data[0].Email;
        tb_Name.Text = data[0].Name;
    }

    protected void btn_SendMessage_Click(object sender, EventArgs e)
    {
        int result = 0;

        string Inq_User = tb_Name.Text;
        string Inq_Msg = tb_Message.Text;
        string Inq_Email = tb_Email.Text;
        string Inq_Subj = ddl_Category.SelectedItem.Text;


        string Inq_Comment = null;
        string Inq_PK = null;
        string CreationDate = null;


        if (ddl_Category.SelectedIndex > -1)
        {
            Inq_Subj = ddl_Category.SelectedItem.Text;
        }


        //Save into session to be displayed on thank you form.aspx
        // InquiryClass objSub = new InquiryClass(Inq_User,Inq_Subj,Inq_Msg,CreationDate,Inq_Email,Inq_PK,Inq_Comment);
        //Session["Submission"] = objSub;




        InquiryClass OBJ = new InquiryClass();  //creating new object and calling the function

        OBJ.insertCustomerInquiry(Inq_User, Inq_Subj, tb_Message.Text, tb_Email.Text, DateTime.Now.ToString());

        Response.Redirect("~/Web/Account/Dashboard.aspx");

    }
}