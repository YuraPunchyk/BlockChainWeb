using BlockChainWeb.Models.Person;
using System.Collections.Generic;


namespace BlockChainWeb.ViewModels {
	public class TeacherViews {
		public Teacher Teacher { get; set; }
		public List<int> Groups { get; set; }
		public string Subject { get; set; }
		public int Group { get; set; }
	}
}
