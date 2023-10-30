
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SporC.BL.Abstract;
using SporC.BL.Concrete;
using SporC.DAL.Repositories.Abstract;
using SporC.Entities.Concrete;
using SporC.Web.Models;
using SporCDAL.Contexts;
using SporC.Entities;
using System.Security.Claims;

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
            List<Post> queryablePosts = _Repository.GetAll(x => !x.IsDeleted).ToList();
            BlogPostViewModel vm = new BlogPostViewModel();
            vm.posts = queryablePosts;
            return View(vm);
        }


        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(BlogPostViewModel bpwm)
        {
            bpwm.post.UserId = int.Parse(User.FindFirstValue((ClaimTypes.NameIdentifier)));
            try
            {
                if (ModelState.IsValid)
                {




                    var addedPost = _Repository.Insert(bpwm.post);



                    if (addedPost != null)
                    {

                        return RedirectToAction("Index", "Post");
                    }
                    else
                    {

                        ModelState.AddModelError(string.Empty, "Veri eklenemedi.");
                    }
                }
                return View(bpwm);
            }
            catch (Exception ex)
            {

                ModelState.AddModelError(string.Empty, "Bir hata oluştu.");
                return View(bpwm.post);
            }
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var post = await _Repository.GetById(id);
            var viewModel = new BlogPostViewModel
            {
                post = post
            };
            return View(viewModel);

        }
        
        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (ModelState.IsValid)
            {
                // Silme işlemini gerçekleştir
                _Repository.DeleteById(id);
                return RedirectToAction("Index");
            }
            else
            {
                // Eğer ModelState geçerli değilse, gerekli hata işlemleri burada yapılmalıdır
                return View("Index"); // Hatayı düzgün bir şekilde ele alarak bir view gösterme
            }
        }

        public async Task<IActionResult> PostDetail(int id)
        {
            var post = await _Repository.GetById(id);

            var pd = new BlogPostViewModel
            {
                post = post
                
            };
            return View(pd);
        }

    }
}


