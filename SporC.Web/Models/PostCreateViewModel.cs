using SporC.Entities.Concrete;
using SporC.Web.Models.DTO_s;

namespace SporC.Web.Models
{
    public class PostCreateViewModel
    {
        public virtual ICollection<User> Users { get; set; }
        public virtual ICollection<Team> Teams { get; set; }
        public virtual ICollection<Category> Categories { get; set; } = new List<Category>();
        public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();   
        public PostcreateDTO PostDTO { get; set; }
        public string Content { get; internal set; }
        public string Title { get; internal set; }
        public int TeamId { get; internal set; }
    }
}
