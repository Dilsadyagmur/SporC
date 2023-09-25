
using SporC.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SporC.Entities.Concrete
{
    public class Post : BaseEntity
    {
        public string  Title { get; set; }
        public string Content { get; set; }
        public int  UserId { get; set; }
        public int TeamId { get; set; }
        public int LikeCount  { get; set; }
        public int CommentCount { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }

        public virtual ICollection<User> Users { get; set; }
        public virtual ICollection<Team> Teams { get; set; }
        
        public virtual ICollection<Comment> Comments { get; set; }

    }
}
