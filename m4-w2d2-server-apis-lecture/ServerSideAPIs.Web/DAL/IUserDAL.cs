using ServerSideAPIs.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerSideAPIs.Web.DAL
{
    public interface IUserDAL
    {
        List<User> GetAllUsers();
        User GetUser(int id);
        void AddUser(User newUser);
        void DeleteUser(int id);
        void UpdateUser(User updatedUser);
    }
}
