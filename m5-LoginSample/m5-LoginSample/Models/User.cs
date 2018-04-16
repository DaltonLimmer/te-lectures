using System.Collections.Generic;

namespace m5_LoginSample.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public IList<Permission> Permissions { get; set; } = new List<Permission>();

    }
}