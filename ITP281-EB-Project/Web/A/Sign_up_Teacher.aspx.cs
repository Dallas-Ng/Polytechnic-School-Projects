using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Web_Account_Sign_up_Teacher : System.Web.UI.Page
{
    AccountClass Acc = new AccountClass();

    protected void Page_Load(object sender, EventArgs e)
    {
        //ddl_Cert.Items.Insert(0, "Please Select");
    }


    /// <summary>
    /// When submitted, Create new object and insert
    /// Redirect to page after completed
    /// </summary>
    protected void btn_Submit_Click(object sender, EventArgs e)
    {
        Page.Validate();

        if (Page.IsValid)
        {

            string Remarks = String.Format("{0}", ddl_Cert.SelectedItem.Text);

            if (FUploadCert.HasFile && FUploadIdentity.HasFile)
            { // Checks if both file uploads contain something
                
                TeacherClass Teacher = new TeacherClass(FUploadCert.FileName, FUploadIdentity.FileName, Remarks, tb_Name.Text, tb_Email.Text);
                AccountClass Acc = new AccountClass();

                string Teacher_ID = Teacher.checkEmail(tb_Email.Text); // checks email, allows to be created if email is empty
                if (Teacher_ID == "none" && Acc.checkEmail(tb_Email.Text) == "none") // Checks with current database of accounts
                {
                    int insertCheck = Teacher.InsertTeacher(); // Inserts new teacher into the database
                    if (insertCheck > 0) // if insert successful
                    {
                        // Gets teacher id from email
                        string afterOutputID = Teacher.checkEmail(tb_Email.Text);

                        // Saves documents as [Teacher_ID]*UNDERSCORE*[File_Name]
                        string CertUrl = Server.MapPath("~/Static/_Account/TeacherData") + "//" + afterOutputID + "_" + FUploadCert.FileName;
                        FUploadCert.SaveAs(CertUrl);

                        string IdentityUrl = Server.MapPath("~/Static/_Account/TeacherData") + "//" + afterOutputID + "_" + FUploadIdentity.FileName;
                        FUploadIdentity.SaveAs(IdentityUrl);

                        // Redirect back to home page
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please wait at least 3-5 business day for us to process your application.');window.location ='../../Index.aspx';", true);
                    }
                    else
                    { // If file upload is not successful
                        Response.Write("<script>alert('Upload not successful, please try again.');</script>");
                    }
                }
                else
                { // Email already exists
                    Response.Write("<script>alert('Email already exists, please try a different email or contact our support staff.');</script>");
                }
            }
            else
            { // File upload missing
                Response.Write("<script>alert('Certificate or identity file missing. Please try again.');</script>");
            }
        }
    }


    protected void lbtn_SignIn_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Web/Sign_in.aspx");
    }


    protected void lbtn_Terms_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Web/A/Terms.aspx");
    }
}
