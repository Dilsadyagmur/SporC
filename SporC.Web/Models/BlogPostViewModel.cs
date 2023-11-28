using SporC.Entities;
using SporC.Web.Models.DTO_s;
using System.Security.Claims;

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
