using SporC.Entities;

namespace SporC.Web.Models.ViewModel
{
    public class UserProfileViewModel
    {
        public List<Post> Posts { get; set; }
        public User User { get; set; }  
    }
}
