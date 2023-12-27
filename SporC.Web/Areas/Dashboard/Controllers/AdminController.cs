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

        public AdminController(IUserManager userManager, IPostManager postManager, ICategoryManager categoryManager, ITeamManager teamManager, ICommentManager commentManager, IRepository<UserType> usertyperep )
        {
            this.userManager = userManager;
			this.postManager = postManager;
			this.categoryManager = categoryManager;
			this.teamManager = teamManager;
			this.commentManager = commentManager;
            this.usertyperep = usertyperep;
        }

        //public IActionResult Login()
        //{
        //    return View();
        //}
        //[HttpPost]
        //[Route("Dashboard/Admin/Login/")]
        //public IActionResult Login(User user)
        //{

        //    User appuser = userManager.GetAll(u => u.UserName == user.UserName && u.Password == user.Password).Include(u => u.UserType).FirstOrDefault();
        //    if (appuser != null)
        //    {
        //        List<Claim> claims = new List<Claim>();
        //        claims.Add(new Claim(ClaimTypes.Name, appuser.UserName));
        //        claims.Add(new Claim(ClaimTypes.Role, appuser.UserType.Name));
        //        claims.Add(new Claim(ClaimTypes.NameIdentifier, appuser.Id.ToString()));

        //        var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
        //        HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

        //        HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), new AuthenticationProperties { IsPersistent = true });

        //        return Ok();
        //    }
        //    else
        //    {
        //        return BadRequest();
        //    }

        //}
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
            return Json(new { data = userManager.GetAllInclude(u => u.IsDeleted==false) });
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await  userManager.GetById(id);
            if (user!=null)
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
                   
                    return  BadRequest("User with this email or username already exists.");
                }

                var verifieduser = await userManager.Insert(newuser);

                if (verifieduser != null)
                {
                   
                    return Ok("User created successfully!");
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

            if (post != null )
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
	


    }
}
