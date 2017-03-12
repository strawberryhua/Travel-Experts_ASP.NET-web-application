using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.Configuration;

namespace X_Pert_Hunters_Web_Application.Models
{
    /************************************
     * Description:Create methods to insert, upadte customer data to database and check login and userId of customer 
     * Author:Hua
     * Created Date:Jan 20, 2017
     * Course Code:CPRG214 ASP.NET
     * **********************************/
    public static class CustomerDB
    {

        //retrieve Customer data from database
        public static Customer GetCustomer(string custUserId)
        {
            Customer cust = null; // found customer
            // define connection
            SqlConnection connection = TraverExpertsDB.GetConnection();

            // define the select query command
            string selectQuery = "select CustomerId, CustFirstName, CustLastName, CustAddress, CustCity, CustProv, " +
                                 "CustPostal, CustCountry, CustHomePhone, CustBusPhone, CustEmail, AgentId, " +
                                 "CustUserId, Password " +
                                 "from Customers " +
                                 "where CustUserId = @CustUserId";
            SqlCommand selectCommand = new SqlCommand(selectQuery, connection);
            selectCommand.Parameters.AddWithValue("@CustUserId", custUserId);
            try
            {
                // open the connection
                connection.Open();

                // execute the query
                SqlDataReader reader = selectCommand.ExecuteReader();

                // process the result if any
                if (reader.Read()) // if there is customer
                {
                    cust = new Customer();
                    cust.CustomerId = (int)reader["CustomerID"];
                    cust.CustFirstName = reader["CustFirstName"].ToString();
                    cust.CustLastName = reader["CustLastName"].ToString();
                    cust.CustAddress = reader["CustAddress"].ToString();
                    cust.CustCity = reader["CustCity"].ToString();
                    cust.CustProv = reader["CustProv"].ToString();
                    cust.CustPostal = reader["CustPostal"].ToString();
                    cust.CustCountry = reader["CustCountry"].ToString();
                    cust.CustHomePhone = reader["CustHomePhone"].ToString();
                    cust.CustBusPhone = reader["CustBusPhone"].ToString();
                    cust.CustEmail = GetNullableString(reader, "CustEmail");
                    cust.AgentId = GetNullableInt(reader,"AgentId");
                    cust.CustUserID = reader["CustUserID"].ToString();
                    cust.Password = reader["Password"].ToString();
                }
            }
            catch (Exception ex)
            {
                throw ex; // let the form handle it
            }
            finally
            {
                connection.Close(); // close connecto no matter what
            }

            return cust;
        }

        //check null for string
        public static string GetNullableString(SqlDataReader reader, string fieldName)
        {
            if (reader[fieldName] != DBNull.Value)
            {
                return reader[fieldName].ToString();
            }
            return null;
        }

        //check null for int
        public static int? GetNullableInt(SqlDataReader reader, string fieldName)
        {
            if (reader[fieldName] != DBNull.Value)
            {
                return (int)reader[fieldName];
            }
            return null;
        }

        //insert new customer to database
        public static int AddCustomer(Customer cust) // returns generated customer id
        {
            int custID = 0;
            // prepare connection
            SqlConnection connection = TraverExpertsDB.GetConnection();

            // prepare the statement
            string insertString = "insert into Customers " +
                                  "(CustFirstName, CustLastName, CustAddress, CustCity, CustProv, CustPostal, CustCountry, CustHomePhone, CustBusPhone, CustEmail, AgentId, CustUserID, Password) " +
                                  "values(@CustFirstName, @CustLastName, @CustAddress, @CustCity, @CustProv, @CustPostal, @CustCountry, @CustHomePhone, @CustBusPhone, @CustEmail, @AgentId, @CustUserID, @Password)";
            SqlCommand insertCommand = new SqlCommand(insertString, connection);
            insertCommand.Parameters.AddWithValue("@CustFirstName", cust.CustFirstName);
            insertCommand.Parameters.AddWithValue("@CustLastName", cust.CustLastName);
            insertCommand.Parameters.AddWithValue("@CustAddress", cust.CustAddress);
            insertCommand.Parameters.AddWithValue("@CustCity", cust.CustCity);
            insertCommand.Parameters.AddWithValue("@CustProv", cust.CustProv);
            insertCommand.Parameters.AddWithValue("@CustPostal", cust.CustPostal);
            insertCommand.Parameters.AddWithValue("@CustCountry", cust.CustCountry);
            insertCommand.Parameters.AddWithValue("@CustHomePhone", cust.CustHomePhone);
            insertCommand.Parameters.AddWithValue("@CustBusPhone", cust.CustBusPhone);
            insertCommand.Parameters.AddWithValue("@CustEmail", cust.CustEmail);

            insertCommand.Parameters.AddWithValue("@AgentId", DBNull.Value);

            insertCommand.Parameters.AddWithValue("@CustUserID", cust.CustUserID);
            insertCommand.Parameters.AddWithValue("@Password", cust.Password);

            try
            {
                // open connection
                connection.Open();

                // execute the statement
                int i = insertCommand.ExecuteNonQuery();
                if (i == 1) // one record inserted
                {
                    // retrieve customer id from the added record
                    string selectString = "select ident_current('Customers') " +
                                          "from Customers";
                    SqlCommand selectCommand = new SqlCommand(selectString, connection);
                    custID = Convert.ToInt32(selectCommand.ExecuteScalar()); // (int) does not work!!!
                }
            }
            catch (Exception ex)
            {
                throw ex; // pass the buck
            }
            finally
            {
                connection.Close();
            }
            return custID;
        }

