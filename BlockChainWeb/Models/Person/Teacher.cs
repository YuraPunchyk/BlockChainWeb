using BlockChainWeb.Models.HellperClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockChainWeb.Models.Person
{
    public class Teacher : User
    {
        public string Faculty { get; set; }
        public string Cathedra { get; set; }
        public List<Subject> Subjects { get; set; }
        public Teacher(string fullname, string faculty,List<Subject> subjects, string cathedra, 
            string id, 
            string email) : base(id, email, fullname,Role.Teacher)
        {
            Cathedra=cathedra;
            Faculty = faculty;
            Subjects = subjects;
        }
    }
}
