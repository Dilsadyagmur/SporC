using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SporC.Entities
{
    public class User : BaseEntity
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public int? Age { get; set; }
        public int?  PostId { get; set; }

        public virtual ICollection<Post>? Posts { get; set; }
     
        public virtual UserType? UserType { get; set; }
        public int? UserTypeId { get; set; }




    }
}
