using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
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
using System.Runtime.Intrinsics.Arm;
using System.Security.Claims;
using System.Text.RegularExpressions;

namespace SporC.Web.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserManager userManager;
        private readonly IPictureManager pictureManager;

        public UserController(IUserManager userManager, IPictureManager pictureManager) 
        {
            this.userManager = userManager;
            this.pictureManager = pictureManager;
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
        public async Task<IActionResult> SignUp(RegisterViewModel rwm, [FromServices] IWebHostEnvironment webHostEnvironment)
        {
			string regexPattern = @"^(?=.*[a-zA-Z])(?=.*\d)(?=.*[-_!@#$%^&*+=<>?]).{8,12}$";


			Regex regex = new Regex(regexPattern);
            if (!regex.IsMatch(rwm.User.Password))
            {
				ViewBag.ErrorMessage = "*Please enter a password that is between 8 and 12 characters long and includes at least one digit, one letter, and one special character.";
				return View(rwm);
            }

            if (ModelState.IsValid)
            {
                if (rwm.User.Password != rwm.ConfirmPassword)
                {
                    ModelState.AddModelError("ConfirmPassword", "Please make sure your passwords match.");
                    return View(rwm);
                }
                var newuser = new User
                {
                    Email = rwm.User.Email,
                    UserName = rwm.User.UserName,
                    Password = rwm.User.Password,
                    Age = rwm.User.Age,
                    UserTypeId = 1,
                  
                };

                if (rwm.ProfilePicture != null && rwm.ProfilePicture.Length > 0)
                {

                    string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "ProfilePic");

                    string uniqueFileName = Guid.NewGuid().ToString() + "_" + rwm.ProfilePicture.FileName;

                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);


                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await rwm.ProfilePicture.CopyToAsync(fileStream);
                    }
                    var existingusermail = await userManager.FindByEmailOrUsernameAsync(rwm.User.Email);
                    var existingusername = await userManager.FindByEmailOrUsernameAsync(rwm.User.UserName);
                    if (existingusermail != null && existingusername != null)
                    {
                        TempData["ErrorMessage"] = "User with this email or username already exists.";
                        return RedirectToAction("SignUp", "User");
                    }
                    
                    var newpicture = new Picture
                    {

                        FileName = uniqueFileName,
                        FilePath = filePath,
                        PicUser = newuser
                    };
                    newuser.Picture = newpicture;

                    var verifieduser = await userManager.Insert(newuser);
                    if (verifieduser != null)
                    {
                        TempData["SuccessMessage"] = "Register created successfully!";
                        return RedirectToAction("Login", "User");
                    }

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
        [HttpGet]
        public async Task<IActionResult> Profile(int id)
        {


           var user=  await userManager.GetById(id);
            if (user == null)
            {
                return BadRequest();
            }
            var userpictureid = user.PictureId ?? 0;
            if (user.PictureId!=null)
            {
                user.Picture = await pictureManager.GetById(userpictureid);
            }
          
            return View(user);
        }

        [HttpGet]
        public async Task<IActionResult> UpdateProfile()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UpdateProfile(int id, [FromForm] UpdateUserViewModel userpp, [FromServices] IWebHostEnvironment webHostEnvironment)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var existingUser = await userManager.GetById(id);

                    if (existingUser == null)
                    {
                        return NotFound();
                    }

                 
                   
                    existingUser.Description = userpp.Description;
                  

                  
                    if (userpp.ProfilePicture != null && userpp.ProfilePicture.Length > 0)
                    {
                        string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "ProfilePic");

                        string uniqueFileName = Guid.NewGuid().ToString() + "_" + userpp.ProfilePicture.FileName;

                        string filePath = Path.Combine(uploadsFolder, uniqueFileName);


                        using (var fileStream = new FileStream(filePath, FileMode.Create))
                        {
                            await userpp.ProfilePicture.CopyToAsync(fileStream);
                        }

                        existingUser.Picture = new Picture
                        {
                            FileName = uniqueFileName,
                            FilePath = filePath,
                            PicUser = existingUser
                        };
                    }

                 

                    await userManager.Update(existingUser);

                  
                    return RedirectToAction("Profile", "User", new { id = existingUser.Id });
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", $"An error was encountered.\nError message: {ex.Message}");
                    return View(userpp);
                }
            }

            return View(userpp);
        }














        //[Authorize(Roles = "Admin")]
        //public IActionResult Index()
        //{
        //    return View();
        //}


        //[Authorize(Roles = "Admin")]
        //public IActionResult GetAll()
        //{
        //    return Json(new { data = userManager.GetAllInclude(u => u.UserType.Id==1, u=>u.UserType) });
        //}

        //[HttpPost]
        //[Authorize(Roles = "Admin")]
        //public IActionResult Delete(User Appuser)
        //{
        //    userManager.Delete(Appuser);
        //    userManager.Save();

        //    return Ok();

        //}


        //[HttpPost]
        //[Authorize(Roles = "Admin")]
        //public IActionResult Add(User appUser)
        //{
        //    userManager.Insert(appUser);
        //    userManager.Save();
        //    return Ok();
        //}

        //[HttpPost]
        //[Authorize(Roles = "Admin")]
        //public IActionResult Update(User appUser)
        //{
        //    userManager.Update(appUser);
        //    userManager.Save();
        //    return Ok();
        //}

    }
}
