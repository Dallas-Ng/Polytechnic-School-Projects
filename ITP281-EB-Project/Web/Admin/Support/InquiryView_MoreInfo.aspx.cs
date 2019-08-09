using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Net.Mail;
public partial class Web_Admin_Support_InquiryView_MoreInfo : System.Web.UI.Page
{
    InquiryClass obj = new InquiryClass();
    protected void Page_Load(object sender, EventArgs e)
    {
        tb_From.Text = "CertcessEducation@gmail.com";
        // tb_Subject.Text = "Thank you for your Inquiry";

        if (!IsPostBack)
        {
            bind();
        }

    }

    protected void bind()
    {
        string Inq_PK = Request.QueryString["InqPK"];
        List<InquiryClass> InqList = new List<InquiryClass>();
        InqList = obj.getSingleInquiry(Inq_PK);


        tb_PK.Text = Inq_PK;
        tb_Email.Text = InqList[0].Inq_Email.ToString();
        tb_Msg.Text = InqList[0].Inq_Msg.ToString();
    }


    protected void btn_Back_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Web/Admin/Support/InquiryView.aspx");

    }

    protected void btn_Send_Click1(object sender, EventArgs e)
    {
        EmailClass.SendInquiry(tb_Email.Text, tb_Body.Text, tb_Subject.Text);
        Response.Redirect("~/Web/Admin/Support/InquiryView.aspx");
    }
}