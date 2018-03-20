using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Forms.Web.Models;

namespace Forms.Web.DAL
{
    public class UserDAL : IUserDAL
    {

        private string _connectionString;
        public UserDAL(string connectionString)
        {
            _connectionString = connectionString;
        }

        public User CreateUser(string emailAddress, string password)
        {
            User u = new User() { EmailAddress = emailAddress, Password = password };

            string sql = "INSERT INTO SiteUser (EmailAddress, Password) VALUES (@user, @pass);" +
                "SELECT CAST(SCOPE_IDENTITY() AS INT);";

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add(new SqlParameter("@user", u.EmailAddress));
                cmd.Parameters.Add(new SqlParameter("@pass", u.Password));

                int newId = (int)cmd.ExecuteScalar();
                u.Id = newId;
            }

            return u;
        }

        public IList<User> GetAllUsers()
        {
            var users = new List<User>();

            string sql = "SELECT UserId, EmailAddress, Password FROM SiteUser;";

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);

                SqlDataReader r = cmd.ExecuteReader();

                while(r.Read())
                {
                    User u = new User() { Id = Convert.ToInt32(r["UserId"]), EmailAddress = r["EmailAddress"].ToString(), Password = r["Password"].ToString() };
                    users.Add(u);
                }
            }

            return users;
        }
    }
}