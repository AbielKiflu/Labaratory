using System.ComponentModel.DataAnnotations;

namespace EntityTest.ViewModels.Account
{
    public class UserVM
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
