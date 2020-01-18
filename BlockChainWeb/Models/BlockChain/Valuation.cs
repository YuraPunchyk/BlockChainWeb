using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockChainWeb.Models
{
    public class Valuation
    {
        public Teacher Teacher { get; set; }
        public float Amount { get; set; }
        public DateTime Date { get; set; }
        public Valuation(Teacher teacher,float amount)
        {
            Teacher = teacher;
            Amount = amount;
            Date = DateTime.Now;
        }
    }
}
