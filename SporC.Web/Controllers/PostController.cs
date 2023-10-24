
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
            // Veritabanından Post verilerini al
            IQueryable<Post> queryablePosts = _Repository.GetAll(x => true);
            List<Post> posts = queryablePosts.ToList();
            return View(posts);
        }


        [HttpGet]
        public async Task< IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Post post)
        {
            try
            {
                if (ModelState.IsValid)
                {
                   
                    var addedPost = _Repository.Insert(post);
                   

                    if (addedPost != null)
                    {
                       
                        return RedirectToAction("Index","Home");
                    }
                    else
                    {
                       
                        ModelState.AddModelError(string.Empty, "Veri eklenemedi.");
                    }
                }
                return View(post); 
            }
            catch (Exception ex)
            {
                
                ModelState.AddModelError(string.Empty, "Bir hata oluştu.");
                return View(post); 
            }
        }

    }
}
