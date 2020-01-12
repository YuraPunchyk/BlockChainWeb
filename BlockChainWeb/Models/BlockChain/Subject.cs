using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockChainWeb.Models
{
    public class Subject
    {
        public int Id { get; private set; }
        public string Name { get; private set; }

        public Subject(string name)
        {
            Name = name;
        }
    }
}
