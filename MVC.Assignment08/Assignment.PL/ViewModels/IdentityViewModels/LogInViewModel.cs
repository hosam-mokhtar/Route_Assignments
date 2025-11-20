using System.ComponentModel.DataAnnotations;

namespace Assignment.PL.ViewModels.IdentityViewModels
{
    public class LogInViewModel
    {
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }


        [DataType(DataType.Password)]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}
