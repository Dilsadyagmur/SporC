using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SporC.DAL.Repositories.Abstract;
using System.Data;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using SporC.Entities;
using SporC.BL.Abstract;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;

namespace SporC.Web.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    public class AdminController : Controller
    {

        private readonly IUserManager userManager;
        private readonly IPostManager postManager;
        private readonly ICategoryManager categoryManager;
        private readonly ITeamManager teamManager;
        private readonly ICommentManager commentManager;
        private readonly IRepository<UserType> usertyperep;

        public AdminController(IUserManager userManager, IPostManager postManager, ICategoryManager categoryManager, ITeamManager teamManager, ICommentManager commentManager, IRepository<UserType> usertyperep)
        {
            this.userManager = userManager;
            this.postManager = postManager;
            this.categoryManager = categoryManager;
            this.teamManager = teamManager;
            this.commentManager = commentManager;
            this.usertyperep = usertyperep;
        }

        [Authorize(Roles = "Admin")]
        //[Route("/Dashboard/Admin/Index")]
        public IActionResult Index()
        {
            List<Post> queryablePosts = new();

            queryablePosts = postManager.GetAll(x => !x.IsDeleted).ToList();
            return View(queryablePosts);
        }

        [Authorize(Roles = "Admin")]

        public IActionResult GetAllUser()
        {
            try
            {
                var userData = userManager.GetAllInclude(u => u.IsDeleted == false);
                return Json(new { data = userData });
            }
            catch (Exception ex)
            {
               
                Debug.WriteLine($"Error in GetAllUser: {ex.Message}");
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await userManager.GetById(id);
            if (user != null)
            {
                userManager.DeleteById(id);
                userManager.Save();
                return Ok();
            }
            else
            {
                return NotFound();
            }



        }


        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddUser(User user)
        {
            if (ModelState.IsValid)
            {

                var newuser = new User
                {
                    Email = user.Email,
                    UserName = user.UserName,
                    Password = user.Password,
                    UserTypeId = user.UserTypeId,
                    


                };

                var existinguser = await userManager.FindByEmailOrUsernameAsync(user.UserName);

                if (existinguser != null)
                {

                    return BadRequest("User with this email or username already exists.");
                }

               var verifieduser = await userManager.Insert(newuser);

                if (verifieduser != null)
                {

                    return Ok("user created successfully!");
                }

            }
            return BadRequest("Modelstate is not valid");
        }


        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult Update(User appUser)
        {
            userManager.Update(appUser);
            userManager.Save();
            return Ok();
        }
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeletePost(int id)
        {
            var post = await postManager.GetById(id);

            if (post != null)
            {

                postManager.DeleteById(id);
                postManager.Save();
                return RedirectToAction("Index", "Admin");
            }
            else
            {
                return NotFound();
            }
        }



        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult Users()
        {
            List<User> Users = new();
            Users = userManager.GetAll().ToList();
            var categories = categoryManager.GetAllCategories().ToList();
            ViewBag.Categories = new SelectList(categories, "Id", "CategoryName");

            var usertypes = usertyperep.GetAll().ToList();
            ViewBag.Usertypes = new SelectList(usertypes, "Id", "Name");
            return View(Users);

        }


        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult Categories()
        {
            var categories = new List<Category>();
            categories = categoryManager.GetAll().ToList();

            return View(categories);
        }


        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddCategory(Category category)
        {
            if (ModelState.IsValid)
            {
                var newcategory = new Category
                {
                    CategoryName = category.CategoryName,

                };

                await categoryManager.Insert(newcategory);
                return Ok("Category created succesfully!");
            }
            return BadRequest("ModelState is not valid!");
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var category = await categoryManager.GetById(id);

            if (category != null)
            {

                categoryManager.DeleteById(id);
                categoryManager.Save();
                return RedirectToAction("Category", "Admin");
            }
            else
            {
                return NotFound();
            }
        }


        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult Teams()
        {
            var teams = new List<Team>();
            teams = teamManager.GetAll().ToList();

            return View(teams);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddTeam(Team team)
        {
            if (ModelState.IsValid)
            {
                var newteam= new Team
                {
                    TeamName = team.TeamName,
                    LogoUrl = team.LogoUrl,

                };

                await teamManager.Insert(newteam);
                return Ok("Category created succesfully!");
            }
            return BadRequest("ModelState is not valid!");
        }
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteTeam(int id)
        {
            var team = await teamManager.GetById(id);

            if (team != null)
            {

                teamManager.DeleteById(id);
                teamManager.Save();
                return RedirectToAction("Teams", "Admin");
            }
            else
            {
                return NotFound();
            }
        }

    }
}
