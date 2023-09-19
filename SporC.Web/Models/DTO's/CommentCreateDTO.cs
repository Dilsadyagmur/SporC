using SporC.Entities.Concrete;
using System.ComponentModel.DataAnnotations;

namespace SporC.Web.Models.DTO_s
{
    public class CommentCreateDTO
    {
        [Required(ErrorMessage = "This field can't be empty!")]
        public string Content { get; set; }
        public DateTime Date { get; set; }
        public string UserId { get; set; }
        public string PostId { get; set; }

        public virtual User Users { get; set; }
        public virtual Post Posts { get; set; }
    }
}
