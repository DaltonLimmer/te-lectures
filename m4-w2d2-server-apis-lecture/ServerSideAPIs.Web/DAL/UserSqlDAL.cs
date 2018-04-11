using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ServerSideAPIs.Web.Models;
using System.Configuration;
using System.Data.SqlClient;

namespace ServerSideAPIs.Web.DAL
{
    public class UserSqlDAL : IUserDAL
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["ApiDB"].ConnectionString;

        public void AddUser(User newUser)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("INSERT INTO users VALUES (@name, @username, @email);", conn);
                    cmd.Parameters.AddWithValue("@name", newUser.Name);
                    cmd.Parameters.AddWithValue("@username", newUser.Username);
                    cmd.Parameters.AddWithValue("@email", newUser.Email);

                    cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                throw;
            }
        }

        public void DeleteUser(int id)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("DELETE FROM users WHERE id = @id;", conn);
                    cmd.Parameters.AddWithValue("@id", id);
                    
                    cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                throw;
            }
        }

        public void UpdateUser(User updatedUser)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("UPDATE users SET name = @name, username = @username, email = @email WHERE id = @id;", conn);
                    cmd.Parameters.AddWithValue("@name", updatedUser.Name);
                    cmd.Parameters.AddWithValue("@username", updatedUser.Username);
                    cmd.Parameters.AddWithValue("@email", updatedUser.Email);
                    cmd.Parameters.AddWithValue("@id", updatedUser.Id);

                    cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                throw;
            }
        }

        public List<User> GetAllUsers()
        {
            List<User> users = new List<User>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT * FROM users;", conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        User u = new User()
                        {
                            Id = Convert.ToInt32(reader["id"]),
                            Name = Convert.ToString(reader["name"]),
                            Username = Convert.ToString(reader["username"]),
                            Email = Convert.ToString(reader["email"])
                        };
                        users.Add(u);
                    }

                    return users;
                }
            }
            catch (SqlException ex)
            {
                throw;
            }            
        }

        public User GetUser(int id)
        {
            User user = null;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT * FROM users WHERE id = @id;", conn);
                    cmd.Parameters.AddWithValue("@id", id);

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        user = new User()
                        {
                            Id = Convert.ToInt32(reader["id"]),
                            Name = Convert.ToString(reader["name"]),
                            Username = Convert.ToString(reader["username"]),
                            Email = Convert.ToString(reader["email"])
                        };                        
                    }

                    return user;
                }
            }
            catch (SqlException ex)
            {
                throw;
            }
        }
    }
}