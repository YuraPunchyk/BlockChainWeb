using BlockChainWeb.Models.Person;

namespace BlockChainWeb.DbContexts {
	public class DbContext : BaseDbContext {

		public DbContext ( string connectionString ) : base(connectionString) {

		}

		public Login Authentication ( string id, string password ) {
			Login login = Register(id, password);
			if(login != null) {
				return login;
			}
			return null;
		}
	}
}