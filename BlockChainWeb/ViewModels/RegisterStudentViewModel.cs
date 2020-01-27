using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlockChainWeb.ViewModels
{
    public class RegisterStudentViewModel
    {
        public int Id { get; set; }

        [Required, MaxLength(200)]
        public string FullName { get; set; }

        [Required, MaxLength(100)]
        public string Login { get; set; }

        [Required, DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password), Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }

        [Required, DataType(DataType.EmailAddress, ErrorMessage = "Email Address is not correct")]
        public string Email { get; set; }

        [Required, MaxLength(200)]
        public string Faculty { get; set; }

        [RegularExpression(@"[1-6]{1}",ErrorMessage ="Course is not correct")]
        public int Course { get; set; }

        [Required, MaxLength(200)]
        public string Cathedra { get; set; }
    }
}
