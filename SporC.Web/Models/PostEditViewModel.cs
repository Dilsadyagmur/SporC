using Microsoft.AspNetCore.Mvc.Rendering;

namespace SporC.Web.Models
{
    public class PostEditViewModel
    {
        public string Content { get; internal set; }
        public int TeamId { get; internal set; }
        public SelectList Teams { get; internal set; }
        public int Id { get; internal set; }
        public string Title { get; internal set; }
    }
}