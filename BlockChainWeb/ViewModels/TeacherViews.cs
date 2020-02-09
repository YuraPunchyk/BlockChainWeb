using BlockChainWeb.Models.Person;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockChainWeb.ViewModels {
	public class TeacherViews {
		public Teacher Teacher { get; set; }
		public List<int> Groups { get; set; }
	}
}
