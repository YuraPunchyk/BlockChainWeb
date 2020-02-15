using System.ComponentModel.DataAnnotations;

namespace BlockChainWeb.ViewModels {
	public class RegisterStudentViewModel {
		public string Id { get; set; }

		[Required, MaxLength(200)]
		public string FullName { get; set; }

		[Required, DataType(DataType.Password)]
		public string Password { get; set; }

		[DataType(DataType.Password), Compare(nameof(Password))]
		public string ConfirmPassword { get; set; }

		[Required, DataType(DataType.EmailAddress, ErrorMessage = "Email Address is not correct")]
		public string Email { get; set; }

		[Required, MaxLength(200)]
		public string Faculty { get; set; }

		[RegularExpression(@"[1-6]{1}", ErrorMessage = "Course is not correct")]
		public int Course { get; set; }
		[RegularExpression(@"[1-6][0-9][1-9]", ErrorMessage = "Group is not correct")]
		public int Group { get; set; }

		[Required, MaxLength(200)]
		public string Cathedra { get; set; }
	}
}