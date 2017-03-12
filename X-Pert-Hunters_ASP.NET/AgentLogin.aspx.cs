using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using X_Pert_Hunters_Web_Application.Models;

namespace X_Pert_Hunters_ASP.NET
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        List<TextBox> lt = new List<TextBox>();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            lt.Add(txtUserName);
            lt.Add(txtPassword);
            if (CustomerDB.CheckLogin(lt))
            {
                Session["user"] = lt[0].Text;

                Response.Redirect("~/Manage.aspx");//if login successfully, go to Manage page
            }
            else
            {
                lblError.Text = "Invalid user or password";//display error message,if not login properly
            }
        }
    }
}