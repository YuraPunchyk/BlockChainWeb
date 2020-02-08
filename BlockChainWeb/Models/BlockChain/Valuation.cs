using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlockChainWeb.Models.Person;

namespace BlockChainWeb.Models {
	public class Valuation {
		public Teacher Teacher { get; set; }
		public float Amount { get; set; }
		public string Description { get; set; }
		public Valuation ( Teacher teacher, float amount, string description ) {
			Teacher = teacher;
			Amount = amount;
			Description = description;
		}
	}
}