/*By: Craig  help from Hua & Almerick
 * Date: January 23
 * Assignment: Threaded Project 2
 * Description: This class contains constructors for Products
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace X_Pert_Hunters_ASP.NET.App_Code
{
    public class Products
    {
        public Products() {}
        public string PackageName { get; set; }

        public string ProductName { get; set; }
        
        public string Description { get; set; }
         
        public decimal BasePrice { get; set; }

        public string BookingNo { get; set; }

        public DateTime BookDate { get; set; }

        public int CustomerNo { get; set; }

        public string CustomerName { get; set; }

        public string CustUserid { get; set; }
    }
}