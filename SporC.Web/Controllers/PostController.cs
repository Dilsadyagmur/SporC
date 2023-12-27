
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SporC.BL.Abstract;
using SporC.BL.Concrete;
using SporC.DAL.Repositories.Abstract;
using SporC.Web.Models;
using SporCDAL.Contexts;
using SporC.Entities;
using System.Security.Claims;
using NuGet.Packaging.Rules;
using NuGet.Protocol.Core.Types;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;
using System.Text.Json;
using SporC.DAL.Repositories.Concrete;
using Microsoft.Identity.Client;
using SporC.Web.Models.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace SporC.Web.Controllers
{
    public class PostController : Controller
    {
        private readonly IPostManager postManager;
        private readonly ICommentManager commentManager;
        private readonly IUserManager userManager;
        private readonly IPictureManager picmanager;
        private readonly ITeamManager teamManager;
        private readonly ICategoryManager categoryManager;

        public PostController(IPostManager postManager, ICommentManager commentManager, IUserManager userManager, IPictureManager picmanager, ITeamManager teamManager, ICategoryManager categoryManager)
        {

            this.postManager = postManager;
            this.commentManager = commentManager;
            this.userManager = userManager;
            this.picmanager = picmanager;
            this.teamManager = teamManager;
            this.categoryManager = categoryManager;
        }
        [AllowAnonymous]
        public async Task<IActionResult> Index(int? teamId = null, int? categoryId=null)
        {
            //var a = UserManager.SendMail("yunusemrekosar2@gmail.com");
            //return Content(a.ToString());
            List<Post> queryablePosts = new();
            if (teamId != null)
            {
                queryablePosts = postManager.GetAll(x => !x.IsDeleted && x.TeamId == teamId)
                .Include(p => p.Picture)
                .ToList();
            }
            else
            {
                queryablePosts = postManager.GetAll(x => !x.IsDeleted)
                .Include(p => p.Picture)
                .ToList();
            }

            if (categoryId!= null)
            {
                queryablePosts = postManager.GetAll(x=> !x.IsDeleted && x.CategoryId==categoryId)
                .Include(p => p.Picture)
                .ToList();
            }
           


            BlogPostViewModel vm = new BlogPostViewModel();
            vm.posts = queryablePosts;

            if (HttpContext.User.Identity.IsAuthenticated)
            {
                ViewBag.CurrentUserId = await userManager.GetCurrentUserIdAsync();
            }


            return View(vm);
        }

        [HttpGet]
        [Authorize(Roles = "User,Admin")]
        public async Task<IActionResult> Create()
        {
            var teams = teamManager.GetAllTeams().ToList();
           
            ViewBag.Teams = new SelectList(teams, "Id", "TeamName");

            var categories = categoryManager.GetAllCategories().ToList();
            ViewBag.Categories = new SelectList(categories, "Id", "CategoryName");

            return View();
        }

        [Authorize(Roles = "User,Admin")]
        [HttpPost]
        public async Task<IActionResult> Create(BlogPostViewModel bpwm, [FromServices] IWebHostEnvironment webHostEnvironment)
        {
            int userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var user = await userManager.GetById(userId);


            if (user != null && bpwm.post.User==null)
            {
            
                bpwm.post.User= await userManager.GetById(bpwm.post.UserId);
            }
            if (user != null)
            {
                bpwm.post.PostUserName = user.UserName;
                bpwm.post.UserId = user.Id;
            }
            else
            {

            }

            try
            {
                if (ModelState.IsValid)
                {

                    if (bpwm.imgFile != null && bpwm.imgFile.Length > 0)
                    {


                        string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "uploads");
                        string uniqueFileName = Guid.NewGuid().ToString() + "_" + bpwm.imgFile.FileName;
                        string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                        using (var fileStream = new FileStream(filePath, FileMode.Create))
                        {
                            await bpwm.imgFile.CopyToAsync(fileStream);
                        }


                        var picture = new Picture
                        {
                            FileName = uniqueFileName,
                            FilePath = filePath,
                            Post = bpwm.post
                        };
                        bpwm.post.Picture = picture;
                        var addedPost = await postManager.Insert(bpwm.post);
                    }

                    return RedirectToAction("Index", "Post");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Veri eklenemedi.");
                }

                foreach (var modelStateEntry in ModelState)
                {
                    var key = modelStateEntry.Key;
                    var errors = modelStateEntry.Value.Errors.Select(e => e.ErrorMessage);

                    Console.WriteLine($"Property: {key}, Errors: {string.Join(", ", errors)}");
                }

                return View(bpwm);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "Bir hata oluştu.");
                return View(bpwm.post);
            }
        }


        [HttpPost]
        public async Task<IActionResult> DeletePost(int id)
        {
            var post = await postManager.GetById(id);

            if (post != null && post.UserId == await userManager.GetCurrentUserIdAsync())
            {

               postManager.DeleteById(id);
               postManager.Save();
                return RedirectToAction("Index", "Post");
            }
            else
            {
                return NotFound();
            }


        }

        [HttpPost]
        public async Task<IActionResult> DeleteComment(int id)
        {
            var comment = await commentManager.GetById(id);
           
                commentManager.DeleteById(id);
                commentManager.Save();

                return RedirectToAction("Index", "Post");
           

         
        }
        [HttpGet]
        public async Task<IActionResult> PostDetail(int id, BlogPostViewModel pm)
        {
            var post = await postManager.GetById(id);

            if (post!=null&& post.User==null && HttpContext.User.Identity.IsAuthenticated)
            {
                post.User= await userManager.GetById(post.UserId);
            }
            
           
              
            if (post != null && post.PictureId.HasValue)
            {
              
                post.Picture = await picmanager.GetById(post.PictureId.Value);
            }


            if (post == null)
            {
                return NotFound();
            }
            
           

            if (HttpContext.User.Identity.IsAuthenticated)
            {
                int userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
                var user = await userManager.GetById(userId);
                ViewBag.CurrentUserName = user.UserName;
            }
            List<Comment> quryableComments = commentManager.GetAll(x => x.IsDeleted == false && x.PostId == id ).ToList();

           

       
            var pd = new BlogPostViewModel
            {
                post = post,
                comments = quryableComments
                
            };

            return View(pd);
        }

        [HttpGet]
        public async Task<IActionResult> UpdatePost()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UpdatePost(int id, BlogPostViewModel postmodel)
        {

            if (ModelState.IsValid)
            {
                try
                {

                    var existingPost = await postManager.GetById(id);

                    if (existingPost == null)
                    {
                        return NotFound();
                    }

                    // Varolan gönderiyi güncelle
                    existingPost.Title = postmodel.post.Title;
                    existingPost.Content = postmodel.post.Content;

                    await postManager.Update(existingPost);

                    return RedirectToAction("Index", "Post");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", $"An error was encountered.\nError message: {ex.Message}");
                    return View(postmodel);
                }
            }

          
            return View(postmodel);

        }
        [Authorize(Roles = "User,Admin")]
        [HttpPost]
        public async Task<IActionResult> CreateComment(int PostId, string content, BlogPostViewModel model)
        {
            #region     eski kod
            try
            {
                int userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
                var user = await userManager.GetById(userId);
                var post = await postManager.GetById(PostId);
                if (post == null)
                {
                    return NotFound();
                }
                var newComment = new Comment
                {
                    Content = content,
                    PostId = PostId,
                   CommentUser = user.UserName,
                   CreateDate = DateTime.Now
                    
                };
                await commentManager.Insert(newComment);
                List<Comment> sortedcomment = new List<Comment>();
                Post quryableComments =  await postManager.GetByIdforInc(PostId).Include(x => x.Comments).OrderByDescending(x=>x.CreateDate).FirstOrDefaultAsync();
                if (quryableComments != null)
                {
                    sortedcomment = quryableComments.Comments.OrderByDescending(x => x.CreateDate).ToList();


                    var json = JsonSerializer.Serialize(new
                    {
                        Id = sortedcomment[0].Id,
                        Content = sortedcomment[0].Content,
                        CreatedDate = sortedcomment[0].CreateDate
                    });
                    return Json(json);
                }
                return Content("null hatası");
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.ToString());
                throw;
            }
            #endregion

        }
        [HttpPost]
        public async Task<IActionResult> UpdateComment(int id, BlogPostViewModel model)
        {

            var updatedcomment = new Comment
            {
                Id = id,

                Content = model.comment.Content
            };

            try
            {
                await commentManager.Update(updatedcomment);
                return RedirectToAction("Index", "Post");
            }
            catch (Exception ex)
            {

                ModelState.AddModelError("", $"An error was encountered.\nError message: {ex.Message}");
                return RedirectToAction("Index", "Post");
            }

        }
    }
}


