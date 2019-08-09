using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Web_Account_Settings_Payment : System.Web.UI.Page
{
    bool hasData = false;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            reload();
        }
    }


    protected void reload()
    {
        PaymentClass Payment = new PaymentClass();
        List<PaymentClass> Data = new List<PaymentClass>();

        string Login_ID = Session["Current_Logged"].ToString();
        Data = Payment.getPaymentInfo(Login_ID);

        if (Data.Count > 0)
        {
            tb_Card_Num.Text = "************" + Data[0].Card_Num_Four.ToString();
            tb_Card_Name.Text = Data[0].Card_Name.ToString();
            ddl_month.SelectedIndex = ddl_month.Items.IndexOf(ddl_month.Items.FindByValue(Data[0].Card_Exp_Date.ToString().Substring(0, 2)));
            ddl_year.SelectedIndex = ddl_year.Items.IndexOf(ddl_year.Items.FindByValue(Data[0].Card_Exp_Date.ToString().Substring(2, 2)));
            tb_CCV.Text = "***";
            hasData = true;
        }
        else
        {
            hasData = false;
            ddl_month.Items.Insert(0, "-");
            ddl_year.Items.Insert(0, "-");
        }

    }


    /// <summary>
    /// When submitted, insert payment object in DB
    /// </summary>
    protected void btn_Submit_Click(object sender, EventArgs e)
    {
        string Exp_Date = ddl_month.Value + ddl_year.Value;
        string Login_ID = Session["Current_Logged"].ToString();

        PaymentClass Payment = new PaymentClass(tb_Card_Num.Text, tb_Card_Num.Text.Substring(12, 4), tb_Card_Name.Text, Exp_Date, tb_CCV.Text, Login_ID);

        List<PaymentClass> Data = Payment.getPaymentInfo(Login_ID);
        if (!Data.Any())
        {
            int result = Payment.Insert();
            if (result > 0)
            {
                Response.Write("<script>alert('Added Card Successful')</script>");
            }
            else
            {
                Response.Write("<script>alert('Card not successfully Added');</script>");
            }
        }
        else
        {
            int result = Payment.Update(tb_Card_Num.Text, tb_Card_Num.Text.Substring(12, 4), tb_Card_Name.Text, Exp_Date, tb_CCV.Text, Login_ID);
            if (result > 0)
            {
                Response.Write("<script>alert('Updated Card Settings Successful')</script>");
            }
            else
            {
                Response.Write("<script>alert('Card not successfully updated');</script>");
            }
        }
        reload();
    }
}