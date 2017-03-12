/*By: Craig  help from Hua & Almerick
 * Date: January 23
 * Assignment: Threaded Project 2
 * Description: This class contains methods
 * that are used for filling data sources with product
 * information
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace X_Pert_Hunters_ASP.NET.App_Code
{
    [DataObject(true)]

    public class ProductsDB
    {
        [DataObjectMethod(DataObjectMethodType.Select)]
        //This method is used for getting products based on customer ID
        public static List<Products> GetProducts(string custUserid)
        {
            //blank list of products
            List<Products> products = new List<Products>();

            //define connection 
            SqlConnection connection = task3DB.GetConnection();

            //define select statment
            string selectProducts = "select  c.CustUserId, pa.PkgName, pr.ProdName, b.bookingNo, d.Description, b.BookingDate, d.BasePrice " +
                                    "from Customers c " +
                                    "join Bookings b " +
                                    "on b.CustomerId = c.Customerid " +
                                    "join BookingDetails d " +
                                    "on d.BookingId = b.BookingId " +
                                    "join Products_Suppliers s " +
                                    "on s.ProductSupplierId = d.ProductSupplierId " +
                                    "left join Packages_Products_Suppliers pps " +
                                    "on pps.ProductSupplierId = s.ProductSupplierId " +
                                    "full outer join Packages pa " +
                                    "on pa.PackageId = pps.PackageId " +
                                    "left join Products pr " +
                                    "on pr.ProductId = s.ProductId " +
                                    "Where c.CustUserId = @CustUserId " +
                                    "order by c.CustFirstName asc ";
                                    
            //command statement
           SqlCommand selectCommand = new SqlCommand(selectProducts, connection);

            //define select command value
            selectCommand.Parameters.AddWithValue("@CustUserId", custUserid);

            try
            {
                //openconnection
                connection.Open();

                SqlDataReader reader = selectCommand.ExecuteReader();

                while(reader.Read())
                {
                    //gets column index based off of PkgName
                    int Index1 = reader.GetOrdinal("PkgName");

                    Products prod = new Products();
                    prod.PackageName = reader["PkgName"].ToString();
                    prod.ProductName = reader["ProdName"].ToString();
                    prod.Description = reader["Description"].ToString();
                    prod.BasePrice = (decimal)reader["BasePrice"];
                    prod.BookingNo = reader["bookingNo"].ToString();
                    prod.BookDate = Convert.ToDateTime(reader["BookingDate"]);
                    prod.CustUserid = reader["CustUserId"].ToString();
                    products.Add(prod); //adds object to list
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }

            return products;
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        //This method is used for getting products and was only used for 
        //testing before sessions were implemented
        public static List<Products> GetCustomer()
        {
            //technician list
            List<Products> Techs = new List<Products>(); //Technician list (empty)
            Products T; //reference to new Technician

            //creates connection
            SqlConnection connection = task3DB.GetConnection();

            //select string
            string selectstring = "SELECT CustUserId, CustFirstName FROM Customers Order By CustFirstName ASC ";

            //select command
            SqlCommand command = new SqlCommand(selectstring, connection);

            try
            {
                //open connection
                connection.Open();

                //run the select command and process the results adding states to the list
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read()) //processess request while reading can still be done
                {
                    T = new Products();
                    T.CustomerName = reader["CustFirstName"].ToString();
                    T.CustUserid = reader["CustUserId"].ToString();
                    Techs.Add(T);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }
            return Techs;

        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        //this method returns the sum of base package prices based on the customer user ID
        public static Products TotalPrice(string custUserId)
        {
            //initiate blank object
            Products Totes = new Products();

            //set sql connection
            SqlConnection connection = task3DB.GetConnection();

            //select total string
            string selectTotal = @"Select c.CustUserId, Sum(BasePrice) as Total 
                                    From BookingDetails bd
                                    inner join Bookings b
                                    on bd.BookingId = b.BookingId
                                    inner join Customers c
                                    on c.CustomerId = b.CustomerId
                                    Where C.CustUserId = @CustUserId                           
                                    Group by C.CustUserId";
            //sets sql command
            SqlCommand command = new SqlCommand(selectTotal, connection);

            //parameter used for customer ID
           command.Parameters.AddWithValue("@CustUserId", custUserId);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Totes.CustUserid = reader["CustUserId"].ToString();
                    Totes.BasePrice = (decimal)reader["Total"];
                }
                reader.Close();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }

            return Totes;

        }

    }
}