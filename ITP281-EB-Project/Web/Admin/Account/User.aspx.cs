using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Web_Admin_Users_User : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            reload();
        }
    }


    /// <summary>
    /// Function to Reload the Data Pulled
    /// Uses Query String as Primary Key for DB
    /// </summary>
    protected void reload()
    {
        AccountClass Acc = new AccountClass();
        List<AccountClass> UserList = new List<AccountClass>();

        string Login_ID = Request.QueryString["User"];
        UserList = Acc.retrieve(Login_ID);

        if (UserList.Count() == 1)
        {
            tb_Login_ID.Text = UserList[0].Login_ID.ToString();
            tb_Recent_Login.Text = UserList[0].Recent_Login.ToString();
            tb_Creation_Date.Text = UserList[0].Creation_Date.ToString();
            tb_Name.Text = UserList[0].Name.ToString();
            tb_Email.Text = UserList[0].Email.ToString();
            tb_Profile.Text = Acc.ImageRetrieve(UserList[0].Login_ID);

            // Check if date of birth is set
            if (DateTime.Parse(UserList[0].DateofBirth.ToString()) == DateTime.MinValue || UserList[0].DateofBirth.ToString() == "01-Jan-01 12:00:00 AM")
            { // If not set, set it as -
                tb_DateofBirth.Text = " ";
            }
            else
            { // If set, pull out the information and display
                tb_DateofBirth.Text = UserList[0].DateofBirth.ToString().Substring(0, 10);
            }

            string Role = UserList[0].Role.ToString();

            if (Role != "" || Role != null)
            {
                ddl_Role.SelectedValue = Role;
            }

            if (Acc.checkEmailConfirmed(Login_ID))
            {
                tb_Email.Attributes["CssClass"] = ("form-control is-valid");
                valid.Attributes["class"] = ("valid-feedback d-block");
            }
            else
            {
                tb_Email.Attributes["CssClass"] = ("form-control is-invalid");
                invalid.Attributes["class"] = ("invalid-feedback d-block");
            }
            reloadButton();
        }
        else
        {
            // Check View button on GridView Query ID
        }

    }

    protected void reloadButton()
    {
        AccountClass Acc = new AccountClass();
        string Login_ID = Request.QueryString["User"];


        if (Acc.checkisDeleted(Login_ID))
        {
            delete_button.Attributes["class"] = "d-none";
            activate_button.Attributes["class"] = "btn btn-outline-danger d-block";
        }
        else
        {
            activate_button.Attributes["class"] = "d-none";
            delete_button.Attributes["class"] = "btn btn-outline-danger d-block";
        }
    }


    /// <summary>
    /// Takes all variables and updates current Login_ID object in SQL DB
    /// </summary>
    protected void btn_Submit_Click(object sender, EventArgs e)
    {
        DateTime DoB;
        if (tb_DateofBirth.Text != " ")
        {
            DoB = DateTime.Parse(tb_DateofBirth.Text);
        }
        else
        {
            DoB = DateTime.MinValue;
        }

        AccountClass Acc = new AccountClass(tb_Login_ID.Text, null, DateTime.Parse(tb_Recent_Login.Text), DateTime.Parse(tb_Creation_Date.Text), tb_Name.Text, tb_Email.Text, DoB, ddl_Role.SelectedItem.Text);
        int result = Acc.UpdateAll();

        if (result > 0)
        {
            Response.Write("<script>alert('Changes made successfully')</script>");
        }
        else
        {
            Response.Write("<script>alert('Changes NOT made successfully')</script>");
        }

        reload();
    }


    /// <summary>
    /// Redirects back to View Page
    /// </summary>
    protected void btn_Back_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Web/Admin/Account/View.aspx");
    }

    protected void btn_Reactivate_Click(object sender, EventArgs e)
    {
        string Login_ID = Request.QueryString["User"];
        int result = AccountClass.ActivateAccount(Login_ID);

        if (result > 0)
        {
            Response.Write("<script>alert('Account activated')</script>");
            reloadButton();
        }
        else
        {
            Response.Write("<script>alert('Account not activated')</script>");
        }
    }


    /// <summary>
    /// View user's payment settings
    /// </summary>
    protected void btn_Payment_Click(object sender, EventArgs e)
    {
        string Login_ID = Request.QueryString["User"];
        Response.Redirect(String.Format("~/Web/Admin/Account/Payment_Settings.aspx?User={0}", Login_ID));
    }

    protected void btn_Courses_Click(object sender, EventArgs e)
    {
        string Login_ID = Request.QueryString["User"];
        Response.Redirect(String.Format("~/Web/Admin/Account/Courses.aspx?User={0}", Login_ID));
    }

    protected void btn_Delete_Click(object sender, EventArgs e)
    {
        int result = 0;
        AccountClass User = new AccountClass();
        string Login_ID = Request.QueryString["User"];
        result = User.Delete(Login_ID, "logical");

        if (result > 0)
        {
            Response.Write("<script>alert('Deactivated account.');</script>");
            reloadButton();
        }
        else
        {
            Response.Write("<script>alert('Error, please try again.');</script>");
        }
    }
}