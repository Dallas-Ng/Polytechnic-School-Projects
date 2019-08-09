using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


using System.Data.SqlClient;
using System.Data;
using System.Configuration;


//Name: TJANDRA PUTRA
//Admin Number : 181110B


public partial class Web_Admin_Support_InquiryView : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            bind();
        }

        if (!Page.IsPostBack)
        {


            ddl_Subj.Items.Insert(0, new ListItem("All", "All"));

        }


    }



    protected void gv_Category_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int result = 0;
        InquiryClass obj = new InquiryClass(); //creating instance of the class
        string ID = gv_Category.DataKeys[e.RowIndex].Value.ToString();//if successfully inserted or deleted will return 1 
        obj.deleteCustomerInquiry(ID);

        if (result > 0)
        {
            Response.Write("<script>alert(' Remove successfully');</script>");
        }
        else
        {
            Response.Write("<script>alert(' Removal NOT successfully');</script>");
        }
        Response.Redirect("~/Web/Admin/Support/InquiryView.aspx");
    }


    protected void gv_Category_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {  

        int result = 0;
        InquiryClass inquiryObj = new InquiryClass();
        GridViewRow row = (GridViewRow)gv_Category.Rows[e.RowIndex];


        string pk = gv_Category.DataKeys[e.RowIndex].Value.ToString();
       // string name = ((TextBox)row.Cells[1].Controls[0]).Text;  //Retrieving data from the textbox and store into variable
        //string email = ((TextBox)row.Cells[2].Controls[0]).Text;
        //string subject = ((TextBox)row.Cells[3].Controls[0]).Text;
        //string message = ((TextBox)row.Cells[4].Controls[0]).Text;
        
        string admin_comment = ((TextBox)row.Cells[3].Controls[0]).Text;

        result = inquiryObj.inquiryUpdate(pk,admin_comment);
            //public int inquiryUpdate(string pk, string user, string subj, string msg, string email, string admin_comment)

        if (result > 0)
        {
            Response.Write("<script>alert('Changes Saved!');</script>");
            // Response.Write("<script>alert('" + name  + "');</script>");

        }
        else
        {
            Response.Write("<script>alert('Product NOT updated');</script>");
        }
        gv_Category.EditIndex = -1;
        bind();
    }


    protected void bind()
    {
        var InquiryClass = new InquiryClass();

        var InqList = InquiryClass.getInquiries();
        gv_Category.DataSource = InqList;
        gv_Category.DataBind();

    }
    protected void gv_Category_RowEditing(object sender, GridViewEditEventArgs e)
    {

        gv_Category.EditIndex = e.NewEditIndex;
        bind();

    }


    protected void gv_Category_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gv_Category.EditIndex = -1;
        bind();
    }



    protected void gv_Category_RowUpdated(object sender, GridViewUpdatedEventArgs e)
    {
        //mistake
    }




    // SEARCHING FOR NAMES
    protected void btn_Search_Click(object sender, EventArgs e)
    {

        //string DBConnect = ConfigurationManager.ConnectionStrings["EBP-DATABASE"].ConnectionString;

        //SqlConnection myConn = new SqlConnection(DBConnect);

        //myConn.Open();

        //SqlCommand sqlCmd = new SqlCommand();

        //string sqlQuery = "SELECT * FROM SupportInquiry WHERE Inq_User LIKE '%'+@Inq_User+'%' ";
        //sqlCmd.CommandText = sqlQuery;
        //sqlCmd.Connection = myConn;
        //sqlCmd.Parameters.AddWithValue("Inq_User", tb_Search.Text);
        //DataTable dt = new DataTable();
        //SqlDataAdapter sda = new SqlDataAdapter(sqlCmd);
        //sda.Fill(dt);
        //gv_Category.DataSource = dt;
        //gv_Category.DataBind();

        DataTable dt = new DataTable();

        var inquiryClassOj = new InquiryClass();
        dt = inquiryClassOj.Search(tb_Search.Text);


        gv_Category.DataSource = dt;
        gv_Category.DataBind();
    }

    protected void btn_Reset_Click(object sender, EventArgs e)
    {
        Response.Redirect("InquiryView.aspx");
    }

    //protected void btn_Archived_Click(object sender, EventArgs e)
    //{
    //    //if (Request.QueryString["sort"] != null)
    //    //{
    //    //    Response.Redirect("~/Web/Admin/Support/InquiryView.aspx?filter=Deleted&sort=" + Request.QueryString["sort"].ToString());
    //    //}
    //    //Response.Redirect("~/Web/Admin/Account/InquiryView.aspx?filter=Deleted");
    //}


    protected void gv_Category_SelectedIndexChanged(object sender, EventArgs e)
    {
       GridViewRow row = gv_Category.SelectedRow;
       string Inq_PK = row.Cells[0].Text;
 

       Response.Redirect("~/Web/Admin/Support/InquiryView_MoreInfo.aspx?InqPK=" + Inq_PK);
        //esponse.Redirect("~/Web/Admin/Course/CourseView.aspx?Course_ID=" + CourseID);
    }



    protected void gv_Category_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gv_Category.PageIndex = e.NewPageIndex;
        bind();

    }




    protected void ddl_Subj_SelectedIndexChanged(object sender, EventArgs e)
    {

        DataTable dt = new DataTable();
        var inquiryObj = new InquiryClass();
        dt = inquiryObj.filterInquiry(ddl_Subj.SelectedItem.Text);
        gv_Category.DataSource = dt;
        gv_Category.DataBind();





    }

}
