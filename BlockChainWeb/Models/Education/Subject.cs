
using System.Collections.Generic;

namespace BlockChainWeb.Models.Education {
	public class Subject {
		public int Id { get; set; }
		public string Name { get; set; }
		public List<TaskSubject> TaskSubjects { get; set; }
	}
}