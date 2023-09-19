
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
        public DateTime Date { get; set; }
        public string UserId { get; set; }
        public string  PostId { get; set; }

        public virtual User Users { get; set; }
        public virtual Post Posts { get; set; }
    }
}
