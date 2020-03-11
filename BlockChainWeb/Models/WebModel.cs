using BlockChainWeb.Models.Education;
using BlockChainWeb.Models.Person;
using System.Collections.Generic;


namespace BlockChainWeb.Models {
	public class WebModel {
		public string Id { get; set; }
		public string Role { get; set; } = "";
		#region Studen
		public Student Student { get; set; }
		public BlockChain BlockChain { get; set; }
		#endregion
		#region Techer
		public List<Group> Groups { get; set; } = null;
		public string Subject { get; set; } = "";
		public int Group { get; set; } 
		public List<Subject> Subjects { get; set; }
		public Subject SubjectModel { get; set; }
		#endregion

		#region Set Valuation
		public List<Student> Students { get; set; } = null;
		public List<string> StudentIds { get; set; } = null;
		public string Description { get; set; } = "";
		public float Amount { get; set; } = -1;
		#endregion
	}
}