using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockChainWeb.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string  Login { get; set; }
        public string  Password { get; set; }
        public string  Email { get; set; }

        public User(string login, string password, string email,string fullname)
        {
            FullName = fullname;
            Login = login;
            Password = password;
            Email = email;
        }
    }
}
