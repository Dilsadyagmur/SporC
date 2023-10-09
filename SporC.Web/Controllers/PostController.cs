
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SporC.BL.Abstract;
using SporC.DAL.Repositories.Abstract;
using SporC.Entities.Concrete;
using SporC.Web.Models;
using SporCDAL.Contexts;

namespace SporC.Web.Controllers
{
    public class PostController : Controller
    {
      private readonly IRepository<Post> _postRepository;

        public PostController(IRepository<Post> postRepository)
        {
            _postRepository = postRepository;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Post post)
        {
            var 
        }
    }
}
