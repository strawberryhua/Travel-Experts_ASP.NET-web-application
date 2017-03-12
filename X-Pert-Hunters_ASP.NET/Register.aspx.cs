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
     * Description:allow a new customer to create an account
     * Author:Hua
     * Created Date:Jan 20, 2017
     * Course Code:CPRG214 ASP.NET
     * **********************************/
    public partial class WebForm1 : System.Web.UI.Page
    {
        public Customer customer;//get the customer
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        //add a new record to database
        protected void txtRegister_Click(object sender, EventArgs e)
        {
            customer = new Customer();
            this.PutCustomerData(customer);
            try
            {
                if (CustomerDB.checkUserId(txtUserName.Text))
                {
                    customer.CustomerId = CustomerDB.AddCustomer(customer);
               
                Session["user"] = customer.CustUserID;//assign userId of customer to a session variable
                
               
                Response.Redirect("~/Manage.aspx");
                }
                else
                {
                    lblError.Text = "UserId " + txtUserName.Text + " is already existed!";
                }


            }
            catch (Exception ex)
            {
                lblError.Text = (ex.Message + ex.GetType().ToString());
            }
        }

        //create method to assign data to customer object
        private void PutCustomerData(Customer customer)
        {
            customer.CustFirstName = txtFirstName.Text;
            customer.CustLastName = txtLastName.Text;
            customer.CustAddress = txtAddress.Text;
            customer.CustCity = txtCity.Text;  
            customer.CustProv = txtProv.Text;    
            customer.CustPostal = txtPostal.Text;
            customer.CustCountry = txtCountry.Text;
            customer.CustHomePhone = txtHomePhone.Text;
            customer.CustBusPhone = txtBusPhone.Text;
            customer.CustEmail = txtEmail.Text;
            customer.AgentId = null;
            customer.CustUserID = txtUserName.Text;
            customer.Password = txtPassword.Text;
        }
    }
}