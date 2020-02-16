using BlockChainWeb.Models.Person;
using System.Collections.Generic;


namespace BlockChainWeb.Models {
	public class WebModel {
		public string Id { get; set; }
		public string Role { get; set; } = "";

		#region Techer
		public List<int> Groups { get; set; } = null;
		public string Subject { get; set; } = "";
		public int Group { get; set; } = -1;
		public List<string> Subjects { get; set; }
		#endregion

		#region Set Valuation
		public List<Student> Students { get; set; } = null;
		public List<string> StudentIds { get; set; } = null;
		public string Description { get; set; } = "";
		public float Amount { get; set; } = -1;
		#endregion
	}
}