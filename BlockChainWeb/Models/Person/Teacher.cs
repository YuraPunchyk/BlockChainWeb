using BlockChainWeb.Models.Education;
using BlockChainWeb.Models.HellperClasses;
using System.Collections.Generic;

namespace BlockChainWeb.Models.Person {
	public class Teacher : User {
		#region Variables
		public string Faculty { get; set; }
		public string Cathedra { get; set; }
		public List<Subject> Subjects { get; set; }
		#endregion

		public Teacher ( string fullname, string faculty, List<Subject> subjects, string cathedra,
			string id,
			string email ) : base(id, email, fullname, Role.Teacher) {
			Cathedra = cathedra;
			Faculty = faculty;
			Subjects = subjects;
		}
	}
}