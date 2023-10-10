
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
        private readonly IRepository<Post> _Repository;

        public PostController(IRepository<Post> Repository)
        {
            _Repository = Repository;
        }

        public async Task<IActionResult> Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Post post)
        {
            var posts = _Repository.Insert(post);
            return View(Index);
        }
    }
}