        //modify customer data
        public static bool UpdateCustomer(Customer customer, Customer old_customer)
        {
            bool successful = false;
            SqlConnection connection = TraverExpertsDB.GetConnection();
            string updateString = "update Customers set " +
                                  "CustFirstName = @NewCustFirstName, " +
                                  "CustLastName = @NewCustLastName, " +
                                  "CustAddress = @NewCustAddress, " +
                                  "CustCity = @NewCustCity, " +
                                  "CustProv = @NewCustProv, " +
                                  "CustPostal = @NewCustPostal, " +
                                  "CustCountry = @NewCustCountry, " +
                                  "CustHomePhone = @NewCustHomePhone, " +
                                  "CustBusPhone = @NewCustBusPhone, " +
                                  "CustEmail = @NewCustEmail, " +
                                  "AgentId = @NewAgentId, " +
                                  "CustUserID = @NewCustUserID, " +
                                  "Password = @NewPassword " +
                                  "where " + // update succeeds only if record not changed by other users
                                  "CustFirstName = @OldCustFirstName and " +
                                  "CustLastName = @OldCustLastName and " +
                                  "CustAddress = @OldCustAddress and " +
                                  "CustCity = @OldCustCity and " +
                                  "CustProv = @OldCustProv and " +
                                  "CustPostal = @OldCustPostal and " +
                                  "CustCountry = @OldCustCountry and " +
                                  "CustHomePhone = @OldCustHomePhone and " +
                                  "(CustBusPhone = @OldCustBusPhone or " +
                                  "CustBusPhone Is NULL and @OldCustBusPhone Is NULL) and " +
                                  "(CustEmail = @OldCustEmail or " +
                                  "CustEmail Is NUll and @OldCustEmail IS NULL) and " +
                                  "(AgentId = @OldAgentId or " +
                                  "AgentId IS NULL and @OldAgentId is NULL) and " +
                                  "CustUserID = @OldCustUserID and " +
                                  "Password = @OldPassword";
            SqlCommand updateCommand = new SqlCommand(updateString, connection);
            updateCommand.Parameters.AddWithValue("@OldCustFirstName", old_customer.CustFirstName);
            updateCommand.Parameters.AddWithValue("@OldCustLastName", old_customer.CustLastName);
            updateCommand.Parameters.AddWithValue("@OldCustAddress", old_customer.CustAddress);
            updateCommand.Parameters.AddWithValue("@OldCustCity", old_customer.CustCity);
            updateCommand.Parameters.AddWithValue("@OldCustProv", old_customer.CustProv);
            updateCommand.Parameters.AddWithValue("@OldCustPostal", old_customer.CustPostal);
            updateCommand.Parameters.AddWithValue("@OldCustCountry", old_customer.CustCountry);
            updateCommand.Parameters.AddWithValue("@OldCustHomePhone", old_customer.CustHomePhone);
            if (old_customer.CustBusPhone != null)
            {
                updateCommand.Parameters.AddWithValue("@OldCustBusPhone", old_customer.CustBusPhone);
            }
            else
            {
                updateCommand.Parameters.AddWithValue("@OldCustBusPhone", DBNull.Value);
            }
            if (old_customer.CustEmail != null)
            {
                updateCommand.Parameters.AddWithValue("@OldCustEmail", old_customer.CustEmail);
            }
            else
            {
                updateCommand.Parameters.AddWithValue("@OldCustEmail", DBNull.Value);
            }
            if (old_customer.AgentId != null)
            {
                updateCommand.Parameters.AddWithValue("@OldAgentId", old_customer.AgentId);
            }

            else
            {
                updateCommand.Parameters.AddWithValue("@OldAgentId", DBNull.Value);
            }
            updateCommand.Parameters.AddWithValue("@OldCustUserID", old_customer.CustUserID);
            updateCommand.Parameters.AddWithValue("@OldPassword", old_customer.Password);

            updateCommand.Parameters.AddWithValue("@NewCustFirstName", customer.CustFirstName);
            updateCommand.Parameters.AddWithValue("@NewCustLastName", customer.CustLastName);
            updateCommand.Parameters.AddWithValue("@NewCustAddress", customer.CustAddress);
            updateCommand.Parameters.AddWithValue("@NewCustCity", customer.CustCity);
            updateCommand.Parameters.AddWithValue("@NewCustProv", customer.CustProv);
            updateCommand.Parameters.AddWithValue("@NewCustPostal", customer.CustPostal);
            updateCommand.Parameters.AddWithValue("@NewCustCountry", customer.CustCountry);
            updateCommand.Parameters.AddWithValue("@NewCustHomePhone", customer.CustHomePhone);
            if (customer.CustBusPhone != null)
            {
                updateCommand.Parameters.AddWithValue("@NewCustBusPhone", customer.CustBusPhone);
            }
            else
            {
                updateCommand.Parameters.AddWithValue("@NewCustBusPhone", DBNull.Value);
            }
            if (customer.CustEmail != null)
            {
                updateCommand.Parameters.AddWithValue("@NewCustEmail", customer.CustEmail);
            }
            else
            {
                updateCommand.Parameters.AddWithValue("@NewCustEmail", DBNull.Value);
            }
            if (customer.AgentId != null)
            {
                updateCommand.Parameters.AddWithValue("@NewAgentId", customer.AgentId);
            }
            else
            {
                updateCommand.Parameters.AddWithValue("@NewAgentId", DBNull.Value);
            }
            updateCommand.Parameters.AddWithValue("@NewCustUserID", customer.CustUserID);
            updateCommand.Parameters.AddWithValue("@NewPassword", customer.Password);



            try
            {
                connection.Open();
                int count = updateCommand.ExecuteNonQuery();
                if (count == 1)
                    successful = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                //connection.Close();
            }
            return successful;
        }

