using m5_LoginSample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace m5_LoginSample.DAL
{
    public interface ILoginDAL
    {
        User GetUser(string username);
        bool ValidateLogin(string username, string password);
    }
}
