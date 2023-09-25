using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SporC.BL.Abstract;
using SporC.BL.Concrete;
using SporC.Entities.Concrete;
using SporC.Web.Models;
using SporCDAL.Contexts;

namespace SporC.Web.Controllers
{
    public class PostController : Controller
    {
        private readonly SqlDbContext context;
        private readonly IPostManager postManager;
        private readonly IMapper mapper;

        public PostController(SqlDbContext context, IPostManager postManager, IMapper mapper)
        {
            this.context = context;
            this.postManager = postManager;
            this.mapper = mapper;
        }
        public IActionResult Index()
        {
          
            return View();  
        }

        [HttpPost]
        public async Task<IActionResult> InsertPost(PostCreateViewModel model)
        {
            var post = mapper.Map<Post>(model.PostDTO);
            await postManager.Insert(post);
            await postManager.Update(post);
            
            return RedirectToAction("Index", "Post");
        }
    }
}


