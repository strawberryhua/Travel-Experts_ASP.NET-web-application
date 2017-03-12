using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace X_Pert_Hunters_Web_Application
{
    /************************************
    * Description:manage page
    * Author:Hua
    * Created Date:Jan 20, 2017
    * Course Code:CPRG214 ASP.NET
    * **********************************/
    public partial class WebForm6 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["user"] != null)
            {
                lblUser.Text = "Welcome " + Session["user"].ToString() + "!"; //welcome banner
            }
            else
            {
                Response.Redirect("~/Default.aspx");
            }
            if(Session["update"] != null)
            {
                lblUpdate.Text = Session["update"].ToString();
              
            }
            
        }

        //Clean Session and Cache to logout
        protected void Logout_Click(object sender, EventArgs e)
        {
            Session.RemoveAll();
            Response.Redirect("~/Default.aspx");
            foreach (System.Collections.DictionaryEntry entry in HttpContext.Current.Cache)
            {
                HttpContext.Current.Cache.Remove((string)entry.Key);
            }
        }


    }
}