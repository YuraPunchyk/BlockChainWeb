
namespace BlockChainWeb.Models.Person {
	public class User {

		#region Variables
		[BsonId]
		public string Id { get; set; }
		public string FullName { get; set; }
		public string Email { get; set; }
		public string UserRole { get; set; }
		#endregion

		public User ( string id, string email, string fullname, string userRole ) {
			FullName = fullname;
			Id = id;
			Email = email;
			UserRole = userRole;
		}
	}
}
