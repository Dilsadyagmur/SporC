using SporC.Entities;
using System.ComponentModel.DataAnnotations;

namespace SporC.Web.Areas.Dashboard.Models
{
    public class AdminUserAddModel
    {
        public User? User { get; set; }

        public List<User>? Users { get; set; }
       

        [Required(ErrorMessage = "Please select a profile picture.")]      
        public IFormFile? ProfilePicture { get; set; }



        public Picture? picture { get; set; }
    }
}
