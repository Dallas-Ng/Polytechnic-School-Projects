using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Web_Admin_Account_Payment_Settings : System.Web.UI.Page
{
    PaymentClass Payment = new PaymentClass();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            Reload();
        }
    }


    protected void Reload()
    {
        string Login_ID = Request.QueryString["User"];

        List<PaymentClass> Data = new List<PaymentClass>();

        Data = Payment.getPaymentInfo(Login_ID);

        if (Data.Count > 0)
        {
            tb_Card_Num.Text = "************" + Data[0].Card_Num_Four.ToString();
            tb_Card_Name.Text = Data[0].Card_Name.ToString();
            tb_Card_Exp_date.Text = Data[0].Card_Exp_Date.ToString();
            tb_CCV.Text = "***";
        }
    }


    /// <summary>
    /// Redirects back to View Page
    /// </summary>
    protected void btn_Back_Click(object sender, EventArgs e)
    {
        string Login_ID = Request.QueryString["User"];
        Response.Redirect(String.Format("~/Web/Admin/Account/User.aspx?User={0}", Login_ID));
    }


    /// <summary>
    /// Redirects back to View Page
    /// </summary>
    protected void btn_Home_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Web/Admin/Account/View.aspx");
    }


}