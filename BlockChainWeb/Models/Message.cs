using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockChainWeb.Models
{
    public class Message
    {
        public int Id { get; private set; }
        public Student Student { get; private set; }
        public Valuation Valuation { get; private set; }
        public DateTime Date { get; private set; }
        
        public Message (Student student,Valuation valuation,DateTime date)
        {
            Student = student;
            Valuation = valuation;
            Date = date;
        }
    }
}
