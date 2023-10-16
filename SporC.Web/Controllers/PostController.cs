
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
                    // Veriyi veritabanına eklemek için Repository kullanımı
                    var addedPost = _Repository.Insert(post);

                    if (addedPost != null)
                    {
                        // Veri başarıyla eklenirse kullanıcıyı Index eylemine yönlendirin
                        return RedirectToAction("Index","Home");
                    }
                    else
                    {
                        // Veritabanına eklenemedi, hata durumunu ele alabilirsiniz.
                        ModelState.AddModelError(string.Empty, "Veri eklenemedi.");
                    }
                }
                return View(post); // Model durumu geçerli değilse, Create görünümünü tekrar gösterin.
            }
            catch (Exception ex)
            {
                // Hata durumunu ele alın veya günlüğe kaydedin.
                // Örneğin, hata mesajını hata günlüğüne kaydetmek:
                // _logger.LogError(ex, "Veri eklenirken hata oluştu.");
                ModelState.AddModelError(string.Empty, "Bir hata oluştu.");
                return View(post); // Hata durumunda, Create görünümünü tekrar gösterin.
            }
        }

    }
}
