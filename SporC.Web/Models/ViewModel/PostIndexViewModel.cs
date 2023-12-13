using Microsoft.AspNetCore.Mvc.Rendering;

namespace SporC.Web.Models.ViewModel
{
    internal class PostIndexViewModel
    {
        public object Posts { get; set; }
        public SelectList Teams { get; set; }
        public int? SelectedTeamId { get; set; }
    }
}