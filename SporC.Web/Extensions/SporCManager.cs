using SporC.BL.Abstract;
using SporC.BL.Concrete;
using SporC.DAL.Repositories.Abstract;
using SporC.DAL.Repositories.Concrete;
using SporC.Entities;

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
            Services.AddScoped<IPictureManager, PictureManager>();  
			Services.AddScoped<IUserManager, UserManager>();


            Services.AddScoped<IUnitOfWork, UnitOfWork>();
            Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            Services.AddAuthentication();
            Services.AddHttpContextAccessor();
            Services.AddAuthorization(options =>
            {
                options.AddPolicy("RequireAdminRole", policy => policy.RequireRole("Admin"));
            });

            return Services;
        }
    }
}
