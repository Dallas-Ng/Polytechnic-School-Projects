using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Web_Support_FAQ : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btn_Ask_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Web/Support/Inquiry.aspx");
    }
}