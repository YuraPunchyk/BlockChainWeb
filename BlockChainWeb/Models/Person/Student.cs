using BlockChainWeb.Models.HellperClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BlockChainWeb.Models.Person {
	public class Student : User {
		#region Variables
		public string Faculty { get; set; }
		public int Course { get; set; }
		public string Cathedra { get; set; }
		public int Group { get; set; }
		public Dictionary<string,BlockChain> Subjects { get; set; }
		#endregion

		public Student ( string fullname, string faculty,
			string cathedra,
			int course, int group, string id, string email, Dictionary<string, BlockChain> subject ) : base(id, email, fullname, Role.Student) {
			Cathedra = cathedra;
			Faculty = faculty;
			Course = course;
			Group = group;
			Subjects = subject;
		}
	}
}