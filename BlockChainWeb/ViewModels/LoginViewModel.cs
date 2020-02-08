using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlockChainWeb.ViewModels {
	public class LoginViewModel {
		[Required, MaxLength(100)]
		public string Id { get; set; }
		[Required, DataType(DataType.Password)]
		public string Password { get; set; }
	}
}