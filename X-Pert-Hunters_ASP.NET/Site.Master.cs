using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace X_Pert_Hunters_Web_Application
{
    public partial class Site : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] != null)
            {
                defaultNav.Visible = false;
                loggedInNav.Visible = true;
                //FindControl("loggedInNav").Visible = true;//I got error here
            }
            else
            {
                defaultNav.Visible = true;
                loggedInNav.Visible = false;
                //Response.Redirect("~/Default.aspx");
            }
        }
        protected void Logout_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("~/Default.aspx");
        }


    }
}