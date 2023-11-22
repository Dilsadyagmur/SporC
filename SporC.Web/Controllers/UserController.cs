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
using SporC.Web.Models;
using System.Data;
using System.Security.Claims;

namespace SporC.Web.Controllers
{
    public class UserController : Controller
    {
        private readonly IRepository<User> _repository;

        public UserController(IRepository<User> repository) 
        {
            _repository = repository;
        }
     
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public   IActionResult Login(User user)
        {
            
            User appuser = _repository.GetAll(u=>u.UserName==user.UserName && u.Password==user.Password).Include(u=>u.UserType).FirstOrDefault();  
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
        [Authorize(Roles = "Admin")]
        public IActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        public IActionResult GetAll()
        {
            return Json(new { data = _repository.GetAllInclude(u => u.UserType.Id==1, u=>u.UserType) });
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult Delete(User Appuser)
        {
            _repository.Delete(Appuser);
            _repository.Save();

            return Ok();

        }


        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult Add(User appUser)
        {
            _repository.Insert(appUser);
            _repository.Save();
            return Ok();
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult Update(User appUser)
        {
            _repository.Update(appUser);
            _repository.Save();
            return Ok();
        }

    }
}
