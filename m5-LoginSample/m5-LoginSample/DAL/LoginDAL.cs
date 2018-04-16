using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using m5_LoginSample.Models;

namespace m5_LoginSample.DAL
{
    public class LoginDAL : ILoginDAL
    {
        private string _connectionString;

        public LoginDAL(string connectionString)
        {
            this._connectionString = connectionString;
        }

        public User GetUser(string username)
        {
            User user = null;

            var sql = "SELECT u.Id, Username, Password, p.Id as PermissionId, p.Name as PermissionName, p.Description as PermissionDescription " +
                " FROM Users u " +
                " LEFT OUTER JOIN UsersPermissions up ON u.id = up.userid" +
                " LEFT OUTER JOIN Permissions p ON up.permissionId = p.id " +
                " WHERE Username = @username";

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);

                cmd.Parameters.Add(new SqlParameter("@username", username));

                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    user = MapToUser(reader, user);
                }
            }

            return user;
        }

        public bool ValidateLogin(string username, string password)
        {

            var sql = "SELECT COUNT(*) FROM Users WHERE Username = @username AND Password = @password";

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);

                cmd.Parameters.Add(new SqlParameter("@username", username));
                cmd.Parameters.Add(new SqlParameter("@password", password));


                int? result = cmd.ExecuteScalar() as int?;

                if(result.HasValue && result.Value >= 1)
                {
                    return true;
                }

            }

            return false;
        }




        private User MapToUser(SqlDataReader reader, User user)
        {
            if (user == null)
            {
                user = new User();
                user.Id = int.Parse(reader["Id"].ToString());
                user.Username = reader["Username"].ToString();
                user.Password = reader["Password"].ToString();
            }

            int? permissionId = reader["PermissionId"] as int?;
            if (permissionId.HasValue)
            {
                var perm = new Permission();
                perm.Id = permissionId.Value;
                perm.Name = reader["PermissionName"].ToString();
                perm.Description = reader["PermissionDescription"].ToString();

                user.Permissions.Add(perm);
            }

            return user;
        }



    }
}