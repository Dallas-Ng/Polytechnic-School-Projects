using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Web_Invoice : System.Web.UI.Page
{
    TransactionHistoryClass Transaction = new TransactionHistoryClass();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            bind();
        }
    }

    protected void gv_Invoice_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void bind()
    {
        //string TID = Request.QueryString["Transaction_ID"];
        
        //List<TransactionHistoryClass> transactionList = new List<TransactionHistoryClass>();
        //transactionList = Transaction.getSingleTransaction();

        var TransactionHistoryClass = new TransactionHistoryClass();
        string Course_ID = Request.QueryString["Course_ID"];
        var transactionList = TransactionHistoryClass.getSingleTransaction(Course_ID);


        gv_Invoice.DataSource = transactionList;
        gv_Invoice.DataBind();

        //gv_Invoice.DataSource = ShoppingCart.Instance.Items;
        //gv_Invoice.DataBind();

    }

    protected void gv_Invoice_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        int result = 0;
        TransactionHistoryClass transactionObj = new TransactionHistoryClass();
        GridViewRow row = (GridViewRow)gv_Invoice.Rows[e.RowIndex];


        string User_ID = gv_Invoice.DataKeys[e.RowIndex].Value.ToString();
        string courseID = ((TextBox)row.Cells[0].Controls[0]).Text;  //Retrieving data from the textbox and store into variable
        //string email = ((TextBox)row.Cells[2].Controls[0]).Text;
        //string subject = ((TextBox)row.Cells[3].Controls[0]).Text;
        //string message = ((TextBox)row.Cells[4].Controls[0]).Text;
        //string admin_comment = ((TextBox)row.Cells[5].Controls[0]).Text;

        result = transactionObj.TransactionUpdate(User_ID, courseID);
        //public int inquiryUpdate(string pk, string user, string subj, string msg, string email, string admin_comment)

        if (result > 0)
        {
            Response.Write("<script>alert('Product updated successfully');</script>");
            // Response.Write("<script>alert('" + name  + "');</script>");

        }
        else
        {
            Response.Write("<script>alert('Product NOT updated');</script>");
        }
        gv_Invoice.EditIndex = -1;
        bind();
    }

    protected void btn_Back_Click(object sender, EventArgs e)
    {
        Response.Redirect("Dashboard.aspx");
    }
}