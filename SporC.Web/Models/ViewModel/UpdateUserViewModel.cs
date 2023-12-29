using SporC.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SporC.Web.Models.ViewModel
{
    public class UpdateUserViewModel
    {



        public string Description { get; set; }


        

      
        public IFormFile? ProfilePicture { get; set; }



        public Picture? picture { get; set; }
    }
}
