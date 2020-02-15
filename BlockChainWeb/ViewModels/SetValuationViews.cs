using BlockChainWeb.Models.Person;
using System.Collections.Generic;

namespace BlockChainWeb.ViewModels {
	public class SetValuationViews {
		public List<Student> Students {get;set;}
		public Teacher Teacher { get; set; }
		public string Subjects { get; set; }
		public List<string> StudentIds { get; set; }
		public string Description { get; set; }
		public float Amount { get; set; }
	}
}
