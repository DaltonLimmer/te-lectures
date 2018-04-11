using GetExercises.Web.DAL.Interfaces;
using GetExercises.Web.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace GetExercises.Web.DAL
{
    public class CustomerDAL : ICustomerDAL
    {
        private string connectionString;

        public CustomerDAL(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public IList<Customer> SearchForCustomers(string search, string sortBy)
        {
            IList<Customer> customers = new List<Customer>();

            if (sortBy.ToLower() != "active" && sortBy.ToLower() != "email")
            {
                sortBy = "last_name";
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("SELECT * FROM customer WHERE first_name LIKE @search OR last_name LIKE @search ORDER BY " + sortBy, conn);
                cmd.Parameters.AddWithValue("@search", "%" + search + "%");
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    customers.Add(MapRowToCustomer(reader));
                }

            }

            return customers;
        }

        private Customer MapRowToCustomer(SqlDataReader reader)
        {
            return new Customer()
            {
                FirstName = Convert.ToString(reader["first_name"]),
                LastName = Convert.ToString(reader["last_name"]),
                Email = Convert.ToString(reader["email"]),
                IsActive = Convert.ToBoolean(reader["activebool"])
            };
        }
    }
}