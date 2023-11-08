using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Core.Types;
using SporC.DAL.Repositories.Abstract;
using SporC.Entities.Concrete;
using SporC.Web.Models;
using System.Security.Claims;

namespace SporC.Web.Controllers
{
    public class CommentController : Controller
    {
        private readonly IRepository<Comment> _crepository;

        public CommentController( IRepository<Comment> crepository)
        {
           
            _crepository = crepository;
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> GetAllComments()
        {

            List<Comment> quryableComments = _crepository.GetAll(x => x.IsDeleted == false).ToList();
            BlogPostViewModel vm = new BlogPostViewModel();
            vm.comments = quryableComments;
            return View(vm);
        }
        [HttpGet]
        public async Task<IActionResult> CreateComment()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateComment(BlogPostViewModel bpwm)
        {
            bpwm.comment.UserId = int.Parse(User.FindFirstValue((ClaimTypes.NameIdentifier)));
            try
            {
               
                if (ModelState.IsValid)
                {


                   

                    var addedComment = _crepository.Insert(bpwm.comment);



                    if (addedComment != null)
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
                return View(bpwm.comment);
            }

        }
    }
}
