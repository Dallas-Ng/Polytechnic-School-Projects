using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Web_Teacher_Settings : System.Web.UI.Page
{
    AccountClass Acc = new AccountClass();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            Reload();
        }
    }

    protected void Reload()
    {
        string Login_ID = Session["Current_Logged"].ToString();

        List<AccountClass> Data = Acc.retrieve(Login_ID);
        tb_Email.Text = Data[0].Email.ToString();
        tb_Name.Text = Data[0].Name.ToString();

        // Check if date of birth is set
        if (DateTime.Parse(Data[0].DateofBirth.ToString()) == DateTime.MinValue || Data[0].DateofBirth.ToString() == "01-Jan-01 12:00:00 AM")
        { // If not set, set it as -
            tb_DateofBirth.Value = " ";
        }
        else
        { // If set, pull out the information and display
            tb_DateofBirth.Value = Data[0].DateofBirth.ToString().Substring(0, 9);
        }
        // Pulls profile picture from user database
        string ImageName = Acc.ImageRetrieve(Login_ID);
        if (ImageName == "Default.png")
        { // If image is default, use this path
            ProfilePicture.Attributes["Src"] = String.Format("../../../Static/_Account/ProfilePictures/{0}", Acc.ImageRetrieve(Login_ID));
        }
        else
        {
            //FileName.InnerText = ImageName;
            ProfilePicture.Attributes["Src"] = String.Format("../../../Static/_Account/ProfilePictures/{0}_{1}", Login_ID, Acc.ImageRetrieve(Login_ID));
        }
    }

    /// <summary>
    /// When submitted, update the user particulars and refresh the page
    /// </summary>
    protected void btn_Submit_Click(object sender, EventArgs e)
    {
        string User = Session["Current_Logged"].ToString();
        DateTime DoB;
        if (tb_DateofBirth.Value != " - ")
        {
            DoB = DateTime.Parse(tb_DateofBirth.Value);
        }
        else
        {
            DoB = DateTime.MinValue;
        }
        AccountClass Acc = new AccountClass(User, null, DateTime.MinValue, DateTime.MinValue, tb_Name.Text, tb_Email.Text, DoB, "");

        int result = Acc.Update();

        if (result > 0)
        {
            string ImageName = Acc.ImageRetrieve(User);
            try
            {
                string PreviousUrl = Server.MapPath("~/Static/_Account/ProfilePictures") + "\\" + User + "_" + ImageName;
                File.Delete(PreviousUrl);
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Error uploading profile picture. Please try again');</script>");
                Console.Write(ex);
            }
            Acc.ImageUpload(FileUpload.FileName, User);
            string ImgUrl = Server.MapPath("~/Static/_Account/ProfilePictures") + "\\" + User + "_" + FileUpload.FileName;
            FileUpload.SaveAs(ImgUrl);

            Response.Write("<script>alert('Settings updated successfully');</script>");
            Reload();
        }
        else
        {
            Response.Write("<script>alert('Profile not successfully updated');</script>");
        }
    }
}