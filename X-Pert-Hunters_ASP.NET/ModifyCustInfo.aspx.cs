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
    * Description:allow customer to modify info
    * Author:Hua
    * Created Date:Jan 20, 2017
    * Course Code:CPRG214 ASP.NET
    * **********************************/
    public partial class WebForm3 : System.Web.UI.Page
    {
        public Customer customer;//find customer

        //get customer data from database
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null)
            {
                Response.Redirect("~/Login.aspx");
            }

            if (!IsPostBack)
            {
               
                string custUserId = Session["user"].ToString();//get userId
                
                this.GetCustomer(custUserId);
                 
                //diplay the customer data
                txtCustomerId.Text = customer.CustomerId.ToString();
                txtFirstName.Text = customer.CustFirstName;
                txtLastName.Text = customer.CustLastName;
                txtAddress.Text = customer.CustAddress;
                txtCity.Text = customer.CustCity;
                txtProv.Text = customer.CustProv;
                txtPostal.Text = customer.CustPostal;
                txtCountry.Text = customer.CustCountry;
                txtHomePhone.Text = customer.CustHomePhone;
                txtBusPhone.Text = customer.CustBusPhone;
                if (customer.CustEmail == null)
                {
                    txtEmail.Text = null;
                }
                else//not null
                {
                    txtEmail.Text = customer.CustEmail;
                    
                }

                if (customer.AgentId == null)
                {
                    txtAgent.Text = "";
                }
                else //not null
                {
                    txtAgent.Text = customer.AgentId.ToString();
                }
                txtUserName.Text = customer.CustUserID;
                txtPassword.Text = customer.Password;


            }
            
        }

        //retrieve data from database
        private void GetCustomer(string userId)
        {
            try
            {
                customer = CustomerDB.GetCustomer(userId);//retrieve customer data from database
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message + ex.GetType().ToString(); //dispaly error message
            }
        }

        //create method to assign data to Customer object
        private void PutCustomerData(Customer cust)
        {
            cust.CustomerId = Convert.ToInt32(txtCustomerId.Text);
            cust.CustFirstName = txtFirstName.Text;
            cust.CustLastName = txtLastName.Text;
            cust.CustAddress = txtAddress.Text;
            cust.CustCity = txtCity.Text;
              
            cust.CustProv = txtProv.Text;
                
            cust.CustPostal = txtPostal.Text;
            cust.CustCountry = txtCountry.Text;
            cust.CustHomePhone = txtHomePhone.Text;
           cust.CustBusPhone = txtBusPhone.Text;
            cust.CustEmail = txtEmail.Text;
            if (txtAgent.Text == "")
            {
                cust.AgentId = null;
            }
            else
            {
                cust.AgentId = Convert.ToInt32(txtAgent.Text); 
            }
            cust.CustUserID = txtUserName.Text;
            cust.Password = txtPassword.Text;
        }

        //modify customer info
        protected void btnSave_Click(object sender, EventArgs e)
        {
            
            this.GetCustomer((string)Session["user"]);
            
            Customer newCustomer = new Customer();//customer object
            
            
            this.PutCustomerData(newCustomer);
            
            try
            {
               
                    if (!CustomerDB.UpdateCustomer(newCustomer, customer))
                    {
                        lblError.Text = "Another user has updated or deleted that customer.";


                    }
                    else
                    {
                       
                        lblSuccMessage.Text = "Your account has been successfully updated!";
                        Session["update"] = lblSuccMessage.Text;
                        Session["user"] = txtUserName.Text;
                        Response.Redirect("~/Manage.aspx");
                }
                
                
            }
            catch (Exception ex)
            {
               lblError.Text = ex.Message + ex.GetType().ToString();
            }
        }

        protected void Application_BeginRequest()
        {
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetExpires(DateTime.UtcNow.AddHours(-1));
            Response.Cache.SetNoStore();
        }

        //clean session and Cache to logout
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