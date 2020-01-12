using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockChainWeb.Models
{
    public class Teacher : User
    {
        public int Id { get; private set; }
        public string FullName { get; private set; }

        public Teacher(string fullname, string login, string password, string email) : base(login, password, email)
        {
            FullName = fullname;
        }
    }
}
