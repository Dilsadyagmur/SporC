
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
        public DateTime Date { get; set; }
        public string  UserId { get; set; }
        public string TeamId { get; set; }
        public string CategoryId { get; set; }

        public virtual ICollection<User> Users { get; set; }
        public virtual ICollection<Team> Teams { get; set; }
        public virtual ICollection<Category> Categories { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }

    }
}
