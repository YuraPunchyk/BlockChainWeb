using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockChainWeb.Models
{
    public class Teacher : User
    {
        public string Faculty { get; private set; }
        public string Cathedra { get; private set; }
        public Teacher(string fullname, string faculty, string cathedra, 
            string login, 
            string password, 
            string email) : base(login, password, email, fullname)
        {
            Cathedra=cathedra;
            Faculty = faculty;
        }
    }
}
