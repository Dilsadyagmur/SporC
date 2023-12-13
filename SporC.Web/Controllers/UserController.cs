using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Core.Types;
using SporC.BL.Abstract;
using SporC.BL.Concrete;
using SporC.DAL.Repositories.Abstract;
using SporC.Entities;
using SporC.Web.Filters;
using SporC.Web.Models;
using SporC.Web.Models.ViewModel;
using System.Data;
using System.Security.Claims;

namespace SporC.Web.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserManager userManager;

        public UserController(IUserManager userManager) 
        {
            this.userManager = userManager;
        }
        [RedirectToHomeIfLoggedIn]
        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }

        [RedirectToHomeIfLoggedIn]
        [AllowAnonymous]
        [HttpPost]
        public   IActionResult Login(User user)
        {
            
            User appuser = userManager.GetAll(u=>u.UserName==user.UserName && u.Password==user.Password).Include(u=>u.UserType).FirstOrDefault();  
            if (appuser != null)
            {
                List<Claim> claims = new List<Claim>();
                claims.Add(new Claim(ClaimTypes.Name, appuser.UserName));
                claims.Add(new Claim(ClaimTypes.Role, appuser.UserType.Name));
                claims.Add(new Claim(ClaimTypes.NameIdentifier, appuser.Id.ToString()));

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

                HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), new AuthenticationProperties {IsPersistent = true });

                return Ok();
            }
            else
            {
                return BadRequest();
            }

        }
        [RedirectToHomeIfLoggedIn]
        [AllowAnonymous]
        [HttpGet]
        public async  Task<IActionResult> SignUp() 
        {

            return View();
        }
        [RedirectToHomeIfLoggedIn]
        [HttpPost]
        public async Task<IActionResult> SignUp(RegisterViewModel user)
        {
            if (ModelState.IsValid)
            {
                var newuser = new User
                {
                    Email = user.Email,
                    UserName = user.UserName,
                    Password = user.Password,
                    Age = user.Age,
                    UserTypeId = 1
                    
                };

                var existinguser = await userManager.FindByEmailOrUsernameAsync(user.Email);

                if (existinguser != null)
                {
                    TempData["ErrorMessage"] = "User with this email or username already exists.";
                    return RedirectToAction("SignUp", "User");
                }

                var verifieduser = await  userManager.Insert(newuser);

                if (verifieduser != null)
                {
                    TempData["SuccessMessage"] = "Register created successfully!";
                    return RedirectToAction("Login", "User");
                }
            }

            return View();
        }

        [HttpPost]
        public IActionResult Logout()
        {
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                HttpContext.SignOutAsync();
                return RedirectToAction("Index", "Post");
            }
            else
            {
                return RedirectToAction("Index", "Post");
            }
        }


















        [Authorize(Roles = "Admin")]
        public IActionResult Index()
        {
            return View();
        }


        [Authorize(Roles = "Admin")]
        public IActionResult GetAll()
        {
            return Json(new { data = userManager.GetAllInclude(u => u.UserType.Id==1, u=>u.UserType) });
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult Delete(User Appuser)
        {
            userManager.Delete(Appuser);
            userManager.Save();

            return Ok();

        }


        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult Add(User appUser)
        {
            userManager.Insert(appUser);
            userManager.Save();
            return Ok();
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult Update(User appUser)
        {
            userManager.Update(appUser);
            userManager.Save();
            return Ok();
        }
       
    }
}
