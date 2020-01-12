using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockChainWeb.Models
{
    public class User
    {
        public int Id { get; private set; }
        public string FullName { get; private set; }
        public string  Login { get; private set; }
        public string  Password { get; private set; }
        public string  Email { get; private set; }

        public User(string login, string password, string email,string fullname)
        {
            FullName = fullname;
            Login = login;
            Password = password;
            Email = email;
        }
    }
}
