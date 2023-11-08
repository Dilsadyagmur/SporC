using SporC.Entities.Concrete;
using SporC.Web.Models.DTO_s;

namespace SporC.Web.Models
{
    public class BlogPostViewModel
    {
     public Post post { get; set; } = new Post();   
     public List<Post>? posts { get; set; }
     public Comment? comment { get; set; }   
    public List<Comment>? comments { get; set; } 
    }
}
