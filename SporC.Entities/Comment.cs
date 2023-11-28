using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SporC.Entities
{
    public class Comment : BaseEntity
    {
        public string Content { get; set; }

        public int PostId { get; set; }

        public string? CommentUser { get; set; }

        public virtual Post? Posts { get; set; }
    }
}
