using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Web_UserTransactionHistory : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            bind();
        }
    }
    protected void gv_UserTransaction_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void gv_UserTransaction_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {


        int result = 0;
        UserTransactionHistory transactionObj = new UserTransactionHistory();
        GridViewRow row = (GridViewRow)gv_UserTransaction.Rows[e.RowIndex];


        string User_ID = gv_UserTransaction.DataKeys[e.RowIndex].Value.ToString();
        string transactionID = ((TextBox)row.Cells[2].Controls[0]).Text;  //Retrieving data from the textbox and store into variable
        //string email = ((TextBox)row.Cells[2].Controls[0]).Text;
        //string subject = ((TextBox)row.Cells[3].Controls[0]).Text;
        //string message = ((TextBox)row.Cells[4].Controls[0]).Text;
        //string admin_comment = ((TextBox)row.Cells[5].Controls[0]).Text;

        result = transactionObj.TransactionUpdate(User_ID, transactionID);
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
        gv_UserTransaction.EditIndex = -1;
        bind();
    }


    protected void bind()
    {
        var UserTransactionHistory = new UserTransactionHistory();

        var transactionList = UserTransactionHistory.getTransactions();


        gv_UserTransaction.DataSource = transactionList;
        gv_UserTransaction.DataBind();

    }
}