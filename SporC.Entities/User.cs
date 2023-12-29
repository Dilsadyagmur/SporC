using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SporC.Entities
{
    public class User : BaseEntity
    {
        [Required(ErrorMessage = "This Field Is Required")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "This Field Is Required")]
        public string Password { get; set; }
        public int? Age { get; set; }




        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        [Required(ErrorMessage = "This Field Is Required")]
        public  string Email { get; set; }


        public string? Description { get; set; }
       
        public virtual ICollection<Post>? Posts { get; set; }
     

        public int? UserTypeId { get; set; }
        public virtual UserType? UserType { get; set; }
      

        public int? PictureId { get; set; } 
        public virtual Picture? Picture { get; set; }

      
     
      
      

    }
}
