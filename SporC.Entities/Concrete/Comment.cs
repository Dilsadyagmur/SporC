
using SporC.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SporC.Entities.Concrete
{
    public class Comment: BaseEntity
    {
        public string Content { get; set; }
        
        public int UserId { get; set; }
        public int  PostId { get; set; }

        public virtual User Users { get; set; }
        public virtual Post Posts { get; set; }
    }
}