        //check login in database
        public static bool CheckLogin(List<TextBox> lt)
        {
            bool successfull = false;
            int count;
            // define connection
            SqlConnection connection = TraverExpertsDB.GetConnection();

            // define the select query command
            string checkUserQuery = "select count(*) " +
                                 "from Customers " +
                                 "where CustUserId ='" + lt[0].Text + "'";
            SqlCommand checkUserCommand = new SqlCommand(checkUserQuery, connection);

            try
            {
                // open the connection
                connection.Open();


                count = Convert.ToInt32(checkUserCommand.ExecuteScalar());



            }
            catch (Exception ex)
            {
                throw ex; // let the form handle it
            }
            finally
            {
                connection.Close(); // close connecto no matter what
            }

            if (count == 1)//have match in database
            {
                string checkPasswordQuery = "select Password " +
                             "from Customers " +
                             "where CustUserId ='" + lt[0].Text + "'";
                SqlCommand checkPassCommand = new SqlCommand(checkPasswordQuery, connection);
                try
                {
                    connection.Open();
                    string password = checkPassCommand.ExecuteScalar().ToString();
                    if (password == lt[1].Text)//have match in database
                    {
                        successfull = true;

                    }

                }
                catch (Exception ex)
                {
                    throw ex; // let the form handle it
                }
                finally
                {
                    connection.Close(); // close connecto no matter what
                }


               
            }
            return successfull;
        }

        //verify if UserId is unique
        public static bool checkUserId(string custUserId)
        {
            bool successfull = false;
            int count;
            // define connection
            SqlConnection connection = TraverExpertsDB.GetConnection();

            // define the select query command
            string checkUserQuery = "select count(*) " +
                                 "from Customers " +
                                 "where CustUserId = @CustUserId";
            SqlCommand checkUserCommand = new SqlCommand(checkUserQuery, connection);
            checkUserCommand.Parameters.AddWithValue("@CustUserId", custUserId);

            try
            {
                // open the connection
                connection.Open();


                count = Convert.ToInt32(checkUserCommand.ExecuteScalar());
                if (count >= 1)
                {
                    successfull = false;
                }
                else
                {
                    successfull = true;
                }



            }
            catch (Exception ex)
            {
                throw ex; // let the form handle it
            }
            finally
            {
                connection.Close(); // close connecto no matter what
            }
            return successfull;
        }

    }
}