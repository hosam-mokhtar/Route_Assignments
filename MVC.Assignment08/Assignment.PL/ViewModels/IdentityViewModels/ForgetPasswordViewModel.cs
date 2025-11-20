using System.ComponentModel.DataAnnotations;

namespace Assignment.PL.ViewModels.IdentityViewModels
{
    public class ForgetPasswordViewModel
    {
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Email can't be Empty")]
        public string Email { get; set; }
    }
}
