using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Web_Admin_Transactions_TransactionHistoryExtract : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            bind();
        }
    }
    protected void gv_Transaction_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void gv_Transaction_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int result = 0;
        TransactionHistoryClass obj = new TransactionHistoryClass();
        string ID = gv_Transaction.DataKeys[e.RowIndex].Value.ToString(); //if successfully inserted or deleted will return 1 
        obj.deleteTransaction(ID);

        if (result > 0)
        {
            Response.Write("<script>alert(' Remove successfully');</script>");
        }
        else
        {
            Response.Write("<script>alert(' Removal NOT successfully');</script>");
        }
        Response.Redirect("~/Web/TransactionHistoryExtract.aspx");
    }


    protected void gv_Transaction_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {


        int result = 0;
        TransactionHistoryClass transactionObj = new TransactionHistoryClass();
        GridViewRow row = (GridViewRow)gv_Transaction.Rows[e.RowIndex];


        string User_ID = gv_Transaction.DataKeys[e.RowIndex].Value.ToString();
        string transactionID = ((TextBox)row.Cells[0].Controls[0]).Text;  //Retrieving data from the textbox and store into variable
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
        gv_Transaction.EditIndex = -1;
        bind();
    }


    protected void bind()
    {
        var TransactionHistoryClass = new TransactionHistoryClass();

        var transactionList = TransactionHistoryClass.getAdminTransactions();


        gv_Transaction.DataSource = transactionList;
        gv_Transaction.DataBind();

    }
    protected void gv_Transaction_RowEditing(object sender, GridViewEditEventArgs e)
    {

        gv_Transaction.EditIndex = e.NewEditIndex;
        bind();

    }


    protected void gv_Transaction_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gv_Transaction.EditIndex = -1;
        bind();
    }



    protected void gv_Transaction_RowUpdated(object sender, GridViewUpdatedEventArgs e)
    {
        //mistake
    }

    //protected void btn_Search_Click(object sender, EventArgs e)
    //{

    //string DBConnect = ConfigurationManager.ConnectionStrings["EBP-Database"].ConnectionString;

    //SqlConnection myConn = new SqlConnection(DBConnect);

    //myConn.Open();

    //SqlCommand sqlCmd = new SqlCommand();

    //string sqlQuery = "SELECT * FROM SupportInquiry WHERE Inq_Subj LIKE '%'+@Inq_Subj+'%' ";
    //sqlCmd.CommandText = sqlQuery;
    //sqlCmd.Connection = myConn;
    //sqlCmd.Parameters.AddWithValue("Inq_Subj", tb_Search.Text);
    //DataTable dt = new DataTable();
    //SqlDataAdapter sda = new SqlDataAdapter(sqlCmd);
    //sda.Fill(dt);
    //gv_Transaction.DataSource = dt;
    //gv_Transaction.DataBind();
    //}

    protected void btn_Reset_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Web/Admin/Dashboard.aspx");
    }
}