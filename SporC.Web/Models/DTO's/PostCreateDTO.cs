using SporC.Entities.Concrete;
using System.ComponentModel.DataAnnotations;

namespace SporC.Web.Models.DTO_s
{
    public class PostcreateDTO
    {
        [Required(ErrorMessage = "Title can't be empty!")]
        public string Title { get; set; }

        [Required(ErrorMessage = "This field can't be empty!")]
        public string Content { get; set; }

        public DateTime Date { get; set; }
        public string UserId { get; set; }
        public string TeamId { get; set; }
        public string CategoryId { get; set; }

        public virtual ICollection<User> Users { get; set; }
        public virtual ICollection<Team> Teams { get; set; }
        public virtual ICollection<Category> Categories { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
    }
}
