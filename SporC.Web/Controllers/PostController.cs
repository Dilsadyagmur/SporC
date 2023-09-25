using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SporC.DAL.Repositories.Abstract;
using SporC.Entities.Concrete;

using SporC.Web.Models;

namespace SporC.Controllers
{
    public class PostController : Controller
    {
        private readonly IRepository<Post> _postRepository;
        private readonly IRepository<Team> _teamRepository;

        // Dependency injection
        public PostController(IRepository<Post> postRepository,
                              IRepository<Team> teamRepository)
        {
            _postRepository = postRepository;
            _teamRepository = teamRepository;
        }

        // GET: Post
        public async Task<IActionResult> Index(int? teamId)
        {
            // Get all posts or filter by teamId and include related entities
            var posts = await _postRepository.GetAllInclude(p => teamId == null || p.TeamId == teamId, p => p.Teams, p => p.Users);

            // Get all teams for dropdown list
            var teams = await _teamRepository.GetAll();

            // Create a view model to pass data to view
            var viewModel = new PostIndexViewModel
            {
                Posts = posts,
                Teams = new SelectList(teams, "Id", "Name"),
                SelectedTeamId = teamId
            };

            return View(viewModel);
        }

        public async Task<IActionResult> Create()
        {
            // Get all teams for dropdown list
            var teams = await _teamRepository.GetAll();

            // Create a view model to pass data to view
            var viewModel = new PostCreateViewModel
            {
                Teams = teams
            };

            return View(viewModel);
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PostCreateViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                // Create a new post from the view model
                var post = new Post
                {
                    Title = viewModel.Title,
                    Content = viewModel.Content,
                    TeamId = viewModel.TeamId,
                    UserId = int.Parse(User.Identity.Name), // Get the current user name
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                    LikeCount = 0,
                    CommentCount = 0
                };

                // Insert the post to the database
                await _postRepository.Insert(post);

                return RedirectToAction(nameof(Index));
            }

            // Get all teams for dropdown list
            var teams = await _teamRepository.GetAll();

            // Update the view model with teams data
            viewModel.Teams = teams;

            return View(viewModel);
        }

        // GET: Post/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            // Get the post by id
            var post = await _postRepository.GetById(id.Value);

            if (post == null)
            {
                return NotFound();
            }

            // Check if the current user is the owner of the post
            if (post.UserId.ToString() != User.Identity.Name)
            {
                return Forbid();
            }

            // Get all teams for dropdown list
            var teams = await _teamRepository.GetAll();

            // Create a view model from the post data
            var viewModel = new PostEditViewModel
            {
                Id = post.Id,
                Title = post.Title,
                Content = post.Content,
                TeamId = post.TeamId,
                Teams = new SelectList(teams, "Id", "Name")
            };

            return View(viewModel);
        }

        // POST: Post/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, PostEditViewModel viewModel)
        {
            if (id != viewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    // Get the post by id
                    var post = await _postRepository.GetById(id);

                    if (post == null)
                    {
                        return NotFound();
                    }

                    // Check if the current user is the owner of the post
                    if (post.UserId.ToString() != User.Identity.Name)
                    {
                        return Forbid();
                    }

                    // Update the post from the view model data
                    post.Title = viewModel.Title;
                    post.Content = viewModel.Content;
                    post.TeamId = viewModel.TeamId;
                    post.UpdatedDate = DateTime.Now;

                    // Update the post in the database
                    await _postRepository.Update(post);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PostExists(viewModel.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }

            // Get all teams for dropdown list
            var teams = await _teamRepository.GetAll();

            // Update the view model with teams data
            viewModel.Teams = (SelectList)teams;

            return View(viewModel);
        }

        private bool PostExists(int id)
        {
            return _postRepository.GetById(id)!=null;
        }



        // POST: Post/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            // Get the post by id
            var post = await _postRepository.GetById(id);

            if (post == null)
            {
                return NotFound();
            }

            // Check if the current user is the owner of the post
            if (post.UserId.ToString() != User.Identity.Name)
            {
                return Forbid();
            }

            // Delete the post from the database
            await _postRepository.Delete(post);

            // Redirect to Index function
            return RedirectToAction(nameof(Index));
        }

       
    }
}
