using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockChainWeb.Models
{
    public class Student : User
    {
        public int Id { get; private set; }
        public string FullName { get; private set; }
        public string Faculty { get; private set; }
        public int Course { get; private set; }
        public List<BlockChain> Subjects { get; private set; } 
     
        public Student (string fullname,string faculty,int course,string login, string password, string email) :base(login, password, email)
        {
            FullName = fullname;
            Faculty = faculty;
            Course = course;
            Subjects = new List<BlockChain>();
        }
    }
}
