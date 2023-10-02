using Microsoft.EntityFrameworkCore;
using SporCDAL.Contexts;

using SporC.BL.Abstract;
using SporC.BL.Concrete;
using SporC.DAL.Repositories.Abstract;
using SporC.DAL.Repositories.Concrete;
using SporC.Web.AutoMapper;
using SporC.Web.Extensions;
using SporC.Entities.Concrete;

namespace SporC.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var connectionstring = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services.AddDbContext<SqlDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString(connectionstring)));

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddAutoMapper(typeof(SporCMapper));
            builder.Services.AddSporCServices();

            
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
          

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            
            
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                  name: "areas",
                  pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
                );
                app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            });
            
            app.Run();
        }
    }
}