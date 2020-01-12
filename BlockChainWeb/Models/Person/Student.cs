using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockChainWeb.Models
{
    public class Student : User
    {
        #region Variables
        public string Faculty { get; private set; }
        public int Course { get; private set; }
        public string Cathedra { get; private set; }
        public List<BlockChain> Subjects { get; private set; }
        #endregion

        public Student (string fullname,string faculty,
            string cathedra,
            int course,string login, 
            string password, string email) :base(login, password, email,fullname)
        {
            Cathedra = cathedra;
            Faculty = faculty;
            Course = course;
            Subjects = new List<BlockChain>();
        }
    }
}
