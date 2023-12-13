using SporC.Entities;
using System.ComponentModel.DataAnnotations;

namespace SporC.Web.Models.ViewModel
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "This Field Is Required")]
        public required string UserName { get; set; }
        [Required(ErrorMessage = "This Field Is Required")]
        public required string Password { get; set; }
        [Display(Name = "Confirm Password")]
        [Required(ErrorMessage = "Enter Confirm Password")]
        [Compare("Password", ErrorMessage = "Please make sure your passwords match.")]
        [DataType(DataType.Password)]
        public required string ConfirmPassword { get; set; }
        public required int? Age { get; set; }
        [Required(ErrorMessage = "This Field Is Required")]
        public required string Email { get; set; }

        public UserType? UserType { get; set; }
    }
}
