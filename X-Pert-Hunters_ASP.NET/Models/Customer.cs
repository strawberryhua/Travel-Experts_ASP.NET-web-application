using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace X_Pert_Hunters_Web_Application.Models
{
    /************************************
     * Description:Define Customer class
     * Author:Hua
     * Created Date:Jan 20, 2017
     * Course Code:CPRG214 ASP.NET
     * **********************************/
    [Serializable]
    public class Customer
    {

        public Customer() { }

        //define public properties
        public int CustomerId { get; set; }
        public string CustFirstName { get; set; }
        public string CustLastName { get; set; }
        public string CustAddress { get; set; }
        public string CustCity { get; set; }
        public string CustProv { get; set; }
        public string CustPostal { get; set; }
        public string CustCountry { get; set; }
        public string CustHomePhone { get; set; }
        public string CustBusPhone { get; set; }
        public string CustEmail { get; set; }
        public int? AgentId { get; set; }
        public string CustUserID { get; set; }
        public string Password { get; set; }
    }
}