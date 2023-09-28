using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SporC.BL.Abstract;
using SporC.Entities.Concrete;
using SporC.Web.Models;
using SporCDAL.Contexts;

namespace SporC.Web.Controllers
{
    public class PosttController1 : Controller
    {
        private readonly SqlDbContext dbContext;
        private readonly IMapper mapper;
        private readonly ITeamManager teamManager;
        private readonly IPostManager postManager;
        private readonly ICategoryManager categoryManager;
        private readonly ICommentManager commentManager;
        private readonly UserManager<User> userManager;

        public PosttController1(SqlDbContext dbContext, IMapper mapper, ITeamManager teamManager, IPostManager postManager, ICategoryManager categoryManager, ICommentManager commentManager, UserManager<User> userManager) 
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
            this.teamManager = teamManager;
            this.postManager = postManager;
            this.categoryManager = categoryManager;
            this.commentManager = commentManager;
            this.userManager = userManager;
        }

        

        //public IActionResult Index()
        //{
        //    var viewModel = new PostCreateViewModel
        //    {
        //        Categories = dbContext.Categories.ToList(),
        //        Teams = dbContext.Teams.ToList()

        //    }

          
        //     return View(viewModel);
        //}

        public async  Task<IActionResult> PostCreate(PostCreateViewModel createViewModel)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError(string.Empty, "Gerekli alanları doldurun!");


                return View(createViewModel);
            }
            try
            {
                var post= mapper.Map<Post> (createViewModel.PostDTO);

                

                return RedirectToAction("Index", "Home");   
            }
            catch (Exception ex)
            {

                ModelState.AddModelError("", $"An error was encountered.\nError message: {ex.Message}");
                return View(createViewModel);
            }
        }
    }
}
