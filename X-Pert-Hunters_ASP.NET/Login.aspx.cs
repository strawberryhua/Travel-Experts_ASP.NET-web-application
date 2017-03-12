using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using X_Pert_Hunters_Web_Application.Models;

namespace X_Pert_Hunters_Web_Application
{
    /************************************
     * Description:Create login page
     * Author:Hua
     * Created Date:Jan 20, 2017
     * Course Code:CPRG214 ASP.NET
     * **********************************/
    public partial class WebForm2 : System.Web.UI.Page
    {
        List<TextBox> lt = new List<TextBox>(); //empty list object
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
        //identify login
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            lt.Add(txtUserName);
            lt.Add(txtPassword);
            if(CustomerDB.CheckLogin(lt))
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