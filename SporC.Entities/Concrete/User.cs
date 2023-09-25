using Microsoft.AspNetCore.Identity;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SporC.Entities.Concrete
{
    public class User : IdentityUser 
    {
        public string UserName { get; set; }
        public int? Age { get; set; }
        public Team? team { get; set; }
        public int? TeamId { get; set; }  
        public virtual ICollection<Post> Posts { get; set; }    
        public virtual ICollection<Comment> Comments  { get; set; }
        public virtual UserType? UserType { get; set; }  
        public int? UserTypeId { get; set; }




    }
}
