using BlockChainWeb.Models.HellperClasses;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockChainWeb.Models.Person {
	public class Teacher : User {
		#region Variables
		public string Faculty { get; set; }
		public string Cathedra { get; set; }
		public List<Subject> Subjects { get; set; }
		#endregion
		[BsonIgnore]
		public List<int> Groups { get; set; }// only for coding

		public Teacher ( string fullname, string faculty, List<Subject> subjects, string cathedra,
			string id,
			string email ) : base(id, email, fullname, Role.Teacher) {
			Cathedra = cathedra;
			Faculty = faculty;
			Subjects = subjects;
		}
	}
}
