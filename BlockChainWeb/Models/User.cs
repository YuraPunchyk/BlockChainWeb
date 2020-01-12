using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockChainWeb.Models
{
    public class User
    {
        public string  Login { get; private set; }
        public string  Password { get; private set; }
        public string  Email { get; private set; }

        public User(string login, string password, string email)
        {
            Login = login;
            Password = password;
            Email = email;
        }
    }
}
