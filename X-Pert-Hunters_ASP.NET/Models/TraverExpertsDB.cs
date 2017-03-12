using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace X_Pert_Hunters_Web_Application.Models
{
    /************************************
     * Description:make connection to database
     * Author:Hua
     * Created Date:Jan 20, 2017
     * Course Code:CPRG214 ASP.NET
     * **********************************/
    public class TraverExpertsDB
    {
        public static SqlConnection GetConnection()
        {
            // pull connection string out of web.config
            string connString =
                ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            SqlConnection conn = new SqlConnection(connString);
            return conn;
        }
    }
}