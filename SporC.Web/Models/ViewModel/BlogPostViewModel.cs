using SporC.Entities;

using System.Security.Claims;

namespace SporC.Web.Models.ViewModel
{
    public class BlogPostViewModel
    {

        public Post? post { get; set; } = new Post();
        public List<Post>? posts { get; set; }
        public Comment? comment { get; set; }
        public List<Comment>? comments { get; set; }

        public Picture? picture { get; set; }    
         public IFormFile? imgFile { get; set; }

        public Team? Team { get; set; }

        public int? TeamId { get; set; }
        public int? CategoryId { get; set; }
    }

}
