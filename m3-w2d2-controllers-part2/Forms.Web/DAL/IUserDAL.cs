using Forms.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forms.Web.DAL
{
    public interface IUserDAL
    {
        User CreateUser(string emailAddress, string password);

        IList<User> GetAllUsers();
    }
}
