
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

namespace SporC.Web.Controllers
{
    public class PostController : Controller
    {
        private readonly IRepository<Post> _Repository;
        private readonly ICommentRepository _cmntrepo;

        public PostController(IRepository<Post> Repository, ICommentRepository commentRepository)
        {
            _Repository = Repository;
            _cmntrepo= commentRepository;
        }

        public async Task<IActionResult> Index()
        {
           
            List<Post> queryablePosts = _Repository.GetAll(x => !x.IsDeleted).ToList();
            BlogPostViewModel vm = new BlogPostViewModel();
            vm.posts = queryablePosts;
            return View(vm);
        }
     


        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(BlogPostViewModel bpwm)
        {
            var user = bpwm.post.User;
            if (user == null)
            {
                return BadRequest();
            }
            bpwm.post.UserId = int.Parse(User.FindFirstValue((ClaimTypes.NameIdentifier)));
            
          
            try
            {
                if (ModelState.IsValid)
                {




                    var addedPost = _Repository.Insert(bpwm.post);

                    

                    if (addedPost != null)
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
                return View(bpwm.post);
            }

        }
      

        [HttpPost]
        public async Task<IActionResult> DeleteById(int id)
        {
            _Repository.DeleteById(id);
            _Repository.Save();
           
            return RedirectToAction("Index", "Post");
        }
        public async Task<IActionResult> PostDetail(int id)
        {
            var post = await _Repository.GetById(id);

            var pd = new BlogPostViewModel
            {
                post = post
                
            };
            return View(pd);
        }
        [HttpGet]
        public async Task<IActionResult> UpdatePost()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UpdatePost(int id, BlogPostViewModel model)
        {
          
            var updatedpost = new Post
            {
                Id = id,
                Title = model.post.Title,
                Content = model.post.Content
            };
         
            try
            {
                await _Repository.Update(updatedpost);
                return RedirectToAction("Index", "Post");
            }
            catch (Exception ex)
            {

                ModelState.AddModelError("", $"An error was encountered.\nError message: {ex.Message}");
                return RedirectToAction("Index","Post");
            }

        }
        [HttpPost]
        public async Task<IActionResult> CreateComment(int PostId, string content)
        {
           var post = _Repository.GetById(PostId);
            if (post==null)
            {
                return NotFound();
            }
            var newComment = new Comment
            {
                Content = content,
                PostId = PostId,
                UserId = int.Parse(User.FindFirstValue((ClaimTypes.NameIdentifier)))

             };
             _cmntrepo.Insert(newComment);

            return RedirectToAction("PostDetail","Post");
    
        }
    }
}


