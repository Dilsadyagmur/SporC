using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SporC.Entities
{
    public class Category : BaseEntity
    {
        public string CategoryName { get; set; }
        public int PostId { get; set; }
        public virtual ICollection<Post> Posts { get; set; }





    }
}
