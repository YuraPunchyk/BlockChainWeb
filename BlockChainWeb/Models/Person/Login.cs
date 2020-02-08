using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockChainWeb.Models.Person {
	public class Login {
		public string Id { get; set; }
		public string Password { get; set; }
		public bool IsStudent { get; set; }
		public bool IsTeacher { get; set; }
		public bool IsAdmin { get; set; }
		public string ForwardIp { get; set; }

		public Login ( string id,string password, bool isStudent, bool isTeacher, bool isAdmin, string forwardIp) {
			Id = id;
			Password = password;
			IsStudent = isStudent;
			IsTeacher = isTeacher;
			IsAdmin = isAdmin;
			ForwardIp = forwardIp;
		}
	}
}
