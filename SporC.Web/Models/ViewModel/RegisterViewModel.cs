using SporC.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SporC.Web.Models.ViewModel
{
    public class RegisterViewModel
    {
       

      
        public User? User { get; set; }


        [Display(Name = "Confirm Password")]
        [Required(ErrorMessage = "Enter Confirm Password")]
       
        [DataType(DataType.Password)]
     
        public required string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Please select a profile picture.")]
        [Display(Name = "Profile Picture")]
        public IFormFile? ProfilePicture { get; set; }



        public Picture? picture { get; set; }
    }
}
