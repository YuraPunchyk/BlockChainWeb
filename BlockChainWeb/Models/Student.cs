using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockChainWeb.Models
{
    public class Student
    {
        public int Id { get; private set; }
        public string FullName { get; private set; }
        public string Password { get;private set; }
        public string Faculty { get; private set; }
        public int Course { get; private set; }
        public List<BlockChain> Subjects { get; private set; } 
        public string Email { get; private set; }
    }
}
