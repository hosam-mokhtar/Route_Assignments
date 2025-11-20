using System.ComponentModel.DataAnnotations;

namespace Assignment.PL.ViewModels.IdentityViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "First Name Can Not Be Null")]
        [MaxLength(50)]
        public string FirstName { get; set; } = null!;


        [Required(ErrorMessage = "Last Name Can Not Be Null")]
        [MaxLength(50)]
        public string LastName { get; set; } = null!;


        [Required(ErrorMessage = "User Name Can Not Be Null")]
        [MaxLength(50)]
        public string UserName { get; set; } = null!;


        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }


        [DataType(DataType.Password)]
        public string Password { get; set; }


        [DataType(DataType.Password)]
        [Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }

        public bool IsAgree { get; set; }
    }
}
