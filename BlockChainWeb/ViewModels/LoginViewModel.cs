using System.ComponentModel.DataAnnotations;

namespace BlockChainWeb.ViewModels {
	public class LoginViewModel {
		[Required, MaxLength(100)]
		public string Id { get; set; }
		[Required, DataType(DataType.Password)]
		public string Password { get; set; }
	}
}