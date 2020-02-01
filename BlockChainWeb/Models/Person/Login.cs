using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockChainWeb.Models.Person
{
    public class Login
    {
        public string Id { get; set; }
        public string Password { get; set;}
        public bool IsStudent { get; set; }
        public bool IsTeacher { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsLogin { get; set; }
        public string ForwardIp { get; set; }
    }
}
