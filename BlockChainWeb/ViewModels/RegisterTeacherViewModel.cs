using BlockChainWeb.Models.Education;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BlockChainWeb.ViewModels {
	public class RegisterTeacherViewModel {
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

		[Required, MaxLength(200)]
		public string Cathedra { get; set; }
		public List<Subject> Subjects { get; set; }
		public List<int> SubjectsId { get; set; }
	}
}