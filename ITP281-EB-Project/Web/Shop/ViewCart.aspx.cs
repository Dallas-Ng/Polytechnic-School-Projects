using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;

public partial class ViewCart : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadCart();
        }   
    }
    protected void LoadCart()
    {
        //bind the Items inside the Session/ShoppingCart Instance with the Datagrid
        gv_CartView.DataSource = ShoppingCart.Instance.Items;
        gv_CartView.DataBind();
        decimal total = 0.0m;
        foreach (ShoppingCartItems item in ShoppingCart.Instance.Items)
        {
            total = total + item.TotalPrice;
        }
        lbl_TotalPrice.Text = total.ToString();

    }

    protected void gv_CartView_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Remove")
        {
            lbl_Error.Text = "Message : " + e.CommandArgument.ToString();
            string productId = e.CommandArgument.ToString();
            ShoppingCart.Instance.RemoveItem(productId);
            LoadCart();
        }
    }

    protected void btn_Clear_Click(object sender, EventArgs e)
    {
        ShoppingCart.Instance.Items.Clear();
        LoadCart();
    }

    protected void btn_Update_Click(object sender, EventArgs e)
    {
        foreach (GridViewRow row in gv_CartView.Rows)
        {
            if (row.RowType == DataControlRowType.DataRow)
            {
                try
                {
                    string course_ID = gv_CartView.DataKeys[row.RowIndex].Value.ToString();
                    //row.Cells[2] means that the quantity textbox must be in column 3.
                    int unit_Price = int.Parse(((TextBox)row.Cells[3].FindControl("tb_Quantity")).Text);
                    ShoppingCart.Instance.SetItemQuantity(course_ID, unit_Price);
                }
                catch (FormatException e1)
                {
                    lbl_Error.Text = e1.Message.ToString();
                }
            }
        }
        LoadCart();
    }

    protected void btn_Back_Click(object sender, EventArgs e)
    {
        Response.Redirect("Courses.aspx?");
    }

    protected void btn_CheckOut_Click(object sender, EventArgs e)
    {
        DateTime currentdate = DateTime.Now;
        //int Transaction_ID = 0;
        CourseClass course = new CourseClass();
        //string Course_ID = Request.QueryString["Course_ID"];
        //CourseClass data = course.getCourse(Course_ID);

        TransactionHistoryClass OBJ = new TransactionHistoryClass();
        foreach (ShoppingCartItems item in ShoppingCart.Instance.Items)
        {
            CourseAccountClass CAC = new CourseAccountClass();
            CAC.Insert((Session["Current_Logged"].ToString()), item.ItemID);

        }

        foreach (ShoppingCartItems item in ShoppingCart.Instance.Items)
        {
            OBJ.insertTransactionHistory(Session["Current_Logged"].ToString(), item.ItemID, item.Product_Name, item.ItemPrice);
        }

        foreach (ShoppingCartItems item in ShoppingCart.Instance.Items)
        {
            Email.SendInvoice(tb_Email.Text, "Thank you for your purchase of " + item.ItemID + " for " + item.ItemPrice + " on " + currentdate + "." );
        }

        Response.Redirect("Popup.aspx");
        //var TransactionHistoryClass = new TransactionHistoryClass();
        //var transactionList = TransactionHistoryClass.insertTransactionHistory();
    }
}
