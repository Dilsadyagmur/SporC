﻿using SporC.BL.Abstract;
using SporC.BL.Concrete;
using SporC.DAL.Repositories.Abstract;
using SporC.DAL.Repositories.Concrete;
using SporC.Entities.Concrete;

namespace SporC.Web.Extensions
{
    public static class SporCManager
    {
        public static IServiceCollection AddSporCServices(this IServiceCollection Services)
        {

            Services.AddScoped<IPostManager, PostManager>();
            Services.AddScoped<ICategoryManager, CategoryManager>();
            Services.AddScoped<ICommentManager, CommentManager>();
            Services.AddScoped<ITeamManager, TeamManager>();
            Services.AddScoped<IPostRepository, PostRepository>();
            Services.AddScoped<ICategoryRepository, CategoryRepository>();
            Services.AddScoped<ICommentRepository, CommentRepository>();
            Services.AddScoped<ITeamRepository, TeamRepository>();

            Services.AddScoped<IBaseRepository<Post>, PostRepository>();
            Services.AddScoped<IBaseRepository<Category>, CategoryRepository>();
            Services.AddScoped<IBaseRepository<Comment>, CommentRepository>();
            Services.AddScoped<IBaseRepository<Team>, TeamRepository>();
            return Services;
        }
    }
}
